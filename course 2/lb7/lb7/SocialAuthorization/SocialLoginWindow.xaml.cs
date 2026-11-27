
using System.Threading.Tasks;
using System.Windows;

namespace lb7.SocialAuthorization
{
    public partial class SocialLoginWindow : Window
    {
        public SocialLoginWindow(ISocialAuthorization service)
        {
            InitializeComponent();

            TitleText.Text = "Вхід через " + service.ProviderName;

            AccountBox.ItemsSource = service.DemoAccounts;
            AccountBox.SelectedIndex = 0;
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (AccountBox.SelectedItem == null)
            {
                MessageBox.Show("Оберіть акаунт!");
                return;
            }

            LoginButton.IsEnabled = false;
            AccountBox.IsEnabled = false;

            LoadingBar.Visibility = Visibility.Visible;
            StatusText.Text = "Виконується авторизація...";

            await Task.Delay(1500);

            StatusText.Text = "Авторизацію успішно виконано!";
            LoadingBar.Visibility = Visibility.Collapsed;

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
