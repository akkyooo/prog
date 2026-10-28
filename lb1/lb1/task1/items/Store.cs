using System;
using System.Collections.Generic;
using System.Text;

namespace lb1.task1.models
{
    internal class Store
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Store(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price} грн";
        }
    }
}
