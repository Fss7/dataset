﻿// csc /r:System.Numerics.dll /optimize /checked [This File]

using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

partial class Solver
{
    Dictionary<int, int> memoise;

    int dfs(int N, int P, int[] H, int leftOver = 0)
    {
        if (N == 0) return 0;

        int key = 0;
        foreach (var h in H)
        {
            key = key * 110 + h;
        }
        key = key * 10 + leftOver;

        if (memoise.ContainsKey(key))
        {
            return memoise[key];
        }

        int ret = 0;

        for (int i = 0; i < H.Length; i++)
        {
            if (H[i] > 0)
            {
                H[i]--;

                var newLeftOver = (P * 2 - i % P + leftOver) % P;
                ret = Math.Max(ret, dfs(N - 1, P, H, newLeftOver) + ((N - 1 > 0 && newLeftOver == 0) ? 1 : 0));

                H[i]++;
            }
        }
        return memoise[key] = ret;
    }

    public void Run()
    {
        var t = ni();
        int caseNo = 1;
        while (t-- > 0)
        {
            int ans = 0;
            var N = ni();
            var P = ni();
            var G = ni(N);

            var H = new int[P];
            foreach (var g in G)
            {
                H[g % P]++;
            }
            memoise = new Dictionary<int, int>();
            ans = dfs(N, P, H) + 1;

            cout.WriteLine("Case #{0}: {1}", caseNo++, ans);
        }
    }
}

// PREWRITEN CODE BEGINS FROM HERE
partial class Solver : Scanner
{
    public static void Main(string[] args)
    {
        new Solver(Console.In, Console.Out).Run();
    }

    TextReader cin;
    TextWriter cout;

    public Solver(TextReader reader, TextWriter writer)
        : base(reader)
    {
        this.cin = reader;
        this.cout = writer;
    }
    public Solver(string input, TextWriter writer)
        : this(new StringReader(input), writer)
    {
    }

    public int ni() { return NextInt(); }
    public int[] ni(int n) { return NextIntArray(n); }
    public long nl() { return NextLong(); }
    public long[] nl(int n) { return NextLongArray(n); }
    public double nd() { return NextDouble(); }
    public string ns() { return Next(); }
}

public class Scanner
{
    private TextReader Reader;
    private Queue<String> TokenQueue = new Queue<string>();
    private CultureInfo ci = CultureInfo.InvariantCulture;

    public Scanner()
        : this(Console.In)
    {
    }

    public Scanner(TextReader reader)
    {
        this.Reader = reader;
    }

    public int NextInt() { return Int32.Parse(Next(), ci); }
    public long NextLong() { return Int64.Parse(Next(), ci); }
    public double NextDouble() { return double.Parse(Next(), ci); }
    public string[] NextArray(int size)
    {
        var array = new string[size];
        for (int i = 0; i < size; i++) array[i] = Next();
        return array;
    }
    public int[] NextIntArray(int size)
    {
        var array = new int[size];
        for (int i = 0; i < size; i++) array[i] = NextInt();
        return array;
    }

    public long[] NextLongArray(int size)
    {
        var array = new long[size];
        for (int i = 0; i < size; i++) array[i] = NextLong();
        return array;
    }

    public String Next()
    {
        if (TokenQueue.Count == 0)
        {
            if (!StockTokens()) throw new InvalidOperationException();
        }
        return TokenQueue.Dequeue();
    }

    public bool HasNext()
    {
        if (TokenQueue.Count > 0)
            return true;
        return StockTokens();
    }

    private bool StockTokens()
    {
        while (true)
        {
            var line = Reader.ReadLine();
            if (line == null) return false;
            var tokens = line.Trim().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0) continue;
            foreach (var token in tokens)
                TokenQueue.Enqueue(token);
            return true;
        }
    }
}
