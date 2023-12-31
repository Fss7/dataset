using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using Enu = System.Linq.Enumerable;

public class Program
{
    public void Solve()
    {
        int N = NextInt(), M = NextInt();
        var E = new int[M][];
        for (int i = 0; i < M; i++) E[i] = new[] { NextInt(), NextInt() };
        int NQ = NextInt();
        var Q = new int[NQ][];
        for (int i = 0; i < NQ; i++) Q[i] = new[] { NextInt(), NextInt(), NextInt() };
        var comp = new TwoEdgeConnectedComponent(N, E, 1);
        var lca = new LowestCommonAncestor(comp.Components.Count);
        for (int a = 0; a < comp.Components.Count; a++)
            foreach (int b in comp.Components[a].Edges)
                if (a < b)
                    lca.AddEdge(a, b);
        lca.Init(0);
        var ans = new bool[NQ];
        for (int i = 0; i < NQ; i++)
        {
            int a = comp.VtoComponentId(Q[i][0] - 1);
            int b = comp.VtoComponentId(Q[i][1] - 1);
            int c = comp.VtoComponentId(Q[i][2] - 1);
            ans[i] = a == b && a == c || lca.Dist(a, b) + lca.Dist(b, c) == lca.Dist(a, c);
        }
        Console.WriteLine(string.Join("\n", ans.Select(b => b ? "OK" : "NG")));
    }

    TextReader _reader = Console.In;
    int NextInt()
    {
        int c;
        while ((c = _reader.Read()) < '0' || c > '9') { }
        int res = c - '0';
        while ((c = _reader.Read()) >= '0' && c <= '9') res = res * 10 + c - '0';
        return res;
    }
}

public class Component
{
    public int[] Vertexes;
    public int[] Edges;
    public Component(int[] vs) { Vertexes = vs; }
}

public class TwoEdgeConnectedComponent
{
    int N, id;
    List<int>[] E;
    int[] VtoCompId, order;
    bool[] inS;
    Stack<int> S = new Stack<int>(), roots = new Stack<int>();
    HashSet<long> BridgesSet = new HashSet<long>();
    public List<int[]> Bridges = new List<int[]>();
    public List<Component> Components = new List<Component>();


    public bool IsBridge(int a, int b) { return BridgesSet.Contains(ToKey(a, b)); }

    public int VtoComponentId(int v) { return VtoCompId[v]; }

    public bool SameComponent(int a, int b) { return VtoCompId[a] == VtoCompId[b]; }


    public TwoEdgeConnectedComponent(int N) { Init(N); }
    public TwoEdgeConnectedComponent(int N, int[][] E, int origin = 0)
    {
        Init(N);
        Array.ForEach(E, e => AddEdge(e[0] - origin, e[1] - origin));
        Decompose();
    }

    void Init(int N)
    {
        this.N = N;
        VtoCompId = new int[N];
        order = new int[N];
        inS = new bool[N];
        E = new List<int>[N];
        for (int i = 0; i < N; i++) E[i] = new List<int>();
    }

    public void AddEdge(int a, int b)
    {
        E[a].Add(b);
        E[b].Add(a);
    }

    public void Decompose()
    {
        for (int i = 0; i < N; i++)
            if (order[i] == 0)
                DFS(i, -1);
        Bridges.Sort((a, b) => a[0] != b[0] ? a[0] - b[0] : a[1] - b[1]);
        foreach (var comp in Components)
        {
            var es = new HashSet<int>();
            foreach (int a in comp.Vertexes)
                foreach (int b in E[a])
                    es.Add(VtoCompId[b]);
            comp.Edges = es.ToArray();
            Array.Sort(comp.Edges);
        }
    }

    void DFS(int v, int prev)
    {
        order[v] = ++id;
        roots.Push(v);
        S.Push(v);
        inS[v] = true;
        foreach (int next in E[v])
            if (order[next] == 0)
                DFS(next, v);
            else if (next != prev && inS[next])
                while (order[roots.Peek()] > order[next]) roots.Pop();
        if (roots.Peek() != v) return;
        if (prev != -1) AddBridge(prev, v);
        AddComponent(prev, v);
    }

    void AddBridge(int a, int b)
    {
        BridgesSet.Add(ToKey(a, b));
        Bridges.Add(new[] { Math.Min(a, b), Math.Max(a, b) });
        a = VtoCompId[a]; b = VtoCompId[b];
    }

    void AddComponent(int prev, int root)
    {
        int compId = Components.Count;
        var vs = new List<int>();
        for (; ; )
        {
            int v = S.Pop();
            inS[v] = false;
            VtoCompId[v] = compId;
            vs.Add(v);
            if (v == root) break;
        }
        vs.Sort();
        Components.Add(new Component(vs.ToArray()));
        roots.Pop();
    }

    long ToKey(long a, long b) { return a < b ? a * N + b : b * N + a; }

}

class LowestCommonAncestor
{
    List<int>[] G;
    RangeMinQueryIndex Rmq;
    List<int> Vs = new List<int>();
    List<int> depth = new List<int>();
    int[] Id, depthAt;

    public LowestCommonAncestor(int root, List<int>[] G)
    {
        this.G = G;
        Init(root);
    }
    public LowestCommonAncestor(int N)
    {
        G = new List<int>[N];
        for (int i = 0; i < N; i++) G[i] = new List<int>();
    }
    public void AddEdge(int a, int b)
    {
        G[a].Add(b);
        G[b].Add(a);
    }

    public int Get(int a, int b)
    {
        int L = Math.Min(Id[a], Id[b]);
        int R = Math.Max(Id[a], Id[b]) + 1;
        int i = Rmq.Get(L, R);
        return Vs[i];
    }
    public int Depth(int a) { return depthAt[a]; }
    public int Dist(int a, int b)
    {
        return depthAt[a] + depthAt[b] - depthAt[Get(a, b)] * 2;
    }

    public void Init(int root)
    {
        Id = new int[G.Length];
        depthAt = new int[G.Length];
        DFS(root, -1, 0);
        Rmq = new RangeMinQueryIndex(depth.Count);
        for (int i = 0; i < depth.Count; i++)
            Rmq.Set(i, depth[i]);
    }
    void DFS(int v, int prev, int d)
    {
        Id[v] = Vs.Count;
        Vs.Add(v);
        depth.Add(d);
        depthAt[v] = d;
        foreach (int next in G[v])
            if (next != prev)
            {
                DFS(next, v, d + 1);
                Vs.Add(v);
                depth.Add(d);
            }
    }
}

class RangeMinQueryIndex
{
    private static readonly int INF = (int)1e9;
    public readonly int N;
    private readonly int[] tree;
    private readonly int[] index;

    public RangeMinQueryIndex(int N)
    {
        while (N < 2 || (N & (N - 1)) != 0) { N += N & -N; }
        this.N = N;
        tree = new int[N * 2];
        index = new int[N * 2];
        for (int i = 0; i < tree.Length; i++) tree[i] = INF;
    }
    public void Set(int i, int val)
    {
        int id = i;
        i += N - 1;
        tree[i] = val;
        index[i] = id;
        while (i > 0)
        {
            i = (i - 1) / 2;
            int L = i * 2 + 1, R = i * 2 + 2;
            if (tree[L] <= tree[R]) { tree[i] = tree[L]; index[i] = index[L]; }
            else { tree[i] = tree[R]; index[i] = index[R]; }
        }
    }
    // [L, R)
    public int Get(int L, int R) { int v = -1; return Rec(0, ref v, 0, N, L, R); }
    private int Rec(int i, ref int val, int currL, int currR, int L, int R)
    {
        if (currL >= R || currR <= L) { val = INF; return -1; }
        if (currL >= L && currR <= R) { val = tree[i]; return index[i]; }
        int mid = (currL + currR) / 2;
        int Lv = INF, Rv = INF;
        int Li = Rec(i * 2 + 1, ref Lv, currL, mid, L, R);
        int Ri = Rec(i * 2 + 2, ref Rv, mid, currR, L, R);
        if (Lv <= Rv) { val = Lv; return Li; }
        val = Rv; return Ri;
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
    static void Init() { Dispose(); A = new string[0]; }
    public static void Set(TextReader r) { Init(); reader = r; }
    public static void Set(string file) { Init(); reader = new StreamReader(file); }
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
    public static void Dispose() { reader.Dispose(); }
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