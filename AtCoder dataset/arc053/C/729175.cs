using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Point = System.Tuple<double, double>;

class temp : IComparable
{
    public long a, b;
    public int CompareTo(object x)
    {
        var y = x as temp;
        if (Math.Max(this.a, this.a - this.b + y.a).CompareTo(Math.Max(y.a, y.a - y.b + this.a)) != 0)
            return Math.Max(this.a, this.a - this.b + y.a).CompareTo(Math.Max(y.a, y.a - y.b + this.a));
        else
        {
            return y.b.CompareTo(this.b);
        }
    }
}

class Program
{
    const int M = 1000000007;
    const double eps = 1e-9;
    static void Main()
    {
        var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
        var sc = new Scan();
        int n = sc.Int;
        var t = new temp[n];
        for (int i = 0; i < n; i++)
        {
            t[i] = new temp();
            sc.Multi(out t[i].a, out t[i].b);
        }
        Array.Sort(t);
        long now = 0;
        long max = 0;
        for (int i = 0; i < n; i++)
        {
            max = Math.Max(max, now + t[i].a);
            now += t[i].a - t[i].b;
        }
        sw.WriteLine(max);
        sw.Flush();
    }
    
    static void swap<T>(ref T a, ref T b) { var t = a; a = b; b = t; }

    static T[] copy<T>(T[] a)
    {
        var ret = new T[a.Length];
        for (int i = 0; i < a.Length; i++) ret[i] = a[i];
        return ret;
    }
    static T[][] copy2<T>(T[][] a)
    {
        var ret = new T[a.Length][];
        for (int i = 0; i < a.Length; i++)
        {
            ret[i] = new T[a[0].Length];
            for (int j = 0; j < a[0].Length; j++) ret[i][j] = a[i][j];
        }
        return ret;
    }
}
class Scan
{
    public int Int { get { return int.Parse(Str); } }
    public long Long { get { return long.Parse(Str); } }
    public string Str { get { return Console.ReadLine().Trim(); } }
    public int[] IntArr { get { return StrArr.Select(int.Parse).ToArray(); } }
    public int[] IntArrWithSep(char sep) { return Str.Split(sep).Select(int.Parse).ToArray(); }
    public long[] LongArr { get { return StrArr.Select(long.Parse).ToArray(); } }
    public double[] DoubleArr { get { return StrArr.Select(double.Parse).ToArray(); } }
    public string[] StrArr { get { return Str.Split(); } }
    public void Multi(out int a, out int b) { var arr = IntArr; a = arr[0]; b = arr[1]; }
    public void Multi(out int a, out int b, out int c) { var arr = IntArr; a = arr[0]; b = arr[1]; c = arr[2]; }
    public void Multi(out int a, out string b) { var arr = StrArr; a = int.Parse(arr[0]); b = arr[1]; }
    public void Multi(out string a, out int b) { var arr = StrArr; a = arr[0]; b = int.Parse(arr[1]); }
    public void Multi(out int a, out char b) { var arr = StrArr; a = int.Parse(arr[0]); b = arr[1][0]; }
    public void Multi(out char a, out int b) { var arr = StrArr; a = arr[0][0]; b = int.Parse(arr[1]); }
    public void Multi(out long a, out long b) { var arr = LongArr; a = arr[0]; b = arr[1]; }
    public void Multi(out long a, out int b) { var arr = LongArr; a = arr[0]; b = (int)arr[1]; }
    public void Multi(out int a, out long b) { var arr = LongArr; a = (int)arr[0]; b = arr[1]; }
    public void Multi(out string a, out string b) { var arr = StrArr; a = arr[0]; b = arr[1]; }
}
class mymath
{
    public bool isprime(long a)
    {
        if (a < 2) return false;
        for (long i = 2; i * i <= a; i++) if (a % i == 0) return false;
        return true;
    }
    public long[][] powmat(long[][] A, long n, int M)
    {
        var E = new long[A.Length][];
        for (int i = 0; i < A.Length; i++)
        {
            E[i] = new long[A.Length];
            E[i][i] = 1;
        }
        if (n == 0) return E;
        var t = powmat(A, n / 2, M);
        if ((n & 1) == 0) return mulmat(t, t, M);
        return mulmat(mulmat(t, t, M), A, M);
    }
    public long[] mulmat(long[][] A, long[] x, int M)
    {
        var ans = new long[A.Length];
        for (int i = 0; i < A.Length; i++) for (int j = 0; j < x.Length; j++) ans[i] = (ans[i] + x[j] * A[i][j]) % M;
        return ans;
    }
    public long[][] mulmat(long[][] A, long[][] B, int M)
    {
        var ans = new long[A.Length][];
        for (int i = 0; i < A.Length; i++)
        {
            ans[i] = new long[B[0].Length];
            for (int j = 0; j < B[0].Length; j++) for (int k = 0; k < B.Length; k++) ans[i][j] = (ans[i][j] + A[i][k] * B[k][j]) % M;
        }
        return ans;
    }
    public long powmod(long a, long b, long M)
    {
        if (a == 0) return 0;
        if (b == 0) return 1;
        var t = powmod(a, b / 2, M);
        if ((b & 1) == 0) return t * t % M;
        return t * t % M * a % M;
    }
    public long gcd(long a, long b)
    {
        while (b > 0) { var t = a % b; a = b; b = t; }
        return a;
    }
    public long lcm(long a, long b) { return a * (b / gcd(a, b)); }
    public long Comb(int n, int r)
    {
        const int M = 1000000007;
        if (n < 0 || r < 0 || r > n) return 0;
        if (n - r < r) r = n - r;
        if (r == 0) return 1;
        if (r == 1) return n;
        var numerator = new int[r];
        var denominator = new int[r];
        for (int k = 0; k < r; k++)
        {
            numerator[k] = n - r + k + 1;
            denominator[k] = k + 1;
        }
        for (int p = 2; p <= r; p++)
        {
            int pivot = denominator[p - 1];
            if (pivot > 1)
            {
                int offset = (n - r) % p;
                for (int k = p - 1; k < r; k += p)
                {
                    numerator[k - offset] /= pivot;
                    denominator[k] /= pivot;
                }
            }
        }
        long result = 1;
        for (int k = 0; k < r; k++) if (numerator[k] > 1) result = result * numerator[k] % M;
        return result;
    }
}