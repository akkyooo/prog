using System.Configuration;
using System.Data;
using System.Windows;
using lb9.Services;
using lb9.ViewModels;

namespace lb9
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();

            IDialogService dialogService = new DialogService(() => mainWindow);

            MainViewModel viewModel = new MainViewModel(new StudentService(), dialogService);

            mainWindow.DataContext = viewModel;
            MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}