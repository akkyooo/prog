using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task2
{
    internal class Registry
    {
        private Device[] devices = new Device[0];
        public void Add(Device device)
        {
            Array.Resize(ref devices, devices.Length + 1);
            devices[devices.Length - 1] = device;
        }
        public void ShowAll()
        {
            foreach (Device d in devices)
            {
                Console.WriteLine(d);
            }
        }
        public void ShowByEngine(bool hasEngine)
        {
            foreach (Device d in devices)
            {
                if (d.HasEngine == hasEngine)
                {
                    Console.WriteLine(d);
                }
            }
        }
        public void SortByWeight()
        {
            Array.Sort(devices);
        }
        public void SortByName()
        {
            Array.Sort(devices, (a, b) => a.Name.CompareTo(b.Name));
        }
    }
}

