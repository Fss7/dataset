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
    static readonly int Unknown = int.MinValue;

    public void Solve()
    {
        int N = Reader.Int();
        var G = EdgeRead(N);
        int K = Reader.Int();
        var Val = Enu.Repeat(Unknown, N).ToArray();
        var heap = new Heap<long>();

        for (int i = 0; i < K; i++)
        {
            int at = Reader.Int() - 1, val = Reader.Int();
            Val[at] = val;
            heap.Push(((long)val << 32) + at);
        }
        while (heap.Count > 0)
        {
            long mask = heap.Pop();
            int val = (int)(mask >> 32);
            int at = (int)mask;
            foreach (int next in G[at])
                if (Val[next] == Unknown)
                {
                    heap.Push(((long)val + 1 << 32) + next);
                    Val[next] = val + 1;
                }
                else if (Math.Abs(Val[next] - val) != 1)
                {
                    Console.WriteLine("No"); return;
                }
        }

        Console.WriteLine("Yes\n" + string.Join("\n", Val));
    }

    int[][] EdgeRead(int V, int E = -1, int origin = 1)
    {
        if (E == -1) E = V - 1;
        var es = new List<int>[V];
        for (int i = 0; i < V; i++) es[i] = new List<int>();
        for (int i = 0; i < E; i++)
        {
            int a = Reader.Int() - origin, b = Reader.Int() - origin;
            es[a].Add(b);
            es[b].Add(a);
        }
        return es.Select(a => a.ToArray()).ToArray();
    }

    class Heap<T>
    {
        private const int InitialSize = 1024;
        private readonly int sign;
        private readonly Comparer<T> comp = Comparer<T>.Default;
        private T[] A = new T[InitialSize];
        public int Count { get; private set; }
        public Heap(bool greater = false) { sign = greater ? 1 : -1; }
        public T Peek() { return A[0]; }
        public bool Empty() { return Count == 0; }
        public void Push(T val)
        {
            if (Count == A.Length)
            {
                T[] next = new T[A.Length * 2];
                Array.Copy(A, next, A.Length);
                A = next;
            }
            A[Count++] = val;
            int i = Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (Math.Sign(comp.Compare(val, A[parent])) == sign)
                {
                    A[i] = A[parent];
                    i = parent;
                }
                else break;
            }
            A[i] = val;
        }
        public T Pop()
        {
            T res = A[0];
            T val = A[--Count];
            if (Count == 0) return res;
            int i = 0;
            while (i * 2 + 1 < Count)
            {
                int L = i * 2 + 1;
                int R = i * 2 + 2;
                if (R < Count && Math.Sign(comp.Compare(A[R], A[L])) == sign) L = R;
                if (Math.Sign(comp.Compare(A[L], val)) == sign) { A[i] = A[L]; i = L; }
                else break;
            }
            A[i] = val;
            return res;
        }
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
    public static T[] Range<T>(int N, Func<T> f) { var r = new T[N]; for (int i = 0; i < N; r[i++] = f()) ; return r; }
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