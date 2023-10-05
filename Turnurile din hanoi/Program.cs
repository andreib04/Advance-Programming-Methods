using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnurile_din_hanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //hanoi(4, 'A', 'B', 'C');

            hanoi4(8, 'A', 'B', 'C', 'D');
        }

        public static void hanoi(int n, char A, char B, char C) //3 tije
        {
            if (n == 1)
            {
                Console.WriteLine($"{A} -> {C}");
            }
            else
            {
                hanoi(n - 1, A, C, B);
                hanoi(1, A, B, C);
                hanoi(n - 1, B, A, C);
            }
        }

        public static void hanoi4(int n, char A, char B, char C, char D) //4 tije
        {
            if (n == 1)
            {
                Console.WriteLine($"{A} -> {D}");
            }
            else if (n == 2) 
            {
                Console.WriteLine($"{A} -> {C}\n" +
                                  $"{A} -> {D}\n" +
                                  $"{C} -> {D}");
            }
            else
            {
                hanoi4(n - 2, A, C, D, B);
                hanoi4(1, A, D, B, C);
                hanoi4(1, A, B, C, D);
                hanoi4(1, C, A, B, D);
                hanoi4(n - 2, B, A, C, D);
            }
        }
    }
}
