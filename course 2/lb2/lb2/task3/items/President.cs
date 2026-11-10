using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task3.items
{
    internal class President : Employer
    {
        public President(string name, System.DateTime birthDate,
           int experienceYears, string education,
           decimal salary, string professionDirection)
           : base(name, birthDate, experienceYears,
                 education, salary, professionDirection)
        {
        }
    }
}
