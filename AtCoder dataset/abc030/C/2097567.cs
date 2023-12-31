using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using static System.Console;
using static System.Math;
class Simple {
    private int N, M;
    private int X, Y;
    private int[] a, b;
    void Solve() {
        //input
        N = io.Int;
        M = io.Int;
        X = io.Int;
        Y = io.Int;
        a = new int[N];
        b = new int[M];
        for(int i = 0; i < N; ++i) a[i] = io.Int;        
        for(int i = 0; i < M; ++i) b[i] = io.Int;        
        //cal
        var cnt = 0;
        var aIndex = 0;
        var bIndex = 0;
        var isA = true;
        var chokudai = 0;
        while(true) {
            if(isA) {
                if(aIndex == N) break;
                if(chokudai <= a[aIndex]) {
                    chokudai = a[aIndex] + X;
                    isA = false;
                }
                aIndex++;                
            } else {
                if(bIndex == M) break;
                if(chokudai <= b[bIndex]) {
                    chokudai = b[bIndex] + Y;
                    isA = true;
                    cnt++;
                }
                bIndex++;                
            }
        }
        //ret
        WriteLine(cnt);
    }
    SimpleIO io = new SimpleIO();
    public static void Main(string[] args) => new Simple().Stream();
    private void Stream() {
        //var exStdIn = new System.IO.StreamReader("stdin.txt");
        //SetIn(exStdIn);
        Solve();
        io.Flush();
    }
}
class SimpleIO {
    string[] _nextBuffer;
    int _bufferCnt;
    char[] cs = new char[] {' ', '"', ','};
    StreamWriter sw = new StreamWriter(OpenStandardOutput()) {
        AutoFlush = false
    };
    public SimpleIO() {
        _nextBuffer = new string[0];
        _bufferCnt = 0;
        SetOut(sw);
    }
    string Next() {
        if(_bufferCnt < _nextBuffer.Length)
            return _nextBuffer[_bufferCnt++];
        var st = ReadLine();
        while(st == "")
            st = ReadLine();
        if(st != null)
            _nextBuffer = st.Split(cs, StringSplitOptions.RemoveEmptyEntries);
        else
            st = "";
        _bufferCnt = 0;
        return _nextBuffer[_bufferCnt++];
    }
    public string String => Next();
    public char Char => char.Parse(String);
    public int Int => int.Parse(String);
    public long Long => long.Parse(String);
    public double Double => double.Parse(String);
    public void Flush() => Out.Flush();
}