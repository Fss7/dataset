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
        long[] num = cin.ArrayLong(N);
        Array.Sort(num);
        Array.Reverse(num);

        Dictionary<long, int> dic = new Dictionary<long, int>();
        foreach (var item in num)
        {
            if (!dic.ContainsKey(item)) dic[item] = 0;
            dic[item]++;
        }

        int ans = 0;

        foreach (var A in num)
        {
            if (dic[A] == 0) continue;
            dic[A]--;
            long T = 1;
            while (T <= A) T *= 2;

            long B = T - A;

            if(dic.ContainsKey(B) && dic[B] >= 1)
            {
                dic[B]--;
                ans++;
            }
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