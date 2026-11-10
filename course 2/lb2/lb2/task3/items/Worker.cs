using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task3.items
{
    internal class Worker : Employer
    {
        public Worker(string name, System.DateTime birthDate,
            int experienceYears, string education,
            decimal salary, string professionDirection)
            : base(name, birthDate, experienceYears,
                  education, salary, professionDirection)
        {
        }
    }
}
