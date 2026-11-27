using System;
using System.Collections.Generic;
using System.Text;
using lb9.Models;

namespace lb9.Services
{
    public interface IDialogService
    {
        Student? ShowStudentDialog(Student student, bool isEdit);

        bool ConfirmDelete(string message);

        void ShowMessage(string message, string title);
    }
}