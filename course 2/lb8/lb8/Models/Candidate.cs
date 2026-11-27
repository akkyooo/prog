
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lb8.Models
{
    public class Candidate : INotifyPropertyChanged
    {
        private string fullName = "";
        private DateTime? birthDate;
        private string education = "";
        private bool english, german, french;
        private string englishLevel = "", germanLevel = "",  frenchLevel = "";
        private bool computerSkills;
        private int workExperience;
        private bool recommendations;

        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged();
            }
        }

        public DateTime? BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged();
            }
        }

        public string Education
        {
            get => education;
            set
            {
                education = value;
                OnPropertyChanged();
            }
        }

        public bool English
        {
            get => english;
            set
            {
                english = value;
                if (!value) EnglishLevel = "";
                OnPropertyChanged();
            }
        }

        public bool German
        {
            get => german;
            set
            {
                german = value;
                if (!value) GermanLevel = "";
                OnPropertyChanged();
            }
        }

        public bool French
        {
            get => french;
            set
            {
                french = value;
                if (!value) FrenchLevel = "";
                OnPropertyChanged();
            }
        }

        public string EnglishLevel
        {
            get => englishLevel;
            set
            {
                englishLevel = value;
                OnPropertyChanged();
            }
        }

        public string GermanLevel
        {
            get => germanLevel;
            set
            {
                germanLevel = value;
                OnPropertyChanged();
            }
        }

        public string FrenchLevel
        {
            get => frenchLevel;
            set
            {
                frenchLevel = value;
                OnPropertyChanged();
            }
        }

        public bool ComputerSkills
        {
            get => computerSkills;
            set
            {
                computerSkills = value;
                OnPropertyChanged();
            }
        }

        public int WorkExperience
        {
            get => workExperience;
            set
            {
                workExperience = value;
                OnPropertyChanged();
            }
        }

        public bool Recommendations
        {
            get => recommendations;
            set
            {
                recommendations = value;
                OnPropertyChanged();
            }
        }

        public Candidate Copy()
        {
            return new Candidate
            {
                FullName = FullName,
                BirthDate = BirthDate,
                Education = Education,
                English = English,
                EnglishLevel = EnglishLevel,
                German = German,
                GermanLevel = GermanLevel,
                French = French,
                FrenchLevel = FrenchLevel,
                ComputerSkills = ComputerSkills,
                WorkExperience = WorkExperience,
                Recommendations = Recommendations
            };
        }

        public void CopyFrom(Candidate candidate)
        {
            FullName = candidate.FullName;
            BirthDate = candidate.BirthDate;
            Education = candidate.Education;

            English = candidate.English;
            EnglishLevel = candidate.EnglishLevel;

            German = candidate.German;
            GermanLevel = candidate.GermanLevel;

            French = candidate.French;
            FrenchLevel = candidate.FrenchLevel;

            ComputerSkills = candidate.ComputerSkills;
            WorkExperience = candidate.WorkExperience;
            Recommendations = candidate.Recommendations;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
