using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

namespace AtCoder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Program().Solve(new ConsoleInput(Console.In, ' '));

            return;
        }

        public void Solve(ConsoleInput cin)
        {

            var O = cin.ReadLine;
            var E = cin.ReadLine;

            long OLen = O.Length;
            long ELen = E.Length;
            char[] OChrAry = O.ToCharArray();
            char[] EChrAry = E.ToCharArray();

            long diff = OLen - ELen;

            if(diff == 1){
                char[] passwd = new char[ELen * 2 + 1];
                for (long i = 0; i < ELen; i++){
                    passwd[i * 2] = OChrAry[i];
                    passwd[i * 2 + 1] = EChrAry[i];
                }
                passwd[ELen * 2] = OChrAry[OLen - 1];
                WriteLine(passwd);
            }else if(diff == 0){
                char[] passwd = new char[ELen * 2];
                for (long i = 0; i < ELen; i++){
                    passwd[i * 2] = OChrAry[i];
                    passwd[i * 2 + 1] = EChrAry[i];
                }
                WriteLine(passwd);
            }

        }
    }

    public static class Extensions
    {
        public static string Reverse(this string sourse)
        {
            char[] chrAry = sourse.ToCharArray();
            Array.Reverse(chrAry);
            return new string(chrAry);
        }
    }

    public class ConsoleInput
    {
        private readonly System.IO.TextReader _stream;
        private char _separator = ' ';
        private Queue<string> inputStream;
        public ConsoleInput(System.IO.TextReader stream, char separator = ' ')
        {
            this._separator = separator;
            this._stream = stream;
            inputStream = new Queue<string>();
        }
        public string Read
        {
            get
            {
                if (inputStream.Count != 0) return inputStream.Dequeue();
                string[] tmp = _stream.ReadLine().Split(_separator);
                for (int i = 0; i < tmp.Length; ++i)
                    inputStream.Enqueue(tmp[i]);
                return inputStream.Dequeue();
            }
        }
        public string ReadLine { get { return _stream.ReadLine(); } }
        public int ReadInt { get { return int.Parse(Read); } }
        public long ReadLong { get { return long.Parse(Read); } }
        public double ReadDouble { get { return double.Parse(Read); } }
        public string[] ReadStrArray(long N) { var ret = new string[N]; for (long i = 0; i < N; ++i) ret[i] = Read; return ret; }
        public int[] ReadIntArray(long N) { var ret = new int[N]; for (long i = 0; i < N; ++i) ret[i] = ReadInt; return ret; }
        public long[] ReadLongArray(long N) { var ret = new long[N]; for (long i = 0; i < N; ++i) ret[i] = ReadLong; return ret; }
    }
}