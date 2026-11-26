using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace DovidnykMelomana.Models;

/// Музичний альбом зі списком треків.

public class Album : ObservableObject
{
    public static readonly string[] Formats = { "CD", "Вініл", "Касета", "Цифровий" };

    private string _title = string.Empty;
    private Guid _artistId;
    private Guid _genreId;
    private int _year = DateTime.Now.Year;
    private int _rating;
    private string _format = "Цифровий";
    private bool _isListened;
    private string _notes = string.Empty;
    private ObservableCollection<Track> _tracks = new();
    private string _artistName = string.Empty;
    private string _genreName = string.Empty;

    public Album()
    {
        _tracks.CollectionChanged += OnTracksChanged;
    }

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public Guid ArtistId
    {
        get => _artistId;
        set => SetProperty(ref _artistId, value);
    }

    public Guid GenreId
    {
        get => _genreId;
        set => SetProperty(ref _genreId, value);
    }

    public int Year
    {
        get => _year;
        set => SetProperty(ref _year, value);
    }

    /// Оцінка від 0 (без оцінки) до 5.
    public int Rating
    {
        get => _rating;
        set
        {
            if (SetProperty(ref _rating, value))
            {
                OnPropertyChanged(nameof(RatingStars));
            }
        }
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

    public ObservableCollection<Track> Tracks
    {
        get => _tracks;
        set
        {
            _tracks.CollectionChanged -= OnTracksChanged;
            _tracks = value ?? new ObservableCollection<Track>();
            _tracks.CollectionChanged += OnTracksChanged;
            OnPropertyChanged();
            OnTracksChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }

    [JsonIgnore]
    public string ArtistName
    {
        get => _artistName;
        set => SetProperty(ref _artistName, value);
    }

    [JsonIgnore]
    public string GenreName
    {
        get => _genreName;
        set => SetProperty(ref _genreName, value);
    }

    [JsonIgnore]
    public int TrackCount => Tracks.Count;

    [JsonIgnore]
    public int TotalSeconds => Tracks.Sum(t => t.DurationSeconds);

    [JsonIgnore]
    public string TotalDurationText => Track.FormatDuration(TotalSeconds);

    [JsonIgnore]
    public string RatingStars => Rating == 0 ? "без оцінки" : new string('★', Rating) + new string('☆', 5 - Rating);

    private void OnTracksChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(TrackCount));
        OnPropertyChanged(nameof(TotalSeconds));
        OnPropertyChanged(nameof(TotalDurationText));
    }
}
