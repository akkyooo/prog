using System.ComponentModel;
using System.Windows;
using lb6.Task2;

namespace lb6.Main
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBox.Show($"Загальна виручка за день: {BestOil.DailyRevenue:F2} грн", "Підсумок робочого дня",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}