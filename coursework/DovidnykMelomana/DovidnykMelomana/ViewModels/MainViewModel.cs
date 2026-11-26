using System.Windows.Input;
using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Головне вікно: об'єднує ViewModel вкладок і загальні команди.

public class MainViewModel : ViewModelBase
{
    private readonly AuthService _auth;
    private readonly CatalogService _catalog;
    private readonly IDialogService _dialogs;
    private string _statusText = string.Empty;
    private int _selectedTabIndex;

    public MainViewModel(AuthService auth, CatalogService catalog, IDialogService dialogs)
    {
        _auth = auth;
        _catalog = catalog;
        _dialogs = dialogs;

        Albums = new AlbumsViewModel(catalog, dialogs);
        Artists = new ArtistsViewModel(catalog, dialogs);
        Genres = new GenresViewModel(catalog, dialogs);
        Tracks = new TracksViewModel(catalog);

        OpenStatisticsCommand = new RelayCommand(() => _dialogs.ShowStatistics(new StatisticsViewModel(_catalog)));
        OpenSettingsCommand = new RelayCommand(OpenSettings);
        LogoutCommand = new RelayCommand(Logout);

        _catalog.CatalogChanged += (_, _) => StatusText = $"Зміни збережено о {DateTime.Now:HH:mm:ss}";
        StatusText = $"Завантажено: альбомів {catalog.Albums.Count}, виконавців {catalog.Artists.Count}, жанрів {catalog.Genres.Count}";
    }

    /// Подія виходу з облікового запису; App показує вікно входу знову.
    public event EventHandler? LoggedOut;

    public AlbumsViewModel Albums { get; }
    public ArtistsViewModel Artists { get; }
    public GenresViewModel Genres { get; }
    public TracksViewModel Tracks { get; }

    public string UserName => _auth.CurrentUser?.DisplayName ?? string.Empty;

    public string StatusText
    {
        get => _statusText;
        set => SetProperty(ref _statusText, value);
    }

    public int SelectedTabIndex
    {
        get => _selectedTabIndex;
        set => SetProperty(ref _selectedTabIndex, value);
    }

    public ICommand OpenStatisticsCommand { get; }
    public ICommand OpenSettingsCommand { get; }
    public ICommand LogoutCommand { get; }

    private void OpenSettings()
    {
        var settings = new SettingsViewModel(_auth, _catalog);
        if (!_dialogs.ShowSettings(settings))
        {
            settings.RevertTheme();
            return;
        }

        OnPropertyChanged(nameof(UserName));
    }

    private void Logout()
    {
        if (_dialogs.Confirm("Вийти з облікового запису?"))
        {
            _auth.Logout();
            LoggedOut?.Invoke(this, EventArgs.Empty);
        }
    }
}
