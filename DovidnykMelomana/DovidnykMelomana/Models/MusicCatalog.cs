namespace DovidnykMelomana.Models;

/// Кореневий об'єкт файлу data.json: увесь музичний каталог.

public class MusicCatalog
{
    public List<Genre> Genres { get; set; } = new();
    public List<Artist> Artists { get; set; } = new();
    public List<Album> Albums { get; set; } = new();
}
