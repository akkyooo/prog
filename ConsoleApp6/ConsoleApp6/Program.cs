using LabApp6.objects;
using LabApp6;
using LabApp6.enums;
using System.Xml.Serialization;

namespace LabApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Ivan", "Petrov", new DateTime(1980, 5, 10));
            Person p2 = new Person("Oleg", "Sidorov", new DateTime(1975, 3, 15));

            Detail d1 = new Detail(p1, "Wheel", 15);
            Detail d2 = new Detail(p2, "Engine", 250);
            Detail d3 = new Detail(p1, "Fender", 40);

            Transport t1 = new Transport();

            Console.WriteLine("SHORT INFO:");
            Console.WriteLine(t1.ToShortString());
            Console.WriteLine("\nINDEXATOR:");
            Console.WriteLine(string.Join(", ", t1[TransportType.Ground], t1[TransportType.Air], t1[TransportType.Water]));

            t1 = new Transport ("Car", TransportType.Ground, new DateTime(2026, 5, 17), 50000, [d1, d2]);

            Console.WriteLine("\nFULL INFO:");
            Console.WriteLine(t1);

            t1.AddDetails(d3);

            Console.WriteLine("\nAFTER ADDING DETAILS:");
            Console.WriteLine(t1);

            Transport t2 = new Transport ("Boeing", TransportType.Air, new DateTime(2026, 5, 16), 1000000, [d2, d3]);
            Transport t3 = new Transport("Boat", TransportType.Water, new DateTime(2026, 5, 15), 200000, [d1, d3]);
            Transport[] transports = { t1, t2, t3 };

            Console.WriteLine("\nLIST OF TRANSPORT DETAILS:\n");

            foreach (Transport t in transports)
            {
                Console.WriteLine(t.TransportName);
                foreach (Detail d in t.Details)
                {
                    Console.WriteLine(d.Description);
                }
                Console.WriteLine();
            }

            Console.WriteLine("COMMON DETAILS:");

            var commonDetails =
                transports[0].Details
                .Select(x => x.Description)
                .Intersect(transports[1].Details.Select(x => x.Description))
                .Intersect(transports[2].Details.Select(x => x.Description));

            foreach (var item in commonDetails)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
