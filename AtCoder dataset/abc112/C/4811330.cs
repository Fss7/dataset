using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static AtCoderTemplate.MyExtensions;
using static AtCoderTemplate.MyInputOutputs;
using static AtCoderTemplate.MyNumericFunctions;

namespace AtCoderTemplate {
    class Program {
        static void Main (string[] args) {
            var N = ReadInt ();
            var seq = Enumerable.Range (0, N).Select (i => Console.ReadLine ().Split (' ').Select (c => long.Parse (c)).ToList ()).ToList ();
            var xyh = Enumerable.Range (0, seq.First ().Count ()).Select (i => seq.Select (items => items[i]).ToList ()).ToList ();
            var x = xyh[0];
            var y = xyh[1];
            var h = xyh[2];

            var correct = new List<List<long>> ();

            foreach (var cy in Enumerable.Range (0, 101)) {
                foreach (var cx in Enumerable.Range (0, 101)) {
                    var maybeIndex = Enumerable.Range (0, N).Where (i => h[i] != 0).First ();
                    var maybeH = h[maybeIndex] + Abs (x[maybeIndex] - cx) + Abs (y[maybeIndex] - cy);
                    var isCorrect = Enumerable.Range (0, N)
                        .All (i => h[i] == Max (maybeH - Abs (x[i] - cx) - Abs (y[i] - cy), 0));
                    if (isCorrect) {
                        Console.WriteLine ($"{cx} {cy} {maybeH}");
                        return;
                    }
                }
            }
        }
    }

    static class MyInputOutputs {
        /* Input & Output*/
        public static int ReadInt () {
            return int.Parse (Console.ReadLine ());
        }
        public static List<int> ReadInts () {
            return Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
        }
        public static List<List<int>> ReadColumns (int n) {
            /*
            ???
            A1 B1
            A2 B2
            ...
            An Bn

            ???
            [[A1,A2,...,An], [B1,B2,...,Bn]]
            */
            var seq = Enumerable.Range (0, n).Select (i => ReadInts ()).ToList ();
            return Enumerable.Range (0, seq.First ().Count ()).Select (i => seq.Select (items => items[i]).ToList ()).ToList ();
        }
        public static void PrintEnum<T> (IEnumerable<T> list) {
            Console.Write (list.First ());
            foreach (var item in list.Skip (1)) {
                Console.Write ($" {item}");
            }
            Console.Write ("\n");
        }
        public static void PrintLnEnum<T> (IEnumerable<T> list) {
            foreach (var item in list) {
                Console.WriteLine (item);
            }
        }
    }

    static class MyNumericFunctions {
        public static int Fact (int n) {
            return Enumerable.Range (1, n).Aggregate (1, ((i, k) => i * k));
        }
        public static int PermNum (int n, int m) {
            if (m > n) {
                return 0;
            }
            return Enumerable.Range (n - m, m + 1).Aggregate (1, ((i, k) => i * k));
        }
        public static int CombNum (int n, int m) {
            return PermNum (n, m) / Fact (m);
        }
        // ????? (m ? n)
        public static int GCD (int m, int n) {
            if (n == 0) {
                return m;
            } else {
                return GCD (n, m % n);
            }
        }
        // ????? (m ? n)
        public static int LCM (int m, int n) {
            return GCD (m, n) / (m * n);
        }
    }

    static class MyExtensions {
        /// <summary>
        /// ???????????
        /// O(N * log(N))
        /// </summary>
        public static IEnumerable<int> Diff (this IEnumerable<int> source) {
            var list = source.ToList ();
            return Enumerable.Range (1, list.Count - 1)
                .Select (i => list[i] - list[i - 1]);
        }

        /// <summary>
        /// ??????
        /// O(N * log(N))
        /// </summary>
        public static IEnumerable<int> CumSum (this IEnumerable<int> source) {
            var list = source.ToList ();
            var result = new List<int> { list[0] };
            foreach (var i in Enumerable.Range (1, source.Count () - 1)) {
                result.Add (result[i - 1] + list[i]);
            }
            return result;
        }

        /// <summary>
        /// ?????????????????
        /// </summary>
        public static IEnumerable<int> SortIndex<T> (this IEnumerable<T> source) {
            return source
                .Select ((item, i) => new { Item = item, Index = i })
                .OrderBy (x => x.Item)
                .Select (x => x.Index);
        }
    }
}