using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Вкладка «Альбоми»: список, пошук, фільтри, сортування та команди редагування.

public class AlbumsViewModel : ViewModelBase
{
    public const string AllGenres = "Усі жанри";

    public static readonly string[] SortOptions =
    {
        "Назва (А–Я)", "Рік (спочатку нові)", "Рік (спочатку старі)", "Оцінка (спочатку вищі)", "Виконавець (А–Я)"
    };

    private readonly CatalogService _catalog;
    private readonly IDialogService _dialogs;
    private string _searchText = string.Empty;
    private string _selectedGenre = AllGenres;
    private string _selectedSort = SortOptions[0];
    private bool _onlyNotListened;
    private int _minRating;
    private Album? _selectedAlbum;

    public AlbumsViewModel(CatalogService catalog, IDialogService dialogs)
    {
        _catalog = catalog;
        _dialogs = dialogs;

        AlbumsView = CollectionViewSource.GetDefaultView(_catalog.Albums);
        AlbumsView.Filter = FilterAlbum;
        ApplySort();

        AddCommand = new RelayCommand(Add, () => _catalog.Artists.Count > 0 && _catalog.Genres.Count > 0);
        EditCommand = new RelayCommand(Edit, () => SelectedAlbum != null);
        DeleteCommand = new RelayCommand(Delete, () => SelectedAlbum != null);
        OpenDetailsCommand = new RelayCommand(OpenDetails, () => SelectedAlbum != null);
        ToggleListenedCommand = new RelayCommand(ToggleListened, () => SelectedAlbum != null);
        ResetFiltersCommand = new RelayCommand(ResetFilters);

        _catalog.CatalogChanged += (_, _) => RefreshAfterChange();
    }

    public ICollectionView AlbumsView { get; }

    public IEnumerable<string> GenreFilterItems =>
        new[] { AllGenres }.Concat(_catalog.Genres.Select(g => g.Name).OrderBy(n => n));

    public IEnumerable<string> Sorts => SortOptions;

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                RefreshView();
            }
        }
    }

    public string SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            if (SetProperty(ref _selectedGenre, value ?? AllGenres))
            {
                RefreshView();
            }
        }
    }

    public string SelectedSort
    {
        get => _selectedSort;
        set
        {
            if (SetProperty(ref _selectedSort, value ?? SortOptions[0]))
            {
                ApplySort();
            }
        }
    }

    public bool OnlyNotListened
    {
        get => _onlyNotListened;
        set
        {
            if (SetProperty(ref _onlyNotListened, value))
            {
                RefreshView();
            }
        }
    }

    public int MinRating
    {
        get => _minRating;
        set
        {
            if (SetProperty(ref _minRating, Math.Clamp(value, 0, 5)))
            {
                RefreshView();
            }
        }
    }

    public Album? SelectedAlbum
    {
        get => _selectedAlbum;
        set => SetProperty(ref _selectedAlbum, value);
    }

    public string CounterText
    {
        get
        {
            var shown = AlbumsView.Cast<object>().Count();
            return $"Показано альбомів: {shown} із {_catalog.Albums.Count}";
        }
    }

    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand OpenDetailsCommand { get; }
    public ICommand ToggleListenedCommand { get; }
    public ICommand ResetFiltersCommand { get; }

    private bool FilterAlbum(object item)
    {
        if (item is not Album album)
        {
            return false;
        }

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var text = SearchText.Trim();
            var found = album.Title.Contains(text, StringComparison.CurrentCultureIgnoreCase)
                        || album.ArtistName.Contains(text, StringComparison.CurrentCultureIgnoreCase)
                        || album.Tracks.Any(t => t.Title.Contains(text, StringComparison.CurrentCultureIgnoreCase));
            if (!found)
            {
                return false;
            }
        }

        if (SelectedGenre != AllGenres && album.GenreName != SelectedGenre)
        {
            return false;
        }

        if (OnlyNotListened && album.IsListened)
        {
            return false;
        }

        return album.Rating >= MinRating;
    }

    private void ApplySort()
    {
        using (AlbumsView.DeferRefresh())
        {
            AlbumsView.SortDescriptions.Clear();
            switch (Array.IndexOf(SortOptions, SelectedSort))
            {
                case 1:
                    AlbumsView.SortDescriptions.Add(new SortDescription(nameof(Album.Year), ListSortDirection.Descending));
                    break;
                case 2:
                    AlbumsView.SortDescriptions.Add(new SortDescription(nameof(Album.Year), ListSortDirection.Ascending));
                    break;
                case 3:
                    AlbumsView.SortDescriptions.Add(new SortDescription(nameof(Album.Rating), ListSortDirection.Descending));
                    break;
                case 4:
                    AlbumsView.SortDescriptions.Add(new SortDescription(nameof(Album.ArtistName), ListSortDirection.Ascending));
                    AlbumsView.SortDescriptions.Add(new SortDescription(nameof(Album.Year), ListSortDirection.Ascending));
                    break;
            }

            AlbumsView.SortDescriptions.Add(new SortDescription(nameof(Album.Title), ListSortDirection.Ascending));
        }
    }

    private void RefreshView()
    {
        AlbumsView.Refresh();
        OnPropertyChanged(nameof(CounterText));
    }

    private void RefreshAfterChange()
    {
        OnPropertyChanged(nameof(GenreFilterItems));
        if (SelectedGenre != AllGenres && _catalog.Genres.All(g => g.Name != SelectedGenre))
        {
            SelectedGenre = AllGenres;
        }

        RefreshView();
    }

    private void ResetFilters()
    {
        _searchText = string.Empty;
        _selectedGenre = AllGenres;
        _onlyNotListened = false;
        _minRating = 0;
        OnPropertyChanged(nameof(SearchText));
        OnPropertyChanged(nameof(SelectedGenre));
        OnPropertyChanged(nameof(OnlyNotListened));
        OnPropertyChanged(nameof(MinRating));
        RefreshView();
    }

    private void Add()
    {
        var editor = new AlbumEditViewModel(_catalog, null);
        if (_dialogs.ShowAlbumEditor(editor))
        {
            SelectedAlbum = editor.Result;
        }
    }

    private void Edit()
    {
        if (SelectedAlbum == null)
        {
            return;
        }

        _dialogs.ShowAlbumEditor(new AlbumEditViewModel(_catalog, SelectedAlbum));
        RefreshView();
    }

    private void Delete()
    {
        if (SelectedAlbum == null)
        {
            return;
        }

        if (_dialogs.Confirm($"Видалити альбом «{SelectedAlbum.Title}» ({SelectedAlbum.ArtistName}) разом із треками?"))
        {
            _catalog.DeleteAlbum(SelectedAlbum);
            SelectedAlbum = null;
        }
    }

    private void OpenDetails()
    {
        if (SelectedAlbum != null)
        {
            _dialogs.ShowAlbumDetails(new AlbumDetailsViewModel(_catalog, SelectedAlbum));
            RefreshView();
        }
    }

    private void ToggleListened()
    {
        if (SelectedAlbum != null)
        {
            SelectedAlbum.IsListened = !SelectedAlbum.IsListened;
            _catalog.Save();
        }
    }
}
