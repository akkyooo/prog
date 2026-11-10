using LabApp8.task2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabApp8.task2.transports
{
    internal class Helicopter : Device, IEngine
    {
        public int EnginePower {get; set;}
        public string FuelType {get; set;}
        public Helicopter(string name, double weight, int enginePower, string fuelType) : base(name, weight, true)
        {
            EnginePower = enginePower;
            FuelType = fuelType;
        }
        public override object Clone()
        {
            return new Helicopter(Name, Weight, EnginePower, FuelType);
        }
    }
}
