using lb2.task3.items;
using System;
using System.Collections.Generic;
using System.Text;
using lb2.task3.models;

namespace lb2.task3
{
    public static class Launcher3
    {
        public static void Run()
        {
            Company company = new Company("TechnoPlus");

            company.Employers.Add(new President(
                "Олександр Петренко", new DateTime(1975, 4, 12),
                25, "Вища", 80000, "Керівництво"));

            company.Employers.Add(new Manager(
                "Іван Коваленко", new DateTime(1980, 3, 15),
                18, "Вища", 45000, "Продажі"));

            company.Employers.Add(new Manager(
                "Володимир Шевченко", new DateTime(1995, 7, 20),
                8, "Вища", 38000, "IT"));

            company.Employers.Add(new Manager(
                "Андрій Мельник", new DateTime(1970, 11, 8),
                22, "Вища", 50000, "Виробництво"));

            company.Employers.Add(new Worker(
                "Володимир Бондар", new DateTime(2002, 5, 10),
                6, "Вища", 22000, "IT"));

            company.Employers.Add(new Worker(
                "Петро Іваненко", new DateTime(1985, 10, 12),
                15, "Вища", 25000, "Виробництво"));

            company.Employers.Add(new Worker(
                "Сергій Ткаченко", new DateTime(1978, 10, 5),
                20, "Середня", 23000, "Виробництво"));

            company.Employers.Add(new Worker(
                "Микола Кравець", new DateTime(1990, 2, 18),
                12, "Вища", 24000, "IT"));

            company.Employers.Add(new Worker(
                "Володимир Савчук", new DateTime(2000, 10, 22),
                7, "Вища", 21000, "Продажі"));

            company.Employers.Add(new Worker(
                "Дмитро Поліщук", new DateTime(1988, 6, 14),
                14, "Середня", 20000, "Виробництво"));

            company.Employers.Add(new Worker(
                "Олег Козак", new DateTime(1982, 10, 9),
                19, "Вища", 26000, "IT"));

            company.Employers.Add(new Worker(
                "Роман Лисенко", new DateTime(1997, 1, 25),
                9, "Вища", 19000, "Продажі"));

            company.Employers.Add(new Worker(
                "Василь Мороз", new DateTime(1979, 8, 3),
                21, "Середня", 22000, "Виробництво"));

            company.Employers.Add(new Worker(
                "Ігор Павленко", new DateTime(1993, 10, 17),
                11, "Вища", 23000, "IT"));

            company.Employers.Add(new Worker(
                "Тарас Руденко", new DateTime(1987, 12, 1),
                16, "Вища", 25000, "Виробництво"));

            company.Employers.Add(new Worker(
                "Максим Бойко", new DateTime(2001, 4, 27),
                5, "Вища", 18000, "Продажі"));

            company.Employers.Add(new Worker(
                "Юрій Климчук", new DateTime(1991, 10, 30),
                13, "Середня", 21500, "Виробництво"));

            company.Employers.Add(new Worker(
                "Артур Дяченко", new DateTime(1998, 9, 16),
                8, "Вища", 20500, "IT"));

            Console.WriteLine("Підприємство: " + company.Name);

            // 1. Кількість робітників
            Console.WriteLine("\n1. Кількість робітників: " +
                company.GetWorkersCount());

            // 2. Загальна зарплата робітників
            Console.WriteLine("\n2. Загальна сума зарплат робітників: " +
                company.GetWorkersSalary() + " грн");

            // 3. Десять робітників із найбільшим стажем
            Console.WriteLine("\n3. Десять робітників із найбільшим стажем:");

            foreach (Worker worker in company.GetTenMostExperiencedWorkers())
                Console.WriteLine(worker);

            // Наймолодший із вищою освітою серед цих десяти
            Worker educatedWorker =
                company.GetYoungestEducatedWorkerFromTopTen();

            Console.WriteLine("\nНаймолодший серед них із вищою освітою:");

            if (educatedWorker != null)
                Console.WriteLine(educatedWorker);
            else
                Console.WriteLine("Такого робітника не знайдено.");

            // 4. Наймолодший і найстарший менеджери
            Console.WriteLine("\n4. Наймолодший менеджер:");
            Console.WriteLine(company.GetYoungestManager());

            Console.WriteLine("\nНайстарший менеджер:");
            Console.WriteLine(company.GetOldestManager());

            // 5. Робітники, народжені в жовтні, за напрямами
            Console.WriteLine("\n5. Робітники, народжені в жовтні:");

            var octoberGroups = company.GetOctoberWorkers()
                .GroupBy(w => w.ProfessionDirection);

            foreach (var group in octoberGroups)
            {
                Console.WriteLine("\nНапрям: " + group.Key);

                foreach (Worker worker in group)
                    Console.WriteLine(worker);
            }

            // 6. Усі Володимири
            Console.WriteLine("\n6. Усі Володимири на підприємстві:");

            var vladimirs = company.GetVladimirs();

            foreach (Employer employer in vladimirs)
                Console.WriteLine(employer);

            // Наймолодший Володимир і премія
            Employer youngestVladimir = company.GetYoungestVladimir();

            Console.WriteLine("\nНаймолодший Володимир:");

            if (youngestVladimir != null)
            {
                decimal bonus = youngestVladimir.Salary / 3;

                Console.WriteLine(youngestVladimir);
                Console.WriteLine("Вітаємо з премією!");
                Console.WriteLine("Розмір премії: " + bonus + " грн");
                Console.WriteLine("Зарплата разом із премією: " +
                    (youngestVladimir.Salary + bonus) + " грн");
            }
            else
            {
                Console.WriteLine("Володимирів не знайдено.");
            }
        }
    }
}
