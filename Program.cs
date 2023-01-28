using System;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp3
{
    class Program
    {
        static int x = Console.CursorLeft; //Расстояние относительно левой стороны
        static int y = Console.CursorTop; //Расстояние относительно верха
        static string texture = "☻"; //Наша текстурка
        static bool pog = false;
        static bool win = false;
        static int[,] arr = new int[20, 20];
        static int ig = 0;
        static int jg = 0;
        static int count = 6;
        static void Main(string[] args)
        {

            BigInteger num1 = BigInteger.Parse("111111111111111111121000001111111110111121001100000100000000021001101110101111100021000000110001000001121110111111111011111121110110000000000000021110110111111111010210000000111111100010210111110000001101110210111111111101101100210100000001101100001210101111100001111011210100001111101111011210111101111100000011210000001111111101111211111110100000000000210000000111111111110021010111111110111110021110000000000000000");
            while (count != 400)
            {
                if (jg == 20)
                {
                    ig++;
                    jg = 0;
                    Console.WriteLine();
                }
                if (num1%10 != 2)
                {
                    if (num1 % 10 == 0)
                    {
                        Console.Write(" ");
                        arr[ig, jg] = 0;
                    }
                    else if (num1 % 10 == 1)
                    {
                        Console.Write("#");
                        arr[ig, jg] = 1;
                    }                                      
                    jg++;
                }
                count++;
                num1 = num1 / 10;
            }
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(19,i);
                Console.Write("#");
                Console.SetCursorPosition(i, 19);
                Console.Write("#");
            }

            Console.SetCursorPosition(18, 18);
            Console.Write("P");
            Console.SetCursorPosition(0, 0);
            Console.Write(texture);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (Console.CursorTop == 18 && Console.CursorLeft == 18)
                {
                    win = true;
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth/2,Console.WindowHeight);
                    Console.WriteLine("Вы победили!!!");
                }
                if (!win)
                {
                    Move(key);
                }
            }
        }
        /// <summary>
        /// Метод управления текстурой
        /// </summary>
        /// <param name="key">Передается нажатая клавиша</param>
        public static void Move(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W && y > 0)
            {
                if (MoveT(y,x))
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(x, y - 1);

                    y = Console.CursorTop;
                    Console.Write(texture);
                }
            }
            if (key.Key == ConsoleKey.S && y < 18)
            {
                if (MoveB(y,x))
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(x, y + 1);

                    y = Console.CursorTop;
                    Console.Write(texture);
                }
            }
            if (key.Key == ConsoleKey.A && x > 0)
            {
                if (MoveL(y,x))
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                    Console.SetCursorPosition(x - 1, y);

                    x = Console.CursorLeft;
                    Console.Write(texture);
                }
            }
            if (key.Key == ConsoleKey.D && x < 19)
            {
                if (MoveR(y, x))
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                    Console.SetCursorPosition(x + 1, y);

                    x = Console.CursorLeft;
                    Console.Write(texture);
                }
            }
        }
     
        /// <summary>
        /// методы коллизии для каждой клавиши движения(T - Top, B - Bottom, R - Right, L - Left)
        /// </summary>
        /// <param name="y">Передача координаты y</param>
        /// <param name="x">Передача координаты x</param>
        /// <returns></returns>
        public static bool MoveR(int y, int x)
        {
            if (arr[y,x+1] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool MoveL(int y, int x)
        {
            if (arr[y, x - 1] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool MoveT(int y, int x)
        {
            if (arr[y-1, x] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool MoveB(int y, int x)
        {
            if (arr[y+1, x] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
