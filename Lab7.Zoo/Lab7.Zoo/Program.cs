using Lab7.Zoo;
using Lab7.Zoo.enums;
using Lab7.Zoo.Animals;

namespace Lab7.Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("ЗАСЕЛЕННЯ ЗООПАРКУ\n");

            var zoo = new ZooManager("Дивосвіт");
            var tigerM = new Tiger("Раджа", 7, 220, "Male", "Амурський", false, 4);
            var tigerF = new Tiger("Зара", 5, 155, "Female", "Бенгальський", false, 3);
            var albino = new Tiger("Сніг", 3, 130, "Male", "Бенгальський", true, 2);

            var croc1 = new Crocodile("Боло", 15, 350, "Male", 4.2, 66, CrocodileHabitat.Freshwater);
            var croc2 = new Crocodile("Неро", 10, 280, "Male", 3.7, 64, CrocodileHabitat.Both);
            var croc3 = new Crocodile("Лея", 8, 200, "Female", 3.1, 60, CrocodileHabitat.Freshwater);

            var kang1 = new Kangaroo("Бумер", 4, 85, "Male", 2.5, 9.0);
            var kang2 = new Kangaroo("Дейзі", 3, 60, "Female", 2.0, 7.5);
            var kang3 = new Kangaroo("Скіп", 6, 72, "Male", 2.3, 8.5);

            zoo.AddAnimal(tigerM);
            zoo.AddAnimal(tigerF);
            zoo.AddAnimal(albino);

            zoo.AddAnimal(croc1);
            zoo.AddAnimal(croc2);
            zoo.AddAnimal(croc3);

            zoo.AddAnimal(kang1);
            zoo.AddAnimal(kang2);
            zoo.AddAnimal(kang3);

            Console.WriteLine("\nТЕСТ МЕТОДІВ");

            Console.WriteLine($"{kang1.Name}");
            Console.WriteLine($"{croc1.Name}");
            Console.WriteLine($"{tigerM.Name}");
            kang3.HasJoey = false;
            Console.WriteLine($"\n{kang3.Name} має малюка: {kang3.HasJoey}");

            Console.WriteLine("\nOBJECT МЕТОДИ");

            var tigerCopy = new Tiger("Раджа", 7, 220, "Male", "Амурський", false, 4);

            Console.WriteLine(tigerM.ToString());
            Console.WriteLine($"Equals: {tigerM.Equals(tigerCopy)}");
            Console.WriteLine($"Hash1: {tigerM.GetHashCode()}");
            Console.WriteLine($"Hash2: {tigerCopy.GetHashCode()}");

            Console.WriteLine("\nВСІ ТВАРИНИ");
            zoo.PrintAllAnimals();
            Console.WriteLine("\nКІЛЬКІСТЬ ВИДІВ");
            zoo.PrintSpeciesCount();
            Console.WriteLine("\nКОРМ НА МІСЯЦЬ");
            zoo.PrintMonthlyFoodNeeds();
        }
    }
}
