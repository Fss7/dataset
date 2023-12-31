using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static AtCoderTemplate.MyExtensions;
using static AtCoderTemplate.MyInputOutputs;
using static AtCoderTemplate.MyNumericFunctions;

namespace AtCoderTemplate {
    public class Program {
        public static void Main (string[] args) {
            var N = ReadInt ();
            var A = ReadLongs ();

            var sorted = A.OrderBy (x => x);

            var diff = sorted.Last () - sorted.First ();
            Print (diff);
        }
    }

    static class MyInputOutputs {
        /* Input & Output*/
        public static int ReadInt () {
            return int.Parse (Console.ReadLine ());
        }
        public static long ReadLong () {
            return long.Parse (Console.ReadLine ());
        }
        public static List<int> ReadInts () {
            return Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
        }
        public static List<long> ReadLongs () {
            return Console.ReadLine ().Split (' ').Select (c => long.Parse (c)).ToList ();
        }
        public static List<List<int>> ReadIntColumns (int n) {
            /*
            ???
            A1 B1
            A2 B2
            ...
            An Bn

            ???
            [[A1,A2,...,An], [B1,B2,...,Bn]]
            */
            var rows = Enumerable.Range (0, n).Select (i => ReadInts ()).ToList ();
            var m = rows.FirstOrDefault ()?.Count () ?? 0;
            return Enumerable.Range (0, m).Select (i => rows.Select (items => items[i]).ToList ()).ToList ();
        }
        public static List<List<long>> ReadLongColumns (int n) {
            /*
            ???
            A1 B1
            A2 B2
            ...
            An Bn

            ???
            [[A1,A2,...,An], [B1,B2,...,Bn]]
            */
            var rows = Enumerable.Range (0, n).Select (i => ReadLongs ()).ToList ();
            var m = rows.FirstOrDefault ()?.Count () ?? 0;
            return Enumerable.Range (0, m).Select (i => rows.Select (items => items[i]).ToList ()).ToList ();
        }

        public static void Print<T> (T item) {
            Console.WriteLine (item);
        }
        public static void PrintIf<T1, T2> (bool condition, T1 trueResult, T2 falseResult) {
            if (condition) {
                Console.WriteLine (trueResult);
            } else {
                Console.WriteLine (falseResult);
            }
        }

        public static void PrintRow<T> (IEnumerable<T> list) {
            /* ????????
            A B C D ...
            */
            if (!list.IsEmpty ()) {
                Console.Write (list.First ());
                foreach (var item in list.Skip (1)) {
                    Console.Write ($" {item}");
                }
            }
            Console.Write ("\n");
        }
        public static void PrintColomn<T> (IEnumerable<T> list) {
            /* ????????
            A
            B
            C
            D
            ...
            */
            foreach (var item in list) {
                Console.WriteLine (item);
            }
        }
        public static void Print2DArray<T> (IEnumerable<IEnumerable<T>> sources) {
            foreach (var row in sources) {
                PrintRow (row);
            }
        }
    }

    static class MyNumericFunctions {
        public static bool isEven (int a) {
            return a % 2 == 0;
        }
        public static bool isEven (long a) {
            return a % 2 == 0;
        }
        public static bool isOdd (int a) {
            return !isEven (a);
        }
        public static bool isOdd (long a) {
            return !isEven (a);
        }

        public static long nPk (int n, int k) {
            if (k > n) {
                return 0;
            } else {
                return Enumerable.Range (n - k + 1, k).Aggregate ((long) 1, ((i, m) => i * m));
            }
        }
        public static long Fact (int n) {
            return nPk (n, n);
        }
        public static long nCk (int n, int k) {
            if (k > n) {
                return 0;
            } else {
                return nPk (n, k) / Fact (k);
            }
        }
        // ?????

        public static long GCD (long m, long n) {
            if (m < n) {
                return GCD (n, m);
            } else if (n == 0) {
                return m;
            } else {
                return GCD (n, m % n);
            }
        }
        // ?????
        public static long LCM (long m, long n) {
            if (m < n) {
                return LCM (n, m);
            } else {
                return (m * n) / GCD (m, n);
            }
        }
    }

    static class MyExtensions {
        // Append?Prepend??.NET Standard 1.6???????Mono 4.6.2 ????????????????????
        public static IEnumerable<T> Append<T> (this IEnumerable<T> source, T element) {
            return source.Concat (Enumerable.Repeat (element, 1));
        }

        public static IEnumerable<T> Prepend<T> (this IEnumerable<T> source, T element) {
            return Enumerable.Repeat (element, 1).Concat (source);
        }

        // TakeLast?SkipLast??.Net Standard 2.1???????Mono 4.6.2 ???????????
        public static IEnumerable<T> TakeLast<T> (this IEnumerable<T> source, int count) {
            return source.Skip (source.Count () - count);
        }

        public static IEnumerable<T> SkipLast<T> (this IEnumerable<T> source, int count) {
            return source.Take (source.Count () - count);
        }

        public static bool IsEmpty<T> (this IEnumerable<T> source) {
            return !source.Any ();
        }

        /// <summary>
        /// ??????i????????k?????
        /// O(N)
        /// </summary>
        public static IEnumerable<T> TakeAwayRange<T> (this IEnumerable<T> source, int i, int count) {
            return source.Take (i).Concat (source.Skip (i + count));
        }

        /// <summary>
        /// ??????i???????????
        /// O(N)
        /// </summary>
        public static IEnumerable<T> TakeAwayAt<T> (this IEnumerable<T> source, int i) {
            return source.TakeAwayRange (i, 1);
        }

        /// <summary>
        /// ??????i??????????????
        /// O(N + K)
        /// </summary>
        public static IEnumerable<T> InsertEnumAt<T> (this IEnumerable<T> source, int i, IEnumerable<T> inserted) {
            return source.Take (i).Concat (inserted).Concat (source.Skip (i));
        }

        /// <summary>
        /// ?????
        /// O(N!)
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Perm<T> (this IEnumerable<T> source, int n) {
            if (n == 0 || source.IsEmpty () || source.Count () < n) {
                return Enumerable.Empty<IEnumerable<T>> ();
            } else if (n == 1) {
                return source.Select (i => new List<T> { i });
            } else {
                var nexts = source.Select ((x, i) =>
                    new { next = source.Take (i).Concat (source.Skip (i + 1)), selected = source.Take (i + 1).Last () });
                return nexts.SelectMany (next => Perm (next.next, n - 1).Select (item => item.Prepend (next.selected)));
            }
        }

        /// <summary>
        /// ?????????????2??????????????????
        /// </summary>
        /// <para>O(N)</para>
        /// <param name="source">???????</param>
        /// <param name="func">2????</param>
        /// <example>[1,2,3,4].MapAdjacent(f) => [f(1,2), f(2,3), f(3,4)]</example>
        public static IEnumerable<TR> MapAdjacent<T1, TR> (this IEnumerable<T1> source, Func<T1, T1, TR> func) {
            var list = source.ToList ();
            return Enumerable.Range (1, list.Count - 1)
                .Select (i => func (list[i], list[i - 1]));
        }

        /// <summary>
        /// ?????????????????(????first)
        /// <para>O(N)</para>
        /// </summary>
        /// <param name="source">???????</param>
        /// <param name="func">2????f</param>
        /// <param name="first">func(first, source[0])??????</param>
        /// <example> [1,2,3].Scanl1(f,0) => [0, f(0,1), f(f(0,1),2), f(f(f(0,1),2),3)]</example>
        public static IEnumerable<TR> Scanl<T, TR> (this IEnumerable<T> source, Func<TR, T, TR> func, TR first) {
            var list = source.ToList ();
            var result = new List<TR> { first };
            foreach (var i in Enumerable.Range (1, source.Count ())) {
                result.Add (func (result[i - 1], list[i]));
            }
            return result;
        }
        /// <summary>
        /// ??????????????????????source.First()?
        /// <para>O(N)</para>
        /// </summary>
        /// <param name="source">???????</param>
        /// <param name="func">2????f</param>
        /// <example> [1,2,3].Scanl1(f) => [1, f(1,2), f(f(1,2),3)]</example>
        public static IEnumerable<T> Scanl1<T> (this IEnumerable<T> source, Func<T, T, T> func) {
            var list = source.ToList ();
            var result = new List<T> { list[0] };
            foreach (var i in Enumerable.Range (1, source.Count () - 1)) {
                result.Add (func (result[i - 1], list[i]));
            }
            return result;
        }

        /// <summary>
        /// ?????????????????
        /// </summary>
        /// <para>O(N * log N)</para>
        public static IEnumerable<int> SortIndex<T> (this IEnumerable<T> source) {
            return source
                .Select ((item, i) => new { Item = item, Index = i })
                .OrderBy (x => x.Item)
                .Select (x => x.Index);
        }
    }
}