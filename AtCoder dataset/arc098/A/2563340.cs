using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Competitive
{
    internal class Solution
    {
        public int N;
        public string S;

        public void Run()
        {
            {
                N = Input.ReadInt();
                S = Console.ReadLine();
            }

            var E = new int[N];
            var W = new int[N];
            for (int i = 0; i < N; i++)
            {
                int e = S[i] == 'E' ? 1 : 0;
                int w = S[i] == 'W' ? 1 : 0;
                E[i] = i == 0 ? e : E[i - 1] + e;
                W[i] = i == 0 ? w : W[i - 1] + w;
            }

            int ret = int.MaxValue;

            for (int i = 0; i < N; i++)
            {
                int left = i == 0 ? 0 : W[i - 1]; 
                int right = E[N - 1] - E[i];
                int r = left + right;
                ret = Math.Min(ret, r);
            }

            Console.WriteLine(ret);
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