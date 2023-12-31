using System;
using System.Collections.Generic;
using System.Linq;
using static Atcoder;
using System.Threading.Tasks;
using System.ComponentModel;

public class Hello
{
    private const int INF = 1000000007;
    public static void Main()
    {
        int[] inp = IntLine();
        int N = inp[0], M = inp[1];
        UnionFind uf = new UnionFind(N + 1);
        List<int[]> e = new List<int[]>();
        for (int i = 0; i < M; i++)
        {
            inp = IntLine().Select(v => v - 1).ToArray();
            e.Add(inp);
            uf.Unite(inp[0], inp[1]);
        }
        // parent : edge
        Dictionary<int, int> e_dic = new Dictionary<int, int>();
        Dictionary<int, HashSet<int>> n_dic = new Dictionary<int, HashSet<int>>();

        for (int i = 0; i < N; i++)
        {
            var p = uf.Root(i);
            if (!n_dic.ContainsKey(p))
            {
                n_dic[p] = new HashSet<int>();
                e_dic[p] = 0;
                n_dic[p].Add(i);
            }
            else n_dic[p].Add(i);
        }

        for (int i = 0; i < M; i++)
        {
            var p = uf.Root(e[i][0]);
            e_dic[p]++;
        }
        int ans = 0;
        foreach (var k in n_dic.Keys)
        {
            if (n_dic[k].Count() - e_dic[k] == 1) ans++;
        }
        Console.WriteLine(ans);
    }
}

public class UnionFind
{
    public List<int> parent = new List<int>();

    public UnionFind(int N)
    {
        for (int i = 0; i < N; i++) parent.Add(i);
    }

    public int Root(int a)
    {
        if (parent[a] == a) return a;
        else return parent[a] = Root(parent[a]);
    }

    public void Unite(int a, int b)
    {
        a = Root(a);
        b = Root(b);
        if (a == b) return;
        parent[a] = parent[b];
    }

    public bool Same(int a, int b) { return (Root(a) == Root(b)); }
}


public class Atcoder
{
    public static void Swap<T>(ref T a, ref T b)
    {
        var t = a;
        a = b;
        b = t;
    }
    public static int GCD(int a, int b)
    {
        if (a < b) Swap(ref a, ref b);
        int d = a % b;
        while (b != 0)
        {
            d = a % b;
            a = b;
            b = d;
        }
        return a;
    }
    public static long LCM(int a, int b)
    {
        return (long)a * b / GCD(a, b);
    }
    public static string StrReverce(string s)
    {
        return new string(s.Reverse().ToArray());
    }
    public static int IntRead()
    {
        return int.Parse(Console.ReadLine());
    }
    public static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        //double sqrtNum = Math.Sqrt(n);
        for (int i = 3; i < n; i += 2)
        {
            if (n % i == 0) return false;
        }
        return true;
    }
    public static string[] SpRead(char c)
    {
        return Console.ReadLine().Split(c);
    }
    public static long[] LSRead()
    {
        return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
    }
    public static long Combination(int n, int r)
    {
        if (n == r) return 1;
        return
            Enumerable.Range((n - r + 1), r).ToList().Aggregate((now, next) => now * next) /
            Enumerable.Range(1, r).ToList().Aggregate((now, next) => now * next);
    }
    public static long Permutation(int n, int r)
    {
        if (n == r) return 1;
        return
            Enumerable.Range((n - r), r).ToList().Aggregate((now, next) => now * next);
    }
    public static long LongRead()
    {
        return long.Parse(Console.ReadLine());
    }
    public static long[] LongLine()
    {
        return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
    }
    public static int[] IntLine()
    {
        return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    }
}