using System;
using System.Collections.Generic;
using System.Text;

namespace lb1.task1.models
{
    internal class Product
    {
        public string Name { get; set; }
        public List<Store> Stores { get; set; }

        public Product(string name)
        {
            Name = name;
            Stores = new List<Store>();
        }

        public void AddStore(string name, double price)
        {
            Stores.Add(new Store(name, price));
        }

        public void Display()
        {
            Console.WriteLine($"Товар: {Name}");

            for (int i = 0; i < Stores.Count; i++)
            {
                Console.WriteLine(Stores[i]);
            }
        }
    }
}
