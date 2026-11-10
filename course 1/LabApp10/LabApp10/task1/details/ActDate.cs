using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp10.task1.details
{
    internal class ActDate
    {
        public Action ShowTime => () => Console.WriteLine($"Current Time: {DateTime.Now:HH:mm:ss}");

        public Action ShowDate => () => Console.WriteLine($"Current Date: {DateTime.Now:dd.MM.yyyy}");

        public Action ShowDay => () => Console.WriteLine($"Current Day: {DateTime.Now.DayOfWeek}");
    }
}