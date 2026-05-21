using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Zoo
{
    public class ZooManager
    {
        private List<Animal> _animals = new List<Animal>();
        public string ZooName {get; set;}
        public ZooManager(string zooName)
        {
            ZooName = zooName;
        }
        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }
        public void PrintAllAnimals()
        {
            Console.WriteLine($"\nЗоопарк: {ZooName}");
            Console.WriteLine("Список тварин");

            foreach (var animal in _animals)
            {
                Console.WriteLine(animal);
                animal.Print();
                animal.LiveInfo();
                Console.WriteLine(" ");
            }
        }
        public void PrintSpeciesCount()
        {
            Console.WriteLine("\nКількість тварин по видах");
            var groups = _animals.GroupBy(a => a.GetType().Name);
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
        }
        public void PrintMonthlyFoodNeeds()
        {
            Console.WriteLine("\nКорм на місяць");

            double total = 0;

            foreach (var animal in _animals)
            {
                double food = animal.MonthlyFood();
                total += food;

                Console.WriteLine($"{animal.GetType().Name} ({animal.ToString()}) → {food:F2} кг/міс");
            }
            Console.WriteLine(" ");
            Console.WriteLine($"ЗАГАЛЬНО по зоопарку: {total:F2} кг/міс");
        }
    }
}
