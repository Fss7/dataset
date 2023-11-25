using System;
namespace WpfApp1
{
    using l = Library;
    using C = Console;
    class program:l.library
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            if (a == 'a' || a == 'i' || a == 'u' || a == 'e' || a == 'o')
            {
                C.WriteLine("vowel");
            }
            else
            {
                C.WriteLine("consonant");
            }
        }
        
    }
}
namespace Library
{
    class library
    {
        public static long Max(long a, long b)
        {
            if (a <= b) return b;
            else return a;
        }
        public static long Min(long a, long b)
        {
            if (a == Max(a, b)) return b;
            else return a;
        }
        public static long GCD(long a, long b)
        {
            while (Max(a, b) % Min(a, b) != 0)
            {
                if (a < b) b %= a;
                else a %= b;
            }
            return Min(a, b);
        }
        public static long LCM(long a, long b)
        {
            return a / GCD(a, b) * b;
        }
    }
}