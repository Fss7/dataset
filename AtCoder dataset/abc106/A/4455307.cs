using System;

namespace atcoderA
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int A = input[0];
            int B = input[1];
            int road = A + B - 1;
            Console.WriteLine(A * B - road);
        }
    }
}