using lb4.task1.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace lb4.task1.tasks
{
    internal class JsonTask
    {
        public static void Serialize(Product[] products, string file)
        {
            string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(file, json);
            Console.WriteLine("JSON серіалізація виконана.");
        }

        public static Product[] Deserialize(string file)
        {
            string json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<Product[]>(json)!;
        }
    }
}
