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
	int F => int.Parse(Str);
	long FL => long.Parse(Str);
	int[] G => Strs.Select(int.Parse).ToArray();
	uint[] GU => Strs.Select(uint.Parse).ToArray();
	decimal[] GD => Strs.Select(decimal.Parse).ToArray();
	long[] GL => Strs.Select(long.Parse).ToArray();
	string Str => ReadLine();
	string[] Strs => Str.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
	static T[] ConstantArray<T>(int n, T val) { var a = new T[n]; for (var i = 0; i < n; i++) a[i] = val; return a; }
	static T[] MakeArray<T>(int n, Func<int, T> f) { var a = new T[n]; for (var i = 0; i < n; i++) a[i] = f(i); return a; }
	static ulong One(int k) => 1ul << k;
	static ulong All(int k) => One(k) - 1;
	static bool Has(ulong s, int k) => (s & One(k)) != 0;
	const int MOD = 1000000007;
	public K()
	{
		SetOut(new StreamWriter(OpenStandardOutput()) { AutoFlush = false });
		Solve();
		Out.Flush();
	}
	void Solve()
	{
		var N = F;
		var S = Str;
		var max = 0;
		for (var i = 0; i <= N; i++)
		{
			var P = new HashSet<char>(S.Substring(0, i));
			var Q = new HashSet<char>(S.Substring(i, N - i));
			P.IntersectWith(Q);
			max = Max(max, P.Count);
		}
		WriteLine(max);
	}
}