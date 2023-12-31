using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Globalization;
using System.Diagnostics;
using static System.Console;
//using System.Numerics;
using static System.Math;
 
class Program
{
    static void Main()
    {
        //SetOut(new StreamWriter(OpenStandardOutput()) { AutoFlush = false });
        new Program().solve();
        Out.Flush();
    }
    Scanner cin = new Scanner();
    readonly int[] dd = { 0, 1, 0, -1, 0 }; //????
    readonly int mod = 1000000007;
 
 
    void solve()
    {
        int N = cin.nextint;
        var Z = cin.nextlong;
        var W = cin.nextlong;
 
        var A = cin.scanlong;
        if (N == 1)
        {
            WriteLine(Abs(W - A[0]));
            return;
        }
 
        var MAX = new long[N];
        var MIN = new long[N];
        MAX[N - 1] = Abs(A[N - 1] - A[N - 2]);
        MIN[N - 1] = Abs(A[N - 1] - A[N - 2]);
 
 
        for (int j = N - 2; j > 0; j--)
        {
            MAX[j] = Abs(A[j - 1] - A[N - 1]);
            MIN[j] = Abs(A[j - 1] - A[N - 1]);
            for (int i = j + 1; i < N; i++)
            {
                MAX[j] = Max(MAX[j], MIN[i]);
                MIN[j] = Min(MIN[j], MAX[i]);
            }
        }
        long ans = Abs(W - A[N - 1]);
        int id = N;
        for (int i = 1; i < N; i++)
        {
            if (ans < MIN[i])
            {
                id = i;
                ans = MIN[i];
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