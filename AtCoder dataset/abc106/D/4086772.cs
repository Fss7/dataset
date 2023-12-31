using System;
using System.Collections.Generic;
using System.Linq;
class Scanner
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
    static void Main() {
        int N = cin.Int();
        int M = cin.Int();
        int Q = cin.Int();
        var L = new int[M];
        var R = new int[M];

        var sum = new int[510, 510];
        for (int i = 0; i < M; i++) {
            L[i] = cin.Int();
            R[i] = cin.Int();
            sum[L[i], R[i]]++;
        }
        for (int i = 1; i <= N; i++) {
            for (int j = 1; j <= N; j++) {
                sum[i, j] += sum[i, j - 1];
            }
        }
        for (int i = 1; i <= N; i++) {
            for (int j = 1; j <= N; j++) {
                sum[i, j] += sum[i - 1, j];
            }
        }

        var p = new int[Q];
        var q = new int[Q];
        for (int i = 0; i < Q; i++) {
            p[i] = cin.Int();
            q[i] = cin.Int();
        }

        for (int i = 0; i < Q; i++) {
            Console.WriteLine(sum[q[i], q[i]] + sum[p[i] - 1, p[i] - 1] - sum[p[i] - 1, q[i]] - sum[q[i], p[i] - 1]);
        }
        Console.ReadLine();
    }
}