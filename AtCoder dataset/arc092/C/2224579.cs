using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;
using static System.Math;
class Z { static void Main() => new K(); }
class K
{
	int F => int.Parse(Str);
	int[] G => Strs.Select(int.Parse).ToArray();
	string Str => ReadLine();
	string[] Strs => Str.Split();
	long MaxSum(List<long> a) => a.Where(i => i >= 0).Sum();
	bool Good(List<long> a) => a.Any(i => i >= 0);
	public K()
	{
		SetOut(new StreamWriter(OpenStandardOutput()) { AutoFlush = false });
		Solve();
		Out.Flush();
	}
	void Solve()
	{
		var N = F;
		var a = G;
		var ev = new List<long>(N / 2);
		var od = new List<long>(N / 2);
		for (var i = 0; i < N; i++) if (i % 2 == 0) ev.Add(a[i]); else od.Add(a[i]);
		bool gev = Good(ev), god = Good(od);
		if (!gev && !god)
		{
			var m = a.Max();
			int i = 0, j = N;
			while (a[i] != m) i++;
			WriteLine(a[i]);
			WriteLine(N - 1);
			for (var k = 0; k < i; k++) { WriteLine(1); j--; }
			while (j > 1) WriteLine(j--);
			return;
		}
		long mev = MaxSum(ev), mod = MaxSum(od);
		WriteLine(Max(mev, mod));
		var del = new List<int>();
		var l = new LinkedList<bool>();
		if (mev >= mod && gev) for (var i = 0; i < N; i++) l.AddLast(i % 2 == 0 && ev[i / 2] >= 0);
		else for (var i = 0; i < N; i++) l.AddLast(i % 2 == 1 && od[i / 2] >= 0);
		while (l.Count > 2)
		{
			var n = l.First;
			if (!n.Value) { del.Add(0); l.RemoveFirst(); }
			else if (!l.Last.Value) { del.Add(l.Count - 1); l.RemoveLast(); }
			else if (n.Next.Next.Value)
			{
				del.Add(1);
				l.RemoveFirst();
				l.RemoveFirst();
			}
			else
			{
				del.Add(2);
				l.Remove(n.Next);
				l.Remove(n.Next);
			}
		}
		if (l.Count > 1) del.Add(l.First.Value ? 1 : 0);
		WriteLine(del.Count);
		foreach (var i in del) WriteLine(i + 1);
	}
}