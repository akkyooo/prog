using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using lb9.Commands;
using lb9.Models;
using lb9.Services;

namespace lb9.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private string surname = "";
        private string name = "";
        private string age = "";
        private string gender = "";
        private string errorMessage = "";

        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public string[] GenderOptions { get; } =
        {
            "Чоловіча",
            "Жіноча"
        };

        public Student ResultStudent { get; private set; } = new Student();

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }
        public event Action<bool?>? RequestClose;

        public StudentViewModel(Student student)
        {
            Surname = student.Surname;
            Name = student.Name;
            Age = student.Age == 0 ? "" : student.Age.ToString();
            Gender = student.Gender;
            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        private void Save()
        {
            List<string> errors = StudentValidation.Validate(Surname, Name, Age, Gender, out int studentAge);

            if (errors.Count > 0)
            {
                ErrorMessage = string.Join(Environment.NewLine, errors);
                return;
            }

            ResultStudent = new Student
            {
                Surname = Surname.Trim(),
                Name = Name.Trim(),
                Age = studentAge,
                Gender = Gender
            };

            ErrorMessage = "";
            RequestClose?.Invoke(true);
        }

        private void Cancel()
        {
            RequestClose?.Invoke(false);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
