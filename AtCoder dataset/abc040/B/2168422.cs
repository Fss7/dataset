using System;

public class Hello
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine().Trim());
        var nx = n / 2 + 1;
        var ret = 999999999999999999L;
        for (long i = 1; i <= nx; i++)
            for (long j = 1; j <= nx; j++)
                if (i * j <= n) ret = Math.Min(ret, Math.Abs(i - j) + n - i * j);
        Console.WriteLine(ret);
    }
}