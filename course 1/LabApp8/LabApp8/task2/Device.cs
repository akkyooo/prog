using LabApp8.task2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task2
{
    internal abstract class Device : IDevice, IComparable, ICloneable
    {
        public string Name {get; set;}
        public double Weight {get; set;}
        public bool HasEngine {get; protected set;}

        protected Device(string name, double weight, bool hasEngine)
        {
            Name = name;
            Weight = weight;
            HasEngine = hasEngine;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine(ToString());
        }
        public int CompareTo(object obj)
        {
            Device other = (Device)obj;
            return Weight.CompareTo(other.Weight);
        }
        public abstract object Clone();
        public override string ToString()
        {
            return $"Name: {Name}, Weight: {Weight}, Engine: {HasEngine}";
        }
    }
}
