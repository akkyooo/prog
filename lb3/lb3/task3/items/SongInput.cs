using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task3.items
{
    internal class SongInput
    {
        public static Song CreateSong()
        {
            Console.Write("Назва пісні: ");
            string title = Console.ReadLine();

            Console.Write("П.І.Б. автора: ");
            string author = Console.ReadLine();

            Console.Write("Композитор: ");
            string composer = Console.ReadLine();

            Console.Write("Рік написання: ");
            int year;

            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Введіть правильний рік: ");
            }

            Console.Write("Текст пісні: ");
            string text = Console.ReadLine();

            Console.Write("Виконавці: ");
            string performersText = Console.ReadLine();
            string[] performers = performersText.Split(',');

            for (int i = 0; i < performers.Length; i++)
            {
                performers[i] = performers[i].Trim();
            }

            return new Song(title, author, composer, year, text, performers);
        }
    }
}
