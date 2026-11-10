using LabApp11.interfaces;
using LabApp11.models;
using LabApp11.services;

namespace LabApp11
{
    class Program
    {
        static void Main()
        {
            ICatalogService catalog = new CatalogService();

            catalog.Add(new Book {Title = "Kobzar", Author = "Shevchenko", Genre = "Poetry", Pages = 300});
            catalog.AddRandom();

            catalog.Add(new Newspaper {Title = "Days", Date = DateTime.Now});
            catalog.AddRandom();

            Almanac a = new Almanac {Title = "Classic"};
            a.AddBook(new Book {Title = "Book A", Author = "Author 1", Genre = "Drama", Pages = 200});
            catalog.AddRandom();
            catalog.Add(a);

            Console.WriteLine("ALL ELEMENTS");
            catalog.ShowAll();

            Console.WriteLine("SEARCH BY NAME");
            catalog.SearchByTitle("Kobzar");

            Console.WriteLine("SEARCH BY AUTHOR");
            catalog.SearchByAuthor("Shevchenko");

            Console.WriteLine("AFTER REMOVAL");
            catalog.Remove("Kobzar");

            catalog.ShowAll();
        }
    }
}
