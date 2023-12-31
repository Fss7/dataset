using System;
using System.IO;

#region Program
namespace Program
{
    #region Solver
    public class Solver
    {
        static IO.StreamScanner
        sc = new IO.StreamScanner(Console.OpenStandardInput());

        int N;
        int M;

        long dpSize;

        int[] rabbit;

        #region Solver
        public Solver()
        {
            N = sc.Integer();
            M = sc.Integer();

            // 2?N?
            dpSize = 1L << N;

            // ??? bit??
            // 0-indexed
            rabbit = new int[N];
            for (int i = 0; i < N; i++)
            {
                rabbit[i] = 1 << i;
            }

            // ????????
            for (int i = 0; i < M; i++)
            {
                int w1 = sc.Integer();
                int w2 = sc.Integer();
                // OR??
                // ?2???????1????????????
                // 0-indexed ??
                rabbit[w2 - 1] |= rabbit[w1 - 1];
            }
        }
        #endregion

        #region Solve
        public void Solve()
        {
            long[] dp = new long[dpSize];
            // ????????????????????
            // ?????????????
            dp[0] = 1;

            // ?????? dp
            // 0-indexed
            for (int i = 0; i < dpSize; i++)
            {
                // ???
                for (int j = 0; j < N; j++)
                {
                    int shift = 1 << j;
                    if ((i & shift) == 0
                        && (i & rabbit[j]) == 0)
                    {
                        // ????? ??dp
                        dp[i | shift] += dp[i];
                    }
                }
            }

            Console.WriteLine(dp[dpSize - 1]);

        }
        #endregion
    }
    #endregion
}
#endregion

#region Execute
class Execute
{
    public static void Main(string[] args)
    {
        new Program.Solver().Solve();
        Program.IO.Printer.Out.Flush();
    }
}
#endregion

#region Program.IO
namespace Program.IO
{
    using System.Text;
    using System.Globalization;
    using System.Linq;
    public class Printer : StreamWriter
    {
        static Printer()
        {
            Out = new Printer(Console.OpenStandardOutput())
            {
                AutoFlush = false
            };
        }
        public static Printer Out
        {
            get;
            set;
        }
        public override IFormatProvider FormatProvider
        {
            get
            {
                return CultureInfo.InvariantCulture;
            }
        }
        public Printer(System.IO.Stream stream)
            : base(stream, new UTF8Encoding(false, true))
        {
        }
        public Printer(System.IO.Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
        }
        public void Write<T>(string format, T[] source)
        {
            base.Write(format, source.OfType<object>().ToArray());
        }
        public void WriteLine<T>(string format, T[] source)
        {
            base.WriteLine(format, source.OfType<object>().ToArray());
        }
    }
    public class StreamScanner
    {
        public readonly Stream str;
        private readonly byte[] buf = new byte[1024];
        private int len, ptr;
        public bool isEof = false;
        public StreamScanner(Stream stream)
        {
            str = stream;
        }
        private T[] enumerate<T>(int n, Func<T> f)
        {
            var a = new T[n];
            for (int i = 0; i < n; ++i) a[i] = f();
            return a;
        }
        public long Long()
        {
            if (isEof)
            {
                return long.MinValue;
            }
            long ret = 0;
            byte b = 0;
            var ng = false;
            do
            {
                b = read();
            }
            while (b != '-' && (b < '0' || '9' < b));
            if (b == '-')
            {
                ng = true;
                b = read();
            }
            for (; true; b = read())
            {
                if (b < '0' || '9' < b)
                {
                    return ng ? -ret : ret;
                }
                else ret = ret * 10 + b - '0';
            }
        }
        public long[] Long(int n)
        {
            return enumerate(n, Long);
        }
        public int Integer()
        {
            return (isEof) ? int.MinValue : (int)Long();
        }
        public int[] Integer(int n)
        {
            return enumerate(n, Integer);
        }
        public char[] Char(int n)
        {
            return enumerate(n, Char);
        }
        public char Char()
        {
            byte b = 0;
            do
            {
                b = read();
            }
            while ((b < 33 || 126 < b) && !isEof);
            return (char)b;
        }
        public string Scan()
        {
            var sb = new StringBuilder();
            for (var b = Char(); b >= 33 && b <= 126; b = (char)read())
            {
                sb.Append(b);
            }
            return sb.ToString();
        }
        private byte read()
        {
            if (isEof)
            {
                return 0;
            }
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
    }
}
#endregion