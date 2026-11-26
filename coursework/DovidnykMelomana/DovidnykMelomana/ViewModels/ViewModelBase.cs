using DovidnykMelomana.Models;

namespace DovidnykMelomana.ViewModels;

/// Базовий клас усіх ViewModel застосунку.

public abstract class ViewModelBase : ObservableObject
{
}

/// ViewModel, яка може попросити закрити своє вікно з результатом true або false.

public interface ICloseable
{
    event EventHandler<bool>? CloseRequested;
}
