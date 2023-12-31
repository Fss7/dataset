﻿﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

// (づ°ω°)づﾐ★゜・。。・゜゜・。。・゜☆゜・。。・゜゜・。。・゜
public class Solver
{
    void Solve()
    {
        int nt = ReadInt();
        for (int tt = 1; tt <= nt; tt++)
        {
            int n = ReadInt();
            double v = ReadDouble();
            double x = ReadDouble();

            var r = new double[n];
            var c = new double[n];
            bool lower = false, higher = false;
            for (int i = 0; i < n; i++)
            {
                r[i] = ReadDouble();
                c[i] = ReadDouble();
                if (c[i] <= x)
                {
                    lower = true;
                }
                if (c[i] >= x)
                {
                    higher = true;
                }
            }

            if (!lower || !higher)
            {
                writer.WriteLine("Case #{0}: IMPOSSIBLE", tt);
                continue;
            }

            if (n == 1)
            {
                writer.WriteLine("Case #{0}: {1}", tt, v / r[0]);
                continue;
            }

            if (c[0] == c[1])
            {
                writer.WriteLine("Case #{0}: {1}", tt, v / (r[0] + r[1]));
                continue;
            }

            double t1 = v * (x - c[1]) / r[0] / (c[0] - c[1]);
            double t2 = v * (x - c[0]) / r[1] / (c[1] - c[0]);

            writer.WriteLine("Case #{0}: {1}", tt, Math.Max(t1, t2));
        }
    }

    #region Main

    protected static TextReader reader;
    protected static TextWriter writer;
    static void Main()
    {
#if DEBUG
        reader = new StreamReader("..\\..\\input.txt");
        //reader = new StreamReader(Console.OpenStandardInput());
        writer = Console.Out;
        writer = new StreamWriter("..\\..\\output.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());
        //reader = new StreamReader("hull.in");
        //writer = new StreamWriter("hull.out");
#endif
        try
        {
            //            var thread = new Thread(new Solver().Solve, 1024 * 1024 * 128);
            //            thread.Start();
            //            thread.Join();
            new Solver().Solve();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
#if DEBUG
#else
            throw;
#endif
        }
        reader.Close();
        writer.Close();
    }

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0)currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(ReadToken()); }
    public static long ReadLong() { return long.Parse(ReadToken()); }
    public static double ReadDouble() { return double.Parse(ReadToken(), CultureInfo.InvariantCulture); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    public static long[] ReadLongArray() { return ReadAndSplitLine().Select(long.Parse).ToArray(); }
    public static double[] ReadDoubleArray() { return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
    public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++)matrix[i] = ReadIntArray(); return matrix; }
    public static int[][] ReadAndTransposeIntMatrix(int numberOfRows)
    {
        int[][] matrix = ReadIntMatrix(numberOfRows); int[][] ret = new int[matrix[0].Length][];
        for (int i = 0; i < ret.Length; i++) { ret[i] = new int[numberOfRows]; for (int j = 0; j < numberOfRows; j++)ret[i][j] = matrix[j][i]; } return ret;
    }
    public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++)lines[i] = reader.ReadLine().Trim(); return lines; }
    public static void WriteArray<T>(IEnumerable<T> array) { writer.WriteLine(string.Join(" ", array)); }
    public static void Write(params object[] array) { WriteArray(array); }
    public static void WriteLines<T>(IEnumerable<T> array) { foreach (var a in array)writer.WriteLine(a); }
    private class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get { return ContainsKey(key) ? base[key] : default(TValue); }
            set { base[key] = value; }
        }
    }
    private static T[] Init<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++)ret[i] = new T(); return ret; }
    #endregion
}