using lb2.task3.items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lb2.task3.models
{
    internal class Company
    {
        public string Name { get; set; }
        public List<Employer> Employers { get; set; }

        public Company(string name)
        {
            Name = name;
            Employers = new List<Employer>();
        }

        public int GetWorkersCount()
        {
            return Employers.OfType<Worker>().Count();
        }

        public decimal GetWorkersSalary()
        {
            return Employers.OfType<Worker>()
                .Sum(w => w.Salary);
        }

        public List<Worker> GetTenMostExperiencedWorkers()
        {
            return Employers.OfType<Worker>()
                .OrderByDescending(w => w.ExperienceYears)
                .Take(10)
                .ToList();
        }

        public Worker? GetYoungestEducatedWorkerFromTopTen()
        {
            return GetTenMostExperiencedWorkers()
                .Where(w => w.Education == "Вища")
                .OrderByDescending(w => w.BirthDate)
                .FirstOrDefault();
        }

        public Manager? GetYoungestManager()
        {
            return Employers.OfType<Manager>()
                .OrderByDescending(m => m.BirthDate)
                .FirstOrDefault();
        }

        public Manager? GetOldestManager()
        {
            return Employers.OfType<Manager>()
                .OrderBy(m => m.BirthDate)
                .FirstOrDefault();
        }

        public List<Worker> GetOctoberWorkers()
        {
            return Employers.OfType<Worker>()
                .Where(w => w.BirthDate.Month == 10)
                .OrderBy(w => w.ProfessionDirection)
                .ToList();
        }

        public List<Employer> GetVladimirs()
        {
            return Employers
                .Where(e => e.Name.Split(' ')[0] == "Володимир")
                .ToList();
        }

        public Employer? GetYoungestVladimir()
        {
            return GetVladimirs()
                .OrderByDescending(e => e.BirthDate)
                .FirstOrDefault();
        }
    }
}

