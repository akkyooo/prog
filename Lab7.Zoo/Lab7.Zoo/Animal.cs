using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7.Zoo.enums;

namespace Lab7.Zoo
{
    public abstract class Animal
    {
        public string Name {get; set;}
        public int Age {get; set;}
        public double Weight {get; set;}
        public string Sex {get; set;}
        public string FoodType {get; set;}
        public double DietSize {get; set;}
        public bool CanReproduce {get; set;}

        protected Animal(string name, int age, double weight, string sex)
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
            this.Sex = sex;
        }
        public abstract void LiveInfo();

        public virtual void Print()
        {
            Console.WriteLine($"Ім'я: {Name}");
            Console.WriteLine($"Вік: {Age}");
            Console.WriteLine($"Вага: {Weight}");
            Console.WriteLine($"Стать: {Sex}");
            Console.WriteLine($"Корм: {FoodType}, {Weight * 0.05:F1} кг/день");
            Console.WriteLine($"Розмноження: {(CanReproduce ? "Так" : "Ні")}");
        }
        public double MonthlyFood()
        {
            return (Weight * 0.05) * 30;
        }
        public override string ToString()
        {
            return $"Тварина: {Name}, вага {Weight} кг";
        }
        public override bool Equals(object obj)
        {
            if (obj is Animal other)
                return Name == other.Name && Weight == other.Weight;

            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Weight);
        }   
    }
}
