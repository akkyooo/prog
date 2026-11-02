using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task3.items
{
    internal class SongSearch
    {
        private List<Song> songs;

        public SongSearch(List<Song> songs)
        {
            this.songs = songs;
        }

        public void Search(string characteristic, string value)
        {
            bool found = false;

            foreach (Song song in songs)
            {
                bool match = false;

                switch (characteristic)
                {
                    case "1":
                        match = song.Title.IndexOf(value,
                            StringComparison.OrdinalIgnoreCase) >= 0;
                        break;

                    case "2":
                        match = song.Author.IndexOf(value,
                            StringComparison.OrdinalIgnoreCase) >= 0;
                        break;

                    case "3":
                        match = song.Composer.IndexOf(value,
                            StringComparison.OrdinalIgnoreCase) >= 0;
                        break;

                    case "4":
                        match = song.Year.ToString() == value;
                        break;

                    case "5":
                        foreach (string performer in song.Performers)
                        {
                            if (performer.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                match = true;
                                break;
                            }
                        }
                        break;
                }

                if (match)
                {
                    song.Display();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("Пісень не знайдено!");
        }

        public void DisplayByPerformer(string performerName)
        {
            bool found = false;

            foreach (Song song in songs)
            {
                foreach (string performer in song.Performers)
                {
                    if (performer.Equals(performerName, StringComparison.OrdinalIgnoreCase))
                    {
                        song.Display();
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
                Console.WriteLine("Пісень цього виконавця не знайдено!");
        }
    }
}

