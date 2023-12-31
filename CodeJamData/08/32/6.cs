using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace GCJ08_R1
{
    class GCJ_B
    {
        static char[] delim = new char[] { ' ', ':' };
        static char[] delim_ = new char[] { ' ' };
        
        string s;
        int[] d;
        int sl;

        bool ugly(long n)
        {
            if (n % 2 == 0) return true;
            if (n % 3 == 0) return true;
            if (n % 5 == 0) return true;
            if (n % 7 == 0) return true;
            return false;
        }

        long calc(int p, long sum, long cur, bool neg)
        {
            long cnt = 0;
            if (p == sl)
            {
                sum += neg ? -cur : cur;
                return ugly(sum) ? 1 : 0;
            }
            int c = d[p];
            cnt += calc(p+1, sum, cur*10+c, neg);
            sum+= neg?-cur:cur;
            cnt += calc(p + 1, sum, c, true);
            cnt += calc(p + 1, sum, c, false);
            return cnt;
        }

        void doCase(int casenum)
        {
            s = rl();
            sl = s.Length;
            d = new int[sl];
            for (int i = 0; i < sl; i++)
            {
                d[i] =  parse<int>(""+s[i]);

            }
            /*
            string[] s = rl().Split(delim_);
            for (int i = 0; i < s.Length; i++)
            {
                dbg(s);
            }
            // */

            long cnt = calc(1, 0, d[0], false);

            //---------------
            wl("Case #" + casenum + ": " + cnt);
        }

        #region PREDEF
        const long INFN = (1L << 63);
        const long INF = unchecked(INFN - 1);

        internal class Point<T>
        {
            public T x, y; 
            public Point(T x, T y) { this.x = x; this.y = y; }
            public double dist(Point<T> p)
            {
                double dx = (double)Convert.ChangeType(p.x, typeof(double)) - (double)Convert.ChangeType(x, typeof(double));
                double dy = (double)Convert.ChangeType(p.y, typeof(double)) - (double)Convert.ChangeType(y, typeof(double));
                return Math.Sqrt(dx * dx + dy * dy);
            }
            public override string ToString() { return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", x, y); }
        }
        internal class Dict : Dictionary<string, int> { }

        static T min<T>(params T[] args) where T : IComparable<T>
        {
            T r = args[0];
            for (int i = 1; i < args.Length; i++)
                if (r.CompareTo(args[i]) > 0) r = args[i];
            return r;
        }
        static T max<T>(params T[] args) where T : IComparable<T>
        {
            T r = args[0];
            for (int i = 1; i < args.Length; i++)
                if (r.CompareTo(args[i]) < 0) r = args[i];
            return r;
        }

        static void w(string s) { Console.Write(s); Debug.Write(s); }
        static void wl(string s) { Console.WriteLine(s); Debug.WriteLine(s); }
        static void dbgf(string format, params object[] args) { Debug.WriteLine(string.Format(CultureInfo.InvariantCulture, "[DBG] " + format, args)); }
        static void dbg(params object[] args) { string f = ""; for (int i = 0; i < args.Length; i++) f += "{" + i + "} "; dbgf(f, args); }

        static string rl() { return Console.ReadLine(); }
        static T parse<T>(string s) { return (T)Convert.ChangeType(s, typeof(T), CultureInfo.InvariantCulture); }
        static void read<T1>(out T1 p1) { p1 = parse<T1>(rl()); }
        static void read<T1, T2>(out T1 p1, out T2 p2)
        {
            string[] l = rl().Split(delim);
            p1 = parse<T1>(l[0]);
            p2 = parse<T2>(l[1]);
        }
        static void read<T1, T2, T3>(out T1 p1, out T2 p2, out T3 p3)
        {
            string[] l = rl().Split(delim);
            p1 = parse<T1>(l[0]);
            p2 = parse<T2>(l[1]);
            p3 = parse<T3>(l[2]);
        }
        static void read<T1, T2, T3, T4>(out T1 p1, out T2 p2, out T3 p3, out T4 p4)
        {
            string[] l = rl().Split(delim);
            p1 = parse<T1>(l[0]);
            p2 = parse<T2>(l[1]);
            p3 = parse<T3>(l[2]);
            p4 = parse<T4>(l[3]);
        }
        static void read<T1, T2, T3, T4, T5>(out T1 p1, out T2 p2, out T3 p3, out T4 p4, out T5 p5)
        {
            string[] l = rl().Split(delim);
            p1 = parse<T1>(l[0]);
            p2 = parse<T2>(l[1]);
            p3 = parse<T3>(l[2]);
            p4 = parse<T4>(l[3]);
            p5 = parse<T5>(l[4]);
        }
        static void read<T1, T2, T3, T4, T5, T6>(out T1 p1, out T2 p2, out T3 p3, out T4 p4, out T5 p5, out T6 p6)
        {
            string[] l = rl().Split(delim);
            p1 = parse<T1>(l[0]);
            p2 = parse<T2>(l[1]);
            p3 = parse<T3>(l[2]);
            p4 = parse<T4>(l[3]);
            p5 = parse<T5>(l[4]);
            p6 = parse<T6>(l[5]);
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                StreamReader streamReader = new StreamReader(args[0]);
                Console.SetIn(streamReader);
            }
            GCJ_B p = new GCJ_B();
            dbgf("--------");
            p.process();
            dbgf("--------");
        }

        int N;
        void process()
        {
            read(out N);
            for (int i = 0; i < N; i++)
            {
                doCase(i + 1);
            }
        }
        #endregion
    }
}
