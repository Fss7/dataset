using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

class Program
{
    public Program()
    {
        int n = int.Parse(Console.ReadLine());
        string result
            = Enumerable.Range(0, n)
            .Select(x => Console.ReadLine())
            .GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .First().Key;
        Console.WriteLine(result);
    }
    static void Main(string[] args)
    {
        var p = new Program();
    }
}