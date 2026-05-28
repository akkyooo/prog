using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task3.interfaces
{
    internal interface ICipher
    {
        string Encode(string text);
        string Decode(string text);
        string Text {get; set;}
    }
}
