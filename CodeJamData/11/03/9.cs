﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GCJ2011_QRB
{
    class Program
    {
        private static void Main(string[] args)
        {
            string filedir = @"c:\temp\google_comp\";
            string inputfile = filedir + @"test1.in";
            string outputfile = inputfile.Replace(".in", ".out");
            Queue<string> lines = new Queue<string>(File.ReadAllLines(inputfile));
            int numcases = int.Parse(lines.Dequeue());
            var results = new List<string>();
            for (int casenum = 0; casenum < numcases; casenum++)
            {
                int num_c = int.Parse(lines.Dequeue());
                int[] c_vals = lines.Dequeue().Split(' ').Select(a => int.Parse(a)).ToArray();
                int sum = 0;
                for (int i = 0; i < c_vals.Length; i++)
                    sum = sum ^ c_vals[i];
                if(sum != 0)
                {
                    results.Add(string.Format("Case #{0}: NO", casenum + 1));
                }
                else
                {
                    Array.Sort(c_vals);
                    int r = c_vals.Sum() - c_vals[0];
                    results.Add(string.Format("Case #{0}: {1}", casenum + 1, r));
                }
            }

            File.WriteAllLines(outputfile, results);

        }

    }

    
    static class Extensions
    {
        public static List<T> TakeN<T>(this Queue<T> q, int num)
        {
            List<T> res = new List<T>();
            for (int i = 0; i < num; i++) res.Add(q.Dequeue());
            return res;
        }
        public static Tuple<int, int> SplitInt2(this string s)
        {
            var r = s.Split(' ').Select(a => int.Parse(a)).ToArray();
            return new Tuple<int, int>(r[0], r[1]);
        }

    }
}
