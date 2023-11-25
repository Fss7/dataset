using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
class Simple
{
    int N;
    int[] A;
    void Solve() {
        //input
        N = io.Int;
        A = new int[N];
        for (int i = 0; i < N; ++i)
            A[i] = io.Int;
        //cal
        Array.Sort(A);
        var sums = new long[N];
        sums[0] = A[0];
        for (int i = 1; i < N; ++i)
            sums[i] = sums[i - 1] + A[i];
        var ans = 1;//?????????
        for (int i = N - 2; i >= 0 && sums[i] * 2 >= A[i + 1]; i--)
            ans++;

        //ret
        Console.WriteLine(ans);
    }
    SimpleIO io = new SimpleIO();
    public static void Main(string[] args) { new Simple().Stream(); }
    void Stream() { Solve(); io.writeFlush(); }
}
class SimpleIO
{
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