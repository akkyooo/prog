using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApp9.task3.store;

namespace LabApp9.task3.interfaces
{
    internal interface IStore
    {
        void AddItem(Item item);
        void RemoveItem(string name);
        void DisplayItems();
        void UpdateItem(string name, int quantity, double price);
    }
}