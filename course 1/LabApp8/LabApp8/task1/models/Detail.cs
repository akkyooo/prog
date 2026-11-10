using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task1.models
{
    internal class Detail : IComparable, ICloneable
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
        public int CompareTo(object obj)
        {
            Detail other = (Detail)obj;
            return Weight.CompareTo(other.Weight);
        }
        public object Clone()
        {
            return new Detail((Person)Manufacturer.Clone(), Description, Weight);
        }
        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}, Description: {Description}, Weight: {Weight}";
        }
    }
}
