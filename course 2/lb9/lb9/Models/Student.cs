using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lb9.Models
{
    public class Student : INotifyPropertyChanged
    {
        private string surname = "";
        private string name = "";
        private int age;
        private string gender = "";
        private bool isMarked;
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AgeText));
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

        public bool IsMarked
        {
            get => isMarked;
            set
            {
                isMarked = value;
                OnPropertyChanged();
            }
        }
        public string FullName => $"{Surname} {Name}";

        public string AgeText
        {
            get
            {
                int lastTwo = Age % 100;
                int lastDigit = Age % 10;
                if (lastTwo >= 11 && lastTwo <= 14)
                    return $"{Age} років";

                if (lastDigit == 1)
                    return $"{Age} рік";

                if (lastDigit >= 2 && lastDigit <= 4)
                    return $"{Age} роки";
                return $"{Age} років";
            }
        }

        public Student Copy()
        {
            return new Student
            {
                Surname = Surname,
                Name = Name,
                Age = Age,
                Gender = Gender
            };
        }

        public void CopyFrom(Student student)
        {
            Surname = student.Surname;
            Name = student.Name;
            Age = student.Age;
            Gender = student.Gender;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}