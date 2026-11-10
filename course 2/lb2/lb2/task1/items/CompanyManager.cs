using lb2.task1.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task1.items
{
    internal class CompanyManager
    {
        private CompanyQueries queries;

        public CompanyManager(CompanyQueries queries)
        {
            this.queries = queries;
        }

        private void Show(string title, List<Company> companies)
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

        public void Run()
        {
            Show("1. Усі фірми:", queries.GetAll());
            Show("2. Фірми з назвою Food:", queries.GetFoodCompanies());
            Show("3. Фірми у галузі маркетингу:", queries.GetMarketingCompanies());
            Show("4. Фірми у галузі маркетингу або IT:", queries.GetMarketingOrITCompanies());
            Show("5. Фірми з кількістю працівників більше 100:", queries.GetCompaniesWithMoreThan100Employees());
            Show("6. Фірми з кількістю працівників від 100 до 300:", queries.GetCompaniesWith100To300Employees());
            Show("7. Фірми у Лондоні:", queries.GetLondonCompanies());
            Show("8. Фірми з директором White:", queries.GetCompaniesWithWhiteDirector());
            Show("9. Фірми, засновані понад два роки тому:", queries.GetCompaniesOlderThanTwoYears());
            Show("10. Фірми, засновані понад 150 днів тому:", queries.GetCompaniesOlderThan150Days());
            Show("11. Директор Black і назва містить White:", queries.GetBlackDirectorAndWhiteName());
        }
    }
}

