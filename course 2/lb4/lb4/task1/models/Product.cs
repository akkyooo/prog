using System;
using System.Collections.Generic;
using System.Text;

namespace lb4.task1.models
{
    public class Product
    {
        public string Name { get; set; }

        public List<StorePrice> Stores { get; set; }

        public Product()
        {
            Name = "";
            Stores = new List<StorePrice>();
        }

        public Product(string name, List<StorePrice> stores)
        {
            Name = name;
            Stores = stores;
        }
    }
}

