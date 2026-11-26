using System.Windows.Input;
using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Вкладка «Треки»: пошук треку в усіх альбомах і список улюблених треків.

public class TracksViewModel : ViewModelBase
{
    private readonly CatalogService _catalog;
    private string _searchText = string.Empty;
    private bool _onlyFavorites;
    private TrackRow? _selectedRow;

    public TracksViewModel(CatalogService catalog)
    {
        _catalog = catalog;
        ToggleFavoriteCommand = new RelayCommand(ToggleFavorite, () => SelectedRow != null);
        _catalog.CatalogChanged += (_, _) => Refresh();
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                Refresh();
            }
        }
    }

    public bool OnlyFavorites
    {
        get => _onlyFavorites;
        set
        {
            if (SetProperty(ref _onlyFavorites, value))
            {
                Refresh();
            }
        }
    }

    public TrackRow? SelectedRow
    {
        get => _selectedRow;
        set => SetProperty(ref _selectedRow, value);
    }

    public IReadOnlyList<TrackRow> Rows =>
        _catalog.Albums
            .SelectMany(album => album.Tracks.Select(track => new TrackRow(track, album)))
            .Where(Matches)
            .OrderBy(r => r.Album.ArtistName)
            .ThenBy(r => r.Album.Year)
            .ThenBy(r => r.Track.Number)
            .ToList();

    public string CounterText
    {
        get
        {
            var rows = Rows;
            return $"Знайдено треків: {rows.Count}; сумарна тривалість: {Track.FormatDuration(rows.Sum(r => r.Track.DurationSeconds))}";
        }
    }

    public ICommand ToggleFavoriteCommand { get; }

    private bool Matches(TrackRow row)
    {
        if (OnlyFavorites && !row.Track.IsFavorite)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(SearchText))
        {
            return true;
        }

        var text = SearchText.Trim();
        return row.Track.Title.Contains(text, StringComparison.CurrentCultureIgnoreCase)
               || row.Album.Title.Contains(text, StringComparison.CurrentCultureIgnoreCase)
               || row.Album.ArtistName.Contains(text, StringComparison.CurrentCultureIgnoreCase);
    }

    private void ToggleFavorite()
    {
        if (SelectedRow == null)
        {
            return;
        }

        SelectedRow.Track.IsFavorite = !SelectedRow.Track.IsFavorite;
        _catalog.Save();
    }

    private void Refresh()
    {
        OnPropertyChanged(nameof(Rows));
        OnPropertyChanged(nameof(CounterText));
    }
}

/// Рядок таблиці треків: трек разом з альбомом, до якого він належить.
public record TrackRow(Track Track, Album Album)
{
    public string Title => Track.Title;
    public string AlbumTitle => Album.Title;
    public string ArtistName => Album.ArtistName;
    public int Year => Album.Year;
    public string DurationText => Track.DurationText;
    public bool IsFavorite => Track.IsFavorite;
}
