using System.Windows.Input;
using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Картка альбому: відомості про альбом, трек-лист і позначення улюблених треків.

public class AlbumDetailsViewModel : ViewModelBase, ICloseable
{
    private readonly CatalogService _catalog;
    private Track? _selectedTrack;

    public AlbumDetailsViewModel(CatalogService catalog, Album album)
    {
        _catalog = catalog;
        Album = album;
        Artist = catalog.FindArtist(album.ArtistId);
        ToggleFavoriteCommand = new RelayCommand(ToggleFavorite, () => SelectedTrack != null);
        CloseCommand = new RelayCommand(() => CloseRequested?.Invoke(this, true));
    }

    public event EventHandler<bool>? CloseRequested;

    public Album Album { get; }
    public Artist? Artist { get; }

    public string Header => $"{Album.ArtistName} – {Album.Title}";

    public string Info =>
        $"{Album.Year} · {Album.GenreName} · {Album.Format} · {(Album.IsListened ? "прослухано" : "ще не прослухано")}";

    public string ArtistInfo => Artist == null
        ? string.Empty
        : $"{Artist.Name}, {(string.IsNullOrEmpty(Artist.Country) ? "країна не вказана" : Artist.Country)}" +
          (Artist.CareerStartYear.HasValue ? $", на сцені з {Artist.CareerStartYear} р." : string.Empty);

    public string Summary
    {
        get
        {
            var favorites = Album.Tracks.Count(t => t.IsFavorite);
            return $"Треків: {Album.TrackCount} · тривалість {Album.TotalDurationText} · улюблених: {favorites}";
        }
    }

    public Track? SelectedTrack
    {
        get => _selectedTrack;
        set => SetProperty(ref _selectedTrack, value);
    }

    public ICommand ToggleFavoriteCommand { get; }
    public ICommand CloseCommand { get; }

    private void ToggleFavorite()
    {
        if (SelectedTrack == null)
        {
            return;
        }

        SelectedTrack.IsFavorite = !SelectedTrack.IsFavorite;
        _catalog.Save();
        OnPropertyChanged(nameof(Summary));
    }
}
