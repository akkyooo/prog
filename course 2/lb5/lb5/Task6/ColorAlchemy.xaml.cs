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

namespace lb5.Task6
{
    /// <summary>
    /// Interaction logic for ColorAlchemy.xaml
    /// </summary>
    public partial class ColorAlchemy : UserControl
    {
        private Random random = new Random();

        private int targetRed;
        private int targetGreen;
        private int targetBlue;

        private bool completed = false;

        public ColorAlchemy()
        {
            InitializeComponent();

            NewRecipe();
        }

        private void NewRecipe()
        {
            targetRed = random.Next(0, 256);
            targetGreen = random.Next(0, 256);
            targetBlue = random.Next(0, 256);

            RecipeText.Text = $"Знайдіть колір: R={targetRed}, G={targetGreen}, B={targetBlue}";
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Crystal == null)
            {
                return;
            }

            int red = (int)RedSlider.Value;
            int green = (int)GreenSlider.Value;
            int blue = (int)BlueSlider.Value;

            Color color = Color.FromRgb((byte)red, (byte)green, (byte)blue);

            Crystal.Fill = new SolidColorBrush(color);

            if (red == targetRed && green == targetGreen && blue == targetBlue && !completed)
            {
                completed = true;
                MessageBox.Show("Зілля готове!");
            }
        }
    }
}
