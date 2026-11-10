using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApp10.task1.details;
using LabApp10;

namespace LabApp10.task1
{
	internal static class Task1Launcher
    {
		public static void Run()
		{
            var act = new ActDate();
            var pred = new DelPred();
            var func = new DelFunc();

            act.ShowTime();
            act.ShowDate();
            act.ShowDay();

            Console.WriteLine();
            Console.WriteLine("Prime 7: " + pred.IsPrime(7));
            Console.WriteLine("Fibonacci 8: " + pred.IsFibonacci(8));

            Console.WriteLine();
            Console.WriteLine("Triangle: " + func.TriangleArea(4, 5));
            Console.WriteLine("Rectangle: " + func.RectangleArea(4, 5));



        }
	}
}
