using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Globalization;
using System.Diagnostics;
using System.Threading.Tasks;



class Myon
{
    public Myon() { }
    public static int Main()
    {
        new Myon().calc();
        return 0;
    }
    

    Scanner cin;

    void calc()
    {
        cin = new Scanner();
        int N = cin.nextInt();
        string S = cin.next();
        string S1 = S.Substring(0, N);

        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < (1 << N); i++)
        {
            StringBuilder sa = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < N; j++)
            {
                if (((i >> j) & 1) == 0) sa.Append(S1[j]);
                else sb.Append(S1[j]);
            }
            string SS = sa.ToString() + "-" + sb.ToString();
            if (!dic.ContainsKey(SS)) dic[SS] = 0;
            dic[SS]++;
        }

        long ans = 0;

        for (int i = 0; i < (1 << N); i++)
        {
            StringBuilder sa = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < N; j++)
            {
                if (((i >> j) & 1) == 0) sa.Append(S[2 * N - j - 1]);
                else sb.Append(S[2 * N - j - 1]);
            }
            string SS = sa.ToString() + "-" + sb.ToString();
            if (dic.ContainsKey(SS)) ans += dic[SS];
        }

        Console.WriteLine(ans);
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
        if (s.Length == 0) return next();
        i = 0;
        return s[i++];
    }

    public int nextInt()
    {
        return int.Parse(next());
    }
    public int[] ArrayInt(int N, int add = 0)
    {
        int[] Array = new int[N];
        for (int i = 0; i < N; i++)
        {
            Array[i] = nextInt() + add;
        }
        return Array;
    }

    public long nextLong()
    {
        return long.Parse(next());
    }

    public long[] ArrayLong(int N, long add = 0)
    {
        long[] Array = new long[N];
        for (int i = 0; i < N; i++)
        {
            Array[i] = nextLong() + add;
        }
        return Array;
    }

    public double nextDouble()
    {
        return double.Parse(next());
    }


    public double[] ArrayDouble(int N, double add = 0)
    {
        double[] Array = new double[N];
        for (int i = 0; i < N; i++)
        {
            Array[i] = nextDouble() + add;
        }
        return Array;
    }
}