using lb2.task1.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task1.items
{
    internal class CompanyCollection
    {
        public List<Company> Companies { get; private set; }

        public CompanyCollection()
        {
            Companies = new List<Company>()
            {
                new Company("Food Market", new DateTime(2018, 5, 10), "Торгівля", "John White", 150, "London"),

                new Company("IT Solutions", new DateTime(2022, 3, 15), "IT", "David Brown", 250, "London"),

                new Company("Marketing Pro", new DateTime(2023, 8, 20), "Маркетинг", "Michael Smith", 80, "Kyiv"),

                new Company("Food World", new DateTime(2020, 1, 12), "Маркетинг", "Robert White", 320, "London"),

                new Company("Computer Center", new DateTime(2025, 2, 1), "IT", "James Wilson", 120, "Kyiv"),

                new Company("Advertising Group", new DateTime(2021, 7, 5), "Маркетинг", "Peter Jones", 200, "Manchester"),

                new Company("White Foods", new DateTime(2020, 4, 10), "Торгівля", "David Black", 180, "London")
            };
        }
    }
}