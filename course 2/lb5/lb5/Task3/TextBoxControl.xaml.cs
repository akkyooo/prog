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

namespace lb5.Task3
{
    /// <summary>
    /// Interaction logic for TextBoxControl.xaml
    /// </summary>
    public partial class TextBoxControl : UserControl
    {
        public TextBoxControl()
        {
            InitializeComponent();
        }
        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            InputText.Visibility = Visibility.Hidden;
        }
        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            InputText.Visibility = Visibility.Visible;
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputText.Clear();
        }
    }

}
