using System.Security.Cryptography;
using System.Text;
using DovidnykMelomana.Models;

namespace DovidnykMelomana.Services;

/// Реєстрація та вхід користувачів. Паролі зберігаються лише у вигляді хешу SHA-256 із salt.

public class AuthService
{
    private readonly string _filePath;
    private List<User> _users = new();

    public AuthService(string filePath)
    {
        _filePath = filePath;
        _users = JsonStorage.Load<List<User>>(_filePath);
    }

    public User? CurrentUser { get; private set; }

    public string? Register(string login, string displayName, string password, string confirmPassword)
    {
        login = login.Trim();
        displayName = displayName.Trim();

        if (login.Length < 3)
        {
            return "Логін має містити щонайменше 3 символи.";
        }

        if (!login.All(c => char.IsLetterOrDigit(c) || c == '_'))
        {
            return "Логін може містити лише літери, цифри та знак «_».";
        }

        if (_users.Any(u => string.Equals(u.Login, login, StringComparison.OrdinalIgnoreCase)))
        {
            return "Користувач із таким логіном уже існує.";
        }

        if (string.IsNullOrWhiteSpace(displayName))
        {
            return "Вкажіть ім'я, яке буде показано в програмі.";
        }

        var passwordError = CheckPassword(password);
        if (passwordError != null)
        {
            return passwordError;
        }

        if (password != confirmPassword)
        {
            return "Паролі не збігаються.";
        }

        var salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
        var user = new User
        {
            Login = login,
            DisplayName = displayName,
            Salt = salt,
            PasswordHash = Hash(password, salt),
            RegisteredAt = DateTime.Now
        };

        _users.Add(user);
        SaveUsers();
        CurrentUser = user;
        return null;
    }

    public string? Login(string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(password))
        {
            return "Введіть логін і пароль.";
        }

        var user = _users.FirstOrDefault(u => string.Equals(u.Login, login.Trim(), StringComparison.OrdinalIgnoreCase));
        if (user == null || user.PasswordHash != Hash(password, user.Salt))
        {
            return "Неправильний логін або пароль.";
        }

        CurrentUser = user;
        return null;
    }

    public void Logout() => CurrentUser = null;

    public void SaveUsers() => JsonStorage.Save(_filePath, _users);

    public static string? CheckPassword(string password)
    {
        if (password.Length < 6)
        {
            return "Пароль має містити щонайменше 6 символів.";
        }

        if (!password.Any(char.IsDigit) || !password.Any(char.IsLetter))
        {
            return "Пароль має містити хоча б одну літеру й одну цифру.";
        }

        return null;
    }

    public static string Hash(string password, string salt)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(salt + password));
        return Convert.ToHexString(bytes);
    }
}
