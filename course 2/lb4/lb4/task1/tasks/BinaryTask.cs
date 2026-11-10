using lb4.task1.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb4.task1.tasks
{
    internal class BinaryTask
    {
        public static void Serialize(Product[] products, string file)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(file)))
            {
                writer.Write(products.Length);

                foreach (Product product in products)
                {
                    writer.Write(product.Name);
                    writer.Write(product.Stores.Count);

                    foreach (StorePrice store in product.Stores)
                    {
                        writer.Write(store.StoreName);
                        writer.Write(store.Price);
                    }
                }
            }

            Console.WriteLine("Бінарна серіалізація виконана.");
        }

        public static Product[] Deserialize(string file)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(file)))
            {
                int count = reader.ReadInt32();
                Product[] products = new Product[count];

                for (int i = 0; i < count; i++)
                {
                    string name = reader.ReadString();
                    int storeCount = reader.ReadInt32();

                    List<StorePrice> stores = new List<StorePrice>();

                    for (int j = 0; j < storeCount; j++)
                    {
                        string storeName = reader.ReadString();
                        decimal price = reader.ReadDecimal();

                        stores.Add(new StorePrice(storeName, price));
                    }

                    products[i] = new Product(name, stores);
                }

                return products;

            }
        }
    }
}
