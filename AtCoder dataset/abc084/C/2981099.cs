#pragma warning disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Diagnostics;

static class MainClass
{
    public static void Main()
    {
        var n = Console.ReadLine().ToInt32() - 1;
        var ls = new List<Train>();
        for (int i = 0; i < n ; i++)
        {
            var x = Console.ReadLine().SplittedStringToInt32List();
            ls.Add(new Train() { S = x[1], C = x[0], F = x[2] });
        }
        var ansls = new List<int>();

        var j = 0;
        while (true)
        {
            if (j == n)
                break;
            var item = ls[j];
            var amari = item.S / item.F;
            ansls.Add(item.C + item.S);
            for (int i = 0; i < j; i++)
            {
                var time = ansls[i];
                var xx = (time / item.F + (time % item.F == 0 ? 0 :1)) * item.F;
                if (xx < item.S)
                    ansls[i] = item.S + item.C;
                else
                    ansls[i] = xx + item.C;
            }
            j++;
        }
        foreach (var item in ansls)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(0);
        Console.ReadLine();
    }

    #region ?????
    #region ????
    public static int LowerBound<T>(this IEnumerable<T> ar, int start, int end, T value, IComparer<T> comparer)
    {
        var arr = ar.ToArray();
        int low = start;
        int high = end;
        int mid;
        while (low < high)
        {
            mid = ((high - low) >> 1) + low;
            if (comparer.Compare(arr[mid], value) < 0)
                low = mid + 1;
            else
                high = mid;
        }
        return low;
    }

    public static int LowerBound<T>(this IEnumerable<T> arr, T value) where T : IComparable
    {
        return LowerBound(arr, 0, arr.Count(), value, Comparer<T>.Default);
    }

    public static int UpperBound<T>(this IEnumerable<T> ar, int start, int end, T value, IComparer<T> comparer)
    {
        var arr = ar.ToArray();
        int low = start;
        int high = end;
        int mid;
        while (low < high)
        {
            mid = ((high - low) >> 1) + low;
            if (comparer.Compare(arr[mid], value) <= 0)
                low = mid + 1;
            else
                high = mid;
        }
        return low;
    }

    public static int UpperBound<T>(this IEnumerable<T> arr, T value)
    {
        return UpperBound(arr, 0, arr.Count(), value, Comparer<T>.Default);
    }
    #endregion
    #region?bit???
    /// <summary>
    /// Bit??????????
    /// </summary>
    /// <param name="len">???????(len?0???????)</param>
    /// <returns>?????</returns>
    public static List<List<bool>> CreateBits(int len)
    {
        return CreateBitsPri(new List<List<bool>>(), len, 0);
    }

    private static List<List<bool>> CreateBitsPri(List<List<bool>> bits, int len, int count)
    {
        if (count == 0)
        {
            var lss = new List<bool>();
            lss.Add(true);
            bits.Add(lss);
            var lx = new List<bool>();
            lx.Add(false);
            bits.Add(lx);
            count++;
            return CreateBitsPri(bits, len, count);
        }
        if (len - count == 0)
            return bits;
        count++;
        var ls = new List<List<bool>>();
        foreach (var item in bits)
        {
            var x = item.ToList();
            x.Add(true);
            item.Add(false);
            ls.Add(item);
            ls.Add(x);
        }
        return CreateBitsPri(ls, len, count);
    }
    #endregion
    #region ?????

    public static int ToInt32(this string str)
    {
        return int.Parse(str);
    }
    public static List<string> SplittedStringToList(this string str)
    {
        return str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
    public static List<int> SplittedStringToInt32List(this string str)
    {
        return str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
    }
    #endregion
    #region ?????????
    public static List<int> GeneratePrimes(int max)
    {

        var range = Enumerable.Range(2, max - 1).ToList();
        var count = range.Count();
        var ls = new List<int>();
        while (true)
        {
            int num = 0;
            try
            {
                num = range.First();
                ls.Add(num);
            }
            catch
            {
                break;
            }
            for (int i = 1; i * num <= max; i++)
            {
                range.Remove(i * num);
            }
            if (range.Count <= 0)
            {
                break;
            }
        }
        return ls;
    }
    #endregion
    #region DeepClone
    public static T DeepClone<T>(this T src)
    {
        using (var memoryStream = new MemoryStream())
        {
            var binaryFormatter
              = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, src);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return (T)binaryFormatter.Deserialize(memoryStream);
        }
    }
    #endregion
    #region ???????
    public static List<List<int>> GeneratePermutations(int n)
    {
        if (n > 14)
            throw new ArgumentOutOfRangeException();
        var ls = new List<List<int>>();
        ls.Add(new List<int>() { 1 });

        for (int i = 0; i < n - 1; i++)
        {
            var newls = new List<List<int>>();
            ls.ForEach(x =>
            {
                var len = x.Count;
                for (int j = 0; j <= len; j++)
                {
                    var item = x.DeepClone();
                    item.Insert(j, i + 2);
                    newls.Add(item);
                }
            });
            ls = newls;
        }
        return ls;

    }
    #endregion
    public static int Max(int a, int b)
    {
        return a >= b ? a : b;
    }
    public static int Min(int a, int b)
    {
        return b >= a ? a : b;
    }
    #endregion
}

internal class Train
{
    public int S;
    public int F;
    public int C;
}