using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task3.items
{
    internal class SongFileManager
    {
        public void Save(SongCollection collection, string filePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(collection.Songs.Count);

                foreach (Song song in collection.Songs)
                {
                    writer.Write(song.Title);
                    writer.Write(song.Author);
                    writer.Write(song.Composer);
                    writer.Write(song.Year);
                    writer.Write(song.Text);
                    writer.Write(song.Performers.Length);

                    foreach (string performer in song.Performers)
                    {
                        writer.Write(performer);
                    }
                }
            }

            Console.WriteLine("Колекцію збережено!");
        }

        public void Load(SongCollection collection, string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено!");
                return;
            }

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                collection.Songs.Clear();

                int count = reader.ReadInt32();

                for (int i = 0; i < count; i++)
                {
                    string title = reader.ReadString();
                    string author = reader.ReadString();
                    string composer = reader.ReadString();
                    int year = reader.ReadInt32();
                    string text = reader.ReadString();
                    int performersCount = reader.ReadInt32();
                    string[] performers = new string[performersCount];

                    for (int j = 0; j < performersCount; j++)
                    {
                        performers[j] = reader.ReadString();
                    }

                    Song song = new Song(title, author, composer, year, text, performers);

                    collection.Songs.Add(song);
                }
            }
            Console.WriteLine("Колекцію завантажено!");
        }
    }
}
