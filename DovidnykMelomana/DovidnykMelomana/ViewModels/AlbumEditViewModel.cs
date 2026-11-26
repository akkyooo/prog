using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Вікно додавання та редагування альбому. Працює з копією даних: модель змінюється лише після натискання «Зберегти» і успішної перевірки.

public class AlbumEditViewModel : EditViewModelBase
{
    private readonly CatalogService _catalog;
    private readonly Album? _original;

    private string _title = string.Empty;
    private Artist? _selectedArtist;
    private Genre? _selectedGenre;
    private string _yearText = DateTime.Now.Year.ToString();
    private int _rating;
    private string _format = "Цифровий";
    private bool _isListened;
    private string _notes = string.Empty;
    private TrackEditItem? _selectedTrack;

    public AlbumEditViewModel(CatalogService catalog, Album? album)
    {
        _catalog = catalog;
        _original = album;

        if (album != null)
        {
            _title = album.Title;
            _selectedArtist = catalog.FindArtist(album.ArtistId);
            _selectedGenre = catalog.FindGenre(album.GenreId);
            _yearText = album.Year.ToString();
            _rating = album.Rating;
            _format = album.Format;
            _isListened = album.IsListened;
            _notes = album.Notes;
            foreach (var track in album.Tracks)
            {
                Tracks.Add(TrackEditItem.From(track));
            }
        }

        AddTrackCommand = new RelayCommand(AddTrack);
        RemoveTrackCommand = new RelayCommand(RemoveTrack, () => SelectedTrack != null);
        MoveUpCommand = new RelayCommand(() => Move(-1), () => SelectedTrack != null && Tracks.IndexOf(SelectedTrack) > 0);
        MoveDownCommand = new RelayCommand(() => Move(1), () => SelectedTrack != null && Tracks.IndexOf(SelectedTrack) < Tracks.Count - 1);

        Tracks.CollectionChanged += (_, _) => OnPropertyChanged(nameof(TracksSummary));
    }

    public override string WindowTitle => _original == null ? "Новий альбом" : $"Редагування: {_original.Title}";

    public Album? Result { get; private set; }

    public IEnumerable<Artist> Artists => _catalog.Artists.OrderBy(a => a.Name);
    public IEnumerable<Genre> Genres => _catalog.Genres.OrderBy(g => g.Name);
    public IEnumerable<string> Formats => Album.Formats;
    public IEnumerable<int> Ratings => Enumerable.Range(0, 6);

    public ObservableCollection<TrackEditItem> Tracks { get; } = new();

    public string Title
    {
        get => _title;
        set
        {
            SetProperty(ref _title, value);
            Validate();
        }
    }

    public Artist? SelectedArtist
    {
        get => _selectedArtist;
        set
        {
            SetProperty(ref _selectedArtist, value);
            Validate();
        }
    }

    public Genre? SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            SetProperty(ref _selectedGenre, value);
            Validate();
        }
    }

    public string YearText
    {
        get => _yearText;
        set
        {
            SetProperty(ref _yearText, value);
            Validate();
        }
    }

    public int Rating
    {
        get => _rating;
        set => SetProperty(ref _rating, value);
    }

    public string Format
    {
        get => _format;
        set => SetProperty(ref _format, value);
    }

    public bool IsListened
    {
        get => _isListened;
        set => SetProperty(ref _isListened, value);
    }

    public string Notes
    {
        get => _notes;
        set => SetProperty(ref _notes, value);
    }

    public TrackEditItem? SelectedTrack
    {
        get => _selectedTrack;
        set => SetProperty(ref _selectedTrack, value);
    }

    public string TracksSummary
    {
        get
        {
            var seconds = Tracks.Sum(t => Track.TryParseDuration(t.DurationText, out var s) ? s : 0);
            return $"Треків: {Tracks.Count}; тривалість: {Track.FormatDuration(seconds)}";
        }
    }

    public ICommand AddTrackCommand { get; }
    public ICommand RemoveTrackCommand { get; }
    public ICommand MoveUpCommand { get; }
    public ICommand MoveDownCommand { get; }

    protected override IEnumerable<string> ValidatedProperties =>
        new[] { nameof(Title), nameof(SelectedArtist), nameof(SelectedGenre), nameof(YearText) };

    protected override string? ValidateProperty(string propertyName)
    {
        switch (propertyName)
        {
            case nameof(Title):
                if (string.IsNullOrWhiteSpace(Title))
                {
                    return "Вкажіть назву альбому.";
                }

                return Title.Trim().Length > 150 ? "Назва альбому задовга (до 150 символів)." : null;

            case nameof(SelectedArtist):
                return SelectedArtist == null ? "Виберіть виконавця." : null;

            case nameof(SelectedGenre):
                return SelectedGenre == null ? "Виберіть жанр." : null;

            case nameof(YearText):
                if (!int.TryParse(YearText, out var year))
                {
                    return "Рік має бути цілим числом.";
                }

                return year < 1900 || year > DateTime.Now.Year
                    ? $"Рік виходу має бути в межах 1900–{DateTime.Now.Year}."
                    : null;
        }

        return null;
    }

    protected override string? ValidateWhole()
    {
        if (_catalog.IsAlbumDuplicate(Title, SelectedArtist!.Id, _original?.Id ?? Guid.Empty))
        {
            return $"Альбом «{Title.Trim()}» виконавця {SelectedArtist.Name} уже є в довіднику.";
        }

        for (var i = 0; i < Tracks.Count; i++)
        {
            var error = Tracks[i].Error;
            if (!string.IsNullOrEmpty(error))
            {
                return $"Трек №{i + 1}: {error}";
            }
        }

        return null;
    }

    protected override void Apply()
    {
        var album = _original ?? new Album();

        album.Title = Title.Trim();
        album.ArtistId = SelectedArtist!.Id;
        album.GenreId = SelectedGenre!.Id;
        album.Year = int.Parse(YearText);
        album.Rating = Rating;
        album.Format = Format;
        album.IsListened = IsListened;
        album.Notes = Notes.Trim();
        album.Tracks = new ObservableCollection<Track>(Tracks.Select(t => t.ToTrack()));

        if (_original == null)
        {
            _catalog.AddAlbum(album);
        }
        else
        {
            CatalogService.RenumberTracks(album);
            _catalog.Save();
        }

        Result = album;
    }

    private void AddTrack()
    {
        var item = new TrackEditItem { Title = string.Empty, DurationText = string.Empty };
        Tracks.Add(item);
        SelectedTrack = item;
    }

    private void RemoveTrack()
    {
        if (SelectedTrack != null)
        {
            Tracks.Remove(SelectedTrack);
        }
    }

    private void Move(int offset)
    {
        if (SelectedTrack == null)
        {
            return;
        }

        var index = Tracks.IndexOf(SelectedTrack);
        Tracks.Move(index, index + offset);
    }
}

/// Рядок таблиці треків у вікні редагування альбому. Тривалість зберігається текстом, щоб користувач міг ввести «4:20», а перевірка показала помилку прямо в клітинці.

public class TrackEditItem : ObservableObject, IDataErrorInfo
{
    private string _title = string.Empty;
    private string _durationText = string.Empty;
    private bool _isFavorite;

    public Guid Id { get; init; } = Guid.NewGuid();

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string DurationText
    {
        get => _durationText;
        set => SetProperty(ref _durationText, value);
    }

    public bool IsFavorite
    {
        get => _isFavorite;
        set => SetProperty(ref _isFavorite, value);
    }

    public string Error
    {
        get
        {
            var titleError = this[nameof(Title)];
            return titleError.Length > 0 ? titleError : this[nameof(DurationText)];
        }
    }

    // порожній рядок означає, що помилки немає
    public string this[string columnName] => columnName switch
    {
        nameof(Title) when string.IsNullOrWhiteSpace(Title) => "назва треку не може бути порожньою.",
        nameof(DurationText) when !Track.TryParseDuration(DurationText, out _) => "тривалість вводиться у форматі хв:сс, наприклад 4:20.",
        _ => string.Empty
    };

    public static TrackEditItem From(Track track) => new()
    {
        Id = track.Id,
        Title = track.Title,
        DurationText = track.DurationSeconds > 0 ? track.DurationText : string.Empty,
        IsFavorite = track.IsFavorite
    };

    public Track ToTrack()
    {
        Track.TryParseDuration(DurationText, out var seconds);
        return new Track
        {
            Id = Id,
            Title = Title.Trim(),
            DurationSeconds = seconds,
            IsFavorite = IsFavorite
        };
    }
}
