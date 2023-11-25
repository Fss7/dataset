using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
//using System.Diagnostics;
using static System.Console;
using Pair = System.Collections.Generic.KeyValuePair<int, int>;
//using System.Numerics;
//using static System.Math;
using static System.Linq.Enumerable;

class Program
{
    static void Main()
    {
        //SetOut(new StreamWriter(OpenStandardOutput()) { AutoFlush = false });
        new Program().solve();
        Out.Flush();
    }
    Scanner cin = new Scanner();
    Random rnd = new Random();
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    readonly int[] dd = { 0, 1, 0, -1, 0 };
    readonly int mod = 1000000007;
    readonly string alfa = "abcdefghijklmnopqrstuvwxyz";
    readonly string ALFA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    int N;
    void solve()
    {
        int A = cin.nextint, B = cin.nextint, C = cin.nextint, D = cin.nextint, E = cin.nextint, F = cin.nextint;


        double max = -1;
        string ans = "";
        for (int i = 0; i <= 30; i++)//A?i?
        {
            for (int j = 0; j <= 30; j++)//B?j?
            {
                if (i == 0 && j == 0) continue;
                int weight = A * 100 * i + B * 100 * j;
                if (weight > F) continue;
                int to = E * (A * i + B * j);

  
                for (int k = 0; k <= to / C; k++)
                {
                    for (int l = 0; l <= to / D; l++)
                    {
                        int w = C * k + D * l;
                        if (w <= to && weight + w <= F)
                        {
 
                            double nou = (double)(100 * w) / (w + weight);
                            if (max < nou)
                            {
                                max = nou;
                                ans = $"{weight + w} {w}";
                            }
                        }
                    }
                }
            }
        }
        WriteLine(ans);
    }

}

class Scanner
{
    string[] s; int i;
    char[] cs = new char[] { ' ' };
    public Scanner() { s = new string[0]; i = 0; }
    public string[] scan { get { return ReadLine().Split(); } }
    public int[] scanint { get { return Array.ConvertAll(scan, int.Parse); } }
    public long[] scanlong { get { return Array.ConvertAll(scan, long.Parse); } }
    public double[] scandouble { get { return Array.ConvertAll(scan, double.Parse); } }
    public string next
    {
        get
        {
            if (i < s.Length) return s[i++];
            string st = ReadLine();
            while (st == "") st = ReadLine();
            s = st.Split(cs, StringSplitOptions.RemoveEmptyEntries);
            i = 0;
            return next;
        }
    }
    public int nextint { get { return int.Parse(next); } }
    public long nextlong { get { return long.Parse(next); } }
    public double nextdouble { get { return double.Parse(next); } }
}