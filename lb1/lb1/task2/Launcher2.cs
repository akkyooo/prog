using lb1.task2.items;
using System;
using System.Collections.Generic;
using System.Text;
using lb1.task2.items;

namespace lb1.task2
{
    public static class Launcher2
    {
        public static void Run()
        {
            string folder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Task2", "files"));

            string listFile = Path.Combine(folder, "firstFile.txt");

            if (!File.Exists(listFile))
            {
                Console.WriteLine("Файл firstFile не знайдено.");
                Console.WriteLine("Перевірте шлях: " + listFile);
                return;
            }

            string[] files = File.ReadAllLines(listFile);
            List<string> filePaths = new List<string>();

            foreach (string file in files)
            {
                if (!string.IsNullOrWhiteSpace(file))
                {
                    filePaths.Add(Path.Combine(folder, file.Trim()));
                }
            }

            TextAnalyzer analyzer = new TextAnalyzer();
            bool repeat = true;

            while (repeat)
            {
                Console.WriteLine("\nСписок файлів:");

                for (int i = 0; i < filePaths.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {Path.GetFileName(filePaths[i])}");
                }

                if (filePaths.Count == 0)
                {
                    Console.WriteLine("Список файлів порожній.");
                    return;
                }

                Console.Write("\nОберіть номер файлу: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) ||
                    choice < 1 || choice > filePaths.Count)
                {
                    Console.WriteLine("Неправильний номер файлу.");
                    continue;
                }

                string fileName = filePaths[choice - 1];

                if (!File.Exists(fileName))
                {
                    Console.WriteLine("Файл не знайдено: " + fileName);
                    continue;
                }

                try
                {
                    Dictionary<string, int> statistics =
                        analyzer.Analyze(fileName);

                    Console.WriteLine("\nСтатистика слів:\n");
                    analyzer.Display(statistics);

                    Console.Write("\nЗберегти статистику у файл? (так/ні): ");
                    string answer = (Console.ReadLine() ?? "").Trim().ToLower();

                    if (answer == "так")
                    {
                        Console.Write("Введіть назву вихідного файлу: ");
                        string outputFile = (Console.ReadLine() ?? "").Trim();

                        if (!string.IsNullOrWhiteSpace(outputFile))
                        {
                            if (!Path.HasExtension(outputFile))
                            {
                                outputFile += ".txt";
                            }

                            outputFile = Path.Combine(folder, outputFile);

                            analyzer.Save(statistics, outputFile);
                        }
                        else
                        {
                            Console.WriteLine("Назву файлу не введено.");
                        }
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("Помилка читання або запису файлу.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Немає доступу до файлу.");
                }

                Console.Write("\nПроаналізувати інший файл? (так/ні): ");
                repeat = (Console.ReadLine() ?? "").Trim().ToLower() == "так";
            }

            Console.WriteLine("\nРоботу завершено.");
        }

    }
}
    
