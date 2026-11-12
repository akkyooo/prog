using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lb5.Task5
{
    /// <summary>
    /// Interaction logic for CatchButtonGame.xaml
    /// </summary>
    public partial class CatchButtonGame : UserControl
    {
        private Random random = new Random();

        public CatchButtonGame()
        {
            InitializeComponent();
        }
        private void CatchButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            double maxLeft = Math.Max(0, GameCanvas.ActualWidth - CatchButton.ActualWidth);
            double maxTop = Math.Max(0, GameCanvas.ActualHeight - CatchButton.ActualHeight);

            double left = random.NextDouble() * maxLeft;
            double top = random.NextDouble() * maxTop;

            Canvas.SetLeft(CatchButton, left);
            Canvas.SetTop(CatchButton, top);
        }

        private void CatchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вітаємо! Ви впіймали кнопку!");
        }
    }
}
