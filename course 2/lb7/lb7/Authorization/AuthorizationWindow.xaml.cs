using System.Windows;
using lb7.Models;
using lb7.Registration;
using lb7.Services;
using lb7.SocialAuthorization;

namespace lb7.Authorization
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заповніть логін та пароль!");
                return;
            }

            User? user = UserService.Authorize(login, password);

            if (user == null)
            {
                MessageBox.Show("Неправильний логін або пароль!");
                return;
            }

            MessageBox.Show($"Вітаємо, {user.FirstName} {user.LastName}!\nАвторизація успішна.");

            Close();
        }

        private void OpenSocialAuthorization(ISocialAuthorization service)
        {
            SocialLoginWindow window = new SocialLoginWindow(service);
            window.Owner = this;

            bool? result = window.ShowDialog();

            if (result == true)
            {
                MessageBox.Show($"Вхід через {service.ProviderName} успішно виконано!");

                Close();
            }
        }

        private void Google_Click(object sender, RoutedEventArgs e)
        {
            OpenSocialAuthorization(new GoogleAuthorization());
        }

        private void Facebook_Click(object sender, RoutedEventArgs e)
        {
            OpenSocialAuthorization(new FacebookAuthorization());
        }

        private void Instagram_Click(object sender, RoutedEventArgs e)
        {
            OpenSocialAuthorization(new InstagramAuthorization());
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            RegistrationWindow window = new RegistrationWindow();
            window.Owner = this;
            window.ShowDialog();

            Show();
        }
    }
}