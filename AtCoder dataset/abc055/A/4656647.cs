using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

internal class Program {
    static void Main() => CustomMain();

    static void Solve() {
        var n = ReadInt();
        WriteAnswer(800 * n - n / 15 * 200);
    }


    static void CustomMain() {
#if DEBUG
        // ?????????????????
        ChangeStdIn();
        // ????
        var stopwatch = new Stopwatch();
        stopwatch.Start();
#endif
        // ?????
        var streamWriter = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
        Console.SetOut(streamWriter);
        // ??
        Solve();
#if DEBUG
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
#endif
        Console.Out.Flush();
    }

    static string ReadString() => Console.ReadLine().Trim();
    static int ReadInt() => int.Parse(ReadString());
    static long ReadLong() => long.Parse(ReadString());
    static float ReadFloat() => float.Parse(ReadString());
    static double ReadDouble => double.Parse(ReadString());

    static string[] ReadStringArray() => ReadString().Split(' ');
    static int[] ReadIntArray() => Array.ConvertAll(ReadString().Split(' '), int.Parse);
    static long[] ReadLongArray() => Array.ConvertAll(ReadString().Split(' '), long.Parse);
    static float[] ReadFloatArray() => Array.ConvertAll(ReadString().Split(' '), float.Parse);
    static double[] ReadDoubleArray() => Array.ConvertAll(ReadString().Split(' '), double.Parse);

    static T TypeConversion<T>(string s) {
        if (typeof(T) == typeof(int)) {
            return (T) Convert.ChangeType(int.Parse(s), typeof(T));
        } else if (typeof(T) == typeof(long)) {
            return (T) Convert.ChangeType(long.Parse(s), typeof(T));
        } else if (typeof(T) == typeof(double)) {
            return (T) Convert.ChangeType(double.Parse(s), typeof(T));
        } else {
            return (T) Convert.ChangeType(s, typeof(T));
        }
    }

    static void ReadMulti<T, U>(out T a, out U b) {
        var str = ReadStringArray();
        a = TypeConversion<T>(str[0]);
        b = TypeConversion<U>(str[1]);
    }

    static void ReadMulti<T, U, V>(out T a, out U b, out V c) {
        var str = ReadStringArray();
        a = TypeConversion<T>(str[0]);
        b = TypeConversion<U>(str[1]);
        c = TypeConversion<V>(str[2]);
    }

    static void WriteAnswer(object ans) => Console.WriteLine(ans);

    static bool IsOdd(long num) {
        return (num & 1) == 1;
    }

    static bool IsEven(long num) {
        return (num & 1) == 0;
    }

    static long GCD(long a, long b) {
        return b != 0 ? GCD(b, a % b) : a;
    }

    static long RoundUp(long a, long b) {
        return (a + b - 1) / b;
    }


    static void ChangeStdIn() {
        var path = "./../../TestCase.txt";
        var exStdIn = new System.IO.StreamReader(path);
        Console.SetIn(exStdIn);
    }
}