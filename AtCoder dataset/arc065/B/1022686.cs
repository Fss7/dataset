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
        int N = Reader.Int(), K = Reader.Int(), L = Reader.Int();
        int[][] E1 = Reader.IntTable(K), E2 = Reader.IntTable(L);

        var uf1 = new UnionFind(N);
        foreach (var e in E1) uf1.Unite(e[0] - 1, e[1] - 1);

        var uf2 = new UnionFind(N);
        foreach (var e in E2) uf2.Unite(e[0] - 1, e[1] - 1);

        var ans = new int[N];
        foreach (var comp in uf1.Components().Values)
        {
            var count = new Dictionary<int, int>();
            foreach (int v in comp)
                AddDic(count, uf2.Root(v), 1);
            foreach (int v in comp)
                ans[v] = count[uf2.Root(v)];
        }

        Console.WriteLine(string.Join(" ", ans));
    }

    void AddDic(Dictionary<int, int> dic, int key, int val)
    {
        if (dic.ContainsKey(key)) dic[key] += val;
        else dic[key] = val;
    }
}

class UnionFind
{
    private int[] parent;
    private byte[] rank;

    public UnionFind(int N)
    {
        parent = new int[N];
        rank = new byte[N];
        for (int i = 0; i < N; i++) parent[i] = -1;
    }
    public int Root(int x)
    {
        if (parent[x] < 0) return x;
        return parent[x] = Root(parent[x]);
    }
    public bool Same(int x, int y)
    {
        return Root(x) == Root(y);
    }
    public int Count(int x)
    {
        return -parent[Root(x)];
    }
    public bool Unite(int x, int y)
    {
        x = Root(x); y = Root(y);
        if (x == y) return false;
        if (rank[x] > rank[y]) { var t = x; x = y; y = t; }
        if (rank[x] == rank[y]) rank[y]++;
        parent[y] += parent[x];
        parent[x] = y;
        return true;
    }
    public Dictionary<int, List<int>> Components()
    {
        var dic = new Dictionary<int, List<int>>();
        for (int i = 0; i < parent.Length; i++)
        {
            int root = Root(i);
            if (!dic.ContainsKey(root)) dic[root] = new List<int>();
            dic[root].Add(i);
        }
        return dic;
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