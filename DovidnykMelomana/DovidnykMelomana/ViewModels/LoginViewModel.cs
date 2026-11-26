using System.Windows.Input;
using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Логіка вікна входу та реєстрації.

public class LoginViewModel : ViewModelBase
{
    private readonly AuthService _auth;
    private string _login = string.Empty;
    private string _displayName = string.Empty;
    private string _errorMessage = string.Empty;
    private bool _isRegisterMode;

    public LoginViewModel(AuthService auth)
    {
        _auth = auth;
        SubmitCommand = new RelayCommand(Submit);
        SwitchModeCommand = new RelayCommand(() =>
        {
            IsRegisterMode = !IsRegisterMode;
            ErrorMessage = string.Empty;
        });
    }

    /// Подія успішного входу; вікно входу закривається і відкривається головне вікно.
    public event EventHandler<User>? LoggedIn;

    public string Login
    {
        get => _login;
        set => SetProperty(ref _login, value);
    }

    public string DisplayName
    {
        get => _displayName;
        set => SetProperty(ref _displayName, value);
    }

    // PasswordBox не підтримує прив'язку, тому паролі передає code-behind вікна
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool IsRegisterMode
    {
        get => _isRegisterMode;
        set
        {
            if (SetProperty(ref _isRegisterMode, value))
            {
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(SubmitText));
                OnPropertyChanged(nameof(SwitchText));
            }
        }
    }

    public string Title => IsRegisterMode ? "Реєстрація" : "Вхід до довідника";
    public string SubmitText => IsRegisterMode ? "Зареєструватися" : "Увійти";
    public string SwitchText => IsRegisterMode ? "Вже маєте обліковий запис? Увійти" : "Немає облікового запису? Зареєструватися";

    public ICommand SubmitCommand { get; }
    public ICommand SwitchModeCommand { get; }

    private void Submit()
    {
        var error = IsRegisterMode
            ? _auth.Register(Login, DisplayName, Password, ConfirmPassword)
            : _auth.Login(Login, Password);

        if (error != null)
        {
            ErrorMessage = error;
            return;
        }

        ErrorMessage = string.Empty;
        LoggedIn?.Invoke(this, _auth.CurrentUser!);
    }
}
