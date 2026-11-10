using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task1.models
{
    internal class Person : IComparable, ICloneable
    {
        private DateTime birthDate;
        private string name;
        private string surname;
        public Person()
        {
            name = "Unknown";
            surname = "Unknown";
            birthDate = DateTime.Now;
        }
        public Person(string name, string surname, DateTime birthDate)
        {
            this.name = name;
            this.surname = surname;
            this.birthDate = birthDate;
        }
        public DateTime BirthDate
        {
            get {return birthDate;}
            set {birthDate = value;}
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public int BirthYear
        {
            get => birthDate.Year;
            set => birthDate = new DateTime(value, birthDate.Month, birthDate.Day);
        }
        public int GetAge()
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age))
                age--;
            return age;
        }
        public int CompareTo(object obj)
        {
            Person other = (Person)obj;
            return Surname.CompareTo(other.Surname);
        }
        public object Clone()
        {
            return new Person(Name, Surname, BirthDate);
        }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Birth Year: {BirthYear}, Age: {GetAge()}";
        }
    }
}

