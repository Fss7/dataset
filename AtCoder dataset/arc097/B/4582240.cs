using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Practice
{
	class Program
	{
		static void Main(string[] args)
		{
			Solve();
		}
		private const int MOD = 10007;// 1000000007;
		static void Solve()
		{
			var o = ReadAndParseIntArr();
			var n = o[0];
			var m = o[1];
			var p = ReadAndParseIntArr();
			var x = new int[m];
			var y = new int[m];
			var union = new DisjointSet(n);
			for(int i=0;i<m;++i)
			{
				o = ReadAndParseIntArr();
				x[i] = o[0]-1;
				y[i] = o[1]-1;
				union.Unite(x[i], y[i]);
			}

			var dic = new Dictionary<int, HashSet<int>>();
			for(int i=0;i<n;++i)
			{
				int root = union.FindSet(i);
				if( !dic.ContainsKey(root))
				{
					dic.Add(root, new HashSet<int>());
				}
				dic[root].Add(i);
			}
			var ans = 0;
			foreach(var kv in dic)
			{
				HashSet<int> hash = kv.Value;
				foreach(int idx in hash)
				{
					if(hash.Contains(p[idx]-1))
					{
						ans++;
					}
				}
			}
			Console.WriteLine(ans);
		}
		


		#region ????????a
		private static bool isPrime(long x)
		{
			if(x == 2) { return true; }
			if(x < 2 || x % 2 == 0) { return false; }
			long i = 3;
			while(i * i <= x)
			{
				if(x % i == 0) { return false; }
				i = i + 2;
			}
			return true;
		}
		private static long lcm(long x, long y)
		{
			return x / gcd(x, y) * y;
		}
		private static long gcd(long x, long y)
		{
			return y > 0 ? gcd(y, x % y) : x;
		}
		private static long pow(long x, long n)
		{
			if(n == 0) { return 1; }
			long res = pow(x * x % MOD, n / 2);
			if(n % 2 == 1)
			{
				res = res * x % MOD;
			}
			return res;
		}
		private static int ReadAndParseInt()
		{
			return int.Parse(Console.ReadLine());
		}
		private static int[] ReadAndParseIntArr()
		{
			return Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
		}
		private static long ReadAndParseLong()
		{
			return long.Parse(Console.ReadLine());
		}
		private static long[] ReadAndParseLongArr()
		{
			return Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
		}

		/// <summary>
		/// ???????????????????
		/// </summary>
		/// <typeparam name="T">???????</typeparam>
		/// <param name="arr">??????????????????</param>
		/// <param name="start">??????? [inclusive]</param>
		/// <param name="end">??????? [exclusive]</param>
		/// <param name="value">?????</param>
		/// <param name="comparer">????(????????)</param>
		/// <returns>????????????????</returns>
		public static int LowerBound<T>(IReadOnlyList<T> arr, int start, int end, T value, IComparer<T> comparer)
		{
			int low = start;
			int high = end;
			int mid;
			while(low < high)
			{
				mid = ((high - low) >> 1) + low;
				if(comparer.Compare(arr[mid], value) < 0)
					low = mid + 1;
				else
					high = mid;
			}
			return low;
		}

		//????????????
		public static int LowerBound<T>(IReadOnlyList<T> arr, T value) where T : IComparable
		{
			return LowerBound(arr, 0, arr.Count, value, Comparer<T>.Default);
		}

		/// <summary>
		/// ?????????????????????
		/// </summary>
		/// <typeparam name="T">???????</typeparam>
		/// <param name="arr">??????????????????</param>
		/// <param name="start">??????? [inclusive]</param>
		/// <param name="end">??????? [exclusive]</param>
		/// <param name="value">?????</param>
		/// <param name="comparer">????(????????)</param>
		/// <returns>??????????????????</returns>
		public static int UpperBound<T>(IReadOnlyList<T> arr, int start, int end, T value, IComparer<T> comparer)
		{
			int low = start;
			int high = end;
			int mid;
			while(low < high)
			{
				mid = ((high - low) >> 1) + low;
				if(comparer.Compare(arr[mid], value) <= 0)
					low = mid + 1;
				else
					high = mid;
			}
			return low;
		}

		//????????????
		public static int UpperBound<T>(IReadOnlyList<T> arr, T value)
		{
			return UpperBound(arr, 0, arr.Count, value, Comparer<T>.Default);
		}
		#endregion
	}
	public class DisjointSet
	{
		private int[] rank;
		private int[] p;
		private int[] size;
		public DisjointSet(int n)
		{
			rank = new int[n];
			p = new int[n];
			size = new int[n];
			for(int i = 0; i < n; ++i)
			{
				MakeSet(i);
			}
		}
		public void MakeSet(int x)
		{
			p[x] = x;
			rank[x] = 0;
			size[x] = 1;
		}
		public bool IsSame(int x, int y)
		{
			return FindSet(x) == FindSet(y);
		}
		public void Unite(int x, int y)
		{
			Link(FindSet(x), FindSet(y));
		}
		public void Link(int x, int y)
		{
			if(rank[x] > rank[y])
			{
				p[y] = x;
				size[x] += size[y];
				size[y] = 0;
			}
			else
			{
				p[x] = y;
				size[y] += size[x];
				size[x] = 0;
				if(rank[x] == rank[y])
				{
					rank[y]++;
				}
			}
		}
		public int FindSet(int x)
		{
			if(x != p[x])
			{
				p[x] = FindSet(p[x]);
			}
			return p[x];
		}
		public int Size(int x)
		{
			int root = FindSet(x);
			return size[root];
		}
	}
}