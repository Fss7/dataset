using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Globalization;
using System.Diagnostics;
 
 
 
class Myon
{
    public Myon() { }
    public static int Main()
    {
        new Myon().calc();
        return 0;
    }
 
    Scanner cin;
 
    long R, B;
    long x, y;
 
    void calc()
    {
        cin = new Scanner();
        R = cin.nextLong();
        B = cin.nextLong();
        x = cin.nextLong();
        y = cin.nextLong();
        long mi = 0;
        long ma = Math.Min(B, R / x);
        while(mi + 10 < ma)
        {
            long mid1 = (mi + mi + ma) / 3;
            long mid2 = (mi + ma + ma) / 3;
            if (calc2(mid1) > calc2(mid2)) ma = mid2;
            else mi = mid1;
        }
        long ans = 0;
        for (long i = mi; i <= ma; i++)
        {
            ans = Math.Max(ans, calc2(i));
        }
        Console.WriteLine(ans);
    }
 
    long calc2(long r)
    {
        return r + Math.Min(R - x * r, (B - r) / y);
    }
}
 
 
 
 
class Scanner
{
    string[] s;
    int i;
 
    char[] cs = new char[] { ' ' };
 
    public Scanner()
    {
        s = new string[0];
        i = 0;
    }
 
    public string next()
    {
        if (i < s.Length) return s[i++];
        string st = Console.ReadLine();
        while (st == "") st = Console.ReadLine();
 
        s = st.Split(cs, StringSplitOptions.RemoveEmptyEntries);
        i = 0;
        return s[i++];
    }
 
    public int nextInt()
    {
        return int.Parse(next());
    }
 
    public long nextLong()
    {
        return long.Parse(next());
    }
 
    public double nextDouble()
    {
        return double.Parse(next());
    }
 
}