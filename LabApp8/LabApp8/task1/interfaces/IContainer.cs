using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task1.interfaces
{
    interface IContainer<T>
    {
        int Count {get;}
        T this[int index] {get; set;}
        void Add(T element);
        void Delete(T element);
    }
}
