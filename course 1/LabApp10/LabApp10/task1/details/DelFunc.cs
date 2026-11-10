using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp10.task1.details
{
    internal class DelFunc
    {
        public Func<double, double, double> TriangleArea =>(a, h) => 0.5 * a * h;
        public Func<double, double, double> RectangleArea =>(a, b) => a * b;
    }
}
