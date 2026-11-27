using System;
using System.Collections.Generic;
using System.Text;

namespace lb9.Services
{
    public static class StudentValidation
    {
        public static List<string> Validate(string surname, string name, string ageText, string gender, out int age)
        {
            List<string> errors = new List<string>();
            age = 0;
            if (string.IsNullOrWhiteSpace(surname))
            {
                errors.Add("Введіть прізвище студента.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("Введіть ім'я студента.");
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                errors.Add("Оберіть стать студента.");
            }

            if (string.IsNullOrWhiteSpace(ageText))
            {
                errors.Add("Вкажіть вік студента.");
            }
            else if (!int.TryParse(ageText, out age))
            {
                errors.Add("Вік повинен бути цілим числом.");
            }
            else if (age < 0)
            {
                errors.Add("Вік не може бути від'ємним.");
            }
            else if (age < 16)
            {
                errors.Add("Вік студента не може бути меншим за 16 років.");
            }
            else if (age > 100)
            {
                errors.Add("Вік студента не може перевищувати 100 років.");
            }

            return errors;
        }
    }
}
