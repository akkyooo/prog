using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApp8.task1;
using LabApp8.task2; 
using LabApp8.task3;

namespace LabApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int task;
            do
            {
                Console.Clear();
                Console.WriteLine("Вибери Завдання:\n 1 - Завдання 1\n 2 - Завдання 2\n 3 - Завдання 3\n 4 - Вихід");

                if (!int.TryParse(Console.ReadLine(), out task)) continue;

                switch (task)
                {
                    case 1:
                        Task1Launcher.Run();
                        break;

                    case 2:
                        Task2Launcher.Run();
                        break;

                    case 3:
                        Task3Launcher.Run();
                        break;

                    case 4:
                        Console.WriteLine("Вихід");
                        break;

                    default:
                        Console.WriteLine("Невірний ввід");
                        break;
                }
                if (task != 4)
                {
                    Console.WriteLine("Натисніть будь-яку клавішу...");
                    Console.ReadKey();
                }
            } while (task != 4);
        }
    }
}
