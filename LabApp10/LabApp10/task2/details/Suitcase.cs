using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp10.task2.details
{
    internal class Suitcase
    {
        public string Color {get; set;}
        public string Manufacturer { get; set;}
        public double Capacity {get; set;}
        public SuitcaseItem?[] Items {get; set;}
        public int MaxItems {get; set;}

        public delegate void ItemHandler(SuitcaseItem item);
        public event ItemHandler? ItemAdded;

        public Suitcase(string color, string dev, double capacity, int maxItems)
        {
            Color = color;
            Manufacturer = dev;
            Capacity = capacity;
            MaxItems = maxItems;
            Items = new SuitcaseItem?[maxItems];
        }
        public double GetUsedVolume()
        {
            double sum = 0;

            foreach (var item in Items)
                if (item != null)
                    sum += item.Volume;

            return sum;
        }
        public void RaiseItemAdded(SuitcaseItem item)
        {
            ItemAdded?.Invoke(item);
        }
    }
}
