using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using static System.Console;
class Program
{
    static void Main()
    {
        //??
        //int n = 100;
        /*
        long n = long.Parse(Console.ReadLine());
        long[] input = new long[5];
        for(int a = 0; a < 5; a++)
        {
            input[a]=long.Parse(Console.ReadLine());
        }
        */
        int[] input = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();
        input = input.Select(i => i).Distinct().ToArray();

        Console.WriteLine(input.Length);

        /*
        //??????
        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        //??

        //??????
        sw.Stop();
        TimeSpan ts = sw.Elapsed;
        Console.WriteLine((int)(Math.Floor((ts).TotalMilliseconds))+"ms");
        */
        Console.ReadLine();
        
    }
}