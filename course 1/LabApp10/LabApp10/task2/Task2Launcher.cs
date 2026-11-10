using LabApp10.task2.details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApp10;

namespace LabApp10.task2
{
    internal static class Task2Launcher
    {
        public static void Run()
        {
            Suitcase suitcase = new Suitcase("Black", "Adidas", 10, 5);
            SuitcaseService service = new SuitcaseService();

            suitcase.ItemAdded += (item) => Console.WriteLine($"Added: {item.Name}, volume = {item.Volume}");
          
            try
            {
                service.AddItem(suitcase, new SuitcaseItem("Laptop", 2, 4));
                service.AddItem(suitcase, new SuitcaseItem("Book", 1, 3));
                service.AddItem(suitcase, new SuitcaseItem("Shoes", 2, 5)); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

        }
    }
}
