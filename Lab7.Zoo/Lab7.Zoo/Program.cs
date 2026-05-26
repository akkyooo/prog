using Lab7.Zoo;
using Lab7.Zoo.enums;
using Lab7.Zoo.Animals;

namespace Lab7.Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ZooManager zoo = ZooFactory.CreateZoo();

            zoo.PrintAllAnimals();
            zoo.PrintSpeciesCount();
            zoo.PrintMonthlyFoodNeeds();

            Console.ReadKey();
        }
    }
}
