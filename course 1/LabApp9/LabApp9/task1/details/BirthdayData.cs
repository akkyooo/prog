using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp9.task1.details
{
    internal class BirthdayData
    {
        public static void doBirthday()
        {
            BirthdayRun b = new BirthdayRun();

            b.SetDate(11, 4, 2008);

            Console.WriteLine($"Date: {b.Day}/{b.Month}/{b.Year}");
            Console.WriteLine($"You were born on: {b.GetBirthDay()}");

            int year = 2026;
            Console.WriteLine($"In {year} your birthday will be on: {b.GetDayInYear(year)}");
            Console.WriteLine($"Days until next birthday: {b.GetDaysUntil()}");
        }
    }
}
