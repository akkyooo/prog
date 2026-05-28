using LabApp8.task2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabApp8.task2.transports
{
    internal class FlyingCarpet : Device
    {
        public FlyingCarpet(string name, double weight) : base(name, weight, false)
        {
        }
        public override object Clone()
        {
            return new FlyingCarpet(Name, Weight);
        }
    }
}
