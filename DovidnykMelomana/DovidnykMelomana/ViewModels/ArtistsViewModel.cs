using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Вкладка «Виконавці»: список виконавців і альбоми вибраного виконавця.

public class ArtistsViewModel : ViewModelBase
{
    private readonly CatalogService _catalog;
    private readonly IDialogService _dialogs;
    private string _searchText = string.Empty;
    private Artist? _selectedArtist;

    public ArtistsViewModel(CatalogService catalog, IDialogService dialogs)
    {
        _catalog = catalog;
        _dialogs = dialogs;

        ArtistsView = new ListCollectionView(_catalog.Artists) { Filter = FilterArtist };
        ArtistsView.SortDescriptions.Add(new SortDescription(nameof(Artist.Name), ListSortDirection.Ascending));

        AddCommand = new RelayCommand(Add);
        EditCommand = new RelayCommand(Edit, () => SelectedArtist != null);
        DeleteCommand = new RelayCommand(Delete, () => SelectedArtist != null);

        _catalog.CatalogChanged += (_, _) =>
        {
            ArtistsView.Refresh();
            OnPropertyChanged(nameof(SelectedArtistAlbums));
            OnPropertyChanged(nameof(SelectedArtistSummary));
        };
    }

    public ICollectionView ArtistsView { get; }

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                ArtistsView.Refresh();
            }
        }
    }

    public Artist? SelectedArtist
    {
        get => _selectedArtist;
        set
        {
            if (SetProperty(ref _selectedArtist, value))
            {
                OnPropertyChanged(nameof(SelectedArtistAlbums));
                OnPropertyChanged(nameof(SelectedArtistSummary));
            }
        }
    }

    public IEnumerable<Album> SelectedArtistAlbums =>
        SelectedArtist == null ? Enumerable.Empty<Album>() : _catalog.AlbumsOf(SelectedArtist).OrderBy(a => a.Year).ToList();

    public string SelectedArtistSummary
    {
        get
        {
            if (SelectedArtist == null)
            {
                return "Виберіть виконавця у списку ліворуч.";
            }

            var albums = _catalog.AlbumsOf(SelectedArtist).ToList();
            if (albums.Count == 0)
            {
                return "Альбомів цього виконавця в довіднику ще немає.";
            }

            var seconds = albums.Sum(a => a.TotalSeconds);
            return $"Альбомів: {albums.Count}; треків: {albums.Sum(a => a.TrackCount)}; загальна тривалість: {Track.FormatDuration(seconds)}";
        }
    }

    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    private bool FilterArtist(object item)
    {
        if (item is not Artist artist || string.IsNullOrWhiteSpace(SearchText))
        {
            return true;
        }

        var text = SearchText.Trim();
        return artist.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase)
               || artist.Country.Contains(text, StringComparison.CurrentCultureIgnoreCase);
    }

    private void Add()
    {
        var editor = new ArtistEditViewModel(_catalog, null);
        if (_dialogs.ShowArtistEditor(editor))
        {
            SelectedArtist = editor.Result;
        }
    }

    private void Edit()
    {
        if (SelectedArtist != null)
        {
            _dialogs.ShowArtistEditor(new ArtistEditViewModel(_catalog, SelectedArtist));
            ArtistsView.Refresh();
        }
    }

    private void Delete()
    {
        if (SelectedArtist == null || !_dialogs.Confirm($"Видалити виконавця «{SelectedArtist.Name}»?"))
        {
            return;
        }

        var error = _catalog.DeleteArtist(SelectedArtist);
        if (error != null)
        {
            _dialogs.ShowError(error);
            return;
        }

        SelectedArtist = null;
    }
}
