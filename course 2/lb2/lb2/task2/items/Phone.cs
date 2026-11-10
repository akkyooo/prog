using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task2.items
{
    internal class Phone
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Phone(string name, string manufacturer,
            decimal price, DateTime releaseDate)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public override string ToString()
        {
            return $"Назва: {Name}, виробник: {Manufacturer}, " + $"ціна: {Price}, дата випуску: {ReleaseDate:dd.MM.yyyy}";
        }
    }
}
