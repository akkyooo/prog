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

namespace lb5.Task4
{
    /// <summary>
    /// Interaction logic for ButtonGame.xaml
    /// </summary>
    public partial class ButtonGame : UserControl
    {
        private Button[] buttons = Array.Empty<Button>();
        private Random random = new Random();

        public ButtonGame()
        {
            InitializeComponent();

            buttons = GameGrid.Children .OfType<Button>() .ToArray();
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            clickedButton.Visibility = Visibility.Hidden;

            Button[] otherButtons = buttons .Where(button => button != clickedButton) .ToArray();

            int visibleCount = buttons.Count(button => button.Visibility == Visibility.Visible);

            if (visibleCount > 1)
            {
                Button otherButton = otherButtons[random.Next(otherButtons.Length)];

                if (otherButton.Visibility == Visibility.Visible)
                {
                    otherButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    otherButton.Visibility = Visibility.Visible;
                }
            }

            if (buttons.All(button => button.Visibility == Visibility.Hidden))
            {
                MessageBox.Show("Вітаємо! Ви приховали всі кнопки!");
            }
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button button in buttons)
            {
                button.Visibility = Visibility.Visible;
            }
        }
    }
}
