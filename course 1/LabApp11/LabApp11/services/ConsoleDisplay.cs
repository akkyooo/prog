using LabApp11.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp11.services
{
    public class ConsoleDisplay : IDisplayService
    {
        public void Show(string text)
        {
            Console.WriteLine(text);
        }
    }
}
