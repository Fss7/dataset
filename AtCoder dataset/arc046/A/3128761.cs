using System;

class Atcoder38
{
    public static void Main()
    {
        int[] conseq = { 1, 2, 3, 4, 5, 6, 7, 8, 9,
            11, 22, 33, 44, 55, 66, 77, 88, 99,
            111, 222, 333, 444, 555, 666, 777, 888, 999,
            1111, 2222, 3333, 4444, 5555, 6666, 7777, 8888, 9999,
            11111, 22222, 33333, 44444, 55555, 66666, 77777, 88888, 99999,
            111111, 222222, 333333, 444444, 555555 };
        int i = int.Parse(Console.ReadLine());
        Console.WriteLine(conseq[i - 1]);
    }
}