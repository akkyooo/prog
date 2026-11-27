using System.Windows;
using System.Windows.Media;
using lb7.Authorization;
using lb7.Registration;

namespace lb7.Main
{
    public partial class MainWindow : Window
    {
        private bool darkTheme = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow window = new AuthorizationWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow window = new RegistrationWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            darkTheme = !darkTheme;

            if (darkTheme)
            {
                Application.Current.Resources["MainColor"] =
                    new SolidColorBrush(Color.FromRgb(40, 120, 110));

                Application.Current.Resources["BackgroundColor"] =
                    new SolidColorBrush(Color.FromRgb(35, 38, 45));

                Application.Current.Resources["TextColor"] =
                    new SolidColorBrush(Colors.White);

                Application.Current.Resources["InputBackground"] =
                    new SolidColorBrush(Color.FromRgb(50, 54, 62));
            }
            else
            {
                Application.Current.Resources["MainColor"] =
                    new SolidColorBrush(Color.FromRgb(99, 91, 219));

                Application.Current.Resources["BackgroundColor"] =
                    new SolidColorBrush(Color.FromRgb(243, 244, 250));

                Application.Current.Resources["TextColor"] =
                    new SolidColorBrush(Color.FromRgb(37, 36, 58));

                Application.Current.Resources["InputBackground"] =
                    new SolidColorBrush(Colors.White);
            }
        }
    }
}