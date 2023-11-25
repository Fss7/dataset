using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using StringBuilder = System.Text.StringBuilder;
using System.Numerics;
using Point = System.Numerics.Complex;
using Number = System.Double;
using _ANSWER = System.Double;
namespace Program
{
    public class Solver
    {
        public void Solve()
        {
            var T = sc.Integer();
            var ans = new _ANSWER[T];
            var f = new Func<_ANSWER>[T];
            for (int _ = 0; _ < T; _++)
            {
                var n = sc.Integer();
                int k = sc.Integer();
                var p = sc.Double(n);
                f[_] = () => solve(n, k, p);
                //ans[_] = f[_]();
            }
            System.Threading.Tasks.Parallel.For(0, T, i => ans[i] = f[i]());
            for (int _ = 0; _ < T; _++)
            {
                IO.Printer.Out.WriteLine("Case #{0}: {1:0.000000000}", _ + 1, ans[_]);
            }
        }
        _ANSWER solve(int n, int k, double[] p)
        {
            Array.Sort(p);
            var max = 0.0;
            for (int _ = 0; _ <= k; _++)
            {
                var P = new List<double>();
                for (int i = 0; i < _; i++)
                {
                    P.Add(p[i]);
                }
                for (int i = 0; i < k - _; i++)
                    P.Add(p[p.Length - 1 - i]);
                P.Sort();
                var dp = new double[k + 1];
                dp[0] = 1;
                for (int i = 0; i < k; i++)
                {
                    var next = new double[k + 1];
                    for (int j = 0; j < k; j++)
                    {
                        next[j] += dp[j] * (1 - P[i]);
                        next[j + 1] += dp[j] * P[i];
                    }
                    dp = next;
                }
                max = Math.Max(max, dp[k / 2]);
            }
            //Debug.WriteLine(max - naive(n, k, p));
            return max;
        }
        double naive(int n, int k, double[] p)
        {
            var max = 0.0;
            var maxmask = 0;
            for (int _ = 0; _ < 1 << n; _++)
            {
                var P = new List<double>();
                for (int __ = 0; __ < n; __++)
                    if ((_ >> __ & 1) == 1) P.Add(p[__]);
                if (P.Count != k) continue;
                var sum = 0.0;
                for (int i = 0; i < 1 << k; i++)
                {
                    var cnt = 0;
                    var v = 1.0;
                    for (int j = 0; j < k; j++)
                        if ((i >> j & 1) == 1) { cnt++; v *= P[j]; }
                        else v *= (1 - P[j]);
                    if (cnt == k / 2) sum += v;
                }
                if (sum >= max)
                {
                    max = Math.Max(max, sum);
                    maxmask = _;
                }
            }
            var s = new char[n];
            for (int i = 0; i < n; i++)
                if ((maxmask >> i & 1) == 1) s[i] = 'o';
                else s[i] = 'x';
            return max;
        }
        public IO.StreamScanner sc = new IO.StreamScanner(Console.OpenStandardInput());
        static T[] Enumerate<T>(int n, Func<int, T> f) { var a = new T[n]; for (int i = 0; i < n; ++i) a[i] = f(i); return a; }
        static public void Swap<T>(ref T a, ref T b) { var tmp = a; a = b; b = tmp; }
    }
}
#region main
static class Ex
{
    static public string AsString(this IEnumerable<char> ie) { return new string(System.Linq.Enumerable.ToArray(ie)); }
    static public string AsJoinedString<T>(this IEnumerable<T> ie, string st = " ") { return string.Join(st, ie); }
    static public void Main()
    {
        var solver = new Program.Solver();
        solver.Solve();
        Program.IO.Printer.Out.Flush();
    }
}
#endregion
#region Ex
namespace Program.IO
{
    using System.IO;
    using System.Text;
    using System.Globalization;
    public class Printer : StreamWriter
    {
        static Printer() { Out = new Printer(Console.OpenStandardOutput()) { AutoFlush = false }; }
        public static Printer Out { get; set; }
        public override IFormatProvider FormatProvider { get { return CultureInfo.InvariantCulture; } }
        public Printer(System.IO.Stream stream) : base(stream, new UTF8Encoding(false, true)) { }
        public Printer(System.IO.Stream stream, Encoding encoding) : base(stream, encoding) { }
        public void Write<T>(string format, T[] source) { base.Write(format, source.OfType<object>().ToArray()); }
        public void WriteLine<T>(string format, T[] source) { base.WriteLine(format, source.OfType<object>().ToArray()); }
    }
    public class StreamScanner
    {
        public StreamScanner(Stream stream) { str = stream; }
        public readonly Stream str;
        private readonly byte[] buf = new byte[1024];
        private int len, ptr;
        public bool isEof = false;
        public bool IsEndOfStream { get { return isEof; } }
        private byte read()
        {
            if (isEof) return 0;
            if (ptr >= len) { ptr = 0; if ((len = str.Read(buf, 0, 1024)) <= 0) { isEof = true; return 0; } }
            return buf[ptr++];
        }
        public char Char() { byte b = 0; do b = read(); while ((b < 33 || 126 < b) && !isEof); return (char)b; }

        public string Scan()
        {
            var sb = new StringBuilder();
            for (var b = Char(); b >= 33 && b <= 126; b = (char)read())
                sb.Append(b);
            return sb.ToString();
        }
        public string ScanLine()
        {
            var sb = new StringBuilder();
            for (var b = Char(); b != '\n'; b = (char)read())
                if (b == 0) break;
                else if (b != '\r') sb.Append(b);
            return sb.ToString();
        }
        public long Long()
        {
            if (isEof) return long.MinValue;
            long ret = 0; byte b = 0; var ng = false;
            do b = read();
            while (b != 0 && b != '-' && (b < '0' || '9' < b));
            if (b == 0) return long.MinValue;
            if (b == '-') { ng = true; b = read(); }
            for (; true; b = read())
            {
                if (b < '0' || '9' < b)
                    return ng ? -ret : ret;
                else ret = ret * 10 + b - '0';
            }
        }
        public int Integer() { return (isEof) ? int.MinValue : (int)Long(); }
        public double Double() { var s = Scan(); return s != "" ? double.Parse(s, CultureInfo.InvariantCulture) : double.NaN; }
        private T[] enumerate<T>(int n, Func<T> f)
        {
            var a = new T[n];
            for (int i = 0; i < n; ++i) a[i] = f();
            return a;
        }

        public char[] Char(int n) { return enumerate(n, Char); }
        public string[] Scan(int n) { return enumerate(n, Scan); }
        public double[] Double(int n) { return enumerate(n, Double); }
        public int[] Integer(int n) { return enumerate(n, Integer); }
        public long[] Long(int n) { return enumerate(n, Long); }
    }
}
#endregion
