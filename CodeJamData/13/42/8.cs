﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Codejam
{
    class B
    {
        private static ThreadStart s_threadStart = new B().Go;
        private static bool s_time = false;

        long N, P, N2;
        bool CheckSure(long x)
        {
            long X = N2;
            long better = x;
            long pos = 0;
            while (better > 0)
            {
                X >>= 1;
                pos += X;
                better = (better - 1) / 2;
            }
            if (pos >= P) return false;
            return true;
        }
        bool CheckCan(long x)
        {
            long X = N2;
            long better = (N2 - 1 - x);
            long pos = 0;
            while (better > 0)
            {
                X >>= 1;
                pos += X;
                better = (better - 1) / 2;
            }
            pos = N2 - 1 - pos;
            if (pos >= P) return false;
            return true;
        }

        private void Test(int tt)
        {
            N = GetLong();
            P = GetLong();
            N2 = 1;
            for (int i = 0; i < N; i++)
            {
                N2 *= 2;
            }

            long sure;
            long lo = 0;
            long hi = N2;
            while (lo + 1 < hi)
            {
                long m = (lo + hi) / 2;
                if (CheckSure(m))
                {
                    lo = m;
                }
                else
                {
                    hi = m;
                }
            }
            sure = lo;
            if (lo + 1 < N2 && CheckSure(lo + 1)) sure = lo + 1;


            long can;
            lo = 0;
            hi = N2;
            while (lo + 1 < hi)
            {
                long m = (lo + hi) / 2;
                if (CheckCan(m))
                {
                    lo = m;
                }
                else
                {
                    hi = m;
                }
            }
            can = lo;
            if (lo + 1 < N2 && CheckSure(lo + 1)) can = lo + 1;

            /*
            for (int i = 0; i < N2; i++)
            {
                Console.WriteLine("Sure "+ i + ": " + CheckSure(i));

            }
            for (int i = 0; i < N2; i++)
            {
                Console.WriteLine("Can " + i + ": " + CheckCan(i));
            }
             */

            Wl(tt, sure + " " + can);
        }

        #region Template

        private void Go()
        {
            int T = GetInt();
            for (int t = 1; t <= T; t++)
            {
                Test(t);
            }
        }

        public static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            Thread main = new Thread(new ThreadStart(s_threadStart), 1 * 1024 * 1024 * 1024);
            timer.Start();
            main.Start();
            main.Join();
            timer.Stop();
            if (s_time)
                Console.WriteLine(timer.ElapsedMilliseconds);
        }

        private static IEnumerator<string> ioEnum;
        private static string GetString()
        {
            do
            {
                while (ioEnum == null || !ioEnum.MoveNext())
                {
                    ioEnum = Console.ReadLine().Split().AsEnumerable().GetEnumerator();
                }
            } while (string.IsNullOrEmpty(ioEnum.Current));

            return ioEnum.Current;
        }

        private static int GetInt()
        {
            return int.Parse(GetString());
        }

        private static long GetLong()
        {
            return long.Parse(GetString());
        }

        private static double GetDouble()
        {
            return double.Parse(GetString());
        }

        private static List<int> GetIntArr(int n)
        {
            List<int> ret = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                ret.Add(GetInt());
            }
            return ret;
        }

        private static void Wl<T>(int testCase, T o)
        {
            Console.WriteLine("Case #{0}: {1}", testCase, o.ToString());
        }

        private static void Wl<T>(int testCase, IEnumerable<T> enumerable)
        {
            Wl(testCase, string.Join(" ", enumerable.Select(e => e.ToString()).ToArray()));
        }

        #endregion
    }
}