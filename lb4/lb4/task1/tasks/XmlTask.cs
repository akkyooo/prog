using lb4.task1.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace lb4.task1.tasks
{
    internal class XmlTask
    {
        public static void Serialize(Product[] products, string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Product[]));

            using (FileStream stream = File.Create(file))
            {
                serializer.Serialize(stream, products);
            }

            Console.WriteLine("XML серіалізація виконана.");
        }

        public static Product[] Deserialize(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Product[]));

            using (FileStream stream = File.OpenRead(file))
            {
                return (Product[])serializer.Deserialize(stream)!;
            }
        }
    }
}

