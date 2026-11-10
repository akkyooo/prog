using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp9.task1.details
{
    internal class BirthdayRun
    {
        public int Day, Month, Year;
        public void SetDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public DayOfWeek GetBirthDay()
        {
            DateTime date = new DateTime(Year, Month, Day);
            return date.DayOfWeek;
        }
        public DayOfWeek GetDayInYear(int year)
        {
            DateTime date = new DateTime(year, Month, Day);
            return date.DayOfWeek;
        }
        public int GetDaysUntil()
        {
            DateTime today = DateTime.Today;
            DateTime next = new DateTime(today.Year, Month, Day);

            if (next < today)
                next = next.AddYears(1);
            return (next - today).Days;
        }
    }
}
