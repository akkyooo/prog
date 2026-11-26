using System.Windows;
using DovidnykMelomana.ViewModels;

namespace DovidnykMelomana.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    // PasswordBox.Password не є DependencyProperty, тому значення передається у ViewModel вручну
    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel viewModel)
        {
            viewModel.Password = PasswordInput.Password;
        }
    }

    private void OnConfirmChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel viewModel)
        {
            viewModel.ConfirmPassword = ConfirmInput.Password;
        }
    }
}
