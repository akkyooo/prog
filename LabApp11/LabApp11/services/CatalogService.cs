using LabApp11.interfaces;
using LabApp11.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabApp11.services
{
    public class CatalogService : ICatalogService
    {
        private CatalogStorage storage = new CatalogStorage();
        private RandomItemFactory factory = new RandomItemFactory();
        private IDisplayService display = new ConsoleDisplay();
        public void Add(ILibraryItem item)
        {
            storage.Add(item);
        }
        public void AddRandom()
        {
            storage.Add(factory.Create());
        }
        public void Remove(string title)
        {
            storage.Remove(title);
        }
        public void ShowAll()
        {
            foreach (var item in storage.GetAll())
                display.Show(item.GetInfo());
        }
        public void SearchByTitle(string title)
        {
            foreach (var item in storage.GetAll())
            {
                if (item.Title.ToLower().Contains(title.ToLower()))
                    display.Show(item.GetInfo());
            }
        }
        public void SearchByAuthor(string author)
        {
            foreach (var item in storage.GetAll())
            {
                if (item is ISearchByAuthor a && a.ContainsAuthor(author))
                    display.Show(item.GetInfo());
            }
        }
    }
}
