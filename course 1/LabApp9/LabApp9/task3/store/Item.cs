using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp9.task3.store
{
    internal struct Item
    {
        public string Name;
        public int Quantity;
        public double Price;
        public ItemCategory Category;
        public void Print()
        {
            Console.WriteLine($"{Name} | {Category} | {Quantity} | {Price}");
        }
    }
}

