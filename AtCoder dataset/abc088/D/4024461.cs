using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Math;
using static AtCoder.cin;
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable JoinDeclarationAndInitializer
// ReSharper disable MemberCanBeMadeStatic.Local
// ReSharper disable PossibleNullReferenceException
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable SuggestVarOrType_Elsewhere
// ReSharper disable InvertIf
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertIfStatementToSwitchStatement
// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable TailRecursiveCall
// ReSharper disable RedundantUsingDirective
// ReSharper disable InlineOutVariableDeclaration
#pragma warning disable

namespace AtCoder
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X;
        public int Y;
    }
    public class Program
    {
        private readonly int[] dx = { 0, 1, -1, 0 };
        private readonly int[] dy = { 1, 0, 0, -1 };

        private bool[][] maze;
        private int[][] dist;
        private int H, W;
        private const int sx = 0, sy = 0;
        private int gy, gx;
        private const int INF = 10000000;

        void bfs()
        {
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(sx, sy));
            dist[sy][sx] = 0;

            while (queue.Any())
            {
                var item = queue.Dequeue();
                //Console.Error.WriteLine($"({item.X}, {item.Y}): {dist[item.X][item.Y]}");

                if (item.X == gx && item.Y == gy) break;
                for (int i = 0; i < 4; i++)
                {
                    var x = item.X + dx[i];
                    var y = item.Y + dy[i];
                    if (OutMap(x, y)) continue;
                    if (maze[y][x] && dist[x][y] == INF)
                    {
                        queue.Enqueue(new Point(x, y));
                        dist[x][y] = dist[item.X][item.Y] + 1;
                    }

                }
            }
        }

        //?????
        private void Solve()
        {
            H = ReadInt;
            W = ReadInt;
            gx = W - 1;
            gy = H - 1;

            maze = new bool[H][];
            dist = new int[W][];
            for (int i = 0; i < W; i++)
            {
                dist[i] = new int[H];
                for (int j = 0; j < H; j++)
                {
                    dist[i][j] = INF;
                }
            }
            for (int i = 0; i < H; i++)
            {
                maze[i] = ReadStr.Select(x => x == '.').ToArray();
            }
            var white_count = maze.SelectMany(x => x).Count(x => x);

            bfs();
            if (dist[gx][gy] == INF)
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine(white_count - dist[gx][gy] - 1);
        }

        bool OutMap(int x, int y) => !(x >= 0 && y >= 0 && x < W && y < H);

        /// <summary>a?b???????</summary>
        static void Swap<T>(ref T a, ref T b) where T : struct
        {
            var tmp = b;
            b = a;
            a = tmp;
        }

        /// <summary>a?b??????????</summary>
        static long Gcd(long a, long b)
        {
            if (a < b) Swap(ref a, ref b);
            return a % b == 0 ? b : Gcd(b, a % b);
        }

        /// <summary>a?b??????????</summary>
        static long Lcm(long a, long b) => a / Gcd(a, b) * b;

        public static void Print(params object[] args)
        {
            foreach (var s in args)
            {
                Console.WriteLine(s);
            }
        }

        public static void Main(string[] args)
        {
            new Program().Solve();
            Console.Read();
        }
    }

    public static class cin
    {
        private const char _separator = ' ';
        private static readonly Queue<string> _input = new Queue<string>();
        private static readonly StreamReader sr =
#if LOCAL
            new StreamReader("in.txt");
#else
            new StreamReader(Console.OpenStandardInput());
#endif

        public static string ReadLine => sr.ReadLine();

        public static string ReadStr => Read;

        public static string Read
        {
            get {
                if (_input.Count != 0) return _input.Dequeue();

                // ReSharper disable once PossibleNullReferenceException
                var tmp = sr.ReadLine().Split(_separator);
                foreach (var val in tmp)
                {
                    _input.Enqueue(val);
                }

                return _input.Dequeue();
            }
        }

        public static int ReadInt => int.Parse(Read);

        public static long ReadLong => long.Parse(Read);

        public static double ReadDouble => double.Parse(Read);

        public static string[] StrArray() => ReadLine.Split(' ');

        public static int[] IntArray() => ReadLine.Split(' ').Select(int.Parse).ToArray();

        public static long[] LongArray() => ReadLine.Split(' ').Select(long.Parse).ToArray();

        public static string[] StrArray(long n)
        {
            var ret = new string[n];
            for (long i = 0; i < n; ++i) ret[i] = Read;
            return ret;
        }

        public static int[] IntArray(long n) => StrArray(n).Select(int.Parse).ToArray();

        public static long[] LongArray(long n) => StrArray(n).Select(long.Parse).ToArray();

        static bool TypeEquals<T, U>() => typeof(T) == typeof(U);
        static T ChangeType<T, U>(U a) => (T)System.Convert.ChangeType(a, typeof(T));

        static T Convert<T>(string s) => TypeEquals<T, int>() ? ChangeType<T, int>(int.Parse(s))
            : TypeEquals<T, long>() ? ChangeType<T, long>(long.Parse(s))
            : TypeEquals<T, double>() ? ChangeType<T, double>(double.Parse(s))
            : TypeEquals<T, char>() ? ChangeType<T, char>(s[0])
            : ChangeType<T, string>(s);

        public static void Multi<T>(out T a) => a = Convert<T>(ReadStr);

        public static void Multi<T, U>(out T a, out U b)
        {
            var ar = StrArray(2);
            a = Convert<T>(ar[0]);
            b = Convert<U>(ar[1]);
        }

        public static void Multi<T, U, V>(out T a, out U b, out V c)
        {
            var ar = StrArray(3);
            a = Convert<T>(ar[0]);
            b = Convert<U>(ar[1]);
            c = Convert<V>(ar[2]);
        }
    }
}