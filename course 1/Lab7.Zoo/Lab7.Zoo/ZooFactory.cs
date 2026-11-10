using Lab7.Zoo.Animals;
using Lab7.Zoo.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Zoo
{
    public static class ZooFactory
    {
        public static ZooManager CreateZoo()
        {
            ZooManager zoo = new ZooManager("Wild Zoo");

            zoo.AddAnimal(new Tiger("Sherkhan", 5, 220, "Male", "Bengal", false));
            zoo.AddAnimal(new Crocodile("Gena", 12, 500, "Male", 4.5, 68, CrocodileHabitat.River));
            zoo.AddAnimal(new Kangaroo("Jack", 4, 85, "Male", 2.8, 8));

            return zoo;
        }
    }
}
