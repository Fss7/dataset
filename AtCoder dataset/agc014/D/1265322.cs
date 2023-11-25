using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

//using System.Threading;

namespace ReadWriteTemplate
{
    public static class Solver
    {
        public static List<Edge>[] e;

        private static void SolveCase()
        {
            int n = ReadInt();
            e = new List<Edge>[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                e[i] = new List<Edge>();
            }
            for (int i = 0; i < n - 1; i++)
            {
                int x = ReadInt();
                int y = ReadInt();
                e[x].Add(new Edge(x, y));
                e[y].Add(new Edge(y, x));
            }

            for (int i = 1; i <= n; i++)
            {
                foreach (Edge edge in e[i])
                {
                    if (edge.H == -1)
                    {
                        Dfs(edge);
                    }
                }
            }

            for (int i = 1; i <= n; i++)
            {
                int oddCount = 0;
                foreach (Edge edge in e[i])
                {
                    if (edge.H == 1)
                    {
                        oddCount++;
                        if (oddCount > 1)
                        {
                            Writer.Write("First");
                            return;
                        }
                    }
                }
            }
            Writer.Write("Second");
        }

        public static void Dfs(Edge edge)
        {
            int h = 1;
            foreach (Edge next in e[edge.Y])
            {
                if (next.Y == edge.X)
                {
                    continue;
                }
                if (next.H == -1)
                {
                    Dfs(next);
                }
                if (next.H == 1)
                {
                    h = 0;
                }
            }
            edge.H = h;
        }

        public class Edge
        {
            public Edge(int x, int y)
            {
                X = x;
                Y = y;
                H = -1;
            }

            public int X;

            public int Y;

            public int H;
        }

        public static void Solve()
        {
            //int T = ReadInt();
            //for (int i = 0; i < T; i++)
            {
                //Writer.Write("Case #{0}: ", i + 1);
                SolveCase();
            }
        }

        public static void Main()
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

#if DEBUG
            Reader = File.OpenText("input.txt"); Writer = File.CreateText("output.txt");
#else
            Reader = Console.In; Writer = Console.Out;
#endif
            //Reader = File.OpenText("concatenation.in"); Writer = File.CreateText("concatenation.out");

            Solve();

            Reader.Close();
            Writer.Close();
        }

        public static IOrderedEnumerable<TSource> OrderByWithShuffle<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.Shuffle().OrderBy(keySelector);
        }

        public static T[] Shuffle<T>(this IEnumerable<T> source)
        {
            T[] result = source.ToArray();
            Random rnd = new Random();
            for (int i = result.Length - 1; i >= 1; i--)
            {
                int k = rnd.Next(i + 1);
                T tmp = result[k];
                result[k] = result[i];
                result[i] = tmp;
            }
            return result;
        }

        #region Read/Write

        private static TextReader Reader;

        private static TextWriter Writer;

        private static Queue<string> CurrentLineTokens = new Queue<string>();

        private static string[] ReadAndSplitLine()
        {
            return Reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string ReadToken()
        {
            while (CurrentLineTokens.Count == 0)
                CurrentLineTokens = new Queue<string>(ReadAndSplitLine());
            return CurrentLineTokens.Dequeue();
        }

        public static string ReadLine()
        {
            return Reader.ReadLine();
        }

        public static int ReadInt()
        {
            return int.Parse(ReadToken());
        }

        public static long ReadLong()
        {
            return long.Parse(ReadToken());
        }

        public static double ReadDouble()
        {
            return double.Parse(ReadToken(), CultureInfo.InvariantCulture);
        }

        public static int[] ReadIntArray()
        {
            return ReadAndSplitLine().Select(int.Parse).ToArray();
        }

        public static long[] ReadLongArray()
        {
            return ReadAndSplitLine().Select(long.Parse).ToArray();
        }

        public static double[] ReadDoubleArray()
        {
            return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        }

        public static int[][] ReadIntMatrix(int numberOfRows)
        {
            int[][] matrix = new int[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
                matrix[i] = ReadIntArray();
            return matrix;
        }

        public static string[] ReadLines(int quantity)
        {
            string[] lines = new string[quantity];
            for (int i = 0; i < quantity; i++)
                lines[i] = Reader.ReadLine().Trim();
            return lines;
        }

        public static void WriteArray<T>(IEnumerable<T> array)
        {
            Writer.WriteLine(string.Join(" ", array));
        }

        #endregion
    }
}