﻿using System;
using System.Collections.Generic;


class Scanner
{
    string[] s;
    int i;

    char[] cs = new char[] { ' ' };

    public Scanner()
    {
        s = new string[0];
        i = 0;
    }

    public string next()
    {
        if (i < s.Length) return s[i++];
        s = Console.ReadLine().Split(cs, StringSplitOptions.RemoveEmptyEntries);
        i = 0;
        return s[i++];
    }

    public double nextDouble()
    {
        return double.Parse(next());
    }

    public int nextInt()
    {
        return int.Parse(next());
    }

    public long nextLong()
    {
        return long.Parse(next());
    }

}


class Myon
{
    Scanner cin;
    Random rnd;
    Myon() { }

    public static void Main()
    {
        new Myon().multi();
    }

    void multi()
    {
        cin = new Scanner();
        rnd = new Random();
        int T = cin.nextInt();
        for (int c = 1; c <= T; c++)
        {
            Console.Write("Case #{0}: ", c);
            calc();
        }
    }

    void calc()
    {
        int n = cin.nextInt();
        int[,] next = new int[n, 2];
        int count = 0;
        int now = 0;
        int p = 0;
        bool[,] check = new bool[1 << n, n];
        for (int i = 0; i < n - 1; i++)
        {
            next[i, 0] = cin.nextInt() - 1;
            next[i, 1] = cin.nextInt() - 1;
        }
        while (true)
        {
            if (p == n - 1)
            {
                Console.WriteLine(count);
                return;
            }
            if (check[now, p])
            {
                Console.WriteLine("Infinity");
                return;
            }
            check[now, p] = true;
            count++;

            now ^= (1 << p);
            p = next[p, 1 ^ (now >> p) % 2];
        }

    }
}
