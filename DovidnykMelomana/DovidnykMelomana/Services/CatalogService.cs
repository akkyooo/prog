using System.Collections.ObjectModel;
using System.IO;
using DovidnykMelomana.Models;

namespace DovidnykMelomana.Services;


/// Зберігає музичний каталог у пам'яті, перевіряє узгодженість даних і записує каталог у data.json після кожної зміни.

public class CatalogService
{
    private readonly string _filePath;

    public CatalogService(string filePath)
    {
        _filePath = filePath;
    }

    public ObservableCollection<Genre> Genres { get; } = new();
    public ObservableCollection<Artist> Artists { get; } = new();
    public ObservableCollection<Album> Albums { get; } = new();

    public string FilePath => Path.GetFullPath(_filePath);

    /// Подія після кожного збереження каталогу.
    public event EventHandler? CatalogChanged;

    public void Load()
    {
        var catalog = JsonStorage.Load<MusicCatalog>(_filePath);

        Genres.Clear();
        Artists.Clear();
        Albums.Clear();

        foreach (var genre in catalog.Genres.OrderBy(g => g.Name))
        {
            Genres.Add(genre);
        }

        foreach (var artist in catalog.Artists.OrderBy(a => a.Name))
        {
            Artists.Add(artist);
        }

        foreach (var album in catalog.Albums)
        {
            RenumberTracks(album);
            Albums.Add(album);
        }

        RefreshLookups();
    }

    public void Save()
    {
        var catalog = new MusicCatalog
        {
            Genres = Genres.ToList(),
            Artists = Artists.ToList(),
            Albums = Albums.ToList()
        };

        JsonStorage.Save(_filePath, catalog);
        RefreshLookups();
        CatalogChanged?.Invoke(this, EventArgs.Empty);
    }

    /// Заповнює в альбомах назви виконавця й жанру за їхніми ідентифікаторами.
    public void RefreshLookups()
    {
        foreach (var album in Albums)
        {
            album.ArtistName = FindArtist(album.ArtistId)?.Name ?? "(невідомий виконавець)";
            album.GenreName = FindGenre(album.GenreId)?.Name ?? "(без жанру)";
        }
    }

    public Artist? FindArtist(Guid id) => Artists.FirstOrDefault(a => a.Id == id);

    public Genre? FindGenre(Guid id) => Genres.FirstOrDefault(g => g.Id == id);

    public IEnumerable<Album> AlbumsOf(Artist artist) => Albums.Where(a => a.ArtistId == artist.Id);

    // Жанри 

    public bool IsGenreNameTaken(string name, Guid exceptId) =>
        Genres.Any(g => g.Id != exceptId && string.Equals(g.Name.Trim(), name.Trim(), StringComparison.CurrentCultureIgnoreCase));

    public void AddGenre(Genre genre)
    {
        Genres.Add(genre);
        Save();
    }

    public string? DeleteGenre(Genre genre)
    {
        var used = Albums.Count(a => a.GenreId == genre.Id);
        if (used > 0)
        {
            return $"Жанр «{genre.Name}» вказано в альбомах: {used}. Спочатку змініть жанр цих альбомів.";
        }

        Genres.Remove(genre);
        Save();
        return null;
    }

    // Виконавці 

    public bool IsArtistNameTaken(string name, Guid exceptId) =>
        Artists.Any(a => a.Id != exceptId && string.Equals(a.Name.Trim(), name.Trim(), StringComparison.CurrentCultureIgnoreCase));

    public void AddArtist(Artist artist)
    {
        Artists.Add(artist);
        Save();
    }

    public string? DeleteArtist(Artist artist)
    {
        var count = Albums.Count(a => a.ArtistId == artist.Id);
        if (count > 0)
        {
            return $"У виконавця «{artist.Name}» є альбоми в довіднику ({count}). Спочатку видаліть їх.";
        }

        Artists.Remove(artist);
        Save();
        return null;
    }

    // Альбоми

    public bool IsAlbumDuplicate(string title, Guid artistId, Guid exceptId) =>
        Albums.Any(a => a.Id != exceptId && a.ArtistId == artistId &&
                        string.Equals(a.Title.Trim(), title.Trim(), StringComparison.CurrentCultureIgnoreCase));

    public void AddAlbum(Album album)
    {
        RenumberTracks(album);
        Albums.Add(album);
        Save();
    }

    public void DeleteAlbum(Album album)
    {
        Albums.Remove(album);
        Save();
    }

    public static void RenumberTracks(Album album)
    {
        for (var i = 0; i < album.Tracks.Count; i++)
        {
            album.Tracks[i].Number = i + 1;
        }
    }
}
