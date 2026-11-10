using lb2.task2.items;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task2
{
    public static class Launcher2
    {
        public static void Run()
        {
            PhoneCollection collection = new PhoneCollection();
            PhoneQueries queries = new PhoneQueries(collection.Phones);

            Console.WriteLine("ЗАВДАННЯ 2. ТЕЛЕФОНИ");

            Console.WriteLine("\n1. Загальна кількість телефонів: " +
                queries.GetPhoneCount());

            Console.WriteLine("2. Кількість телефонів із ціною більше 100: " +
                queries.GetCountMoreThan100());

            Console.WriteLine("3. Кількість телефонів із ціною від 400 до 700: " +
                queries.GetCountFrom400To700());

            Console.Write("\nВведіть виробника для підрахунку (наприклад, Samsung): ");
            string manufacturer = Console.ReadLine();

            Console.WriteLine("4. Кількість телефонів виробника " + manufacturer + ": " +
                queries.GetCountByManufacturer(manufacturer ?? ""));

            Console.WriteLine("\n5. Телефон із мінімальною ціною:");
            Console.WriteLine(queries.GetCheapestPhone());

            Console.WriteLine("\n6. Телефон із максимальною ціною:");
            Console.WriteLine(queries.GetMostExpensivePhone());

            Console.WriteLine("\n7. Найстаріший телефон:");
            Console.WriteLine(queries.GetOldestPhone());

            Console.WriteLine("\n8. Найновіший телефон:");
            Console.WriteLine(queries.GetNewestPhone());

            Console.WriteLine("\n9. Середня ціна телефону: " +
                queries.GetAveragePrice().ToString("F2"));

            Show("10. П'ять найдорожчих телефонів:",
                queries.GetFiveMostExpensive());

            Show("11. П'ять найдешевших телефонів:",
                queries.GetFiveCheapest());

            Show("12. Три найстаріші телефони:",
                queries.GetThreeOldest());

            Show("13. Три найновіші телефони:",
                queries.GetThreeNewest());

            Console.WriteLine("\n14. Статистика за виробниками:");
            foreach (var group in queries.GetManufacturerStatistics())
            {
                Console.WriteLine(group.Key + " - " + group.Count());
            }

            Console.WriteLine("\n15. Статистика за моделями:");
            foreach (var group in queries.GetModelStatistics())
            {
                Console.WriteLine(group.Key + " - " + group.Count());
            }

            Console.WriteLine("\n16. Статистика за роками випуску:");
            foreach (var group in queries.GetYearStatistics().OrderBy(g => g.Key))
            {
                Console.WriteLine(group.Key + " - " + group.Count());
            }
        }
        private static void Show(string title, List<Phone> phones)
        {
            Console.WriteLine("\n" + title);

            foreach (Phone phone in phones)
            {
                Console.WriteLine(phone);
            }
        }
    }
}
