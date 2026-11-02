using System;
using System.Collections.Generic;
using System.Text;

namespace lb4.task1.models
{
    public class StorePrice
    {
        public string StoreName { get; set; }

        public decimal Price { get; set; }

        public StorePrice()
        {
            StoreName = "";
            Price = 0;
        }

        public StorePrice(string storeName, decimal price)
        {
            StoreName = storeName;
            Price = price;
        }
    }
}
