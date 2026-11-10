using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp11.interfaces
{
    public interface ICatalogService
    {
        void Add(ILibraryItem item);
        void AddRandom();
        void Remove(string title);
        void ShowAll();
        void SearchByTitle(string title);
        void SearchByAuthor(string author);
    }
}
