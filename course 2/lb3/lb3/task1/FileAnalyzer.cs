using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task1
{
    internal class FileAnalyzer
    {
        public void Analyze(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено!");
                return;
            }

            string text = File.ReadAllText(filePath);

            int sentences = 0;
            int upperLetters = 0;
            int lowerLetters = 0;
            int vowels = 0;
            int consonants = 0;
            int digits = 0;

            string vowelLetters = "аеєиіїоуюяАЕЄИІЇОУЮЯ";

            foreach (char symbol in text)
            {
                if (symbol == '.' || symbol == '!' || symbol == '?')
                    sentences++;

                if (char.IsUpper(symbol))
                    upperLetters++;

                if (char.IsLower(symbol))
                    lowerLetters++;

                if (char.IsDigit(symbol))
                    digits++;

                if (char.IsLetter(symbol))
                {
                    if (vowelLetters.Contains(symbol))
                        vowels++;
                    else
                        consonants++;
                }
            }

            Console.WriteLine("\nСтатистика файлу:");
            Console.WriteLine("Кількість речень: " + sentences);
            Console.WriteLine("Кількість великих літер: " + upperLetters);
            Console.WriteLine("Кількість маленьких літер: " + lowerLetters);
            Console.WriteLine("Кількість голосних літер: " + vowels);
            Console.WriteLine("Кількість приголосних літер: " + consonants);
            Console.WriteLine("Кількість цифр: " + digits);
        }
    }
}
