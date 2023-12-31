using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Competitive
{
    internal class Solution
    {
        public int N;
        public long[] A;
        public bool[] U;
        public long MOD = 1000000007;

        public void Run()
        {
            N = Input.ReadInt();
            A = Input.ReadLongArray();
            Array.Sort(A);

            U = new bool[N];
            for (int i = 0; i < N; i++)
            {
                U[i] = false;
            }

            int r = 0;
            for (int b = 40; b >= 0; b--)
            {
                long x = 1L << b;
                int j = 0;
                for (int i = N - 1; i >= 0; i--)
                {
                    if (U[i]) continue;
                    while (j < N)
                    {
                        if (!U[j] && i != j && A[i] + A[j] == x)
                        {
                            U[i] = true;
                            U[j] = true;
                            r++;
                            j++;
                            break;
                        }
                        else if (A[i] + A[j] > x)
                        {
                            break;
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
            }

            Console.WriteLine(r);
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