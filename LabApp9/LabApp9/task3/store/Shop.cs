using LabApp9.task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp9.task3.store
{
    internal class Shop : IStore
    {
        private List<Item> items = new List<Item>();
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void RemoveItem(string name)
        {
            items.RemoveAll(i => i.Name == name);
        }
        public void UpdateItem(string name, int quantity, double price)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == name)
                {
                    Item temp = items[i];
                    temp.Quantity = quantity;
                    temp.Price = price;
                    items[i] = temp;
                }
            }
        }
        public void DisplayItems()
        {
            foreach (var item in items)
                item.Print();
        }
    }
}
