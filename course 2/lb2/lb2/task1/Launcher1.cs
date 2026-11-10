using lb2.task1.items;
using lb2.task1.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task1
{
    public static class Launcher1
    {
        public static void Run()
        {
            CompanyCollection collection = new CompanyCollection();
            CompanyQueries queries = new CompanyQueries(collection.Companies);

            Show("1. Усі фірми:", queries.GetAll());
            Show("2. Фірми, які мають назву Food:", queries.GetFoodCompanies());
            Show("3. Фірми у галузі маркетингу:", queries.GetMarketingCompanies());
            Show("4. Фірми у галузі маркетингу або IT:", queries.GetMarketingOrITCompanies());
            Show("5. Фірми з кількістю працівників більше 100:", queries.GetCompaniesWithMoreThan100Employees());
            Show("6. Фірми з кількістю працівників від 100 до 300:", queries.GetCompaniesWith100To300Employees());
            Show("7. Фірми у Лондоні:", queries.GetLondonCompanies());
            Show("8. Фірми з прізвищем директора White:", queries.GetCompaniesWithWhiteDirector());
            Show("9. Фірми, засновані понад два роки тому:", queries.GetCompaniesOlderThanTwoYears());
            Show("10. Фірми, з дня заснування яких минуло більше 150 днів:", queries.GetCompaniesOlderThan150Days());
            Show("11. Директор Black і назва містить White:", queries.GetBlackDirectorAndWhiteName());
        }

        private static void Show(string title, List<Company> companies)
        {
            Console.WriteLine("\n" + title);

            if (companies.Count == 0)
            {
                Console.WriteLine("Компаній не знайдено.");
                return;
            }

            foreach (Company company in companies)
            {
                Console.WriteLine(company);
            }
        }
    }
}
