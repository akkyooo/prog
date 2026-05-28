using LabApp9.task3.interfaces;
using LabApp9.task3.store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp9.task3
{
    internal class Task3Launcher
    {
        public static void Run()
        {
            IStore shop = new Shop();
            Item item1 = new Item
            {
                Name = "Potion", Quantity = 10, Price = 50, Category = ItemCategory.Consumable
            };
            Item item2 = new Item
            {
                Name = "Sword", Quantity = 2, Price = 200, Category = ItemCategory.Weapon
            };

            shop.AddItem(item1);
            shop.AddItem(item2);
            shop.DisplayItems();

            Console.WriteLine("\nAfter update:");

            ((Shop)shop).UpdateItem("Potion", 20, 45);
            shop.RemoveItem("Sword");
            shop.DisplayItems();
            Console.ReadKey();
        }
    }
}
