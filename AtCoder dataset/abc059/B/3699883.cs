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

            var A = cin.ReadLine;
            var B = cin.ReadLine;

            int ALen = A.Length;
            int BLen = B.Length;
            char[] AChrAry = A.ToCharArray();
            char[] BChrAry = B.ToCharArray();

            if (ALen > BLen){
                WriteLine("GREATER");
                return;
            }
            else if (ALen < BLen){
                WriteLine("LESS");
                return;
            }
            else if (ALen == BLen){
                for (int i = 0; i < ALen; i++){
                    if(AChrAry[i] - '0' > BChrAry[i] - '0'){
                        WriteLine("GREATER");
                        return;
                    }else if (AChrAry[i] - '0' < BChrAry[i] - '0'){
                        WriteLine("LESS");
                        return;
                    }else if (AChrAry[i] - '0' == BChrAry[i] - '0'){
                        continue;
                    }
                }


                WriteLine("EQUAL");
                return;
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