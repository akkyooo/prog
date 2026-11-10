using LabApp9.task2.details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp9.task2
{
    public static class Task2Launcher
    {
        public static void Run()
        {
            RGBColor color = new RGBColor();

            color.SetColor(255, 100, 50);

            color.PrintHEX();
            color.PrintHSL();
            color.PrintCMYK();

            Console.ReadKey();
        }
    }
}

