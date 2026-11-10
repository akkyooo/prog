using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp10.task3.details
{
    internal static class ArrayUtils
    {
        public delegate int ArrayOperation(int[] arr);
        public static ArrayOperation CountDivBy7 = arr => arr.Count(x => x % 7 == 0);
        public static ArrayOperation CountPositive = arr => arr.Count(x => x > 0);
    }
}
