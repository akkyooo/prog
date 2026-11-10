using System;
using System.Collections.Generic;
using System.Text;

namespace lb1.task1.models
{
    internal class ProductCatalog
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Товар додано.");
        }

        public void DisplayAll()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Список товарів порожній.");
                return;
            }

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"\nІндекс товару: {i}");
                products[i].Display();
            }
        }

        public void RemoveProduct(int index)
        {
            if (index >= 0 && index < products.Count)
            {
                products.RemoveAt(index);
                Console.WriteLine("Товар видалено.");
            }
            else
            {
                Console.WriteLine("Неправильний індекс.");
            }
        }

        public void EditProduct(int index, string newName)
        {
            if (index >= 0 && index < products.Count)
            {
                products[index].Name = newName;
                Console.WriteLine("Назву товару змінено.");
            }
            else
            {
                Console.WriteLine("Неправильний індекс.");
            }
        }

        public void FindStores(string productName, double maxPrice)
        {
            bool found = false;

            for (int i = 0; i < products.Count; i++)
            {
                if (string.Equals(
                    products[i].Name,
                    productName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = 0; j < products[i].Stores.Count; j++)
                    {
                        Store store = products[i].Stores[j];

                        if (store.Price <= maxPrice)
                        {
                            Console.WriteLine(store);
                            found = true;
                        }
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Відповідних магазинів не знайдено.");
            }
        }
    }
}

