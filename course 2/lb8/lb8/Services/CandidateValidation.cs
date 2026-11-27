
using System;
using System.Text.RegularExpressions;
using lb8.Models;

namespace lb8.Services
{
    public static class CandidateValidation
    {
        public static string? Validate(Candidate candidate)
        {
            string name = candidate.FullName.Trim();
            if (string.IsNullOrWhiteSpace(name))
                return "Введіть прізвище, ім'я та по батькові.";

            if (!Regex.IsMatch(name, @"^[\p{L}'’\-]+(?:\s+[\p{L}'’\-]+)+$"))
            {
                return "ПІБ повинно містити щонайменше два слова та не містити цифр.";
            }

            if (!candidate.BirthDate.HasValue)
                return "Оберіть дату народження.";

            DateTime birthDate = candidate.BirthDate.Value;

            if (birthDate < new DateTime(1940, 1, 1) || birthDate > DateTime.Today)
            {
                return "Дата народження повинна бути в межах від 1940 року до сьогодні.";
            }

            if (candidate.Education != "Середня" &&
                candidate.Education != "Середня спеціальна" &&
                candidate.Education != "Вища")
            {
                return "Оберіть освіту.";
            }

            if (candidate.WorkExperience < 0 || candidate.WorkExperience > 60)
            {
                return "Стаж роботи повинен бути від 0 до 60 років.";
            }

            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Date > DateTime.Today.AddYears(-age))
                age--;

            int maximumExperience = Math.Max(0, age - 16);

            if (candidate.WorkExperience > maximumExperience)
                return "Стаж роботи не може перевищувати можливий стаж кандидата.";

            if (candidate.English && string.IsNullOrWhiteSpace(candidate.EnglishLevel))
            {
                return "Оберіть рівень володіння англійською мовою.";
            }

            if (candidate.German && string.IsNullOrWhiteSpace(candidate.GermanLevel))
            {
                return "Оберіть рівень володіння німецькою мовою.";
            }

            if (candidate.French && string.IsNullOrWhiteSpace(candidate.FrenchLevel))
            {
                return "Оберіть рівень володіння французькою мовою.";
            }

            return null;
        }
    }
}
