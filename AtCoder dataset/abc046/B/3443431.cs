using System;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var n = NextInt();
        var k = NextInt();

        var ans = 1;

        for (var i = 0; i < n; i++)
        {
            ans *= k - ((i == 0) ? 0 : 1);
        }
        WriteLine(ans);
    }

    static int NextInt()
    {
        return int.Parse(NextString());
    }

    static string NextString()
    {
        var result = new List<char>();
        while (true)
        {
            int next = Read();
            if (next < 0)
                break;
            var nextChar = (char)next;
            if (!char.IsWhiteSpace(nextChar))
                result.Add(nextChar);
            else if (nextChar != '\r')
                break;
        }
        return string.Join("", result);
    }
}