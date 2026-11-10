using lb1.task3.items;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb1.task3
{
    public static class Launcher3
    {
        public static void Run()
        {
            PrinterQueue printer = new PrinterQueue();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nЧЕРГА ДРУКУ ПРИНТЕРА");
                Console.WriteLine("1. Додати запит на друк");
                Console.WriteLine("2. Переглянути чергу");
                Console.WriteLine("3. Надрукувати наступний документ");
                Console.WriteLine("4. Переглянути статистику");
                Console.WriteLine("5. Зберегти статистику у файл");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        Console.Write("Користувач: ");
                        string user = Console.ReadLine() ?? "";

                        Console.Write("Назва документа: ");
                        string document = Console.ReadLine() ?? "";

                        Console.Write("Пріоритет (1 - низький, 2 - середній, 3 - високий): ");

                        if (int.TryParse(Console.ReadLine(), out int priority)
                            && priority >= 1 && priority <= 3
                            && !string.IsNullOrWhiteSpace(user)
                            && !string.IsNullOrWhiteSpace(document))
                        {
                            printer.AddJob(new PrintJob(user, document, priority));
                        }
                        else
                        {
                            Console.WriteLine("Неправильно введені дані.");
                        }
                        break;

                    case "2":
                        printer.DisplayQueue();
                        break;

                    case "3":
                        printer.PrintNext();
                        break;

                    case "4":
                        printer.DisplayStatistics();
                        break;

                    case "5":
                        Console.Write("Назва файлу: ");
                        string fileName = Console.ReadLine() ?? "";

                        if (!string.IsNullOrWhiteSpace(fileName))
                        {
                            try
                            {
                                printer.SaveStatistics(fileName);
                            }
                            catch (IOException)
                            {
                                Console.WriteLine("Помилка запису у файл.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Не введено назву файлу.");
                        }
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Невірний пункт меню.");
                        break;
                }
            }
        }
    }
}
