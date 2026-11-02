using lb3.task3.items;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task3
{
    internal static class Launcher3
    {
        public static void Run()
        {
            SongCollection collection = new SongCollection();
            SongSearch search = new SongSearch(collection.Songs);
            SongFileManager fileManager = new SongFileManager();

            while (true)
            {
                Console.WriteLine("\nКОЛЕКЦІЯ ПІСЕНЬ");
                Console.WriteLine("1. Додати пісню");
                Console.WriteLine("2. Видалити пісню");
                Console.WriteLine("3. Змінити інформацію про пісню");
                Console.WriteLine("4. Пошук пісні");
                Console.WriteLine("5. Вивести всі пісні");
                Console.WriteLine("6. Вивести пісні за виконавцем");
                Console.WriteLine("7. Зберегти колекцію у файл");
                Console.WriteLine("8. Завантажити колекцію з файлу");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        collection.Add(SongInput.CreateSong());
                        break;

                    case "2":
                        Console.Write("Введіть назву пісні: ");
                        collection.Remove(Console.ReadLine());
                        break;

                    case "3":
                        collection.DisplayAll();

                        Console.Write("Введіть номер пісні: ");
                        int index;

                        if (int.TryParse(Console.ReadLine(), out index))
                        {
                            collection.Edit(index - 1,
                                SongInput.CreateSong());
                        }
                        else
                        {
                            Console.WriteLine("Неправильний номер!");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nПошук за:");
                        Console.WriteLine("1. Назвою");
                        Console.WriteLine("2. Автором");
                        Console.WriteLine("3. Композитором");
                        Console.WriteLine("4. Роком написання");
                        Console.WriteLine("5. Виконавцем");
                        Console.Write("Оберіть характеристику: ");
                        string characteristic = Console.ReadLine();

                        if (characteristic == "1" ||
                            characteristic == "2" ||
                            characteristic == "3" ||
                            characteristic == "4" ||
                            characteristic == "5")
                        {
                            Console.Write("Введіть значення: ");
                            string value = Console.ReadLine();

                            search.Search(characteristic, value);
                        }
                        else
                        {
                            Console.WriteLine("Неправильний вибір!");
                        }
                        break;

                    case "5":
                        collection.DisplayAll();
                        break;

                    case "6":
                        Console.Write("Введіть ім'я виконавця: ");
                        search.DisplayByPerformer(Console.ReadLine());
                        break;

                    case "7":
                        Console.Write("Введіть шлях до файлу: ");
                        fileManager.Save(collection, Console.ReadLine());
                        break;

                    case "8":
                        Console.Write("Введіть шлях до файлу: ");
                        fileManager.Load(collection, Console.ReadLine());
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неправильний вибір!");
                        break;
                }
            }
        }
    }
}
