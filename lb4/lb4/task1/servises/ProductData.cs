using lb4.task1.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb4.task1.servises
{
    internal class ProductData
    {
        public static Product[] CreateProducts()
        {
            Product[] products =
            {
                new Product("Ноутбук", new List<StorePrice>
                {
                    new StorePrice("Rozetka", 25000),
                    new StorePrice("Comfy", 27000),
                    new StorePrice("Foxtrot", 24500)
                }),

                new Product("Телефон", new List<StorePrice>
                {
                    new StorePrice("Rozetka", 12000),
                    new StorePrice("Comfy", 11500),
                    new StorePrice("Foxtrot", 13000)
                }),

                new Product("Навушники", new List<StorePrice>
                {
                    new StorePrice("Rozetka", 2000),
                    new StorePrice("Comfy", 1800),
                    new StorePrice("Foxtrot", 2200)
                }),

                new Product("Монітор", new List<StorePrice>
                {
                    new StorePrice("Rozetka", 8000),
                    new StorePrice("Comfy", 8500),
                    new StorePrice("Foxtrot", 7800)
                })
            };

            return products;
        }
    }
}
