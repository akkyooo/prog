using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task2.interfaces
{
    internal interface IDevice
    {
        string Name {get; set;}
        double Weight {get; set;}
        bool HasEngine {get;}
        void ShowInfo();
    }
}
