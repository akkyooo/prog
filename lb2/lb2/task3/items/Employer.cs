using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task3.items
{
    internal class Employer
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int ExperienceYears { get; set; }
        public string Education { get; set; }
        public decimal Salary { get; set; }
        public string ProfessionDirection { get; set; }

        public Employer(string name, DateTime birthDate,
            int experienceYears, string education,
            decimal salary, string professionDirection)
        {
            Name = name;
            BirthDate = birthDate;
            ExperienceYears = experienceYears;
            Education = education;
            Salary = salary;
            ProfessionDirection = professionDirection;
        }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;

                if (BirthDate.Date > DateTime.Now.AddYears(-age).Date)
                    age--;

                return age;
            }
        }

        public override string ToString()
        {
            return $"{Name}, вік: {Age}, стаж: {ExperienceYears} років, " +
                   $"освіта: {Education}, зарплата: {Salary} грн, " +
                   $"напрям: {ProfessionDirection}";
        }
    }
}
