using System;

namespace ARC064A{
    public class Program{
        public static void Main(string[] args){
            var sr = new StreamReader();
            //---------------------------------
            var N = sr.Next<int>();
            var X = sr.Next<int>();
            var A = sr.Next<int>(N);

            var res = 0L;
            for(var i = 0; i < N; i++){
                var dif = Math.Max(0, A[i] - X);
                A[i] -= dif;
                res += dif;
            }
            for(var i = 1; i < N; i++){
                var dif = Math.Max(0, A[i - 1] + A[i] - X);
                A[i] -= dif;
                res += dif;
            }

            Console.WriteLine(res);
            //---------------------------------
        }
    }

    public class StreamReader{
        private readonly char[] _c = {' '};
        private int _index = -1;
        private string[] _input = new string[0];
        private readonly System.IO.StreamReader _sr = new System.IO.StreamReader(Console.OpenStandardInput());

        public T Next<T>(){
            if(_index == _input.Length - 1){
                _index = -1;
                while(true){
                    string rl = _sr.ReadLine();
                    if(rl == null){
                        if(typeof(T).IsClass) return default(T);
                        return (T)typeof(T).GetField("MinValue").GetValue(null);
                    }
                    if(rl != ""){
                        _input = rl.Split(_c, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    }
                }
            }
            return (T)Convert.ChangeType(_input[++_index], typeof(T), System.Globalization.CultureInfo.InvariantCulture);
        }

        public T[] Next<T>(int x){
            var ret = new T[x];
            for(var i = 0; i < x; ++i) ret[i] = Next<T>();
            return ret;
        }

        public T[][] Next<T>(int y, int x){
            var ret = new T[y][];
            for(var i = 0; i < y; ++i) ret[i] = Next<T>(x);
            return ret;
        }
    }
}