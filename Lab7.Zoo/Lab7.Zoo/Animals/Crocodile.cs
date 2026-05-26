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

        public Crocodile(
            string name,
            int age,
            double weight,
            string sex,
            double length,
            int toothCount,
            CrocodileHabitat habitat)
            : base(name, age, weight, sex)
        {
            Length = length;
            ToothCount = toothCount;
            Habitat = habitat;

            IsNocturnal = true;

            FoodType = FoodType.Mixed;
            DietSize = weight * 0.03;

            CanReproduce = true;
            CanLiveTogether = false;

            AggressionLevel = 4;
            IsPredator = true;
            HabitatType = "Water";
        }

        public override string LiveInfo()
        {
            return $"{Name} живе у воді та полює із засідки.";
        }

        public override string Print()
        {
            return base.Print() + "\n" +
                   $"Довжина: {Length} м\n" +
                   $"Кількість зубів: {ToothCount}\n" +
                   $"Тип водойми: {Habitat}\n" +
                   $"Нічний: {(IsNocturnal ? "Так" : "Ні")}";
        }

        public override double MonthlyFood()
        {
            return Weight * 0.03 * 30;
        }

        public override string ToString()
        {
            return $"Крокодил: {Name}, {Weight} кг";
        }

        public override bool Equals(object obj)
        {
            if (obj is Crocodile other)
            {
                return Name == other.Name &&
                       Length == other.Length;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Length);
        }
    }
}
