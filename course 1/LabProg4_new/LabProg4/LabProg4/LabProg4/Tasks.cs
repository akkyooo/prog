using System;
using System.Collections.Generic;
using System.Text;

namespace LabProg4
{
    internal class Tasks
    {
        static Random random = new Random();
        public static void Task1()
        {
            int[][]? A = CreateArray();
            if (A == null)
            {
                Console.WriteLine("Массив не створено. Повернення до меню застосунку");
                Console.ReadKey();
            }

            Print(A, "\nМасив:");
            
            (int sum1,int sum2)= DifferentInSumm(A);
            Console.WriteLine("\nРізниця сум: " + (sum1 - sum2));

            SortRows(A);
            Print(A, "\nПісля обробки:");

            SaveArrayToFile(A, "output.txt");

            Console.ReadKey();
        }

        private static void SaveArrayToFile(int[][] a, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var row in a)
                {
                    foreach (var x in row)
                        sw.Write(x + " ");
                    sw.WriteLine();
                }
            }
        }

        public static void SortRows(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int maxIndex = 0;

                for (int j = 1; j < a[i].Length; j++)
                    if (a[i][j] > a[i][maxIndex])
                        maxIndex = j;

                Array.Sort(a[i], maxIndex+1, a[i].Length - maxIndex-1);
                //for (int j = maxIndex + 1; j < A[i].Length - 1; j++)
                //    for (int p = j + 1; p < A[i].Length; p++)
                //        if (A[i][j] < A[i][p])
                //        {
                //            int temp = A[i][j];
                //            A[i][j] = A[i][p];
                //            A[i][p] = temp;
                //        }
            }
        }
        public static (int ,int) DifferentInSumm(int[][] a)
        {
            int sum1 = 0, sum2 = 0;
            int total = a.Length * a.Length;
            int half = total / 2;
            int k = 0;

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (k < half) sum1 += a[i][j];
                    else sum2 += a[i][j];
                    k++;
                }

            return (sum1, sum2);
        }

        public static int[][]? CreateArray()
        {
            int[][] A=null;
            Console.WriteLine("1-Клавіатура, 2-файл, 3-Рандом");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("n: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        A = new int[n][];
                        for (int i = 0; i < n; i++)
                        {
                            A[i] = new int[n];
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write($"[{i},{j}]: ");
                                A[i][j] = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        string[] lines = File.ReadAllLines("input.txt");
                        int n = lines.Length;

                        A = new int[n][];

                        for (int i = 0; i < n; i++)
                        {
                            string[] parts = lines[i]
                                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            A[i] = new int[parts.Length];
                            for (int j = 0; j < parts.Length; j++)
                                A[i][j] = Convert.ToInt32(parts[j]);
                        }
                        break;
                    }
                case 3:
                    {
                        Console.Write("n: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        A = new int[n][];
                        for (int i = 0; i < n; i++)
                        {
                            A[i] = new int[n];
                            for (int j = 0; j < n; j++)
                                A[i][j] = random.Next(-50, 51);
                        }
                        break;
                    }

            }
            return A;
        }
        public static void Print(int[][] A, string text)
        {
            Console.WriteLine(text);

            foreach (var row in A)
            {
                foreach (var x in row)
                    Console.Write("{0,5}", x);
                Console.WriteLine();
            }
        }

        public static void Task2()
        {
            Console.Write("Введіть кількість рядків масиву: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 1) n = 3;
            int[][] Mas = new int[n][];
            for (int i = 0; i < Mas.Length; i++)
            {
                Console.Write("Введіть розмірність {0} рядка: ", i + 1);
                int len = Convert.ToInt32(Console.ReadLine());
                if (len < 1) len = 2;

                Mas[i] = new int[len];
                for (int j = 0; j < Mas[i].Length; j++)
                    Mas[i][j] = random.Next(1, 100);
            }
            Console.WriteLine("\nСтворено ступінчатий масив:\n");

            for (int i = 0; i < Mas.Length; i++)
            {
                Console.Write("Рядок {0} ({1} ел.): ", i, Mas[i].Length);
                foreach (int val in Mas[i])
                    Console.Write("{0,5}", val);
                Console.WriteLine();
            }
            int maxVal = Mas[0][0];
            int maxRow = 0;
            int maxCol = 0;

            for (int i = 0; i < Mas.Length; i++)
            {
                for (int j = 0; j < Mas[i].Length; j++)
                {
                    if (Mas[i][j] > maxVal)
                    {
                        maxVal = Mas[i][j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            Console.WriteLine("\nМаксимальний елемент: {0}", maxVal);
            Console.WriteLine("Знаходиться у рядку {0}, стовпці {1}", maxRow, maxCol);
            Console.ReadKey();

            if (maxRow != 0)
            {
                int[] temp = Mas[0];
                Mas[0] = Mas[maxRow];
                Mas[maxRow] = temp;
                Console.WriteLine("\nРядок 0 та рядок {0} — переставлено.", maxRow);
            }
            else
            {
                Console.WriteLine("\nМаксимум вже у рядку 0, перестановка рядків не потрібна.");
            }
            if (maxCol != 0)
            {
                for (int i = 0; i < Mas.Length; i++)
                {
                    if (Mas[i].Length > maxCol)
                    {
                        int tmp = Mas[i][0];
                        Mas[i][0] = Mas[i][maxCol];
                        Mas[i][maxCol] = tmp;
                    }
                }
                Console.WriteLine("Стовпець 0 та стовпець {0} — переставлено.", maxCol);
            }
            else
            {
                Console.WriteLine("Максимум вже у стовпці 0, перестановка стовпців не потрібна.");
            }
            Console.WriteLine("\nМасив після переміщення максимуму в [0][0]:\n");
            for (int i = 0; i < Mas.Length; i++)
            {
                Console.Write("Рядок {0} ({1} ел.): ", i, Mas[i].Length);
                foreach (int val in Mas[i])
                    Console.Write("{0,5}", val);
                Console.WriteLine();
            }
            Console.WriteLine("\nПеревірка: Mas[0][0] = {0}", Mas[0][0]);
            Console.ReadKey();
        }


        public static void Task3()
        {
            Console.WriteLine("Оберіть спосіб заповнення:");
            Console.WriteLine("1 - вручну");
            Console.WriteLine("2 - випадкові числа");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть розмір n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 2) n = 2;
            int[][] Mas = new int[n][];

            switch (choice)
            {
                case 1:
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Mas[i] = new int[n];
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write($"Mas[{i},{j}] = ");
                                Mas[i][j] = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Mas[i] = new int[n];
                            for (int j = 0; j < n; j++)
                                Mas[i][j] = random.Next(1, 50);
                        }
                        break;
                    }
            }
            Console.WriteLine("\nМасив:");
            Print(Mas);
            if (IsMagicSquare(Mas))
                Console.WriteLine("\nЦе магічний квадрат");
            else
                Console.WriteLine("\nЦе НЕ магічний квадрат");
        }
        static bool IsMagicSquare(int[][] Mas)
        {
            int n = Mas.Length;
            for (int i = 0; i < n; i++)
                if (Mas[i].Length != n)
                    return false;
            int magic = 0;
            for (int j = 0; j < n; j++)
                magic += Mas[0][j];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                    sum += Mas[i][j];

                if (sum != magic)
                    return false;
            }
            for (int j = 0; j < n; j++)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                    sum += Mas[i][j];

                if (sum != magic)
                    return false;
            }
            int diag1 = 0;
            for (int i = 0; i < n; i++)
                diag1 += Mas[i][i];

            if (diag1 != magic)
                return false;

            int diag2 = 0;
            for (int i = 0; i < n; i++)
                diag2 += Mas[i][n - 1 - i];

            if (diag2 != magic)
                return false;

            return true;
        }
        static void Print(int[][] Mas)
        {
            for (int i = 0; i < Mas.Length; i++)
            {
                for (int j = 0; j < Mas[i].Length; j++)
                    Console.Write("{0,5}", Mas[i][j]);
                Console.WriteLine();
            }
        }
    }
}