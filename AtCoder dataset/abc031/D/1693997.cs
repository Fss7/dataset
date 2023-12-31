using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
class Simple {
    int K, N;
    string[] v, w;
    void Solve() {
        //input
        K = io.Int;
        N = io.Int;
        v = new string[N];
        w = new string[N];
        for (int i = 0; i < N;++i){
            v[i] = io.String;
            w[i] = io.String;
        }
        //1~3?K????????
        var res = gRangedArr(K, 1, 3);
        //?????????
        foreach (var list in res) {
            //??
            var f = true;
            for (int i = 0; i < N;++i){
                var len = 0;
                foreach(var c in v[i])
                    len += list[int.Parse(c.ToString()) - 1];
                if (len != w[i].Length) {
                    f = false;
                    break;
                }
            }
            //????????????????????
            if (f){               
                var ans = new string[K];
                for (int i = 0; i < N; ++i) {
                    var ind = 0;
                    foreach (var c in v[i]){
                        var c2i = int.Parse(c.ToString()) - 1;
                        var len = list[c2i];
                        if(ans[c2i]==null||ans[c2i]==""||ans[c2i]==w[i].Substring(ind, len)){
                            ans[c2i] = w[i].Substring(ind, len);                            
                            ind += len;                            
                        }else{
                            //????????????
                            goto OUT;
                        }
                    }                   
                }
                //ret
                foreach (var val in ans) {                 
                    Console.WriteLine(val);
                }
                return;
            }
            OUT:;
        }
    }
    List<int[]> gRangedArr(int content, int rangeStart, int rangeEnd) {
        var result = new List<int[]>();
        _gRangedArr(content-1, new int[content], result, rangeStart, rangeEnd);
        return result;
    }
    void _gRangedArr(int n, int[] Arr, List<int[]> result, int rs, int re) {
        if (n < 0) { result.Add(Arr); return; }
        for (int i = rs; i <= re; ++i) {
            var newArr = Arr.ToArray();
            newArr[n] = i;
            _gRangedArr(n - 1, newArr, result, rs, re);
        }
    }

    SimpleIO io = new SimpleIO();
    public static void Main(string[] args) { new Simple().Stream(); }
    void Stream() {Solve();io.writeFlush();}
}
class SimpleIO {
    string[] nextBuffer;
    int BufferCnt;
    char[] cs = new char[] { ' ' };
    StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
    public SimpleIO() {
        nextBuffer = new string[0];
        BufferCnt = 0;
        Console.SetOut(sw);
    }
    public string Next() {
        if (BufferCnt < nextBuffer.Length)
            return nextBuffer[BufferCnt++];
        string st = Console.ReadLine();
        while (st == "")
            st = Console.ReadLine();
        nextBuffer = st.Split(cs, StringSplitOptions.RemoveEmptyEntries);
        BufferCnt = 0;
        return nextBuffer[BufferCnt++];
    }
    public string String => Next();
    public char Char => char.Parse(String);
    public int Int => int.Parse(String);
    public long Long => long.Parse(String);
    public double Double => double.Parse(String);
    public void writeFlush() { Console.Out.Flush(); }
}