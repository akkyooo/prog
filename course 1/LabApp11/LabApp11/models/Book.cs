using LabApp11.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp11.models
{
    public class Book : ILibraryItem, ISearchByAuthor
    {
        public string Title {get; set;}
        public string Author { get; set;}
        public string Genre {get; set;}
        public int Pages {get; set;}

        public string GetInfo()
        {
            return $"[Book] {Title}, Author: {Author}, Genre: {Genre}, Pages: {Pages}";
        }
        public bool ContainsAuthor(string author)
        {
            return Author.ToLower().Contains(author.ToLower());
        }
    }
}
