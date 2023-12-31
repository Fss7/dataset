using System.Linq;
using System.Collections.Generic;
using static System.Console;
class Z { static void Main() => new K(); }
class K
{
	const long M = 1000000007;
	int[] G => ReadLine().Split().Select(int.Parse).ToArray();
	int N;
	long A, D;
	long[] j, k, l, m;
	bool[] z;
	List<E>[] g;
	public K()
	{
		var I = G; N = I[0]; var Q = I[1];
		I = G; int s = I[0] - 1, t = I[1] - 1;
		g = new List<E>[N];
		for (var i = 0; i < N; i++) g[i] = new List<E>();
		for (var i = 0; i < Q; i++)
		{
			I = G; int a = I[0] - 1, b = I[1] - 1, c = I[2];
			g[a].Add(new E(b, c));
			g[b].Add(new E(a, c));
		}
		C(s, ref j, ref l);
		C(t, ref k, ref m);
		A = S(l[t]);
		D = j[t];
		z = new bool[N];
		B(t);
		WriteLine((A %= M) < 0 ? A + M : A);
	}
	long S(long x) => x * x % M;
	void B(int u)
	{
		if (z[u]) return;
		z[u] = true;
		if (2 * j[u] == D) A -= S(l[u] * m[u] % M);
		foreach (var e in g[u]) if (j[e.V] + e.D == j[u])
			{
				if (2 * j[u] > D && 2 * j[e.V] < D) A -= S(m[u] * l[e.V] % M);
				B(e.V);
			}
	}
	void C(int u, ref long[] d, ref long[] c)
	{
		d = new long[N]; c = new long[N];
		for (var v = 0; v < N; v++) d[v] = (long)4e18;
		var q = new Q();
		d[u] = 0; c[u] = 1;
		q.E(new E(u, 0));
		while (q.C > 0)
		{
			var p = q.D();
			var v = p.V;
			if (d[v] < p.D) continue;
			foreach (var e in g[v])
			{
				var t = d[v] + e.D;
				if (d[e.V] > t) { q.E(new E(e.V, d[e.V] = t)); c[e.V] = c[v]; }
				else if (d[e.V] == t) c[e.V] = (c[e.V] + c[v]) % M;
			}
		}
	}
}
struct E
{
	public readonly int V;
	public readonly long D;
	public E(int v, long d) { V = v; D = d; }
	public long C(E e) => D - e.D;
}
class Q
{
	List<E> a = new List<E>();
	public int C;
	public void E(E x)
	{
		var i = C++;
		a.Add(x);
		while (i > 0)
		{
			var p = (i - 1) / 2;
			if (a[p].C(x) <= 0) break;
			a[i] = a[p];
			i = p;
		}
		a[i] = x;
	}
	public E D()
	{
		var v = a[0];
		var x = a[--C];
		a.RemoveAt(C);
		if (C == 0) return v;
		var i = 0;
		while (i * 2 + 1 < C)
		{
			var l = 2 * i + 1;
			var r = 2 * i + 2;
			if (r < C && a[r].C(a[l]) < 0) l = r;
			if (a[l].C(x) >= 0) break;
			a[i] = a[l];
			i = l;
		}
		a[i] = x;
		return v;
	}
}