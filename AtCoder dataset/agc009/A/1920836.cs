using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
class Simple{
    private int N;
    private long[] a, b;
    void Solve(){
        //input
        N = io.Int;
        a = new long[N];
        b = new long[N];
        for(int i = 0; i < N; ++i){
            a[i] = io.Int;
            b[i] = io.Int;
        }
        //cal
        var cnt = 0L;
        for(int i = N - 1; i >= 0; --i) if((a[i] + cnt) % b[i] != 0) cnt += b[i] * ((a[i] + cnt) / b[i] + 1) - (a[i] + cnt);
        //ret
        Console.WriteLine(cnt);
    }
    SimpleIO io = new SimpleIO();
    public static void Main(string[] args) { new Simple().Stream(); }
    void Stream(){
        Solve();
        io.writeFlush();
    }
}
class SimpleIO{
    string[] nextBuffer;
    int BufferCnt;
    char[] cs = new char[]{' '};
    StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()){AutoFlush = false};
    public SimpleIO(){
        nextBuffer = new string[0];
        BufferCnt = 0;
        Console.SetOut(sw);
    }
    public string Next(){
        if(BufferCnt < nextBuffer.Length) return nextBuffer[BufferCnt++];
        string st = Console.ReadLine();
        while(st == "") st = Console.ReadLine();
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