using System;

namespace atcoderA
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int N = input[0];
            int K = input[1];
            Console.WriteLine(N % K == 0 ? 0 : 1);
        }
    }
}