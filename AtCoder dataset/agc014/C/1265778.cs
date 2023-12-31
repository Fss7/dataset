using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;
using CodeChallenges;
using System.Diagnostics;

#region helpers
namespace CodeChallenges.Boilerplate
{    
    class BufferedStreamReader : StreamReader { const int QUEUE_INITSIZE = 1000; public BufferedStreamReader(String fileName): base(fileName) { } public BufferedStreamReader(Stream stream): base(stream) { } private Queue<string> buffer = new Queue<string>(QUEUE_INITSIZE); public override string ReadLine() { if (buffer.Count > 0) throw new InvalidOperationException("must read from buffer first"); return base.ReadLine(); } public string ReadToken() { while (buffer.Count == 0) { base.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach((t) => { buffer.Enqueue(t); }); } return buffer.Dequeue(); } public void ResetBuffer() { buffer = new Queue<string>(QUEUE_INITSIZE); } }
    class FormattedStreamWriter : StreamWriter { public FormattedStreamWriter(Stream stream) : base(stream) { } public FormattedStreamWriter(string filePath) : base(filePath) { } public override IFormatProvider FormatProvider { get { return CultureInfo.InvariantCulture; } } }
    static class IOExtensions
    {
        public static string ReadString(this BufferedStreamReader reader) { return reader.ReadToken(); }
        public static string[] ReadStringArray(this BufferedStreamReader reader, int n) { var array = new string[n]; for (int i = 0; i < n; ++i) { array[i] = reader.ReadToken(); } return array; }
        public static int ReadInt(this BufferedStreamReader reader) { return int.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); }
        public static int[] ReadIntArray(this BufferedStreamReader reader, int n) { var array = new int[n]; for (int i = 0; i < n; ++i) { array[i] = int.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); } return array; }
        public static uint ReadUnsignedInt(this BufferedStreamReader reader) { return uint.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); }
        public static long ReadLong(this BufferedStreamReader reader) { return long.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); }
        public static long[] ReadLongArray(this BufferedStreamReader reader, int n) { var array = new long[n]; for (int i = 0; i < n; ++i) { array[i] = long.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); } return array; }
        public static ulong ReadUnsignedLong(this BufferedStreamReader reader) { return ulong.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); }
        public static double ReadDouble(this BufferedStreamReader reader) { return double.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); }
        public static double[] ReadDoubleArray(this BufferedStreamReader reader, int n) { var array = new double[n]; for (int i = 0; i < n; ++i) { array[i] = double.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); } return array; }
        public static decimal ReadDecimal(this BufferedStreamReader reader) { return decimal.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); }
        public static decimal[] ReadDecimalArray(this BufferedStreamReader reader, int n) { var array = new decimal[n]; for (int i = 0; i < n; ++i) { array[i] = decimal.Parse(reader.ReadToken(), CultureInfo.InvariantCulture); } return array; }
        public static void WriteArrayLine<T>(this FormattedStreamWriter writer, T[] array, int n, string format = "{0}", string separator = " ") { for (int i = 0; i < n; ++i) { if (i > 0) writer.Write(separator); writer.Write(format, array[i]); } writer.WriteLine(); }
        public static void WriteArrayLine<T>(this FormattedStreamWriter writer, T[] array, string format = "{0}", string separator = " ") { writer.WriteArrayLine(array, array.Length, format, separator); }
    }
    abstract class BaseSolver
    {
        public static T[][] Create2DArray<T>(int dim1, int dim2) { var res = new T[dim1][]; for (int i = 0; i < dim1; ++i) res[i] = new T[dim2]; return res; }
        public static T[][][] Create3DArray<T>(int dim1, int dim2, int dim3) { var res = new T[dim1][][]; for (int i = 0; i < dim1; ++i) res[i] = Create2DArray<T>(dim2, dim3); return res; }
        public static T[][][][] Create4DArray<T>(int dim1, int dim2, int dim3, int dim4) { var res = new T[dim1][][][]; for (int i = 0; i < dim1; ++i) res[i] = Create3DArray<T>(dim2, dim3, dim4); return res; }
        public abstract void Do();
    }    
}
#endregion

#region launch
class Program
{
    static void Main(string[] args)
    {
#if SOLVER_ATWORKSPACE
        var run = true; var outputFile = "output.txt"; var inputFile = "input.txt";
        switch (args[0]) { case "g": run = false; outputFile = "input.txt"; inputFile = "output.txt"; break;case "r":default: run = true; inputFile = "input.txt"; outputFile = "output.txt"; break; }
#endif

        using (var writer = new CodeChallenges.Boilerplate.FormattedStreamWriter(
#if SOLVER_ATWORKSPACE
outputFile
#else
            Console.OpenStandardOutput()
#endif
))
        {
            using (var reader = new CodeChallenges.Boilerplate.BufferedStreamReader(
#if SOLVER_ATWORKSPACE
inputFile
#else 
            Console.OpenStandardInput()
#endif
))
            {
#if SOLVER_ATWORKSPACE
                var stopw = new Stopwatch(); stopw.Start();
#endif
#if SOLVER_ATWORKSPACE
                if (run) new ConcreteSolver(reader, writer).Do(); else new Generator(reader, writer).Create();

#else
                new ConcreteSolver(reader, writer).Do();
#endif
#if SOLVER_ATWORKSPACE
                stopw.Stop(); writer.WriteLine("> {0}ms", stopw.ElapsedMilliseconds);
#endif
            }
        }
    }
}
#endregion

namespace CodeChallenges
{
    using CodeChallenges.Boilerplate;

    class ConcreteSolver: BaseSolver
    {
        private readonly BufferedStreamReader reader;
        private readonly FormattedStreamWriter writer;

        public ConcreteSolver(BufferedStreamReader reader, FormattedStreamWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public override void Do()
        {
            var h = reader.ReadInt();
            var w = reader.ReadInt();
            var k = reader.ReadInt();
            var s = new string[h];
            for (int i = 0; i < h; ++i)
                s[i] = reader.ReadString();
            var dx = new int[] { 0, 1, 0, -1 };
            var dy = new int[] { 1, 0, -1, 0 };
            var res = Create2DArray<int>(h, w);
            int answer = int.MaxValue;
            for (int i = 0; i < h; ++i)
                for (int j = 0; j < w; ++j)
                {
                    if (s[i][j] == 'S')
                    {
                        res[i][j] = 1;
                        var q = new Queue<int>();
                        q.Enqueue(1000 * i + j);
                        while (q.Count > 0)
                        {
                            var dq = q.Dequeue();                            
                            var qi = dq / 1000;
                            var qj = dq % 1000;
                            var toborder = Math.Min(Math.Min(qi, qj), Math.Min(h - 1 - qi, w - 1 - qj));
                            if (toborder % k > 0)
                                toborder = toborder / k + 1;
                            else
                                toborder = toborder / k;
                            answer = Math.Min(answer, 1 + toborder);
                            if (res[qi][qj] <= k)
                            {
                                for (int l = 0; l < 4; ++l)
                                {
                                    if (qi + dx[l] >= 0 && qj + dy[l] >= 0 && qi + dx[l] < h && qj + dy[l] < w)
                                    {
                                        if (res[qi + dx[l]][qj + dy[l]] == 0 && s[qi + dx[l]][qj + dy[l]] == '.')
                                        {
                                            res[qi + dx[l]][qj + dy[l]] = 1 + res[qi][qj];
                                            q.Enqueue((qi + dx[l]) * 1000 + qj + dy[l]);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            writer.WriteLine(answer);
        }
    }
}