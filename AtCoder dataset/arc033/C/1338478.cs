using System;
using System.Linq;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using SB = System.Text.StringBuilder;
//using System.Numerics;
using Number = System.Int64;
//using static System.Math;
//using static MathEx;
//using P = System.Collections.Generic.KeyValuePair<int, int>;
namespace Program
{
    public class Solver
    {
        public void Solve()
        {
            var q = sc.Integer();
            /*
            var times = new List<long>();
            var rand = new Random(0);
            for (int _ = 0; _ < 11; _++)
            {
                var s = new Set<int>();
                s.IsMultiSet = true;

                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                for (int i = 0; i < 200000; i++)
                    s.Add(rand.Next());
                for (int i = 0; i < 200000; i++)
                    s.RemoveAt(rand.Next() % s.Count);
                sw.Stop();
                times.Add(sw.ElapsedMilliseconds);
            }
            IO.Printer.Out.WriteLine(times.AsJoinedString());
            times.Sort();
            IO.Printer.Out.WriteLine(times[5]);
            IO.Printer.Out.WriteLine(times.Average());
            return;
            times.Clear();
            rand = new Random(0);
            for (int _ = 0; _ < 11; _++)
            {
                var s = new S<int>();
                s.IsMultiSet = true;

                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                for (int i = 0; i < 1000000; i++)
                    s.Add(rand.Next());
                for (int i = 0; i < 1000000; i++)
                    s.RemoveAt(rand.Next() % s.Count);
                sw.Stop();
                times.Add(sw.ElapsedMilliseconds);
            }
            IO.Printer.Out.WriteLine(times.AsJoinedString());
            times.Sort();
            IO.Printer.Out.WriteLine(times[5]);
            IO.Printer.Out.WriteLine(times.Average());
            return;
            //*/
            //*
            var s = new Set<int>();
            for (int i = 0; i < q; i++)
            {
                Debug.WriteLine(s.Items.AsJoinedString());
                if (sc.Integer() == 1) s.Add(sc.Integer());
                else
                {
                    var k = sc.Integer() - 1;
                    var v = s[k];
                    IO.Printer.Out.WriteLine(v);
                    s.Remove(v);
                }
            }
            //*/
        }

        //*
        int ri => sc.Integer();
        long rl => sc.Long();
        double rd => sc.Double();
        string rs => sc.Scan();
        char rc => sc.Char();

        [System.Diagnostics.Conditional("DEBUG")]
        void put(params object[] a) => Debug.WriteLine(string.Join(" ", a));

        //*/
        public IO.StreamScanner sc = new IO.StreamScanner(Console.OpenStandardInput());

        static T[] Enumerate<T>(int n, Func<int, T> f)
        {
            var a = new T[n];
            for (int i = 0; i < n; ++i) a[i] = f(i);
            return a;
        }
        static void Swap<T>(ref T a, ref T b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }
}

#region main

static class Ex
{
    public static string AsString(this IEnumerable<char> ie)
    {
        return new string(ie.ToArray());
    }

    public static string AsJoinedString<T>(this IEnumerable<T> ie, string st = " ")
    {
        return string.Join(st, ie);
    }

    public static void Main()
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
        static Printer()
        {
            Out = new Printer(Console.OpenStandardOutput()) { AutoFlush = false };
        }

        public static Printer Out { get; set; }

        public override IFormatProvider FormatProvider
        {
            get { return CultureInfo.InvariantCulture; }
        }

        public Printer(Stream stream) : base(stream, new UTF8Encoding(false, true))
        {
        }

        public Printer(Stream stream, Encoding encoding) : base(stream, encoding)
        {
        }

        public void Write<T>(string format, T[] source)
        {
            base.Write(format, source.OfType<object>().ToArray());
        }

        public void WriteLine<T>(string format, T[] source)
        {
            base.WriteLine(format, source.OfType<object>().ToArray());
        }
    }

    public class StreamScanner
    {
        public StreamScanner(Stream stream)
        {
            str = stream;
        }

        public readonly Stream str;
        private readonly byte[] buf = new byte[1024];
        private int len, ptr;
        public bool isEof;

        public bool IsEndOfStream
        {
            get { return isEof; }
        }

        private byte read()
        {
            if (isEof) return 0;
            if (ptr < len) return buf[ptr++];
            ptr = 0;
            if ((len = str.Read(buf, 0, 1024)) > 0) return buf[ptr++];
            isEof = true;
            return 0;
        }

        public char Char()
        {
            byte b;
            do b = read(); while ((b < 33 || 126 < b) && !isEof);
            return (char)b;
        }

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
            long ret = 0;
            byte b;
            var ng = false;
            do b = read(); while (b != 0 && b != '-' && (b < '0' || '9' < b));
            if (b == 0) return long.MinValue;
            if (b == '-')
            {
                ng = true;
                b = read();
            }
            for (; ; b = read())
            {
                if (b < '0' || '9' < b)
                    return ng ? -ret : ret;
                ret = ret * 10 + b - '0';
            }
        }

        public int Integer()
        {
            return (isEof) ? int.MinValue : (int)Long();
        }

        public double Double()
        {
            var s = Scan();
            return s != "" ? double.Parse(s, CultureInfo.InvariantCulture) : double.NaN;
        }

        static T[] enumerate<T>(int n, Func<T> f)
        {
            var a = new T[n];
            for (int i = 0; i < n; ++i) a[i] = f();
            return a;
        }

        public char[] Char(int n)
        {
            return enumerate(n, Char);
        }

        public string[] Scan(int n)
        {
            return enumerate(n, Scan);
        }

        public double[] Double(int n)
        {
            return enumerate(n, Double);
        }

        public int[] Integer(int n)
        {
            return enumerate(n, Integer);
        }

        public long[] Long(int n)
        {
            return enumerate(n, Long);
        }
    }
}

#endregion


public class Set<T>
{
    Node root;
    IComparer<T> comparer;
    readonly Node nil;
    public bool IsMultiSet { get; set; }
    public Set(IComparer<T> comparer)
    {
        nil = new Node(default(T));
        root = nil;
        this.comparer = comparer;
    }
    public Set(Comparison<T> comaprison) : this(Comparer<T>.Create(comaprison)) { }
    public Set() : this(Comparer<T>.Default) { }
    public bool Add(T v)
    {
        key = v;
        return insert(ref root);
    }
    public bool Remove(T v)
    {
        key = v;
        return remove(ref root);
    }
    public T this[int index] { get { return find(root, index); } }
    public int Count { get { return root.Count; } }
    public void RemoveAt(int k)
    {
        if (k < 0 || k >= root.Count) throw new ArgumentOutOfRangeException();
        removeAt(ref root, k);
    }
    public T[] Items
    {
        get
        {
            var ret = new T[root.Count];
            var k = 0;
            walk(root, ret, ref k);
            return ret;
        }
    }
    void walk(Node t, T[] a, ref int k)
    {
        if (t.Count == 0) return;
        walk(t.lst, a, ref k);
        a[k++] = t.Key;
        walk(t.rst, a, ref k);
    }

    T key;
    bool insert(ref Node t)
    {
        if (t == nil) { t = new Node(key); t.lst = t.rst = nil; t.Update(); return true; }
        var cmp = comparer.Compare(t.Key, key);
        bool res;
        if (cmp > 0)
            res = insert(ref t.lst);
        else if (cmp == 0)
        {
            if (IsMultiSet) res = insert(ref t.lst);
            else return false;
        }
        else res = insert(ref t.rst);
        balance(ref t);
        return res;
    }
    bool remove(ref Node t)
    {
        if (t == nil) return false;
        var cmp = comparer.Compare(key, t.Key);
        bool ret;
        if (cmp < 0) ret = remove(ref t.lst);
        else if (cmp > 0) ret = remove(ref t.rst);
        else
        {
            ret = true;
            var k = t.lst.Count;
            if (k == 0) { t = t.rst; return true; }
            if (t.rst.Count == 0) { t = t.lst; return true; }


            t.Key = find(t.lst, k - 1);
            removeAt(ref t.lst, k - 1);
        }
        balance(ref t);
        return ret;
    }
    void removeAt(ref Node t, int k)
    {
        var cnt = t.lst.Count;
        if (cnt < k) removeAt(ref t.rst, k - cnt - 1);
        else if (cnt > k) removeAt(ref t.lst, k);
        else
        {
            if (cnt == 0) { t = t.rst; return; }
            if (t.rst.Count == 0) { t = t.lst; return; }

            t.Key = find(t.lst, k - 1);
            removeAt(ref t.lst, k - 1);
        }
        balance(ref t);
    }
    void balance(ref Node t)
    {
        var balance = t.lst.Height - t.rst.Height;
        if (balance == -2)
        {
            if (t.rst.lst.Height - t.rst.rst.Height > 0) rotR(ref t.rst);
            rotL(ref t);
        }
        else if (balance == 2)
        {
            if (t.lst.lst.Height - t.lst.rst.Height < 0) rotL(ref t.lst);
            rotR(ref t);
        }
        else t.Update();
    }

    T find(Node t, int k)
    {
        if (k < 0 || k > root.Count) throw new ArgumentOutOfRangeException();
        for (;;)
        {
            if (k == t.lst.Count) return t.Key;
            else if (k < t.lst.Count) t = t.lst;
            else { k -= t.lst.Count + 1; t = t.rst; }
        }
    }
    int LowerBound(T v)
    {
        var k = 0;
        var t = root;
        for (;;)
        {
            if (t == nil) return k;
            if (comparer.Compare(v, t.Key) <= 0) t = t.lst;
            else { k += t.lst.Count + 1; t = t.rst; }
        }
    }
    int UpperBound(T v)
    {
        var k = 0;
        var t = root;
        for (;;)
        {
            if (t == nil) return k;
            if (comparer.Compare(t.Key, v) <= 0) { k += t.lst.Count + 1; t = t.rst; }
            else t = t.lst;
        }
    }

    void rotR(ref Node t)
    {
        var l = t.lst;
        t.lst = l.rst;
        l.rst = t;
        t.Update();
        l.Update();
        t = l;
    }
    void rotL(ref Node t)
    {
        var r = t.rst;
        t.rst = r.lst;
        r.lst = t;
        t.Update();
        r.Update();
        t = r;
    }


    class Node
    {
        public Node(T key)
        {
            Key = key;
        }
        public int Count { get; private set; }
        public sbyte Height { get; private set; }
        public T Key { get; set; }
        public Node lst, rst;
        public void Update()
        {
            Count = 1 + lst.Count + rst.Count;
            Height = (sbyte)(1 + Math.Max(lst.Height, rst.Height));
        }
        public override string ToString()
        {
            return string.Format("Count = {0}, Key = {1}", Count, Key);
        }
    }
}

public class S<T>
{
    readonly IComparer<T> comparer;
    public bool IsMultiSet { get; set; }
    Node root = Node.nil;
    Node deleted = Node.nil;
    T key;


    public S(IComparer<T> comparer) { this.comparer = comparer; }
    public S(Comparison<T> comaprison) : this(Comparer<T>.Create(comaprison)) { }
    public S() : this(Comparer<T>.Default) { }

    public bool Add(T v)
    {
        key = v;
        return insert(ref root);
    }
    public bool Remove(T v)
    {
        deleted = Node.nil;
        key = v;
        return remove(ref root);
    }
    public T this[int index] { get { return find(root, index); } }
    public int Count { get { return root.Count; } }
    public void RemoveAt(int k)
    {
        if (k < 0 || k >= root.Count) throw new ArgumentOutOfRangeException();
        deleted = Node.nil;
        removeAt(ref root, k);
    }
    public T[] Items
    {
        get
        {
            var ret = new T[root.Count];
            var k = 0;
            walk(root, ret, ref k);
            return ret;
        }
    }

    int LowerBound(T v)
    {
        var k = 0;
        var t = root;
        for (;;)
        {
            if (t.Count == 0) return k;
            if (comparer.Compare(v, t.Key) <= 0) t = t.lst;
            else { k += t.lst.Count + 1; t = t.rst; }
        }
    }
    int UpperBound(T v)
    {
        var k = 0;
        var t = root;
        for (;;)
        {
            if (t.Count == 0) return k;
            if (comparer.Compare(t.Key, v) <= 0) { k += t.lst.Count + 1; t = t.rst; }
            else t = t.lst;
        }
    }
    void walk(Node t, T[] a, ref int k)
    {
        if (t.Count == 0) return;
        walk(t.lst, a, ref k);
        a[k++] = t.Key;
        walk(t.rst, a, ref k);
    }


    bool insert(ref Node t)
    {
        if (t.Count == 0) t = new Node(key);
        else
        {
            var cmp = comparer.Compare(key, t.Key);
            if (!IsMultiSet && cmp == 0) return false;
            else if (cmp <= 0) insert(ref t.lst);
            else insert(ref t.rst);
            skew(ref t);
            split(ref t);
            t.Update();
        }
        return true;
    }
    void removeAt(ref Node t, int k)
    {
        var cnt = t.lst.Count;
        if (cnt < k) removeAt(ref t.rst, k - cnt - 1);
        else if (cnt > k) removeAt(ref t.lst, k);
        else
        {
            key = t.Key;
            remove(ref t);
            return;
        }
        if (t.lst.Rank < t.Rank - 1 || t.rst.Rank < t.Rank - 1)
        {
            t.Rank--;
            if (t.rst.Rank > t.Rank) t.rst.Rank = t.Rank;
            skew(ref t);
            skew(ref t.rst);
            skew(ref t.rst.rst);
            split(ref t);
            split(ref t.rst);
        }
        t.Update();
    }
    bool remove(ref Node t)
    {
        if (t.Count == 0) return deleted.Count != 0;
        var cmp = comparer.Compare(key, t.Key);
        if (cmp < 0)
        {
            if (!remove(ref t.lst)) return false;
        }
        else
        {
            if (cmp == 0) deleted = t;
            if (!remove(ref t.rst)) return false;
        }
        if (deleted.Count != 0)
        {
            deleted.Key = t.Key;
            deleted = Node.nil;
            t = t.rst;
        }
        else if (t.lst.Rank < t.Rank - 1 || t.rst.Rank < t.Rank - 1)
        {
            t.Rank--;
            if (t.rst.Rank > t.Rank) t.rst.Rank = t.Rank;
            skew(ref t);
            skew(ref t.rst);
            skew(ref t.rst.rst);
            split(ref t);
            split(ref t.rst);
        }
        t.Update();
        return true;
    }
    T find(Node t, int k)
    {
        if (k < 0 || k > root.Count) throw new ArgumentOutOfRangeException();
        for (;;)
        {
            var cnt = t.lst.Count;
            if (k == cnt) return t.Key;
            else if (k < cnt) t = t.lst;
            else { k -= t.lst.Count + 1; t = t.rst; }
        }
    }
    void skew(ref Node t)
    {
        if (t.lst.Rank == t.Rank) { var l = t.lst; t.lst = l.rst; l.rst = t; t.Update(); l.Update(); t = l; }

    }
    void split(ref Node t)
    {
        if (t.rst.rst.Rank == t.Rank) { var r = t.rst; t.rst = r.lst; r.lst = t; t.Update(); r.Rank++; r.Update(); t = r; }
    }
    class Node
    {
        static public readonly Node nil;
        static Node()
        {
            nil = new Node();
            nil.lst = nil.rst = nil;
        }
        Node() { Rank = -1; }
        public Node(T key)
        {
            Key = key;
            lst = rst = nil;
            Count = 1;
        }
        public int Count { get; set; }
        public int Rank { get; set; }
        public T Key { get; set; }
        public Node lst, rst;
        public void Update() { if (Count != 0) Count = 1 + lst.Count + rst.Count; }
    }
}