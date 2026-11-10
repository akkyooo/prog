using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task1.models
{
    internal class Company
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int EmployeesCount { get; set; }
        public string Address { get; set; }

        public Company(string name, DateTime foundationDate,
            string businessProfile, string directorFullName,
            int employeesCount, string address)
        {
            Name = name;
            FoundationDate = foundationDate;
            BusinessProfile = businessProfile;
            DirectorFullName = directorFullName;
            EmployeesCount = employeesCount;
            Address = address;
        }

        public override string ToString()
        {
            return $"Назва: {Name}, дата заснування: {FoundationDate:dd.MM.yyyy}, " +
                   $"профіль: {BusinessProfile}, директор: {DirectorFullName}, " +
                   $"працівників: {EmployeesCount}, адреса: {Address}";
        }
    }
}