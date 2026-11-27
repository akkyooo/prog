using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using lb9.Commands;
using lb9.Models;
using lb9.Services;

namespace lb9.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly StudentService studentService;
        private readonly IDialogService dialogService;
        private Student? selectedStudent;
        public ObservableCollection<Student> Students { get; } = new ObservableCollection<Student>();

        public Student? SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                OnPropertyChanged();

                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEmpty => Students.Count == 0;
        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public MainViewModel(StudentService service, IDialogService dialogs)
        {
            studentService = service;
            dialogService = dialogs;

            AddCommand = new RelayCommand(_ => AddStudent());
            EditCommand = new RelayCommand(_ => EditStudent(), _ => SelectedStudent != null);
            DeleteCommand = new RelayCommand(_ => DeleteStudents(), _ => CanDelete());
            Students.CollectionChanged += Students_CollectionChanged;
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                List<Student> students = studentService.LoadStudents(out string warning);
                foreach (Student student in students)
                {
                    AddStudentToCollection(student);
                }

                if (!string.IsNullOrWhiteSpace(warning))
                {
                    dialogService.ShowMessage(warning, "Попередження завантаження");
                }
            }
            catch (Exception exception)
            {
                dialogService.ShowMessage("Не вдалося завантажити файл Students.xml.\n\n" + exception.Message, "Помилка завантаження");
            }

            OnPropertyChanged(nameof(IsEmpty));
            UpdateCommands();
        }

        private void AddStudentToCollection(Student student)
        {
            student.PropertyChanged += Student_PropertyChanged;
            Students.Add(student);
        }

        private void Student_PropertyChanged( object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Student.IsMarked))
            {
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private void Students_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsEmpty));
            UpdateCommands();
        }

        private void UpdateCommands()
        {
            EditCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
        }

        private bool CanDelete()
        {
            return Students.Any(student => student.IsMarked) || SelectedStudent != null;
        }

        private void AddStudent()
        {
            Student? student = dialogService.ShowStudentDialog(new Student(), false);

            if (student == null)
                return;

            List<Student> updatedStudents = Students.ToList();
            updatedStudents.Add(student);

            if (SaveChanges(updatedStudents))
            {
                AddStudentToCollection(student);
            }
        }

        private void EditStudent()
        {
            if (SelectedStudent == null)
                return;

            Student originalStudent = SelectedStudent;
            Student ? editedStudent = dialogService.ShowStudentDialog(originalStudent.Copy(), true);

            if (editedStudent == null)
                return;

            List<Student> updatedStudents = Students.ToList();
            int index = updatedStudents.IndexOf(originalStudent);

            if (index < 0)
                return;

            updatedStudents[index] = editedStudent;

            if (SaveChanges(updatedStudents))
            {
                originalStudent.CopyFrom(editedStudent);
            }
        }

        private void DeleteStudents()
        {
            List<Student> selectedStudents = Students
                .Where(student => student.IsMarked)
                .ToList();

            if (selectedStudents.Count == 0 && SelectedStudent != null)
            {
                selectedStudents.Add(SelectedStudent);
            }

            if (selectedStudents.Count == 0)
                return;

            string message = selectedStudents.Count == 1 ? "Ви дійсно хочете видалити цього студента?" : $"Ви дійсно хочете видалити " +
                  $"{selectedStudents.Count} студентів?";

            if (!dialogService.ConfirmDelete(message))
                return;

            List<Student> updatedStudents = Students
                .Where(student => !selectedStudents.Contains(student))
                .ToList();

            if (!SaveChanges(updatedStudents))
                return;

            foreach (Student student in selectedStudents)
            {
                student.PropertyChanged -= Student_PropertyChanged;
                Students.Remove(student);
            }

            SelectedStudent = null;
        }

        private bool SaveChanges(List<Student> students)
        {
            try
            {
                studentService.SaveStudents(students);
                return true;
            }
            catch (Exception exception)
            {
                dialogService.ShowMessage("Не вдалося зберегти зміни у файлі Students.xml.\n\n" + exception.Message, "Помилка збереження");
                return false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
