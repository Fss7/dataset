using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //int a = int.Parse(Console.ReadLine());
        Console.WriteLine(a.Count(x => x == a.Max()) == 1 ? a.Max() : a.Min());
    }
}