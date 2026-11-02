using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task3.items
{
    internal class SongCollection
    {
        private List<Song> songs = new List<Song>();

        public List<Song> Songs
        {
            get { return songs; }
        }

        public void Add(Song song)
        {
            songs.Add(song);
            Console.WriteLine("Пісню додано!");
        }

        public void Remove(string title)
        {
            for (int i = 0; i < songs.Count; i++)
            {
                if (songs[i].Title.Equals(title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    songs.RemoveAt(i);
                    Console.WriteLine("Пісню видалено!");
                    return;
                }
            }

            Console.WriteLine("Пісню не знайдено!");
        }

        public void Edit(int index, Song song)
        {
            if (index >= 0 && index < songs.Count)
            {
                songs[index] = song;
                Console.WriteLine("Інформацію змінено!");
            }
            else
            {
                Console.WriteLine("Неправильний номер пісні!");
            }
        }

        public void DisplayAll()
        {
            if (songs.Count == 0)
            {
                Console.WriteLine("Колекція порожня!");
                return;
            }

            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine("\nПісня №" + (i + 1));
                songs[i].Display();
            }
        }
    }
}
