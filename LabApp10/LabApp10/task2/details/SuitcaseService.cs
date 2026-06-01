using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp10.task2.details
{
    internal class SuitcaseService
    {
        public void AddItem(Suitcase suitcase, SuitcaseItem suitcaseItem)
        {
            if (suitcase.GetUsedVolume() + suitcaseItem.Volume > suitcase.Capacity)
                throw new Exception("Suitcase overflow!");

            for (int i = 0; i < suitcase.MaxItems; i++)
            {
                if (suitcase.Items[i] == null)
                {
                    suitcase.Items[i] = suitcaseItem;
                    suitcase.RaiseItemAdded(suitcaseItem);
                    return;
                }
            }

            Console.WriteLine("No space in array.");
        }
    }
}
