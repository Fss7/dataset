#region Template code
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Globalization;

static class MyLinq
{
    public static int MaxIdx<T>(this IEnumerable<T> seq) where T : IComparable
    {
        int res = -1;
        T max = default(T);
        int i = 0;
        foreach (T t in seq)
        {
            if (res == -1 || t.CompareTo(max) > 0) { res = i; max = t; }
            i += 1;
        }
        return res;
    }
    public static int MaxIdx<T, S>(this IEnumerable<T> seq, Func<T, S> func) where S : IComparable
    {
        return seq.Select(func).MaxIdx();
    }
    public static int MinIdx<T>(this IEnumerable<T> seq) where T : IComparable
    {
        int res = -1;
        T min = default(T);
        int i = 0;
        foreach (T t in seq)
        {
            if (res == -1 || t.CompareTo(min) < 0) { res = i; min = t; }
            i += 1;
        }
        return res;
    }
    public static int MinIdx<T, S>(this IEnumerable<T> seq, Func<T, S> func) where S : IComparable
    {
        return seq.Select(func).MinIdx();
    }

}

class Program
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Solution sol = new Solution();
        sol.go();
    }
}

partial class Solution
{
    #region I/O
    protected TextReader input = null;
    protected TextWriter output = null;

    string[] line;
    int index;
    protected string ReadLine()
    {
        line = null;
        return input.ReadLine();
    }

    protected int ReadLine_int()
    {
        line = null;
        string s = input.ReadLine();
        return Convert.ToInt32(s);
    }

    protected string[] SplitLine()
    {
        index = 0;
        return line = input.ReadLine().Split();
    }

    protected List<int> SplitLine_int()
    {
        index = 0;
        line = input.ReadLine().Split();

        List<int> result = new List<int>();
        foreach (string s in line)
        {
            if (s == "") continue;
            result.Add(Convert.ToInt32(s));
        }
        return result;
    }
    protected List<double> SplitLine_double()
    {
        index = 0;
        line = input.ReadLine().Split();

        List<double> result = new List<double>();
        foreach (string s in line)
        {
            if (s == "") continue;
            result.Add(Convert.ToDouble(s));
        }
        return result;
    }



    protected string GetString()
    {
        return line[index++];
    }

    protected int GetInt()
    {
        return Convert.ToInt32(line[index++]);
    }

    protected long GetLong()
    {
        return Convert.ToInt64(line[index++]);
    }

    protected double GetDouble()
    {
        return Convert.ToDouble(line[index++], CultureInfo.InvariantCulture);
    }

    protected void Write(string s)
    {
        output.Write(s);
        Console.Out.Write(s);
    }

    protected void Write(string format, params object[] ss)
    {
        output.Write(format, ss);
        Console.Out.Write(format, ss);
    }

    protected void WriteLine()
    {
        output.WriteLine();
        Console.Out.WriteLine();
    }

    protected void WriteLine(string s)
    {
        output.WriteLine(s);
        Console.Out.WriteLine(s);
    }

    protected void WriteLine(string format, params object[] ss)
    {
        output.WriteLine(format, ss);
        Console.Out.WriteLine(format, ss);

    }

    #endregion

    static string hex(int x)
    {
        return String.Format("{0:x}", x);
    }

    public void go()
    {
        Environment.CurrentDirectory = "../..";
        input = File.OpenText(name + ".in");
        output = File.CreateText(name + ".out");
        int N = ReadLine_int();
        for (cas = 1; cas <= N; cas++)
        {
            Solve();
        }

        output.Close();
        input.Close();
        Console.Out.WriteLine("Done...");
        Console.In.ReadLine();
    }
    int cas = -1;
}
#endregion

partial class Solution
{
    const string name = "A-large";

    Tuple<long, long> parse(string s)
    {
        int index = s.IndexOf('/');
        long p = long.Parse(s.Substring(0, index));
        long q = long.Parse(s.Substring(index + 1));
        return Tuple.Create(p, q);
    }
    long gcd(long p, long q)
    {
        while (true)
        {
            q -= q / p * p;
            if (q == 0) return p;
            long t = p;
            p = q;
            q = t;
        }
    }
    void Solve()
    {
        //int N = ReadLine_int();

        string s = ReadLine();
        var pq = parse(s);
        long p = pq.Item1;
        long q = pq.Item2;
        long d = gcd(p, q);
        p /= d;
        q /= d;
        while (p % 2 == 0 && q % 2 == 0)
        {
            p = p / 2;
            q = q / 2;
        }

        long qq = q;
        while (true)
        {
            if (qq == 1) break;
            if (qq % 2 == 1)
            {
                WriteLine("Case #{0}: {1}", cas, "impossible");
                return;
            }
            qq /= 2;
        }
        for (int i = 1; i <= 40; i++)
        {
            if (p * 2 >= q)
            {
                WriteLine("Case #{0}: {1}", cas, i);
                return;
            }
            q /= 2;
        }

        WriteLine("Case #{0}: {1}", cas, "impossible");
    }


}

