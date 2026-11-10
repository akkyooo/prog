using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace lb1.task2.items
{
    internal class TextAnalyzer
    {
        public Dictionary<string, int> Analyze(string fileName)
        {
            string text = File.ReadAllText(fileName);
            string[] words = Regex.Split(text.ToLower(), @"[^\p{L}\p{Nd}]+");

            Dictionary<string, int> statistics = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (word.Length == 0)
                    continue;

                if (statistics.ContainsKey(word))
                    statistics[word]++;
                else
                    statistics.Add(word, 1);
            }

            return statistics;
        }

        public void Display(Dictionary<string, int> statistics)
        {
            foreach (KeyValuePair<string, int> item in statistics)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

        public void Save(Dictionary<string, int> statistics, string outputFile)
        {
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (KeyValuePair<string, int> item in statistics)
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }

            Console.WriteLine("Статистику збережено у файл.");
        }
    }
}

