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

namespace lb5.Task2
{
    /// <summary>
    /// Interaction logic for VisibilityControl.xaml
    /// </summary>
    public partial class VisibilityControl : UserControl
    {
        public VisibilityControl()
        {
            InitializeComponent();
        }
        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            MessageText.Visibility = Visibility.Hidden;
        }
        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            MessageText.Visibility = Visibility.Visible;
        }
    }
}
