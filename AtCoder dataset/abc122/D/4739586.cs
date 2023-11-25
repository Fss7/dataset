using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve();
        }
        private const int MOD = 1000000007;
        private const int INF = 100000000;
        private static char[] table = new char[] { 'A', 'C', 'G', 'T' };
        private static int[,,,] dp = new int[101, 4, 4, 4];
        static void Solve()
        {
            var n = ReadAndParseInt();
            dp[0, 3, 3, 3] = 1;
            for(int len = 0;len<n;++len)
            {
                for(int c1 = 0;c1<4;++c1)
                {
                    for(int c2=0;c2<4;++c2)
                    {
                        for (int c3 = 0; c3 < 4; ++c3)
                        {
                            if (dp[len, c1, c2, c3] == 0) { continue; }

                            for (int a = 0; a < 4; ++a)
                            {
                                if (a == 2 && c1 == 1 && c2 == 0) { continue; }
                                if (a == 1 && c1 == 2 && c2 == 0) { continue; }
                                if (a == 1 && c1 == 0 && c2 == 2) { continue; }
                                if (a == 1 && c1 == 2 && c3 == 0) { continue; }
                                if (a == 1 && c2 == 2 && c3 == 0) { continue; }

                                dp[len + 1, a, c1, c2] += dp[len, c1, c2, c3];
                                dp[len + 1, a, c1, c2] %= MOD;
                            }
                        }
                    }
                }
            }
            var ans = 0;
            for (int c1 = 0; c1 < 4; ++c1)
            {
                for (int c2 = 0; c2 < 4; ++c2)
                {
                    for (int c3 = 0; c3 < 4; ++c3)
                    {
                        ans += dp[n, c1, c2, c3];
                        ans %= MOD;
                    }
                }
            }
            Console.WriteLine(ans);
        }

        #region ????????
        private static bool isPrime(long x)
        {
            if (x == 2) { return true; }
            if (x < 2 || x % 2 == 0) { return false; }
            long i = 3;
            while (i * i <= x)
            {
                if (x % i == 0) { return false; }
                i = i + 2;
            }
            return true;
        }
        private static long lcm(long x, long y)
        {
            return x / gcd(x, y) * y;
        }
        private static long gcd(long x, long y)
        {
            return y > 0 ? gcd(y, x % y) : x;
        }
        private static long pow(long x, long n)
        {
            if (n == 0) { return 1; }
            long res = pow(x * x % MOD, n / 2);
            if (n % 2 == 1)
            {
                res = res * x % MOD;
            }
            return res;
        }
        private static int ReadAndParseInt()
        {
            return int.Parse(Console.ReadLine());
        }
        private static int[] ReadAndParseIntArr()
        {
            return Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        }
        private static long ReadAndParseLong()
        {
            return long.Parse(Console.ReadLine());
        }
        private static long[] ReadAndParseLongArr()
        {
            return Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T t = x;
            x = y;
            y = t;
        }

        /// <summary>
        /// ???????????????????
        /// </summary>
        /// <typeparam name="T">???????</typeparam>
        /// <param name="arr">??????????????????</param>
        /// <param name="start">??????? [inclusive]</param>
        /// <param name="end">??????? [exclusive]</param>
        /// <param name="value">?????</param>
        /// <param name="comparer">????(????????)</param>
        /// <returns>????????????????</returns>
        public static int LowerBound<T>(IReadOnlyList<T> arr, int start, int end, T value, IComparer<T> comparer)
        {
            int low = start;
            int high = end;
            int mid;
            while (low < high)
            {
                mid = ((high - low) >> 1) + low;
                if (comparer.Compare(arr[mid], value) < 0)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }

        //????????????
        public static int LowerBound<T>(IReadOnlyList<T> arr, T value) where T : IComparable
        {
            return LowerBound(arr, 0, arr.Count, value, Comparer<T>.Default);
        }

        /// <summary>
        /// ?????????????????????
        /// </summary>
        /// <typeparam name="T">???????</typeparam>
        /// <param name="arr">??????????????????</param>
        /// <param name="start">??????? [inclusive]</param>
        /// <param name="end">??????? [exclusive]</param>
        /// <param name="value">?????</param>
        /// <param name="comparer">????(????????)</param>
        /// <returns>??????????????????</returns>
        public static int UpperBound<T>(IReadOnlyList<T> arr, int start, int end, T value, IComparer<T> comparer)
        {
            int low = start;
            int high = end;
            int mid;
            while (low < high)
            {
                mid = ((high - low) >> 1) + low;
                if (comparer.Compare(arr[mid], value) <= 0)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }

        //????????????
        public static int UpperBound<T>(IReadOnlyList<T> arr, T value)
        {
            return UpperBound(arr, 0, arr.Count, value, Comparer<T>.Default);
        }
        #endregion
    }

    public class DisjointSet
    {
        private int[] rank;
        private int[] p;
        private int[] size;
        public DisjointSet(int n)
        {
            rank = new int[n];
            p = new int[n];
            size = new int[n];
            for (int i = 0; i < n; ++i)
            {
                MakeSet(i);
            }
        }
        public void MakeSet(int x)
        {
            p[x] = x;
            rank[x] = 0;
            size[x] = 1;
        }
        public bool IsSame(int x, int y)
        {
            return FindSet(x) == FindSet(y);
        }
        public void Unite(int x, int y)
        {
            Link(FindSet(x), FindSet(y));
        }
        public void Link(int x, int y)
        {
            if (rank[x] > rank[y])
            {
                p[y] = x;
                size[x] += size[y];
                size[y] = 0;
            }
            else
            {
                p[x] = y;
                size[y] += size[x];
                size[x] = 0;
                if (rank[x] == rank[y])
                {
                    rank[y]++;
                }
            }
        }
        public int FindSet(int x)
        {
            if (x != p[x])
            {
                p[x] = FindSet(p[x]);
            }
            return p[x];
        }
        public int Size(int x)
        {
            int root = FindSet(x);
            return size[root];
        }
    }
}