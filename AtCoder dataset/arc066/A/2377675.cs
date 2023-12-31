using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ARC066C
{
    public class Program
    {
        void Solve(StreamScanner ss, StreamWriter sw)
        {
            //---------------------------------
            var N = ss.Next(int.Parse);
            var A = ss.Next(int.Parse, N).OrderBy(x => x).ToArray();

            for (var i = 0; i < N; i++)
            {
                if (A[i] == (N % 2 == 0 ? i + 1 - i % 2 : i + i % 2)) continue;
                sw.WriteLine(0);
                return;
            }

            sw.WriteLine(new ModInt(2).Pow(N / 2));
            //---------------------------------
        }

        static void Main()
        {
            var ss = new StreamScanner(new StreamReader(Console.OpenStandardInput()));
            var sw = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            new Program().Solve(ss, sw);
            sw.Flush();
        }

        static readonly Func<string, string> String = s => s;
    }

    public struct ModInt
    {
        public static int Mod = 1000000007;

        readonly long value;
        public int Value { get { return (int)value; } }
        public ModInt Inverse { get { return GetInverse(); } }

        public ModInt(long value)
        {
            value %= Mod;
            this.value = value < 0 ? value + Mod : value;
        }

        ModInt GetInverse()
        {
            if (value == 0) throw new InvalidOperationException("value must NOT equal 0");
            return Pow(Mod - 2);
        }

        public ModInt Square()
        {
            return this * this;
        }

        public ModInt Pow(long exp)
        {
            if (exp == 0) return 1;
            if (exp % 2 == 0) return Pow(exp / 2).Square();
            return this * Pow(exp - 1);
        }

        public static ModInt Parse(string str)
        {
            return long.Parse(str);
        }

        public static implicit operator ModInt(long value)
        {
            return new ModInt(value);
        }

        public static ModInt operator +(ModInt left, ModInt right)
        {
            return left.value + right.value;
        }

        public static ModInt operator -(ModInt left, ModInt right)
        {
            return left.value - right.value;
        }

        public static ModInt operator *(ModInt left, ModInt right)
        {
            return left.value * right.value;
        }

        public static ModInt operator /(ModInt left, ModInt right)
        {
            return left * right.Inverse;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ModInt)) return false;
            return value == ((ModInt)obj).value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }

    public class StreamScanner
    {
        static readonly char[] Sep = {' '};
        readonly Queue<string> buffer = new Queue<string>();
        readonly TextReader textReader;

        public StreamScanner(TextReader textReader)
        {
            this.textReader = textReader;
        }

        public T Next<T>(Func<string, T> parser)
        {
            if (buffer.Count != 0) return parser(buffer.Dequeue());
            var nextStrings = textReader.ReadLine().Split(Sep, StringSplitOptions.RemoveEmptyEntries);
            foreach (var nextString in nextStrings) buffer.Enqueue(nextString);
            return Next(parser);
        }

        public T[] Next<T>(Func<string, T> parser, int x)
        {
            var ret = new T[x];
            for (var i = 0; i < x; ++i) ret[i] = Next(parser);
            return ret;
        }

        public T[][] Next<T>(Func<string, T> parser, int x, int y)
        {
            var ret = new T[y][];
            for (var i = 0; i < y; ++i) ret[i] = Next(parser, x);
            return ret;
        }
    }
}