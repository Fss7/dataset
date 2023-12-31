using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
class Z { static void Main() => new K(); }
class K
{
	static int F => int.Parse(Str);
	static long FL => long.Parse(Str);
	static int[] G => Strs.Select(int.Parse).ToArray();
	static decimal[] GD => Strs.Select(decimal.Parse).ToArray();
	static long[] GL => Strs.Select(long.Parse).ToArray();
	static string Str => ReadLine();
	static string[] Strs => Str.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
	static T[] ConstantArray<T>(int n, T val) { var a = new T[n]; for (var i = 0; i < n; i++) a[i] = val; return a; }
	static T[] MakeArray<T>(int n, Func<int, T> f) { var a = new T[n]; for (var i = 0; i < n; i++) a[i] = f(i); return a; }
	const int MOD = 1000000007;
	public K()
	{
		SetOut(new StreamWriter(OpenStandardOutput()) { AutoFlush = false });
		Solve();
		Out.Flush();
	}
	static int N;
	void Solve()
	{
		var I = G;
		N = I[0];
		WriteLine(ToString(Calc(Get(), Get(), I[1] - 1)));
	}
	static int[] Get() => G.Select(i => i - 1).ToArray();
	static string ToString(int[] p) => string.Join(" ", p.Select(i => i + 1));
	static int[] Calc(int[] p, int[] q, int K)
	{
		if (K == 0) return p;
		if (K == 1) return q;
		if (K < 6) return Calc(q, Mult(q, Inv(p)), K - 1);
		int[] ip = Inv(p), iq = Inv(q), x = Mult(q, ip, iq, p), y = Mult(ip, q, p, iq);
		switch (K % 6)
		{
			case 0: return Mult(Pow(x, K / 6), q, p, iq, Pow(y, K / 6 - 1));
			case 1: return Mult(Pow(x, K / 6), q, Pow(y, K / 6));
			case 2: return Mult(Pow(x, K / 6), q, ip, Pow(y, K / 6));
			case 3: return Mult(Pow(x, K / 6), q, ip, iq, Pow(y, K / 6));
			case 4: return Mult(Pow(x, K / 6 + 1), iq, Pow(y, K / 6));
			default: return Mult(Pow(x, K / 6 + 1), p, iq, Pow(y, K / 6));
		}
	}
	static int[] Inv(int[] a)
	{
		var c = new int[N];
		for (var i = 0; i < N; i++) c[a[i]] = i;
		return c;
	}
	static int[] Mult(int[] a, int[] b)
	{
		var c = new int[N];
		for (var i = 0; i < N; i++) c[i] = a[b[i]];
		return c;
	}
	static int[] Mult(params int[][] a)
	{
		if (a.Length == 0) return MakeArray(N, i => i);
		var x = a[0];
		for (var i = 1; i < a.Length; i++) x = Mult(x, a[i]);
		return x;
	}
	static int[] Pow(int[] a, int b)
	{
		var p = MakeArray(N, i => i);
		var x = a;
		while (b > 0)
		{
			if ((b & 1) == 1) p = Mult(p, x);
			b >>= 1;
			x = Mult(x, x);
		}
		return p;
	}
}