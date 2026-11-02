using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task3.items
{
    internal class Song
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Composer { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string[] Performers { get; set; }

        public Song(string title, string author, string composer,
            int year, string text, string[] performers)
        {
            Title = title;
            Author = author;
            Composer = composer;
            Year = year;
            Text = text;
            Performers = performers;
        }

        public void Display()
        {
            System.Console.WriteLine("\nНазва: " + Title);
            System.Console.WriteLine("Автор: " + Author);
            System.Console.WriteLine("Композитор: " + Composer);
            System.Console.WriteLine("Рік написання: " + Year);
            System.Console.WriteLine("Текст пісні:\n" + Text);
            System.Console.WriteLine("Виконавці: " + string.Join(", ", Performers));
        }
    }
}

