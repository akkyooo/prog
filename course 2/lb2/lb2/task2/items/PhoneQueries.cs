using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task2.items
{
    internal class PhoneQueries
    {
        private List<Phone> phones;

        public PhoneQueries(List<Phone> phones)
        {
            this.phones = phones;
        }

        public int GetPhoneCount()
        {
            return phones.Count();
        }

        public int GetCountMoreThan100()
        {
            return phones.Count(p => p.Price > 100);
        }

        public int GetCountFrom400To700()
        {
            return phones.Count(p => p.Price >= 400 && p.Price <= 700);
        }

        public int GetCountByManufacturer(string manufacturer)
        {
            return phones.Count(p => p.Manufacturer == manufacturer);
        }

        public Phone GetCheapestPhone()
        {
            return phones.OrderBy(p => p.Price).First();
        }

        public Phone GetMostExpensivePhone()
        {
            return phones.OrderByDescending(p => p.Price).First();
        }

        public Phone GetOldestPhone()
        {
            return phones.OrderBy(p => p.ReleaseDate).First();
        }

        public Phone GetNewestPhone()
        {
            return phones.OrderByDescending(p => p.ReleaseDate).First();
        }

        public decimal GetAveragePrice()
        {
            return phones.Average(p => p.Price);
        }

        public List<Phone> GetFiveMostExpensive()
        {
            return phones.OrderByDescending(p => p.Price).Take(5).ToList();
        }

        public List<Phone> GetFiveCheapest()
        {
            return phones.OrderBy(p => p.Price).Take(5).ToList();
        }

        public List<Phone> GetThreeOldest()
        {
            return phones.OrderBy(p => p.ReleaseDate).Take(3).ToList();
        }

        public List<Phone> GetThreeNewest()
        {
            return phones.OrderByDescending(p => p.ReleaseDate).Take(3).ToList();
        }

        public IEnumerable<IGrouping<string, Phone>> GetManufacturerStatistics()
        {
            return phones.GroupBy(p => p.Manufacturer);
        }

        public IEnumerable<IGrouping<string, Phone>> GetModelStatistics()
        {
            return phones.GroupBy(p => p.Name);
        }

        public IEnumerable<IGrouping<int, Phone>> GetYearStatistics()
        {
            return phones.GroupBy(p => p.ReleaseDate.Year);
        }
    }
}
