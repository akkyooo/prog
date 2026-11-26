using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DovidnykMelomana.ViewModels;

/// База для вікон редагування: зберігає помилки перевірки полів (INotifyDataErrorInfo) і надає команди «Зберегти» та «Скасувати».

public abstract class EditViewModelBase : ViewModelBase, INotifyDataErrorInfo, ICloseable
{
    private readonly Dictionary<string, List<string>> _errors = new();

    protected EditViewModelBase()
    {
        SaveCommand = new RelayCommand(Save);
        CancelCommand = new RelayCommand(() => CloseRequested?.Invoke(this, false));
    }

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    public event EventHandler<bool>? CloseRequested;

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public abstract string WindowTitle { get; }

    public bool HasErrors => _errors.Count > 0;

    /// Усі повідомлення про помилки одним рядком для підказки під формою.
    public string ErrorSummary => string.Join(Environment.NewLine, _errors.Values.SelectMany(e => e).Distinct());

    public IEnumerable GetErrors(string? propertyName)
    {
        if (propertyName != null && _errors.TryGetValue(propertyName, out var list))
        {
            return list;
        }

        return Array.Empty<string>();
    }

    protected void SetError(string propertyName, string? error)
    {
        if (error == null)
        {
            if (_errors.Remove(propertyName))
            {
                RaiseErrorsChanged(propertyName);
            }

            return;
        }

        _errors[propertyName] = new List<string> { error };
        RaiseErrorsChanged(propertyName);
    }

    protected void ClearAllErrors()
    {
        foreach (var key in _errors.Keys.ToList())
        {
            _errors.Remove(key);
            RaiseErrorsChanged(key);
        }
    }

    /// Перевіряє одне поле після введення.
    protected void Validate([CallerMemberName] string? propertyName = null)
    {
        if (propertyName != null)
        {
            SetError(propertyName, ValidateProperty(propertyName));
        }
    }

    protected abstract string? ValidateProperty(string propertyName);

    protected abstract IEnumerable<string> ValidatedProperties { get; }

    /// Записує зміни в модель і в файл. Виконується лише тоді, коли помилок немає.
    protected abstract void Apply();

    /// Перевірки, які залежать від кількох полів або від інших записів каталогу.
    protected virtual string? ValidateWhole() => null;

    private void Save()
    {
        foreach (var property in ValidatedProperties)
        {
            Validate(property);
        }

        if (!HasErrors)
        {
            var wholeError = ValidateWhole();
            if (wholeError != null)
            {
                SetError(string.Empty, wholeError);
            }
        }

        if (HasErrors)
        {
            return;
        }

        Apply();
        CloseRequested?.Invoke(this, true);
    }

    private void RaiseErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        OnPropertyChanged(nameof(HasErrors));
        OnPropertyChanged(nameof(ErrorSummary));
    }
}
