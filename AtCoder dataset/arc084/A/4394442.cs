#pragma warning disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Numerics;
using System.Collections;

static class MainClass
{
    public static void Main(string[] args)
    {
        var n = Console.ReadLine().ToInt32();
        var ans = Console.ReadLine().SplittedStringToInt32List();
        var bns = Console.ReadLine().SplittedStringToInt32List();
        var cns = Console.ReadLine().SplittedStringToInt32List();
        
        ans.Sort();
        bns.Sort();
        cns.Sort();
        BigInteger counts2 = 0;
        foreach (var item in bns)
        {
            var cnscount = cns.UpperBound(item);
            var anscount1 = ans.LowerBound(item);
            
            if (anscount1 < 0 || cnscount < 0 || anscount1 > n || cnscount > n)
                continue;
            var counts = Math.Max((long)(n - cnscount),0l) * Math.Max((long)(anscount1),0l);
            counts2 += counts;
        }
        Console.WriteLine(counts2);

        Console.ReadLine();
    }


    public static int LowerBound<T>(this List<T> ar, int start, int end, T value, IComparer<T> comparer)
    {
        int low = start;
        int high = end;
        int mid;
        while (low < high)
        {
            mid = ((high - low) >> 1) + low;
            if (comparer.Compare(ar[mid], value) < 0)
                low = mid + 1;
            else
                high = mid;
        }
        return low;
    }

    public static int LowerBound<T>(this List<T> arr, T value) where T : IComparable
    {
        return LowerBound(arr, 0, arr.Count(), value, Comparer<T>.Default);
    }

    public static int UpperBound<T>(this List<T> ar, int start, int end, T value, IComparer<T> comparer)
    {
        int low = start;
        int high = end;
        int mid;
        while (low < high)
        {
            mid = ((high - low) >> 1) + low;
            if (comparer.Compare(ar[mid], value) <= 0)
                low = mid + 1;
            else
                high = mid;
        }
        return low;
    }

    public static int UpperBound<T>(this List<T> arr, T value)
    {
        return UpperBound(arr, 0, arr.Count(), value, Comparer<T>.Default);
    }


    public static int Manhattan(int x1,int x2,int y1,int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
    

    public static long Sums(IEnumerable<int> list)
    {
        var sum = 0l;
        foreach (var item in list)
        {
            sum += item;
        }
        return sum;
    }

    public static long f(long n,long b)
    {
        if (n < b)
        {
            return n;
        }
        else
        {
            return f((long)Math.Floor((double)n/b),b) + n % b;
        }
    }

    public static string N(long n,long b)
    {
        var sb = new StringBuilder();
        while (true)
        {
            sb.Append((n % b).ToString());
            n /= b;
            if (n < b)
            {
                sb.Append(n.ToString());
                break;
            }
        }
        return new string( sb.ToString().Reverse().ToArray() );
    }

    #region ?????
    public static long ToInt64(this string str) => long.Parse(str);
    public static int ToInt32(this string str) => int.Parse(str);
    public static BigInteger ToBigInteger(this string str) => BigInteger.Parse(str);
    public static List<string> SplittedStringToList(this string str) => str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    public static List<int> SplittedStringToInt32List(this string str) => str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
    public static List<long> SplittedStringToInt64List(this string str) => str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToList();
    public static List<BigInteger> SplittedStringToBigInteger(this string str) => str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => BigInteger.Parse(x)).ToList();
    public const int INF = int.MaxValue / 2;
    public const long LONGINF = long.MaxValue / 2;
    public const int Mod1e9 = 1000000007;

    public static void PrintArray(bool[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            var sb = new StringBuilder();
            for (int j = 0; j < array.GetLength(1); j++)
            {
                sb.Append(array[i, j]).Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }

    #endregion
}