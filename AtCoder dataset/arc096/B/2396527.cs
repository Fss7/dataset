using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
//using System.Numerics;  //comment out if AOJ
using System.Text;

using Problem = Tmp.Problem;
using MyIO;

#pragma warning disable   //for AOJ

namespace Tmp
{
    class Problem : IDisposable
    {
        bool IsGCJ;
        int Repeat;
        Scanner sc;
        Printer pr;
        public Problem(bool isGCJ, Scanner scanner, Printer printer)
        {
            sc = scanner;
            pr = printer;
            IsGCJ = isGCJ;
            if (isGCJ) Repeat = sc.nextInt();
            else Read();
        }
        public Problem(bool isGCJ) : this(isGCJ, new Scanner(), new Printer()) { }
        public Problem(bool isGCJ, Scanner scanner) : this(isGCJ, scanner, new Printer()) { }
        public Problem(bool isGCJ, Printer printer) : this(isGCJ, new Scanner(), printer) { }
        public void Solve()
        {
            if (IsGCJ) for (var i = 0; i < Repeat; i++) { Read(); pr.Write("Case #" + (i + 1) + ": "); SolveOne(); }
            else SolveOne();
        }
        public void Dispose()
        {
            sc.Dispose();
            pr.Dispose();
        }
        public int Size { get { return 1; } }
        public const long Mod = 1000000007;

        // ????????????
        // string S;
        // int a;
        int n;
        long  c, ans;
        long[] x, v;
        HashMap<long, long> map;
        /// <summary>
        /// ????????????
        /// </summary>
        void Read()
        {

        }
        /// <summary>
        /// ???????????
        /// </summary>
        void SolveOne()
        {
            n = sc.nextInt();
            c = sc.nextLong();
            x = new long[n];
            v = new long[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = sc.nextLong();
                v[i] = sc.nextLong();
            }

            long[,] imos = new long[n + 2, 3];
            long[,] rimos = new long[n + 2, 3];
            long[,] dp = new long[n + 2, 3];
            long[,] rdp = new long[n + 2, 3];

            for (int i = 0; i < 3; i++)
            {
                imos[0, i] = 0;
                imos[n + 1, i] = 0;
                rimos[0, i] = 0;
                rimos[n + 1, i] = 0;

                dp[0, i] = 0;
                dp[n + 1, i] = 0;
                rdp[0, i] = 0;
                rdp[n + 1, i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                imos[i + 1, 0] = imos[i, 0] + v[i];
                imos[i + 1, 1] = imos[i + 1, 0] - x[i];
                imos[i + 1, 2] = imos[i + 1, 0] - 2 * x[i];
                for (int j = 0; j < 3; j++)
                {
                    dp[i + 1, j] = Math.Max(dp[i, j], imos[i + 1, j]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                rimos[n - i, 0] = rimos[n - i + 1, 0] + v[n - i - 1];
                rimos[n - i, 1] = rimos[n - i, 0] - (c - x[n - i - 1]);
                rimos[n - i, 2] = rimos[n - i, 0] - 2 * (c - x[n - i - 1]);
                for (int j = 0; j < 3; j++)
                {
                    rdp[n - i, j] = Math.Max(rdp[n - i + 1, j], rimos[n - i, j]);
                }
            }

            ans = 0;
            for (int i = 0; i <= n; i++)
            {
                ans = Math.Max(ans,dp[i,1]+ rdp[i+1,2]);
                ans = Math.Max(ans,dp[i,2]+ rdp[i+1,1]);

            }

            Console.WriteLine(ans);
        }
    }
}
class Program
{
    //public static RandomSFMT rand = new RandomSFMT();
    public static bool IsJudgeMode = true;
    public static bool IsGCJMode = false;
    public static bool IsSolveCreated = true;
    static void Main()
    {
        if (IsJudgeMode)
            if (IsGCJMode) using (var problem = new Problem(true, new Scanner("C-large-practice.in.txt"), new Printer("output.txt"))) problem.Solve();
            else using (var problem = new Problem(false, new Printer())) problem.Solve();
        else
        {
            var num = 1;
            int size = 0;
            decimal time = 0;
            for (var tmp = 0; tmp < num; tmp++)
            {
                using (var P = IsSolveCreated ? new Problem(false, new Scanner("input.txt"), new Printer()) : new Problem(false))
                {
                    size = P.Size;
                    //time += Func.MeasureTime(() => P.Solve());
                }
            }
            Console.WriteLine("{0}, {1}ms", size, time / num);
        }
    }
}

/// <summary>
/// ????????IO
/// </summary>
namespace MyIO
{
    class Printer : IDisposable
    {
        bool isConsole;
        TextWriter file;
        public Printer() { file = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false }; isConsole = true; }
        public Printer(string path) { file = new StreamWriter(path, false) { AutoFlush = false }; isConsole = false; }
        public void Write<T>(T value) { file.Write(value); }
        public void Write(bool b) { file.Write(b ? "YES" : "NO"); }
        public void Write(string str, params object[] args) { file.Write(str, args); }
        public void WriteLine() { file.WriteLine(); }
        public void WriteLine<T>(T value) { file.WriteLine(value); }
        public void WriteLine(bool b) { file.WriteLine(b ? "YES" : "NO"); }
        public void WriteLine<T>(IEnumerable<T> list) { foreach (var x in list) file.WriteLine(x); }
        public void WriteLine<T>(List<T> list) { foreach (var x in list) file.WriteLine(x); }
        public void WriteLine<T>(T[] list) { foreach (var x in list) file.WriteLine(x); }
        public void WriteLine(string str, params object[] args) { file.WriteLine(str, args); }
        public void Dispose() { file.Flush(); if (!isConsole) file.Dispose(); }
    }
    class Scanner : IDisposable
    {
        bool isConsole;
        TextReader file;
        public Scanner() { file = Console.In; }
        public Scanner(string path) { file = new StreamReader(path); isConsole = false; }
        public void Dispose() { if (!isConsole) file.Dispose(); }

        #region next????
        string[] nextBuffer = new string[0];
        int BufferCnt = 0;

        char[] cs = new char[] { ' ' };

        public string next()
        {
            while (BufferCnt >= nextBuffer.Length)
            {
                string st = file.ReadLine();
                while (st == "") st = file.ReadLine();
                nextBuffer = st.Split(cs, StringSplitOptions.RemoveEmptyEntries);
                BufferCnt = 0;
            }
            return nextBuffer[BufferCnt++];
        }

        public int nextInt()
        {
            return int.Parse(next());
        }

        public long nextLong()
        {
            return long.Parse(next());
        }

        public double nextDouble()
        {
            return double.Parse(next());
        }

        private T[] enumerate<T>(int n, Func<T> f)
        {
            var a = new T[n];
            for (int i = 0; i < n; ++i) a[i] = f();
            return a;
        }

        public string[] next(int n) { return enumerate(n, next); }
        public double[] nextDouble(int n) { return enumerate(n, nextDouble); }
        public int[] nextInt(int n) { return enumerate(n, nextInt); }
        public long[] nextLong(int n) { return enumerate(n, nextLong); }
        #endregion
    }
}

class HashMap<K, V> : Dictionary<K, V>

{

    new public V this[K i]

    {

        get

        {

            V v;

            return TryGetValue(i, out v) ? v : base[i] = default(V);

        }

        set { base[i] = value; }

    }

}