using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp10.task2.details
{
    internal class SuitcaseItem
    {
        public string Name {get; set;}
        public float Weight {get; set;}
        public float Volume {get; set;}

        public SuitcaseItem(string name, float weight, float volume)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
        }
        public SuitcaseItem()
        {
            Name = "Unknown";
            Weight = 0.0f;
            Volume = 0.0f;
        }
        public override string ToString() => $"Item: {Name}, Weight: {Weight} kg, Volume: {Volume}";

    }
}
