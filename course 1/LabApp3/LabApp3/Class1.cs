using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp3
{
    internal class Tasks
    {
        static Random random = new Random();
        public static void Task1()
        {
            int i;
            int[] array = null;
            Console.WriteLine("1-Клавіатура, 2-файл, 3-Рандом");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Введіть кількість елементів: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    array = new int[n];

                    Console.WriteLine("Введіть елементи:");
                    for (i = 0; i < array.Length; i++)
                        array[i] = Convert.ToInt32(Console.ReadLine());
                    break;

                case 2:
                    using (StreamReader sr = new StreamReader("input.txt"))
                    {
                        string text = sr.ReadToEnd();
                        string[] parts = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                        array = new int[parts.Length];
                        for (i = 0; i < parts.Length; i++)
                            array[i] = Convert.ToInt32(parts[i]);
                    }
                    break;

                case 3:
                    Console.Write("Введіть кількість елементів: ");
                    int m = Convert.ToInt32(Console.ReadLine());
                    array = new int[m];

                    for (i = 0; i < array.Length; i++)
                        array[i] = random.Next(-50, 51);
                    break;

                default:
                    Console.WriteLine("Невірний вибір");
                    return;
            }
            Console.WriteLine("\nПочатковий масив:");
            foreach (int x in array)
                Console.Write("{0,5}", x);
            int minIndex = 0, maxIndex = 0;
            for (i = 1; i < array.Length; i++)
            {
                if (array[i] < array[minIndex]) minIndex = i;
                if (array[i] > array[maxIndex]) maxIndex = i;
            }

            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);
            for (i = start + 1; i < end; i++)
                array[i] *= 2;

            Console.WriteLine("\n\nРезультат:");
            foreach (int x in array)
                Console.Write("{0,5}", x);

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine("Результат:");
                foreach (int x in array)
                    sw.Write(x + " ");
            }       
            Console.ReadKey();
        }

        public static void Task2()
        {
            int i, j;
            int[,] A = null;
            Console.WriteLine("1-Клавіатура, 2-файл, 3-Рандом");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("n: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        A = new int[n, n];

                        for (i = 0; i < n; i++)
                            for (j = 0; j < n; j++)
                            {
                                Console.Write($"[{i},{j}]: ");
                                A[i, j] = Convert.ToInt32(Console.ReadLine());
                            }
                        break;
                    }

                case 2:
                    {
                        string[] lines = File.ReadAllLines("input.txt");

                        int n = lines.Length;
                        A = new int[n, n];

                        for (i = 0; i < n; i++)
                        {
                            string[] parts = lines[i]
                                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                            for (j = 0; j < parts.Length && j < n; j++)
                            {
                                A[i, j] = Convert.ToInt32(parts[j]);
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        Console.Write("n: ");
                        int m = Convert.ToInt32(Console.ReadLine());
                        A = new int[m, m];

                        for (i = 0; i < m; i++)
                            for (j = 0; j < m; j++)
                                A[i, j] = random.Next(-50, 51);
                        break;
                    }
                default:
                 return;
            }
            Console.WriteLine("\nМасив:");
            for (i = 0; i < A.GetLength(0); i++)
            {
                for (j = 0; j < A.GetLength(1); j++)
                    Console.Write("{0,5}", A[i, j]);
                Console.WriteLine();
            }
            int sum1 = 0, sum2 = 0;
            int total = A.Length;
            int half = total / 2;
            int k = 0;
            for (i = 0; i < A.GetLength(0); i++)
                for (j = 0; j < A.GetLength(1); j++)
                {
                    if (k < half) sum1 += A[i, j];
                    else sum2 += A[i, j];
                    k++;
                }
            Console.WriteLine("\nРізниця сум: " + (sum1 - sum2));
            for (i = 0; i < A.GetLength(0); i++)
            {
                int maxIndex = 0;

                for (j = 1; j < A.GetLength(1); j++)
                    if (A[i, j] > A[i, maxIndex])
                        maxIndex = j;
                for (j = maxIndex + 1; j < A.GetLength(1) - 1; j++)
                    for (int p = j + 1; p < A.GetLength(1); p++)
                        if (A[i, j] < A[i, p])
                        {
                            int temp = A[i, j];
                            A[i, j] = A[i, p];
                            A[i, p] = temp;
                        }
            }
            Console.WriteLine("\nПісля обробки:");
            for (i = 0; i < A.GetLength(0); i++)
            {
                for (j = 0; j < A.GetLength(1); j++)
                    Console.Write("{0,5}", A[i, j]);
                Console.WriteLine();
            }
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                for (i = 0; i < A.GetLength(0); i++)
                {
                    for (j = 0; j < A.GetLength(1); j++)
                        sw.Write(A[i, j] + " ");
                    sw.WriteLine();
                }
            }
            Console.ReadKey();
        }


        public static void Task3()
        {
            int size = 4;
            int[,] board = new int[size, size];
            Random random = new Random();

            AddRandomTile(board);
            AddRandomTile(board);

            int score = 0;
            bool running = true;

            while (running)
            {
                Console.Clear();
                PrintBoard(board);
                Console.WriteLine($"\nScore: {score}");
                Console.WriteLine("WASD - рух, F - save, R - load, Q - вихід");

                var key = Console.ReadKey(true).Key;
                int gained = 0;

                switch (key)
                {
                    case ConsoleKey.W: gained = Move(board, Direction.Up); break;
                    case ConsoleKey.S: gained = Move(board, Direction.Down); break;
                    case ConsoleKey.A: gained = Move(board, Direction.Left); break;
                    case ConsoleKey.D: gained = Move(board, Direction.Right); break;

                    case ConsoleKey.F: SaveToFile(board); continue;
                    case ConsoleKey.R: board = LoadFromFile(size); continue;
                    case ConsoleKey.Q: running = false; continue;
                    default: continue;
                }

                if (gained > 0)
                {
                    score += gained;
                    AddRandomTile(board);
                }
            }
        }
        enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        static int Move(int[,] board, Direction dir)
        {
            int size = board.GetLength(0);
            int score = 0;

            for (int line = 0; line < size; line++)
            {
                int[] arr = new int[size];

                for (int i = 0; i < size; i++)
                {
                    int r = line, c = i;

                    if (dir == Direction.Up) { r = i; c = line; }
                    if (dir == Direction.Down) { r = size - 1 - i; c = line; }
                    if (dir == Direction.Right) { r = line; c = size - 1 - i; }

                    arr[i] = board[r, c];
                }

                score += ProcessLine(arr);

                for (int i = 0; i < size; i++)
                {
                    int r = line, c = i;

                    if (dir == Direction.Up) { r = i; c = line; }
                    if (dir == Direction.Down) { r = size - 1 - i; c = line; }
                    if (dir == Direction.Right) { r = line; c = size - 1 - i; }

                    board[r, c] = arr[i];
                }
            }

            return score;
        }

        static int ProcessLine(int[] line)
        {
            int score = 0;
            List<int> list = new List<int>();

            for (int i = 0; i < line.Length; i++)
                if (line[i] != 0)
                    list.Add(line[i]);
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    list[i] *= 2;
                    score += list[i];
                    list.RemoveAt(i + 1);
                }
            }
            while (list.Count < line.Length)
                list.Add(0);

            for (int i = 0; i < line.Length; i++)
                line[i] = list[i];

            return score;
        }

        static void AddRandomTile(int[,] board)
        {
            Random random = new Random();

            List<(int, int)> empty = new List<(int, int)>();

            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j] == 0)
                        empty.Add((i, j));

            if (empty.Count == 0) return;

            var cell = empty[random.Next(empty.Count)];
            board[cell.Item1, cell.Item2] = random.Next(100) < 90 ? 2 : 4;
        }

        static void SaveToFile(int[,] board)
        {
            using StreamWriter sw = new StreamWriter("save.txt");

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                    sw.Write(board[i, j] + " ");
                sw.WriteLine();
            }
        }

        static int[,] LoadFromFile(int size)
        {
            int[,] res = new int[size, size];
            if (!File.Exists("save.txt")) return res;

            using StreamReader sr = new StreamReader("save.txt");

            for (int i = 0; i < size; i++)
            {
                string[] parts = sr.ReadLine().Split(' ');

                for (int j = 0; j < size; j++)
                    res[i, j] = int.Parse(parts[j]);
            }

            return res;
        }
        static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                    Console.Write((board[i, j] == 0 ? "." : board[i, j].ToString()).PadLeft(5));

                Console.WriteLine();
            }
        }
    }
}