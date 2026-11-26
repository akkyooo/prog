using System.Windows.Input;
using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Статистика колекції: загальні показники, розподіл за жанрами й десятиліттями, найкращі альбоми.

public class StatisticsViewModel : ViewModelBase, ICloseable
{
    public StatisticsViewModel(CatalogService catalog)
    {
        var albums = catalog.Albums.ToList();
        var tracks = albums.SelectMany(a => a.Tracks).ToList();

        AlbumCount = albums.Count;
        ArtistCount = catalog.Artists.Count;
        TrackCount = tracks.Count;
        TotalDuration = Track.FormatDuration(tracks.Sum(t => t.DurationSeconds));
        ListenedText = albums.Count == 0
            ? "0 %"
            : $"{albums.Count(a => a.IsListened) * 100 / albums.Count} % ({albums.Count(a => a.IsListened)} із {albums.Count})";

        var rated = albums.Where(a => a.Rating > 0).ToList();
        AverageRating = rated.Count == 0 ? "–" : rated.Average(a => a.Rating).ToString("0.0");
        FavoriteCount = tracks.Count(t => t.IsFavorite);

        GenreBars = BuildBars(albums.GroupBy(a => a.GenreName).Select(g => (g.Key, g.Count())));
        DecadeBars = BuildBars(albums
            .GroupBy(a => a.Year / 10 * 10)
            .OrderBy(g => g.Key)
            .Select(g => ($"{g.Key}-ті", g.Count())), keepOrder: true);

        TopAlbums = albums
            .Where(a => a.Rating > 0)
            .OrderByDescending(a => a.Rating)
            .ThenBy(a => a.Year)
            .Take(5)
            .Select(a => $"{a.RatingStars}  {a.ArtistName} – {a.Title} ({a.Year})")
            .ToList();

        CloseCommand = new RelayCommand(() => CloseRequested?.Invoke(this, true));
    }

    public event EventHandler<bool>? CloseRequested;

    public int AlbumCount { get; }
    public int ArtistCount { get; }
    public int TrackCount { get; }
    public int FavoriteCount { get; }
    public string TotalDuration { get; }
    public string ListenedText { get; }
    public string AverageRating { get; }
    public IReadOnlyList<BarItem> GenreBars { get; }
    public IReadOnlyList<BarItem> DecadeBars { get; }
    public IReadOnlyList<string> TopAlbums { get; }
    public ICommand CloseCommand { get; }

    private static IReadOnlyList<BarItem> BuildBars(IEnumerable<(string Label, int Count)> source, bool keepOrder = false)
    {
        var list = source.ToList();
        if (!keepOrder)
        {
            list = list.OrderByDescending(x => x.Count).ThenBy(x => x.Label).ToList();
        }

        var max = list.Count == 0 ? 1 : list.Max(x => x.Count);
        // ширина смуги в пікселях пропорційна кількості альбомів
        return list.Select(x => new BarItem(x.Label, x.Count, 220.0 * x.Count / max)).ToList();
    }
}

/// Один рядок стовпчикового відображення в статистиці.
public record BarItem(string Label, int Count, double Width);
