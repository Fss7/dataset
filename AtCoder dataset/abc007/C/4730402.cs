using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Convert;
using static System.Math;
using Pair = System.Tuple<int, int>;
using Edge = System.Tuple<int, int, long>;
//using Debug;
//using static System.Globalization.CultureInfo;

class Program
{
    static void Main(string[] args)
    {
        var rc = Input.ar;
        var st = Input.ar;
        var go = Input.ar;
        var gred = Input.gred(rc[0]);
        var que = new Queue<Pair>();
        var dist = new int[rc[0], rc[1]];
        que.Enqueue(new Pair(st[0]-1, st[1]-1));
        var gH = new[] { 0, 0, 1, -1 };
        var gW = new[] { 1, -1, 0, 0 };
        while (que.Count != 0)
        {
            var p = que.Dequeue();
            for(var i = 0; i < 4; i++)
            {
                var h = p.Item1 + gH[i];
                var w = p.Item2 + gW[i];
                if (Search.IsInside(h, w, rc) && dist[h, w] == 0 && (h != st[0]-1 || w != st[1]-1)&&gred[h][w]=='.')
                {
                    dist[h, w] = dist[p.Item1, p.Item2] + 1;
                    que.Enqueue(new Pair(h, w));
                }
            }
        }
        WriteLine(dist[go[0] - 1, go[1] - 1]);
    }
}

public class Input
{
    public static string read => ReadLine();
    public  static int[] ar => Array.ConvertAll(read.Split(' '), int.Parse);
    public  static int num => ToInt32(read);
    public static long[] arL => Array.ConvertAll(read.Split(' '), long.Parse);
    public  static long numL => ToInt64(read);
    public static string[] gred(int h) 
        => Enumerable.Repeat(0, h).Select(v => read).ToArray();
    public static int[][] twodim(int num)
        => Enumerable.Repeat(0, num).Select(v => ar).ToArray();
    public static long[][] twodimL(int num)
        => Enumerable.Repeat(0, num).Select(v => arL).ToArray();
    public const long Inf = (long)1e18;
    public const double eps = 1e-11;
    public  const string Alfa = "abcdefghijklmnopqrstuvwxyz";
    public  const int MOD = 1000000007;
}

public class Search
{
    public static int UpperBound<T>(T[] array,T value)
        where T:IComparable<T>
    {
        var low = 0;
        var high = array.Length;
        while (high > low)
        {
            var mid = (high + low) / 2;
            if (array[mid].CompareTo(value) == 1) high = mid;
            else low = mid + 1;
        }
        return low;
    }

    public static int LowerBound<T>(T[] array,T value)
        where T : IComparable<T>
    {
        var low = 0;
        var high = array.Length;
        while (high > low)
        {
            var mid = (high + low) / 2;
            if (array[mid].CompareTo(value) != -1) high = mid;
            else low = mid + 1;
        }
        return low;
    }

    public static T Max<T>(params T[] array)
        => array.Max();
    public static T Min<T>(params T[] array)
        => array.Min();
    public static bool IsInside(int h, int w, int[] hw)
        => 0 <= h && h < hw[0] && 0 <= w && w < hw[1];
    public static bool IsPrime(long num)
    {
        if (num % 2 == 0 || num == 1) return false;
        for (var i = 3; i * i <= num; i += 2)
            if (num % i == 0) return false;
        return true;
    }
}