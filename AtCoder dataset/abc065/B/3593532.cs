using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
// ReSharper disable MemberCanBeMadeStatic.Local
// ReSharper disable PossibleNullReferenceException
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable SuggestVarOrType_Elsewhere


namespace All
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Program().Solve(new Input(Console.In));
        }

        private void Solve(Input cin)
        {

            //066: 0330

            var N = cin.ReadInt;
            var a = cin.ReadIntArray(N);

            var pusshed = new HashSet<int>();

            var last = 1;
            var count = 0;
            while (true)
            {
                var now = a[last - 1];
                if (!pusshed.Add(now))
                {
                    Console.WriteLine("-1");
                    return;
                }

                count++;
                if (now == 2)
                    break;
                last = now;
            }

            Console.WriteLine(count);
        }

        bool good( string s)
        {
            return s.Length % 2 == 0 && s.Substring(0, s.Length / 2) == s.Substring(s.Length / 2);
        }

    }

    public class Input
    {
        private readonly TextReader _stream;
        private readonly char _separator;
        private readonly Queue<string> _input;

        public Input(TextReader reader, char separator = ' ')
        {
            this._separator = separator;
            this._stream = reader;
            this._input = new Queue<string>();
        }

        public string Read
        {
            get {
                if (this._input.Count != 0) return this._input.Dequeue();

                var tmp = this._stream.ReadLine().Split(this._separator);
                foreach (var val in tmp) {
                    this._input.Enqueue(val);
                }

                return this._input.Dequeue();
            }
        }

        public string ReadLine => _stream.ReadLine();

        public int ReadInt => int.Parse(Read);

        public long ReadLong => long.Parse(Read);

        public double ReadDouble => double.Parse(Read);

        public string[] ReadStrArray(long n)
        {
            var ret = new string[n];
            for (long i = 0; i < n; ++i) ret[i] = Read;
            return ret;
        }

        public int[] ReadIntArray(long n)
        {
            var ret = new int[n];
            for (long i = 0; i < n; ++i) ret[i] = ReadInt;
            return ret;
        }

        public long[] ReadLongArray(long n)
        {
            var ret = new long[n];
            for (long i = 0; i < n; ++i) ret[i] = ReadLong;
            return ret;
        }
    }
}