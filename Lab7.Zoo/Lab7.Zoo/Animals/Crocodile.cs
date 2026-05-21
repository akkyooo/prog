using Lab7.Zoo.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab7.Zoo.Animals
{
    public class Crocodile : Animal
    {
        public double Length {get; set;}
        public int ToothCount {get; set;}
        public CrocodileHabitat Habitat {get; set;}
        public bool IsNocturnal {get; set;}
        public Crocodile(string name, int age, double weight, string sex, double length, int toothCount, CrocodileHabitat habitat)
            : base(name, age, weight, sex)
        {
            Length = length;
            ToothCount = toothCount;
            Habitat = habitat;
            IsNocturnal = true;
            FoodType = "Meat";
            DietSize = weight * 0.03;
            CanReproduce = true;
        }
        public override void LiveInfo()
        {
            Console.WriteLine($"{Name} живе у воді та полює з засідки.");
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Довжина: {Length} м");
            Console.WriteLine($"Зубів: {ToothCount}");
            Console.WriteLine($"Середовище: {Habitat}");
            Console.WriteLine($"Нічний: {(IsNocturnal ? "Так" : "Ні")}");
        }
        public override string ToString()
        {
            return $"Крокодил: {Name}, {Weight} кг";
        }
        public override bool Equals(object obj)
        {
            if (obj is Crocodile other)
                return Name == other.Name && Length == other.Length;

            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Length);
        }
    }
}
