using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lab7.Zoo.enums;

namespace Lab7.Zoo.Animals
{
    public class Tiger : Animal
    {
        public string Subspecies {get; set;}
        public bool IsAlbino {get; set;}

        public Tiger(
            string name,
            int age,
            double weight,
            string sex,
            string subspecies,
            bool isAlbino)
            : base(name, age, weight, sex)
        {
            Subspecies = subspecies;
            IsAlbino = isAlbino;

            FoodType = FoodType.Meat;
            DietSize = weight * 0.06;

            CanReproduce = true;
            CanLiveTogether = false;

            AggressionLevel = 5;
            IsPredator = true;
            HabitatType = "Jungle";
        }

        public override string LiveInfo()
        {
            return $"{Name} — хижак та живе окремо.";
        }

        public override string Print()
        {
            return base.Print() + "\n" +
                   $"Підвид: {Subspecies}\n" +
                   $"Альбінос: {(IsAlbino ? "Так" : "Ні")}";
        }

        public override double MonthlyFood()
        {
            return Weight * 0.06 * 30;
        }

        public override string ToString()
        {
            return $"Тигр: {Name}, {Weight} кг";
        }

        public override bool Equals(object obj)
        {
            if (obj is Tiger other)
            {
                return Name == other.Name &&
                       Subspecies == other.Subspecies;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Subspecies);
        }
    }
}
