using Lab7.Zoo.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Zoo
{
    public class ZooManager
    {
        public const int MAX_ANIMALS = 10;
        private Animal[] animals;
        private int count;
        public string ZooName {get; set;}

        public ZooManager(string zooName)
        {
            ZooName = zooName;
            animals = new Animal[MAX_ANIMALS];
            count = 0;
        }

        public void AddAnimal(Animal animal)
        {
            if (count >= MAX_ANIMALS)
            {
                Console.WriteLine("Зоопарк переповнений");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                if (!animals[i].CanLiveWith(animal))
                {
                    Console.WriteLine(
                        $"{animal.Name} не може жити з {animals[i].Name}");
                    return;
                }
            }

            animals[count] = animal;
            count++;
            Console.WriteLine($"{animal.Name} доданий у зоопарк");
        }

        public void PrintAllAnimals()
        {
            Console.WriteLine($"\nЗоопарк: {ZooName}");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine(animals[i].ToString());
                Console.WriteLine(animals[i].Print());
                Console.WriteLine(animals[i].LiveInfo());
                Console.WriteLine(" ");
            }
        }

        public void PrintSpeciesCount()
        {
            int tigers = 0;
            int crocodiles = 0;
            int kangaroos = 0;

            for (int i = 0; i < count; i++)
            {
                if (animals[i] is Tiger)
                    tigers++;
                else if (animals[i] is Crocodile)
                    crocodiles++;
                else if (animals[i] is Kangaroo)
                    kangaroos++;
            }

            Console.WriteLine("\nКількість тварин:");
            Console.WriteLine($"Тигри: {tigers}");
            Console.WriteLine($"Крокодили: {crocodiles}");
            Console.WriteLine($"Кенгуру: {kangaroos}");
        }

        public void PrintMonthlyFoodNeeds()
        {
            double total = 0;
            Console.WriteLine("\nКорм на місяць:");
            for (int i = 0; i < count; i++)
            {
                double food = animals[i].MonthlyFood();
                total += food;
                Console.WriteLine($"{animals[i].Name} -> {food:F2} кг");
            }
            Console.WriteLine($"\nЗагалом для зоопарку: {total:F2} кг");
        }
    }
}
