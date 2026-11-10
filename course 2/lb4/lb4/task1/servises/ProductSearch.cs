using lb4.task1.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb4.task1.servises
{
    internal class ProductSearch
    {
        public static void FindProduct(List<Product> products)
        {
            Console.Write("\nВведіть назву товару: ");
            string name = Console.ReadLine();

            Console.Write("Введіть максимальну ціну: ");
            decimal maxPrice = decimal.Parse(Console.ReadLine());

            bool found = false;

            foreach (Product product in products)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (StorePrice store in product.Stores)
                    {
                        if (store.Price <= maxPrice)
                        {
                            Console.WriteLine($"{store.StoreName} - {store.Price} грн");
                            found = true;
                        }
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Товар за вказаною ціною не знайдено.");
            }
        }
    }
}
