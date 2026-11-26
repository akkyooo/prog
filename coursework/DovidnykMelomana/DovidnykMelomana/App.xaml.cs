using System.IO;
using System.Windows;
using DovidnykMelomana.Services;
using DovidnykMelomana.ViewModels;
using DovidnykMelomana.Views;

namespace DovidnykMelomana;

/// <summary>
/// Точка входу: створює сервіси, завантажує дані й керує переходом між вікном входу та головним вікном.
/// </summary>
public partial class App : Application
{
    private AuthService _auth = null!;
    private CatalogService _catalog = null!;
    private readonly IDialogService _dialogs = new DialogService();

    public static string DataFolder => Path.Combine(AppContext.BaseDirectory, "Data");

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        DispatcherUnhandledException += (_, args) =>
        {
            MessageBox.Show("Сталася непередбачена помилка: " + args.Exception.Message,
                "Довідник меломана", MessageBoxButton.OK, MessageBoxImage.Error);
            args.Handled = true;
        };

        _auth = new AuthService(Path.Combine(DataFolder, "users.json"));
        _catalog = new CatalogService(Path.Combine(DataFolder, "data.json"));

        try
        {
            _catalog.Load();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не вдалося прочитати файл data.json: " + ex.Message +
                            "\nПрограма запуститься з порожнім каталогом.",
                "Довідник меломана", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        ShowLogin();
    }

    private void ShowLogin()
    {
        var viewModel = new LoginViewModel(_auth);
        var window = new LoginWindow { DataContext = viewModel };
        viewModel.LoggedIn += (_, user) =>
        {
            ThemeService.Apply(user.Theme);
            ShowMain();
            window.Close();
        };

        MainWindow = window;
        window.Show();
    }

    private void ShowMain()
    {
        var viewModel = new MainViewModel(_auth, _catalog, _dialogs);
        var window = new MainWindow { DataContext = viewModel };
        viewModel.LoggedOut += (_, _) =>
        {
            ThemeService.Apply("Світла");
            ShowLogin();
            window.Close();
        };

        MainWindow = window;
        window.Show();
    }
}
