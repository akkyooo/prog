using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using lb9.Models;
using lb9.ViewModels;
using lb9.Views;

namespace lb9.Services
{
    public class DialogService : IDialogService
    {
        private readonly Func<Window?> getOwner;
        public DialogService(Func<Window?> getOwner)
        {
            this.getOwner = getOwner;
        }

        public Student? ShowStudentDialog(Student student, bool isEdit)
        {
            StudentViewModel viewModel = new StudentViewModel(student);
            StudentWindow window = new StudentWindow(viewModel)
            {
                Owner = getOwner(),
                Title = isEdit ? "Редагування студента" : "Додавання студента"
            };

            bool? result = window.ShowDialog();
            return result == true ? viewModel.ResultStudent : null;
        }

        public bool ConfirmDelete(string message)
        {
            MessageBoxResult result = MessageBox.Show(getOwner(), message, "Підтвердження видалення",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public void ShowMessage(string message, string title)
        {
            MessageBox.Show(getOwner(), message, title,
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}