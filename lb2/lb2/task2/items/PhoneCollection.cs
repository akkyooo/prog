using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task2.items
{
    internal class PhoneCollection
    {
        public List<Phone> Phones { get; private set; }

        public PhoneCollection()
        {
            Phones = new List<Phone>()
            {
                new Phone("iPhone 13", "Apple", 650, new DateTime(2021, 9, 24)),
                new Phone("iPhone 13", "Apple", 600, new DateTime(2021, 9, 24)),
                new Phone("iPhone 15", "Apple", 900, new DateTime(2023, 9, 22)),
                new Phone("Galaxy S22", "Samsung", 550, new DateTime(2022, 2, 25)),
                new Phone("Galaxy S22", "Samsung", 500, new DateTime(2022, 2, 25)),
                new Phone("Galaxy S24", "Samsung", 850, new DateTime(2024, 1, 31)),
                new Phone("Xperia 10", "Sony", 350, new DateTime(2022, 4, 1)),
                new Phone("Xperia 5", "Sony", 700, new DateTime(2023, 9, 1)),
                new Phone("Redmi Note 10", "Xiaomi", 180, new DateTime(2021, 3, 4)),
                new Phone("Redmi Note 12", "Xiaomi", 300, new DateTime(2023, 3, 23)),
                new Phone("Nokia 3310", "Nokia", 80, new DateTime(2000, 9, 1)),
                new Phone("Pixel 8", "Google", 750, new DateTime(2023, 10, 12)),
                new Phone("Pixel 9", "Google", 950, new DateTime(2024, 8, 13)),
                new Phone("iPhone 10", "Apple", 420, new DateTime(2017, 11, 3)),
                new Phone("Galaxy A15", "Samsung", 220, new DateTime(2023, 12, 11))
            };
        }
    }
}
