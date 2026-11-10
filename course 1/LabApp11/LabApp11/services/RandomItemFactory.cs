using LabApp11.interfaces;
using LabApp11.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp11.services
{
    public class RandomItemFactory
    {
        private Random random = new Random();
        public ILibraryItem Create()
        {
            int type = random.Next(3);
            if (type == 0)
            {
                return new Book
                {
                    Title = "Book " + random.Next(100), Author = "Author " + random.Next(10), Genre = "Genre", Pages = 100
                };
            }
            else if (type == 1)
            {
                return new Newspaper
                {
                    Title = "News " + random.Next(100), Date = DateTime.Now
                };
            }
            else
            {
                Almanac a = new Almanac {Title = "Almanac " + random.Next(100)};
                a.AddBook(new Book {Title = "Inner Book", Author = "Author X", Genre = "Drama", Pages = 200});
                return a;
            }
        }
    }
}
