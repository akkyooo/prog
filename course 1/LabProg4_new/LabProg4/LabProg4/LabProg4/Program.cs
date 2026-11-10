using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProg4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int task = -1;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            do
            {
                Console.Clear();//винесла очістку консолі на початок циклу та видалили непотрібні звернення до цього методу нище
                Console.WriteLine("Вибери Завдання:\n 1 - Завдання 1\n 2 - Завдання 2\n 3 - Завдання 3\n 0 - Вихід");
                if (!int.TryParse(Console.ReadLine(), out task))
                {
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    continue;
                }
                if (task == 0)
                {
                    Console.WriteLine("Вихід з програми. До побачення!");
                    break;
                }

                switch (task)
                {
                    case 1:
                       
                        Tasks.Task1();
                        break;
                    case 2:
                       
                        Tasks.Task2();
                        break;
                    case 3:
                        
                        Tasks.Task3();
                        break;
                    case 4:
                        Console.WriteLine("Відмова від виконання.");
                        break;
                    default:
                        Console.WriteLine("Невірний ввід. Введіть число від 1 до 5.");
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
                Console.ReadKey();
            
            } while (task != 4);
        }
    }
}

