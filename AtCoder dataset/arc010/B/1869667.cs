using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Globalization;
using System.Diagnostics;
using static System.Console;
//using System.Numerics;
//using static System.Math;


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
        var Q = new DateTime[N + 1];
        for (int i = 0; i < N; i++)
        {
            var T = ReadLine().Split('/').Select(int.Parse).ToArray();
            Q[i] = new DateTime(2012, T[0], T[1]);
        }
        Q[N] = new DateTime(2013, 1, 1);
        Array.Sort(Q);

        var D = new DateTime(2012, 1, 1);

        int id = 0;
        int ans = 0;
        int hurikae = 0;
        int cnt = 0;
        while (D.Year == 2012)
        {
            bool weekend = false;
            if (D.DayOfWeek == DayOfWeek.Saturday || D.DayOfWeek == DayOfWeek.Sunday)
            {
                weekend = true;
            }
            while (Q[id] < D)
            {
                id++;
            }
            bool holiday = false;
            if (Q[id] == D)
            {
                holiday = true;
            }

            if (weekend && holiday)
            {
                cnt++;
                hurikae++;
            }
            else if (weekend || holiday)
            {
                cnt++;
            }
            else
            {
                if (hurikae > 0)
                {
                    cnt++;
                    hurikae--;
                }
                else
                {
                    ans = Math.Max(cnt, ans);
                    cnt = 0;
                }
            }
            D = D.AddDays(1);
        }
        ans = Math.Max(cnt, ans);
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