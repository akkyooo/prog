using LabApp10.task2.details;
using LabApp10.task3.details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp10.task3
{
    internal static class Task3Launcher
    {
        public static void Run()
        {
            Random random = new Random();
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 100);
            }
            Console.WriteLine("Array:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine($"Multiples of 7: {ArrayUtils.CountDivBy7(numbers)}");
            Console.WriteLine($"Positive numbers: {ArrayUtils.CountPositive(numbers)}");

            DateTime date = DateTime.Now;
            Console.WriteLine($"Date: {date.ToShortDateString()}");
            Console.WriteLine($"Is today Programmer's Day? {DateUtils.IsProgrammerDay(date)}");

            string text = "C# is a powerful programming language.";
            string[] words = { "programming language", "code", "java" };

            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Any coincidences? {TextUtils.ContainsWords(text, words)}");
        }
    }
}  
