using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Competitive
{
    internal class Solution
    {
        public int N;
        public char[,] S;

        public void Run()
        {
            // input
            N = Input.ReadInt();
            S = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < N; j++)
                    S[i, j] = line[j];
            }

            // check
            int[] F = new int[N];
            for (int a = 0; a < N; a++)
            {
                F[a] = Check(a) ? 1 : 0;
            }

            // calc
            int ret = 0;
            for (int y = 0; y < N; y++)
                for (int x = 0; x < N; x++)
                {
                    int a = (y - x + 2 * N) % N;
                    ret += F[a];
                }

            Console.WriteLine(ret);
        }

        public bool Check(int a)
        {
            for (int y = 0; y < N; y++)
                for (int x = 0; x < N; x++)
                {
                    if (SlidedCell(y, x, a) != SlidedCell(x, y, a)) return false;
                }

            return true;
        }

        public char SlidedCell(int y, int x, int a)
        {
            return S[y, (x - a + 2 * N) % N];
        }
    }

    // libs ----------


    // common ----------

    internal static class Input
    {
        public static string ReadString()
        {
            string line = Console.ReadLine();
            return line;
        }

        public static int ReadInt()
        {
            string line = Console.ReadLine();
            return int.Parse(line);
        }

        public static int[] ReadIntArray()
        {
            string line = Console.ReadLine();
            return line.Split(' ').Select(int.Parse).ToArray();
        }

        public static long ReadLong()
        {
            string line = Console.ReadLine();
            return long.Parse(line);
        }

        public static long[] ReadLongArray()
        {
            string line = Console.ReadLine();
            return line.Split(' ').Select(long.Parse).ToArray();
        }

        public static double[] ReadDoubleArray()
        {
            string line = Console.ReadLine();
            return line.Split(' ').Select(double.Parse).ToArray();
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new Solution();
            s.Run();
        }
    }
}