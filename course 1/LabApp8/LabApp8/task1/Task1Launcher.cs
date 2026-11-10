using LabApp8.task1.models;

namespace LabApp8.task1
{

    public static class Task1Launcher
    {
        public static void Run() 
        {
            {
                Detail d1 = new Detail(new Person("Ivan", "Petrenko", new DateTime(1990, 1, 1)), "Engine", 120);
                Detail d2 = new Detail(new Person("Oleg", "Ivanov", new DateTime(1985, 5, 5)), "Wheel", 30);
                Detail d3 = new Detail(new Person("Anna", "Sydorenko", new DateTime(1995, 7, 7)), "Door", 50);

                Transport transport = new Transport();
                transport.Add(d1);
                transport.Add(d2);
                transport.Add(d3);
                Console.WriteLine("Before sorting:\n");

                foreach (Detail d in transport)
                {
                    Console.WriteLine(d);
                }
                transport.Sort();
                Console.WriteLine("\nAfter sorting:\n");

                foreach (Detail d in transport)
                {
                    Console.WriteLine(d);
                }
                transport.Save("transport.txt");
                Console.WriteLine("\nSaved to file.");

                Transport newTransport = new Transport();
                newTransport.Add((Detail)transport[0].Clone());
                newTransport.Add((Detail)transport[1].Clone());
                Console.WriteLine("\nNew container:\n");

                foreach (Detail d in newTransport)
                {
                    Console.WriteLine(d);
                }
                newTransport.Save("newtransport.txt");
                Console.WriteLine("\nNew container saved.");
            }
        }
    }
}
 

