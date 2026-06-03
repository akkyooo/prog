using LabApp11.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp11.models
{
    public class Almanac : ILibraryItem, ISearchByAuthor
    {
        public string Title {get; set;}
        private Book[] books = new Book[0];
        public void AddBook(Book book)
        {
            Book[] newArr = new Book[books.Length + 1];
            for (int i = 0; i < books.Length; i++)
                newArr[i] = books[i];

            newArr[newArr.Length - 1] = book;
            books = newArr;
        }
        public string GetInfo()
        {
            return $"[Almanac] {Title}, Book: {books.Length}";
        }
        public bool ContainsAuthor(string author)
        {
            foreach (var b in books)
                if (b.Author.ToLower().Contains(author.ToLower()))
                    return true;
            return false;
        }
    }
}
