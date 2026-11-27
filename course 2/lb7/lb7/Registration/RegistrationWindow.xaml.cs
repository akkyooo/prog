
using System.Text.RegularExpressions;
using System.Windows;
using lb7.Models;
using lb7.Services;

namespace lb7.Registration
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameBox.Text.Trim();
            string lastName = LastNameBox.Text.Trim();
            string login = LoginBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Заповніть усі поля!");
                return;
            }

            if (!Regex.IsMatch(firstName, @"^[\p{L}]+$") || !Regex.IsMatch(lastName, @"^[\p{L}]+$"))
            {
                MessageBox.Show("Ім'я та прізвище повинні містити лише літери!");
                return;
            }

            if (!Regex.IsMatch(login, @"^[A-Za-z][A-Za-z0-9_]{2,19}$"))
            {
                MessageBox.Show("Логін повинен містити від 3 до 20 символів. " + "Дозволені латинські літери, цифри та знак підкреслення.");
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Введіть коректну електронну пошту!");
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Пароль повинен містити щонайменше 6 символів!");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не збігаються!");
                return;
            }

            User user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Login = login,
                Email = email,
                Password = password
            };

            if (UserService.Register(user, out string errorMessage))
            {
                MessageBox.Show("Реєстрація успішна!");
                DialogResult = true;
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
