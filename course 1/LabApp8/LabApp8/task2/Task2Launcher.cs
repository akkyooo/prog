using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApp8.task2.transports;
using LabApp8.task2.interfaces;

namespace LabApp8.task2
{
    public static class Task2Launcher
    {
        public static void Run()
        {
            {
                Registry registry = new Registry();

                registry.Add(new Airplane("Boeing", 10000, 5000, "Jet"));
                registry.Add(new Helicopter("Apache", 5000, 3000, "Diesel"));
                registry.Add(new Balloon("Red Balloon", 200));
                registry.Add(new HangGlider("SkyWing", 80));
                registry.Add(new FlyingCarpet("Magic Carpet", 20));

                Console.WriteLine("ALL DEVICES:\n");
                registry.ShowAll();

                Console.WriteLine("\nDEVICES WITH ENGINE:\n");
                registry.ShowByEngine(true);

                Console.WriteLine("\nDEVICES WITHOUT ENGINE:\n");
                registry.ShowByEngine(false);

                Console.WriteLine("\nSORT BY WEIGHT:\n");
                registry.SortByWeight();
                registry.ShowAll();

                Console.WriteLine("\nSORT BY NAME:\n");
                registry.SortByName();
                registry.ShowAll();

                Console.WriteLine("\nCLONE TEST:\n");
                Airplane original = new Airplane("F16", 8000, 4000, "Jet");
                Airplane copy = (Airplane)original.Clone();

                Console.WriteLine("Original:");
                Console.WriteLine(original);

                Console.WriteLine("\nCopy:");
                Console.WriteLine(copy);
            }
        }
    }
}
