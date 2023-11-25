using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AtCoder
{
    class Program
    {
        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }

        static void Main(string[] args)
        {
            string S = Read();
            int N = S.Length;
            int min = N;
            for (int i = 1; i < N; ++i)
            {
                if (S[i - 1] != S[i])
                {
                    min = Math.Min(Math.Max(i, N - i), min);
                }
            }
            Console.WriteLine(min);
        }
    }
}