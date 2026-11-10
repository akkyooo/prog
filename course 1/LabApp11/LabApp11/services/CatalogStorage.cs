using LabApp11.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp11.services
{
    public class CatalogStorage
    {
        private ILibraryItem[] items = new ILibraryItem[0];
        public void Add(ILibraryItem item)
        {
            ILibraryItem[] newArr = new ILibraryItem[items.Length + 1];
            for (int i = 0; i < items.Length; i++)
                newArr[i] = items[i];
            newArr[newArr.Length - 1] = item;
            items = newArr;
        }
        public void Remove(string title)
        {
            int count = 0;
            foreach (var i in items)
                if (!i.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    count++;

            ILibraryItem[] newArr = new ILibraryItem[count];
            int index = 0;
            foreach (var i in items)
            {
                if (!i.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    newArr[index++] = i;
            }
            items = newArr;
        }
        public ILibraryItem[] GetAll()
        {
            return items;
        }
    }
}
