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
        public FoodType FoodType {get; set;}
        public double DietSize {get; set;}
        public bool CanReproduce {get; set;}
        public bool CanLiveTogether {get; set;}
        public int AggressionLevel {get; set;}
        public bool IsPredator {get; set;}
        public string HabitatType {get; set;}

        protected Animal(
            string name,
            int age,
            double weight,
            string sex)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Sex = sex;
        }
        public abstract string LiveInfo();
        public virtual string Print()
        {
            return
                $"Ім'я: {Name}\n" +
                $"Вік: {Age}\n" +
                $"Вага: {Weight} кг\n" +
                $"Стать: {Sex}\n" +
                $"Корм: {FoodType}\n" +
                $"Добова норма: {DietSize:F1} кг\n" +
                $"Розмноження: {(CanReproduce ? "Так" : "Ні")}\n" +
                $"Може жити з іншими: {(CanLiveTogether ? "Так" : "Ні")}\n" +
                $"Агресивність: {AggressionLevel}/5\n" +
                $"Хижак: {(IsPredator ? "Так" : "Ні")}\n" +
                $"Середовище: {HabitatType}\n" +
                $"Рівень небезпеки: {DangerLevel()}";
        }

        public virtual double MonthlyFood()
        {
            return DietSize * 30;
        }

        public virtual bool CanLiveWith(Animal other)
        {
            if (IsPredator && !other.IsPredator)
                return false;

            if (AggressionLevel >= 4 &&
                other.AggressionLevel >= 4)
                return false;

            if (HabitatType != other.HabitatType)
                return false;

            return true;
        }

        public virtual string DangerLevel()
        {
            if (AggressionLevel >= 4)
                return "Небезпечна";

            if (AggressionLevel >= 2)
                return "Помірна";

            return "Спокійна";
        }

        public override string ToString()
        {
            return $"Тварина: {Name}, вага {Weight} кг";
        }

        public override bool Equals(object obj)
        {
            if (obj is Animal other)
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
