using System;
using System.Linq;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using SB = System.Text.StringBuilder;
using Number = System.Int64;
using System.Numerics;
using static System.Math;
//using static MathEx;
namespace Program
{
    public class Solver
    {
        public void Solve()
        {
            var n = ri;
            var m = ri;
            var Q = Enumerate(n + 1, x => new List<KeyValuePair<int, int>>());
            for (int i = 0; i < m; i++)
            {
                var l = ri;
                var r = ri;
                var x = ri;
                Q[r].Add(new KeyValuePair<int, int>(l, x));
            }
            ModInteger ans = 0;
            var dp = new int[28372625];
            dp[0] = 1;
            for (int i = 0; i <= n; i++)
                for (int j = i; j <= n; j++)
                    for (int k = j; k <= n; k++)
                    {
                        var s = enc(i, j, k);
                        if (dp[s] == 0) continue;
                        //Debug.WriteLine("{0} {1} {2} {3}", i, j, k, dp[i, j, k]);
                        var max = Max(i, Max(j, k));
                        var ok = true;
                        foreach (var q in Q[max])
                        {
                            var cnt = 0;
                            if (q.Key <= i) cnt++;
                            if (q.Key <= j) cnt++;
                            if (q.Key <= k) cnt++;
                            if (cnt != q.Value)
                            {
                                ok = false;
                                break;
                            }
                        }
                        if (!ok) continue;
                        dp[s] %= 1000000007;

                        if (max == n) ans += dp[s];
                        dp[enc(j, k, max + 1)] += dp[s];
                        dp[enc(j, k, max + 1)] %= 1000000007;
                        dp[enc(i, k, max + 1)] += dp[s];
                        dp[enc(i, k, max + 1)] %= 1000000007;
                        dp[enc(i, j, max + 1)] += dp[s];
                        dp[enc(i, j, max + 1)] %= 1000000007;
                    }
            IO.Printer.Out.WriteLine(ans);
        }
        int enc(int i, int j, int k) => i * 302 * 302 + j * 302 + k;

        int ri => sc.Integer();
        long rl => sc.Long();
        double rd => sc.Double();
        string rs => sc.Scan();
        char rc => sc.Char();

        [System.Diagnostics.Conditional("DEBUG")]
        void put(params object[] a) => Debug.WriteLine(string.Join(" ", a));

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
    public class Printer: StreamWriter
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
#region ModNumber
public partial struct ModInteger
{
    public const long Mod = (long)1e9 + 7;
    public long num;
    public ModInteger(long n) { num = n; }
    public override string ToString() { return num.ToString(); }
    public static ModInteger operator +(ModInteger l, ModInteger r) { l.num += r.num; if (l.num >= Mod) l.num -= Mod; return l; }
    public static ModInteger operator -(ModInteger l, ModInteger r) { l.num -= r.num; if (l.num < 0) l.num += Mod; return l; }
    public static ModInteger operator *(ModInteger l, ModInteger r) { return new ModInteger(l.num * r.num % Mod); }
    public static implicit operator ModInteger(long n) { return new ModInteger(n); }
    public static ModInteger Pow(ModInteger v, long k)
    {
        ModInteger ret = 1;
        var n = k;
        for (; n > 0; n >>= 1, v *= v)
        {
            if ((n & 1) == 1)
                ret = ret * v;
        }
        return ret;
    }
}
#endregion