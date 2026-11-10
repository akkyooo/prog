using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp2
{
    internal class Tasks
    {
        static Random random = new Random();
        public static void Task1()
        {
            double a, x, y;
            Console.WriteLine("РЕЗУЛЬТАТ РОЗРАХУНКУ");
            for (a = 1.25; a <= 2.0; a += 0.25)
            {
                Console.WriteLine("a=" + a);
                for (x = -2; x <= 2; x += 0.1)
                {
                    y = (1 - Math.Exp(-Math.Pow(x / a, 2))) / a;
                    Console.WriteLine($"x={x,5:F2}\t y={y,7:F6}");

                }

            }
        }
        public static void Task2()
        {
            double x, y, s, u;
            int k;
            string rep;
            do
            {
                Console.WriteLine("Введіть x:");
                x = double.Parse(Console.ReadLine());
                Console.WriteLine("\n Поточні результати:");
                k = 0;
                s = 0;
                u = 1;
                while (Math.Abs(u) >= 0.000001)
                {
                    s += u;
                    u *= -x * (2 * k + 1) / (2 * (k + 1) * (2 * k + 2));
                    k++;
                    Console.WriteLine($"Ітерація {k}: член ряду= {u} Сума= {s}");

                }
                y = Math.Sqrt(x + 1);
                Console.WriteLine("\nРезультати:");
                Console.WriteLine($"Сума ряду S={s}");
                Console.WriteLine($"Кількість членів = {k}");
                Console.WriteLine($"y = sqrt(x+1) = {y}");
                Console.WriteLine("Для повторного вводу натисніть довільну клавішу" + "Для закінчення програми натисніть Enter.");
                rep = Console.ReadLine();

            } while (rep != "");

        }
        public static void Task3()
        {
            int correct = 0;
            int a, b, answer;
            int level, n;

            Random rand = new Random();

            Console.WriteLine("Виберіть рівень складності:");
            Console.WriteLine("1 - Легкий");
            Console.WriteLine("2 - Середній");
            Console.WriteLine("3 - Складний");

            level = int.Parse(Console.ReadLine());

            switch (level)
            {
                case 1:
                    n = 5;
                    break;
                case 2:
                    n = 10;
                    break;
                case 3:
                    n = 15;
                    break;
                default:
                    Console.WriteLine("Невірний вибір!");
                    return;
            }


            for (int i = 1; i <= n; i++)
            {
                a = rand.Next(1, 10);
                b = rand.Next(1, 10);

                Console.Write($"Питання {i}: {a} * {b} = ");
                answer = int.Parse(Console.ReadLine());

                if (answer == a * b)
                {
                    Console.WriteLine("Правильно");
                    correct++;
                }
                else
                {
                    Console.WriteLine($"Неправильно. Вірна відповідь: {a * b}");
                }
            }


            Console.WriteLine("\nРезультат:");
            Console.WriteLine("Правильних: " + correct + " з " + n);


            if (correct == n)
            {
                Console.WriteLine("Оцінка: 12");
            }
            else if (correct >= n / 2)
            {
                Console.WriteLine("Оцінка: 8");
            }
            else
            {
                Console.WriteLine("Оцінка: 4");
            }

            Console.ReadLine();
        }
        public static void Task4()
        {
            int mode;
            int a, b, answer;
            int correct = 0;

            Random rand = new Random();

            Console.WriteLine("Brain Training");
            Console.WriteLine("1. + ");
            Console.WriteLine("2. - ");
            Console.WriteLine("3 . * ");

            mode = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 5; i++)
            {
                a = rand.Next(1, 10);
                b = rand.Next(1, 10);

                int result = 0;

                switch (mode)
                {
                    case 1:
                        Console.Write(a + " + " + b + " = ");
                        result = a + b;
                        break;

                    case 2:
                        Console.Write(a + " - " + b + " = ");
                        result = a - b;
                        break;

                    case 3:
                        Console.Write(a + " * " + b + " = ");
                        result = a * b;
                        break;

                    default:
                        Console.WriteLine("Помилка");
                        return;
                }

                answer = int.Parse(Console.ReadLine());

                if (answer == result)
                {
                    correct++;
                }
            }
            Console.WriteLine("Правильних: " + correct);
            if (correct == 5)
            {
                Console.WriteLine("Оцінка: 12");
            }
            else if (correct >= 3)
            {
                Console.WriteLine("Оцінка: 8");
            }
            else
            {
                Console.WriteLine("Оцінка: 4");
            }

            Console.ReadLine();
        }
    }
}