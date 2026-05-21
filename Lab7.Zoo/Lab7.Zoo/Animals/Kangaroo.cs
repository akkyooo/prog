using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab7.Zoo.Animals
{
    public class Kangaroo : Animal
    {
        public double JumpHeight { get; set; }
        public double JumpLength { get; set; }
        public bool HasJoey { get; set; }
        public Kangaroo(string name, int age, double weight, string sex, double jumpHeight, double jumpLength)
            : base(name, age, weight, sex)
        {
            JumpHeight = jumpHeight;
            JumpLength = jumpLength;
            HasJoey = false;
            FoodType = "Plants";
            DietSize = weight * 0.04;
            CanReproduce = true;
        }
        public override void LiveInfo()
        {
            Console.WriteLine($"{Name} пересувається стрибками по савані.");
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Висота стрибка: {JumpHeight} м");
            Console.WriteLine($"Довжина стрибка: {JumpLength} м");
            Console.WriteLine($"Є малюк: {(HasJoey ? "Так" : "Ні")}");
        }
        public override string ToString()
        {
            return $"Кенгуру: {Name}, {Weight} кг";
        }
        public override bool Equals(object obj)
        {
            if (obj is Kangaroo other)
                return Name == other.Name && Weight == other.Weight;

            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Weight);
        }
    }
}
