using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

class Solver {
    Scanner sc = new Scanner();

    public void Solve() {
        int H = sc.nextInt();
        int W = sc.nextInt();
        var c = new int[10, 10];
        var A = new int[H, W];
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                c[i, j] = sc.nextInt();
            }
        }
        for (int i = 0; i < H; i++) {
            for (int j = 0; j < W; j++) {
                A[i, j] = sc.nextInt();
            }
        }

        for (int k = 0; k < 10; k++) {
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    c[i, j] = Math.Min(c[i, j], c[i, k] + c[k, j]);
                }
            }
        }

        long ans = 0;
        for (int i = 0; i < H; i++) {
            for (int j = 0; j < W; j++) {
                if (A[i, j] == -1) continue;
                ans += c[A[i, j], 1];
            }
        }
        WriteLine(ans);
    }

}



class Scanner {
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

    public int nextInt() {
        return int.Parse(next());
    }
    public int[] ArrayInt(int N, int add = 0) {
        int[] Array = new int[N];
        for (int i = 0; i < N; i++) {
            Array[i] = nextInt() + add;
        }
        return Array;
    }

    public long nextLong() {
        return long.Parse(next());
    }

    public long[] ArrayLong(int N, long add = 0) {
        long[] Array = new long[N];
        for (int i = 0; i < N; i++) {
            Array[i] = nextLong() + add;
        }
        return Array;
    }

    public double nextDouble() {
        return double.Parse(next());
    }

    public double[] ArrayDouble(int N, double add = 0) {
        double[] Array = new double[N];
        for (int i = 0; i < N; i++) {
            Array[i] = nextDouble() + add;
        }
        return Array;
    }
}

class Program {
    static void Main(string[] args) {
        Solver s = new Solver();
        s.Solve();
    }
}