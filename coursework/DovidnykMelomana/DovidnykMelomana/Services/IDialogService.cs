using DovidnykMelomana.ViewModels;

namespace DovidnykMelomana.Services;

/// Відкриття вікон і повідомлень із ViewModel без прямого звернення до класів View.

public interface IDialogService
{
    bool ShowAlbumEditor(AlbumEditViewModel viewModel);
    bool ShowArtistEditor(ArtistEditViewModel viewModel);
    bool ShowGenreEditor(GenreEditViewModel viewModel);
    void ShowAlbumDetails(AlbumDetailsViewModel viewModel);
    void ShowStatistics(StatisticsViewModel viewModel);
    bool ShowSettings(SettingsViewModel viewModel);
    bool Confirm(string message);
    void ShowError(string message);
    void ShowInfo(string message);
}
