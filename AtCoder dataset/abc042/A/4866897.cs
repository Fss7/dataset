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
        input = input.OrderBy(i => i).ToArray();

        Console.WriteLine(input[0]==5&&input[1]==5&&input[2]==7?"YES":"NO");

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