using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Налаштування: кольорова тема та відомості про файли даних.

public class SettingsViewModel : EditViewModelBase
{
    private readonly AuthService _auth;
    private readonly User _user;
    private string _selectedTheme;
    private string _displayName;

    public SettingsViewModel(AuthService auth, CatalogService catalog)
    {
        _auth = auth;
        _user = auth.CurrentUser!;
        _selectedTheme = ThemeService.CurrentTheme;
        _displayName = _user.DisplayName;
        DataFilePath = catalog.FilePath;
    }

    public override string WindowTitle => "Налаштування";

    public IEnumerable<string> Themes => ThemeService.Themes;

    public string SelectedTheme
    {
        get => _selectedTheme;
        set
        {
            if (SetProperty(ref _selectedTheme, value))
            {
                // тема змінюється одразу, щоб користувач бачив результат до збереження
                ThemeService.Apply(value);
            }
        }
    }

    public string DisplayName
    {
        get => _displayName;
        set
        {
            SetProperty(ref _displayName, value);
            Validate();
        }
    }

    public string Login => _user.Login;
    public string RegisteredText => _user.RegisteredAt.ToString("dd.MM.yyyy");
    public string DataFilePath { get; }

    protected override IEnumerable<string> ValidatedProperties => new[] { nameof(DisplayName) };

    protected override string? ValidateProperty(string propertyName) =>
        propertyName == nameof(DisplayName) && string.IsNullOrWhiteSpace(DisplayName)
            ? "Ім'я не може бути порожнім."
            : null;

    protected override void Apply()
    {
        _user.DisplayName = DisplayName.Trim();
        _user.Theme = SelectedTheme;
        _auth.SaveUsers();
    }

    /// Повертає тему, збережену раніше, якщо користувач натиснув «Скасувати».
    public void RevertTheme() => ThemeService.Apply(_user.Theme);
}
