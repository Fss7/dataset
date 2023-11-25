using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Input
{
    private static Queue<string> q = new Queue<string>();
    private static void Confirm() { if (q.Count == 0) foreach (var s in Console.ReadLine().Split(' ')) q.Enqueue(s); }
    public static int NextInt() { Confirm(); return int.Parse(q.Dequeue()); }
    public static long NextLong() { Confirm(); return long.Parse(q.Dequeue()); }
    public static string NextString() { Confirm(); return q.Dequeue(); }
    public static double NextDouble() { Confirm(); return double.Parse(q.Dequeue()); }
    public static int[] LineInt() { return Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); }
    public static long[] LineLong() { return Console.ReadLine().Split(' ').Select(long.Parse).ToArray(); }
    public static string[] LineString() { return Console.ReadLine().Split(' ').ToArray(); }
    public static double[] LineDouble() { return Console.ReadLine().Split(' ').Select(double.Parse).ToArray(); }
}

class Program
{
    static long N, K;
    static long[] A;

    public static void Main(string[] args)
    {
        N = Input.NextLong();
        K = Input.NextLong();
        A = Input.LineLong();

        var k = K;
        int maxBitN = 0;
        for (; ;)
        {
            k = k >> 1;
            if (k == 0)
                break;
            maxBitN++;
        }

        long answer = 0;
        for (int i = maxBitN; i >= 0; i--)
        {
            long bitM = 1L << i;
            var nOf1 = A.Count(n => (n & bitM) != 0);
            var nOf0 = A.Count() - nOf1;
            var cAns = answer + ((nOf1 <= nOf0) ? bitM : 0);
            if (cAns <= K)
                answer = cAns;
        }

        Console.WriteLine(A.Sum(n => n ^ answer));
    }
}