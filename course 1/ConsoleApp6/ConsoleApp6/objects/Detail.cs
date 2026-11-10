using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp6.objects
{
    internal class Detail
    {
        public Person Manufacturer {get; set;}
        public string Description {get; set;}
        public double Weight {get; set;}
        public Detail(Person manufacturer, string description, double weight)
        {
            Manufacturer = manufacturer;
            Description = description;
            Weight = weight;
        }
        public Detail()
        {
            Manufacturer = new Person();
            Description = "Unknown";
            Weight = 0;
        }
        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer.ToShortString()}, Description: {Description}, Weight: {Weight}";
        }
    }
}
