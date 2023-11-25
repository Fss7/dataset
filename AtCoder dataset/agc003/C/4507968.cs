using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        //???????1??????????????
        //???????????2??????
        //?????????????????????????
        //??????????????????????????????????�
        //?????swap????????????????�
        //swap?????????2????/2
        //?????
        int n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToList();
        var ca = a.Compress().ToList();
        Console.WriteLine(ca.Where((x, y) => x % 2 != y % 2).Count() / 2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<int> Compress<T>(this IEnumerable<T> enumerable) where T : IComparable<T>
    {
        var dict = enumerable.OrderBy(x => x).Distinct().Select((x, y) => new Tuple<T, int>(x, y)).ToDictionary(x => x.Item1, x => x.Item2);
        return enumerable.Select(x => dict[x]);
    }
}