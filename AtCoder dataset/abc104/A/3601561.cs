using System;

class Atcoder92
{
    public static void Main()
    {
        int r = int.Parse(Console.ReadLine());

        if (r < 1200)
            Console.WriteLine("ABC");
        else if (r >= 1200 && r < 2800)
            Console.WriteLine("ARC");
        else
            Console.WriteLine("AGC");
    }
}