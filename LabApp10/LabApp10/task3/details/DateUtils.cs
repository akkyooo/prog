using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp10.task3.details
{
    internal static class DateUtils
    {
        public delegate bool DateCheck(DateTime date);
        public static DateCheck IsProgrammerDay = date => date.DayOfYear == 256;
    }
}
