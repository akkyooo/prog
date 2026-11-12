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

namespace lb5.Task1
{
    /// <summary>
    /// Interaction logic for Greeting.xaml
    /// </summary>
    public partial class Greeting : UserControl
    {
        public Greeting()
        {
            InitializeComponent();
        }
        private void HelloButton_Click(object sender, RoutedEventArgs e)
        {
            GreetingLabel.Content = "Привіт";
        }
        private void GoodbyeButton_Click(object sender, RoutedEventArgs e)
        {
            GreetingLabel.Content = "До побачення";
        }
    }
}
