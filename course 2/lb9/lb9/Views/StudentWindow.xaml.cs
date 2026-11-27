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
using System.Windows.Shapes;
using lb9.ViewModels;

namespace lb9.Views
{
    public partial class StudentWindow : Window
    {
        private readonly StudentViewModel viewModel;

        public StudentWindow(StudentViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = viewModel;
            viewModel.RequestClose += CloseWindow;
            Closed += StudentWindow_Closed;
        }

        private void CloseWindow(bool? result)
        {
            DialogResult = result;
        }

        private void StudentWindow_Closed(object? sender, EventArgs e)
        {
            viewModel.RequestClose -= CloseWindow;
            Closed -= StudentWindow_Closed;
        }
    }
}