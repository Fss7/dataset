using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Globalization;
//using System.Diagnostics;
using static System.Console;
//using System.Numerics;
//using static System.Math;
//using pair = Pair<int, int>;

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
        int H = cin.nextint;
        int W = cin.nextint;
        var T = new Two_D(H, W);
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                T.D[i, j] = cin.nextint;
                if ((i + j) % 2 == 1) T.D[i, j] *= -1;
            }
        }
        T.build();

        long ans = 0;
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                for (int k = i; k < H; k++)
                {
                    for (int l = j; l < W; l++)
                    {
                        if (T.query(i, j, k, l) == 0)
                        {
                            ans = Math.Max(ans, (k - i + 1) * (l - j + 1));
                        }
                    }
                }
            }
        }
        WriteLine(ans);

    }

}


class Two_D
{
    public long[,] D;
    public int H;
    public int W;
    public Two_D(int H, int W)
    {
        this.H = H + 10;
        this.W = W + 10;
        D = new long[this.H, this.W];
    }
    public void build()
    {
        for (int i = 0; i < H; i++)
        {
            for (int j = 1; j < W; j++)
            {
                D[i, j] += D[i, j - 1];
            }
        }
        for (int i = 1; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                D[i, j] += D[i - 1, j];
            }
        }
    }
    public void imos(int min_y, int min_x, int max_y, int max_x)
    {
        D[min_y, min_x]++;
        D[min_y, max_x + 1]--;
        D[max_y + 1, min_x]--;
        D[max_y + 1, max_x + 1]++;
    }
    //sum [(min_y, min_x), (max_y, max_x)]
    public long query(int min_y, int min_x, int max_y, int max_x)
    {
        long ret = D[max_y, max_x];
        if (min_y > 0) ret -= D[min_y - 1, max_x];
        if (min_x > 0) ret -= D[max_y, min_x - 1];
        if (min_y > 0 && min_x > 0) ret += D[min_y - 1, min_x - 1];

        return ret;
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