using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab7.Zoo.Animals
{
    public class Tiger : Animal
    {
        public string Subspecies {get; set;}
        public bool IsAlbino {get; set;}  
        public int AggressionLevel {get; set;}

        public Tiger(string name, int age, double weight, string sex, string subspecies, bool isAlbino, int aggressionLevel)
            : base(name, age, weight, sex)
        {
            Subspecies = subspecies;
            IsAlbino = isAlbino;
            AggressionLevel = aggressionLevel;
            FoodType = "Meat";
            DietSize = weight * 0.05;
            CanReproduce = true;
        }

        public override void LiveInfo()
        {
            Console.WriteLine($"{Name} — хижак, живе окремо.");
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Підвид: {Subspecies}");
            Console.WriteLine($"Альбінос: {(IsAlbino ? "Так" : "Ні")}");
            Console.WriteLine($"Агресивність: {AggressionLevel}/5");
        }
        public override string ToString()
        {
            return $"Тигр: {Name}, {Weight} кг, {Subspecies}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Tiger other)
                return Name == other.Name &&
                       Subspecies == other.Subspecies &&
                       IsAlbino == other.IsAlbino;

            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Subspecies, IsAlbino);
        }
    }
}
