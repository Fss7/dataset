using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using StringBuilder = System.Text.StringBuilder;
using System.Numerics;

namespace Program
{

    public class Solver
    {
        public void Solve()
        {
            var n = sc.Integer();
            var plus = new List<Pair<long, long>>();
            var zero = 0L;
            var mynus = new List<Pair<long, long>>();
            for (int i = 0; i < n; i++)
            {
                var a = sc.Integer();
                var b = sc.Integer();
                var total = a - b;
                if (total > 0) plus.Add(new Pair<long, long>(a, total));
                else if (total == 0) zero = Math.Max(zero, a);
                else mynus.Add(new Pair<long, long>(a, total));
            }
            mynus.Sort();
            plus.Sort((l, r) => (l.x - l.y).CompareTo((r.x - r.y)));
            plus.Reverse();
            Func<long, long> f = (lim) =>
                {
                    var v = 0L;
                    var max = 0L;
                    var ok = true;
                    foreach (var x in mynus)
                    {
                        max = Math.Max(max, v + x.x);
                        v += x.y;
                        Debug.WriteLine(v);
                    }
                    max = Math.Max(max, v + zero);
                    foreach (var x in plus)
                    {
                        max = Math.Max(max, v + x.x);
                        v += x.y;
                        Debug.WriteLine(v);
                    }

                    return max;
                };
            IO.Printer.Out.WriteLine(f(-1));

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
#region Compair
static public class Pair
{
    static public Pair<FT, ST> Create<FT, ST>(FT f, ST s)
        where FT : IComparable<FT>
        where ST : IComparable<ST>
    { return new Pair<FT, ST>(f, s); }
    static public Pair<FT, ST> Min<FT, ST>(Pair<FT, ST> p, Pair<FT, ST> q)
        where FT : IComparable<FT>
        where ST : IComparable<ST>
    { return (p.CompareTo(q) <= 0) ? p : q; }
    static public Pair<FT, ST> Max<FT, ST>(Pair<FT, ST> p, Pair<FT, ST> q)
        where FT : IComparable<FT>
        where ST : IComparable<ST>
    { return (p.CompareTo(q) >= 0) ? p : q; }
}
public struct Pair<FT, ST> : IComparable<Pair<FT, ST>>
    where FT : IComparable<FT>
    where ST : IComparable<ST>
{
    public FT x;
    public ST y;
    public Pair(FT f, ST s) : this() { x = f; y = s; }

    public int CompareTo(Pair<FT, ST> other)
    {
        var cmp = x.CompareTo(other.x);
        return cmp != 0 ? cmp : y.CompareTo(other.y);
    }
    public override string ToString() { return string.Format("{0} {1}", x, y); }
}
#endregion