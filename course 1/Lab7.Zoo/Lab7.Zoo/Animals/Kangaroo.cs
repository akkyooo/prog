using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lab7.Zoo.enums;

namespace Lab7.Zoo.Animals
{
    public class Kangaroo : Animal
    {
        public double JumpHeight {get; set;}
        public double JumpLength {get; set;}
        public bool HasJoey {get; set;}

        public Kangaroo(
            string name,
            int age,
            double weight,
            string sex,
            double jumpHeight,
            double jumpLength)
            : base(name, age, weight, sex)
        {
            JumpHeight = jumpHeight;
            JumpLength = jumpLength;

            HasJoey = false;

            FoodType = FoodType.Plants;
            DietSize = weight * 0.04;

            CanReproduce = true;
            CanLiveTogether = true;

            AggressionLevel = 1;
            IsPredator = false;
            HabitatType = "Savanna";
        }
        public override string LiveInfo()
        {
            return $"{Name} пересувається стрибками по савані.";
        }
        public override string Print()
        {
            return base.Print() + "\n" +
                   $"Висота стрибка: {JumpHeight} м\n" +
                   $"Довжина стрибка: {JumpLength} м\n" +
                   $"Є малюк: {(HasJoey ? "Так" : "Ні")}";
        }
        public override double MonthlyFood()
        {
            return Weight * 0.04 * 30;
        }
        public override string ToString()
        {
            return $"Кенгуру: {Name}, {Weight} кг";
        }
        public override bool Equals(object obj)
        {
            if (obj is Kangaroo other)
            {
                return Name == other.Name &&
                       Weight == other.Weight;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Weight);
        }
    }
}
