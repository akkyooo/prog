using lb4.task1.tasks;
using lb4.task1.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lb4.task1.servises;

namespace lb4.task1
{
    public static class Launcher
    {
        public static void Run()
        {
            Product[] products = ProductData.CreateProducts();

            BinaryTask.Serialize(products, "products.bin");
            JsonTask.Serialize(products, "products.json");
            XmlTask.Serialize(products, "products.xml");

            Product[] binaryProducts = BinaryTask.Deserialize("products.bin");
            Product[] jsonProducts = JsonTask.Deserialize("products.json");
            Product[] xmlProducts = XmlTask.Deserialize("products.xml");

            Console.WriteLine("\nРезультат десеріалізації:");
            Console.WriteLine($"Binary: {binaryProducts.Length} товарів");
            Console.WriteLine($"JSON: {jsonProducts.Length} товарів");
            Console.WriteLine($"XML: {xmlProducts.Length} товарів");

            ProductSearch.FindProduct(jsonProducts.ToList());
        }
    }
}