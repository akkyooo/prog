using System.Windows;
using DovidnykMelomana.ViewModels;
using DovidnykMelomana.Views;

namespace DovidnykMelomana.Services;


// Реалізація IDialogService для WPF: створює вікна, призначає їм DataContext і показує модально.

public class DialogService : IDialogService
{
    private static Window? Owner => Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive)
                                    ?? Application.Current.MainWindow;

    public bool ShowAlbumEditor(AlbumEditViewModel viewModel) =>
        ShowDialog(new AlbumEditWindow(), viewModel);

    public bool ShowArtistEditor(ArtistEditViewModel viewModel) =>
        ShowDialog(new ArtistEditWindow(), viewModel);

    public bool ShowGenreEditor(GenreEditViewModel viewModel) =>
        ShowDialog(new GenreEditWindow(), viewModel);

    public void ShowAlbumDetails(AlbumDetailsViewModel viewModel) =>
        ShowDialog(new AlbumDetailsWindow(), viewModel);

    public void ShowStatistics(StatisticsViewModel viewModel) =>
        ShowDialog(new StatisticsWindow(), viewModel);

    public bool ShowSettings(SettingsViewModel viewModel) =>
        ShowDialog(new SettingsWindow(), viewModel);

    public bool Confirm(string message) =>
        MessageBox.Show(Owner!, message, "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;

    public void ShowError(string message) =>
        MessageBox.Show(Owner!, message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);

    public void ShowInfo(string message) =>
        MessageBox.Show(Owner!, message, "Довідник меломана", MessageBoxButton.OK, MessageBoxImage.Information);

    private static bool ShowDialog(Window window, ViewModelBase viewModel)
    {
        window.DataContext = viewModel;
        window.Owner = Owner;

        // ViewModel закриває вікно через подію, не знаючи про сам клас Window
        if (viewModel is ICloseable closeable)
        {
            closeable.CloseRequested += (_, result) =>
            {
                window.DialogResult = result;
            };
        }

        return window.ShowDialog() == true;
    }
}
