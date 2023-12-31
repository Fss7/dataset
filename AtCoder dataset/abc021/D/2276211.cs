using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine(combination(n + k - 1, k));
    }
    static int combination(int n, int r)
    {
        int mod = 1000000007;
        long res = 1;
        long den = 1;
        for (int i = 1; i <= n; i++)
        {
            res = (res * i) % mod;
            if (i == n - r || i == r)
            {
                den = (den * res) % mod;
                if (n - r == r) den = (den * res) % mod;
            }
        }
        long rev = power((int)den, mod - 2);
        return (int)((res * rev) % mod);
    }

    static int power(int n, int m)
    {
        const int mod = 1000000007;
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res = (res * pow) % mod;
            pow = (pow * pow) % mod;
            m >>= 1;
        }
        return (int)res;
    }
}