using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task1.interfaces
{
    interface IFileContainer<T> : IContainer<T>
    {
        void Save(string fileName);
        void Load(string fileName);
        bool IsDataSaved {get;}
    }
}
