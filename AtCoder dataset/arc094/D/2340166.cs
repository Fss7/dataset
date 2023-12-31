using System;
using System.Linq;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using SB = System.Text.StringBuilder;
using Number = System.Int64;
using System.Numerics;
using static System.Math;
namespace Program {
    public class Solver {
        Random rnd = new Random(0);
        public void Solve() {
           var s=rs;
           var n=s.Length;
           if(s.ToCharArray().Distinct().Count()==1)
           {
                Console.WriteLine(1);return;
           }
           else if(n==2){
                Console.WriteLine(2);return;
           }
           else if(n==3&&s.ToCharArray().Distinct().Count()==3){
               Console.WriteLine(3);return;
           }
           else{
               
               var parity = 0;
               foreach (var c in s)parity+=c-'a';
               parity%=3;
               long ans=0;
               var dp = new long[3,3,2];
               dp[0,0,0]=1;
               dp[1,1,0]=1;
               dp[2,2,0]=1;
               for(int i=1;i<n;i++){
                   var next=new long[3,3,2];
                   for(int u=0;u<3;u++)
                   for(int v=0;v<3;v++)
                   for(int r=0;r<3;r++)
                   for(int k=0;k<2;k++)
                    {
                        var nk = v==r?1:k;
                        update(ref next[(u+r)%3,r,nk],dp[u,v,k]);
                    }
                    dp=next;
               }
               for(int i=0;i<3;i++)update(ref ans,dp[parity,i,1]);
               for(int i=0;i<n-1;i++){
                   if(s[i]==s[i+1]){Console.WriteLine(ans);return;}
               }
               update(ref ans,1);
               Console.WriteLine(ans);
           }
            
        }
        void update(ref long u,long v){
            const long MOD=998244353;
            u+=v;
            u%=MOD;
        }
        const long INF = 1L << 60;
        //static int[] dx = { -1, 0, 1, 0 };
        //static int[] dy = { 0, 1, 0, -1 };
 
        int ri { get { return sc.Integer(); } }
        long rl { get { return sc.Long(); } }
        double rd { get { return sc.Double(); } }
        string rs { get { return sc.Scan(); } }
        public IO.StreamScanner sc = new IO.StreamScanner(Console.OpenStandardInput());
 
        static T[] Enumerate<T>(int n, Func<int, T> f) {
            var a = new T[n];
            for (int i = 0; i < n; ++i) a[i] = f(i);
            return a;
        }
        static public void Swap<T>(ref T a, ref T b) { var tmp = a; a = b; b = tmp; }
    }
}
 
#region main
static class Ex {
    static public string AsString(this IEnumerable<char> ie) { return new string(ie.ToArray()); }
    static public string AsJoinedString<T>(this IEnumerable<T> ie, string st = " ") {
        return string.Join(st, ie);
    }
    static public void Main() {
        Console.SetOut(new Program.IO.Printer(Console.OpenStandardOutput()) { AutoFlush = false });
        var solver = new Program.Solver();
        try
        {
            solver.Solve();
            Console.Out.Flush();
        }
        catch { }
    }
}
#endregion
#region Ex
namespace Program.IO {
    using System.IO;
    using System.Text;
    using System.Globalization;
 
    public class Printer: StreamWriter {
        public override IFormatProvider FormatProvider { get { return CultureInfo.InvariantCulture; } }
        public Printer(Stream stream) : base(stream, new UTF8Encoding(false, true)) { }
    }
 
    public class StreamScanner {
        public StreamScanner(Stream stream) { str = stream; }
 
        public readonly Stream str;
        private readonly byte[] buf = new byte[1024];
        private int len, ptr;
        public bool isEof = false;
        public bool IsEndOfStream { get { return isEof; } }
 
        private byte read() {
            if (isEof) return 0;
            if (ptr >= len)
            {
                ptr = 0;
                if ((len = str.Read(buf, 0, 1024)) <= 0)
                {
                    isEof = true;
                    return 0;
                }
            }
            return buf[ptr++];
        }
 
        public char Char() {
            byte b = 0;
            do b = read(); while ((b < 33 || 126 < b) && !isEof);
            return (char)b;
        }
        public string Scan() {
            var sb = new StringBuilder();
            for (var b = Char(); b >= 33 && b <= 126; b = (char)read()) sb.Append(b);
            return sb.ToString();
        }
        public string ScanLine() {
            var sb = new StringBuilder();
            for (var b = Char(); b != '\n' && b != 0; b = (char)read()) if (b != '\r') sb.Append(b);
            return sb.ToString();
        }
        public long Long() { return isEof ? long.MinValue : long.Parse(Scan()); }
        public int Integer() { return isEof ? int.MinValue : int.Parse(Scan()); }
        public double Double() { return isEof ? double.NaN : double.Parse(Scan(), CultureInfo.InvariantCulture); }
    }
}
#endregion