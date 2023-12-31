using System;
using System.Collections.Generic;
using System.Linq;
class Scanner //????
{
    string[] s;
    int i;

    char[] cs = new char[] { ' ' };

    public Scanner() {
        s = new string[0];
        i = 0;
    }

    public string next() {
        if (i < s.Length) return s[i++];
        string st = Console.ReadLine();
        while (st == "") st = Console.ReadLine();
        s = st.Split(cs, StringSplitOptions.RemoveEmptyEntries);
        if (s.Length == 0) return next();
        i = 0;
        return s[i++];
    }

    public int Int() {
        return int.Parse(next());
    }
    public int[] ArrayInt(int N, int add = 0) {
        int[] Array = new int[N];
        for (int i = 0; i < N; i++) {
            Array[i] = Int() + add;
        }
        return Array;
    }

    public long Long() {
        return long.Parse(next());
    }

    public long[] ArrayLong(int N, long add = 0) {
        long[] Array = new long[N];
        for (int i = 0; i < N; i++) {
            Array[i] = Long() + add;
        }
        return Array;
    }
}
class Program {
    static Scanner cin = new Scanner();
    static void Main(string[] args) {
        int N = cin.Int();
        var t = new int[N];
        for (int i = 0; i < N; i++) {
            t[i] = cin.Int();
        }
        int ans = int.MaxValue;
        for (int i = 0; i < (1 << N); i++) {
            int tmp = 0;
            for (int j = 0; j < N; j++) {
                if ((i >> j & 1) == 1) tmp += t[j];
            }
            int tmp2 = Math.Max(tmp, t.Sum() - tmp);
            ans = Math.Min(ans, tmp2);
        }
        Console.WriteLine(ans);
        Console.ReadLine();
    }
}