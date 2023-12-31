using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Enu = System.Linq.Enumerable;

public class Program
{
    public void Solve()
    {
        var S = Reader.String();
        var hash = new RollingHash(S);
        var hashrev = new RollingHash(new string(S.Reverse().ToArray()));
        long ans = 0;

        for (int i = S.Length / 2 + 1; i < S.Length - 1; i++)
        {
            int remLen = S.Length - i;
            int L = 0, R = Math.Min(i - 2, remLen - 1) + 1;
            while (R - L > 1)
            {
                int mid = (L + R) / 2;
                if (hash[0, mid] == hash[i, i + mid]) L = mid;
                else R = mid;
            }
            int A = L;
            L = 0; R = Math.Min(i - 2, remLen - 1) + 1;
            while (R - L > 1)
            {
                int mid = (L + R) / 2;
                if (hashrev[0, mid] == hashrev[remLen, remLen + mid]) L = mid;
                else R = mid;
            }
            int C = L;
            if (A > 0 && C > 0 && A + C >= remLen)
                ans += A - (remLen - C) + 1;
        }

        Console.WriteLine(ans);
    }

    class RollingHash
    {
        readonly int[] Mod = { (int)1e9 + 7, (int)1e9 + 9 };
        readonly int[][] Hash = new int[2][], Inv = new int[2][];

        public RollingHash(string A, int seed = -1)
        {
            var random = (seed == -1) ? new Random() : new Random(seed);
            for (int i = 0; i < 2; i++)
                Init(random.Next(10000, 20000), Mod[i], ref A, ref Hash[i], ref Inv[i]);
        }
        void Init(long x, long mod, ref string A, ref int[] hash, ref int[] inv)
        {
            int N = A.Length;
            hash = new int[N + 1];
            inv = new int[N + 1];
            inv[0] = 1;
            long powX = 1;
            long invX = ModPower(x, mod - 2, mod);
            for (int i = 0; i < N; i++)
            {
                hash[i + 1] = (int)((hash[i] + powX * A[i]) % mod);
                inv[i + 1] = (int)(inv[i] * invX % mod);
                powX = powX * x % mod;
            }
        }
        public long this[int L, int R] { get { return Get(L, R); } }
        public long Get(int L, int R)
        {
            return (((long)Hash[0][R] - Hash[0][L] + Mod[0]) * Inv[0][L] % Mod[0] << 32) +
                    ((long)Hash[1][R] - Hash[1][L] + Mod[1]) * Inv[1][L] % Mod[1];
        }
    }

    static long ModPower(long x, long n, long mod) // x ^ n
    {
        long res = 1;
        while (n > 0)
        {
            if ((n & 1) == 1) res = res * x % mod;
            x = x * x % mod;
            n >>= 1;
        }
        return res;
    }
}


class Entry { static void Main() { new Program().Solve(); } }
class Reader
{
    static TextReader reader = Console.In;
    static readonly char[] separator = { ' ' };
    static readonly StringSplitOptions op = StringSplitOptions.RemoveEmptyEntries;
    static string[] A = new string[0];
    static int i;
    static void Init() { A = new string[0]; }
    public static void Set(TextReader r) { reader = r; Init(); }
    public static void Set(string file) { reader = new StreamReader(file); Init(); }
    public static bool HasNext() { return CheckNext(); }
    public static string String() { return Next(); }
    public static int Int() { return int.Parse(Next()); }
    public static long Long() { return long.Parse(Next()); }
    public static double Double() { return double.Parse(Next()); }
    public static int[] IntLine() { return Array.ConvertAll(Split(Line()), int.Parse); }
    public static int[] IntArray(int N) { return Range(N, Int); }
    public static int[][] IntTable(int H) { return Range(H, IntLine); }
    public static string[] StringArray(int N) { return Range(N, Next); }
    public static string[][] StringTable(int N) { return Range(N, () => Split(Line())); }
    public static string Line() { return reader.ReadLine().Trim(); }
    static T[] Range<T>(int N, Func<T> f) { return Enu.Range(0, N).Select(i => f()).ToArray(); }
    static string[] Split(string s) { return s.Split(separator, op); }
    static string Next() { CheckNext(); return A[i++]; }
    static bool CheckNext()
    {
        if (i < A.Length) return true;
        string line = reader.ReadLine();
        if (line == null) return false;
        if (line == "") return CheckNext();
        A = Split(line);
        i = 0;
        return true;
    }
}