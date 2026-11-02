using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task2
{
    internal class Censor
    {
        public void Process(string textPath, string wordsPath)
        {
            if (!File.Exists(textPath) || !File.Exists(wordsPath))
            {
                Console.WriteLine("Один із файлів не знайдено!");
                return;
            }

            string text = File.ReadAllText(textPath);
            string[] badWords = File.ReadAllLines(wordsPath);

            foreach (string word in badWords)
            {
                string badWord = word.Trim();

                if (badWord.Length > 0)
                {
                    string replacement = new string('*', badWord.Length);

                    text = System.Text.RegularExpressions.Regex.Replace(
                        text,
                        System.Text.RegularExpressions.Regex.Escape(badWord),
                        replacement,
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase
                    );
                }
            }

            Console.WriteLine("\nРезультат цензурування:");
            Console.WriteLine(text);
        }
    }
}
