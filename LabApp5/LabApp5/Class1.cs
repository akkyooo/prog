using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace LabApp5
{
    internal class Tasks
    {
        public static void Task1()
        {
            Console.Write("Введіть рядок: ");
            string input = Console.ReadLine();
            Console.Write("Введіть зсув k: ");
            int n = int.Parse(Console.ReadLine());
            string encrypted = Encrypt(input, n);
            Console.WriteLine("Зашифрований рядок: " + encrypted);
            string decrypted = Decrypt(encrypted, n);
            Console.WriteLine("Розшифрований рядок: " + decrypted);

            Console.ReadKey();
        }
        static string Encrypt(string text, int shift)
        {
            StringBuilder sb = new StringBuilder();
            Regex regex = new Regex(@"[A-Za-z]");

            foreach (char c in text)
            {
                if (regex.IsMatch(c.ToString()))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int newChar = (c - offset + shift) % 26;
                    if (newChar < 0)
                        newChar += 26;
                    sb.Append((char)(newChar + offset));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        static string Decrypt(string text, int shift)
        {
            StringBuilder sb = new StringBuilder();
            Regex regex = new Regex(@"[A-Za-z]");
            foreach (char c in text)
            {
                if (regex.IsMatch(c.ToString()))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int newChar = (c - offset - shift) % 26;
                    if (newChar < 0)
                        newChar += 26;
                    sb.Append((char)(newChar + offset));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public static void Task2()
        {
            string input = "";
            Console.WriteLine("Звідки взяти текст?");
            Console.WriteLine("1-Клавіатура, 2-текст");
            Console.Write("Ваш вибір: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Введіть текст: ");
                        input = Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        input = "А роза упала на лапу Азора";
                        break;
                    }
                default:
                    Console.WriteLine("Невірний вибір");
                    return;          
            }
            StringBuilder cleanedBuilder = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                    cleanedBuilder.Append(char.ToLower(c));
            }
            string cleaned = cleanedBuilder.ToString();
            bool isPalindrome = true;

            for (int i = 0; i < cleaned.Length / 2; i++)
            {
                if (cleaned[i] != cleaned[cleaned.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            Console.WriteLine("Оригінал: " + input);
            Console.WriteLine("Очищений: " + cleaned);
            if (isPalindrome)
                Console.WriteLine("Результат: Це паліндром");
            else
                Console.WriteLine("Результат: Це НЕ паліндром");

            Console.WriteLine();
        }

    }
}


