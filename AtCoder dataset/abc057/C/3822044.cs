using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Atcoder
{
    class Program
    {

        static List<int[]> list = new List<int[]>();
        static int[] yMove = new int[] {-1,1,0,0};
        static int[] xMove = new int[] {0,0,-1,1};
        static bool[,] miz;
        static int cnt = 0;
        static long abs = long.MaxValue;
        static long _A = 0;

        static void Main(string[] args)
        {

            //var line1 = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            //var N = line1[0];
            //var M = line1[1];
            //var a = new long[M];
            //var b = new long[M];

            //int bridge = 0;

            //int[,] dag = new int[N,N];

            //for (int i = 0; i < M; i++)
            //{
            //    var line2 = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            //    a[i] = line2[0]-1;
            //    b[i] = line2[1]-1;
            //    dag[a[i], b[i]] = 1;
            //    dag[b[i], a[i]] = 1;
            //}

            //for (int i = 0; i < M; i++)
            //{
            //    bool[] visited = new bool[N];
            //    dag[a[i], b[i]] = 0;
            //    dag[b[i], a[i]] = 0;
            //    DFS(0,visited,dag);

            //    if (visited.Where(n => n == true).Count() != N)
            //    {
            //        bridge++;
            //    }

            //    dag[a[i], b[i]] = 1;
            //    dag[b[i], a[i]] = 1;
            //}
            //Console.WriteLine(bridge);
            //var line1 = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

            //var A = line1[0];
            //var B = line1[1];
            //var C = line1[2];
            //var D = line1[3];
            //var E = line1[4];
            //var F = line1[5];

            //var N = int.Parse(Console.ReadLine());
            //char[] mozi = new char[N];
            //long[] MARCH = new long[5];
            //long cnt = 0;


            //for (int i = 0; i < N; i++)
            //{
            //    mozi[i] = Console.ReadLine().ToCharArray()[0];
            //}

            //MARCH[0] = mozi.Where(n => n == 'M').Count();
            //MARCH[1] = mozi.Where(n => n == 'A').Count();
            //MARCH[2] = mozi.Where(n => n == 'R').Count();
            //MARCH[3] = mozi.Where(n => n == 'C').Count();
            //MARCH[4] = mozi.Where(n => n == 'H').Count();

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = i + 1; j < 4; j++)
            //    {
            //        for (int k = j + 1; k < 5; k++)
            //        {
            //            cnt += MARCH[i] * MARCH[j] * MARCH[k];
            //        }
            //    }
            //}

            //Console.WriteLine(cnt);

            //var N = int.Parse(Console.ReadLine());

            //var line1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            //var line2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            //int candy = 0;
            //int MAX = 0;

            //for (int i = 0; i < N; i++)
            //{
            //    for (int k = 0; k <= i; k++)
            //    {
            //        candy += line1[k];
            //    }

            //    for (int j = N - 1; j >= i; j--)
            //    {
            //        candy += line2[j];
            //    }

            //    MAX = Math.Max(candy,MAX);
            //    candy = 0;
            //}

            //Console.WriteLine(MAX);

            //var N = int.Parse(Console.ReadLine());
            //List<int[]> list = new List<int[]>();
            //int t = 0;
            //int x = 0;
            //int y = 0;

            //for (int i = 0; i < N; i++)
            //{
            //    var txy = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            //    list.Add(txy);
            //}

            //foreach (var item in list)
            //{
            //    if (item[0] - t >= Math.Abs(item[1] + item[2] - x - y))
            //    {

            //        if (((item[0] - t) % 2 == 1 && Math.Abs(x + y - item[1] - item[2]) % 2 == 1) ||
            //            ((item[0] - t) % 2 == 0 && Math.Abs(x + y - item[1] - item[2]) % 2 == 0))
            //        {
            //            t = item[0];
            //            x = item[1];
            //            y = item[2];
            //        }
            //        else
            //        {
            //            Console.WriteLine("No");
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("No");
            //        return;
            //    }
            //}

            //Console.WriteLine("Yes");

            //var line1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            //if (line1[1] >= 10000)
            //{
            //    for (int i = 0; i <= line1[1]/10000; i++)
            //    {
            //        for (int j = 0; j <= line1[1] / 5000; j++)
            //        {
            //            if (10000 * i + 5000 * j + (line1[0] - i - j) * 1000 == line1[1] && line1[0] - i - j >= 0)
            //            {
            //                Console.WriteLine("{0} {1} {2}",i,j,line1[0] - i - j);
            //                return;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < 2; i++)
            //    {
            //        for (int j = 0; j <= 9; j++)
            //        {
            //            if (5000 * i + 1000 * j == line1[1] && i + j == line1[0])
            //            {
            //                Console.WriteLine("{0} {1} {2}", 0, i, j);
            //                return;
            //            }
            //        }
            //    }
            //}

            //Console.WriteLine("{0} {1} {2}", -1, -1, -1);


            //var N = int.Parse(Console.ReadLine());
            //int[,] station = new int[N,3];
            //long sum = 0;


            //for (int i = 0; i < N - 1; i++)
            //{
            //    var line = Array.ConvertAll(Console.ReadLine().Split(),int.Parse);
            //    station[i, 0] = line[0];
            //    station[i, 1] = line[1];
            //    station[i, 2] = line[2];
            //}

            //for (int j = 0; j < N -1; j++)
            //{
            //    for (int i = j; i < N - 1; i++)
            //    {
            //        var F = station[i, 2];
            //        var S = station[i, 1];
            //        if (i == j)
            //        {
            //            sum += station[i, 0] + station[i, 1];
            //        }
            //        else
            //        {
            //            if (sum < S)
            //            {
            //                sum = S + station[i, 0];
            //            }
            //            else if (sum % F == 0)
            //            {
            //                sum += station[i, 0];
            //            }
            //            else
            //            {
            //                sum += F - (sum % F) + station[i, 0];
            //            }
            //        }
            //    }

            //    Console.WriteLine(sum);
            //    sum = 0;
            //}
            //Console.WriteLine(sum);

            //var line = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            //long A = line[0];
            //int i = 0;

            //while (A <= line[1])
            //{
            //    A *=2;
            //    i++;
            //}

            //Console.WriteLine(i);
            //var N = long.Parse(Console.ReadLine());
            //var line = Array.ConvertAll(Console.ReadLine().Split(),long.Parse);
            //Dictionary<long, long> dic = new Dictionary<long, long>();
            //long sum = 0;

            //for (int i = 0; i < N; i++)
            //{
            //    if (dic.ContainsKey(line[i]))
            //    {
            //        dic[line[i]]++;
            //    }
            //    else
            //    {
            //        dic.Add(line[i], 1);
            //    }
            //}

            //foreach (var item in dic)
            //{
            //    if (item.Key == item.Value)
            //    {

            //    }
            //    else if (item.Key < item.Value)
            //    {
            //        sum += item.Value - item.Key;
            //    }
            //    else
            //    {
            //        sum += item.Value;
            //    }
            //}

            //Console.WriteLine(sum);

            //var line = Array.ConvertAll(Console.ReadLine().Split(),long.Parse);
            //var N = line[0];
            //var K = line[1];

            //var line2 = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            //long cnt = 0;
            //long sum = 0;

            //long[] lngarray = new long[N];

            //for (int i = 0; i < N; i++)
            //{
            //    lngarray[line2[i]-1]++;
            //}

            //if (lngarray.Where(n => n !=0).Count() <= K)
            //{
            //    Console.WriteLine(0);
            //    return;
            //}

            //var orderlng = lngarray.Where(n => n != 0).OrderBy(n => n).ToArray();

            //for (int i = 0; i < orderlng.Length; i++)
            //{
            //    if (cnt == orderlng.Length - K)
            //    {
            //        Console.WriteLine(sum);
            //        return;
            //    }
            //    else
            //    {
            //        sum += orderlng[i];
            //        cnt++;
            //    }
            //}
            //int soe = 0;
            //saiki(soe, new int[10]);

            //var N = int.Parse(Console.ReadLine());
            //var F = new List<int[]>();
            //var P = new List<int[]>();

            //for (int i = 0; i < N; i++)
            //{
            //    var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            //    F.Add(line);
            //}

            //for (int i = 0; i < N; i++)
            //{
            //    var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            //    P.Add(line);
            //}

            //int sum = int.MinValue;
            //list.RemoveAt(0);
            //foreach (var item in list)
            //{
            //    int tmpsum = 0;
            //    for (int i = 0; i < N; i++)
            //    {
            //        int c = 0;
            //        for (int j = 0; j < 10; j++)
            //        {
            //            if (item[j] == 1 && F[i][j] == 1)
            //            {
            //                c++;
            //            }
            //        }

            //        tmpsum += P[i][c];
            //    }
            //    sum = Math.Max(sum, tmpsum);
            //}

            //Console.WriteLine(sum);


            //var line = Console.ReadLine().ToCharArray();
            //int[] hai = new int[7];

            //hai[0] = int.Parse(line[0].ToString());
            //hai[2] = int.Parse(line[1].ToString());
            //hai[4] = int.Parse(line[2].ToString());
            //hai[6] = int.Parse(line[3].ToString());

            //saikiseven(1,0, hai);

            //string ope1 = list[0][1] == 0 ? "+" : "-";
            //string ope2 = list[0][3] == 0 ? "+" : "-";
            //string ope3 = list[0][5] == 0 ? "+" : "-";

            //Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}=7", list[0][0],ope1, list[0][2], ope2,list[0][4], ope3,list[0][6]);

            //var N = long.Parse(Console.ReadLine());
            //var line = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            //long[] A = new long[N];

            //for (int i = 0; i < N; i++)
            //{
            //    A[i] = Math.Abs(i - (N - i -1));
            //}

            //var tmp1 = line.OrderBy(n => n).ToArray();
            //var tmp2 = A.OrderBy(n => n).ToArray();

            //for (int i = 0; i < N; i++)
            //{
            //    if (tmp1[i] != tmp2[i])
            //    {
            //        Console.WriteLine(0);
            //        return;
            //    }
            //}

            //long X = 1;

            //for (int i = 0; i < N/2; i++)
            //{
            //    X *= 2;
            //    X %= 1000000007;
            //}
            //Console.WriteLine(X);

            //var line =Array.ConvertAll(Console.ReadLine().Split(),int.Parse);

            //var sx = line[0];
            //var sy = line[1];
            //var tx = line[2];
            //var ty = line[3];

            //var path1 = new string('U', ty - sy) + new string('R',tx - sx);
            //var path2 = new string('D', ty - sy) + new string('L', tx - sx);
            //var path3 = new string('L', 1) + new string('U', ty - sy + 1) + new string('R', tx - sx + 1) + new string('D', 1);
            //var path4 = new string('R', 1) + new string('D', ty - sy + 1) + new string('L', tx - sx + 1) + new string('U', 1);
            //Console.WriteLine(path1 + path2 + path3 + path4);
            //int[] sosuu = new int[1000];

            //var N = int.Parse(Console.ReadLine());
            //int[] sosuu = new int[1001];

            //long ans = 1;

            //for (int i = 1; i < N + 1; i++)
            //{
            //    PrimeFactors(i, sosuu);
            //}

            //for (int i = 2; i < N + 1; i++)
            //{
            //    ans *= sosuu[i] + 1;
            //    ans %= 1000000007;

            //}

            //Console.WriteLine(ans);

            //var N = long.Parse(Console.ReadLine());
            //long X = 0;
            //long Y = 0;

            //X = N / 11;

            //if ((N - (11 * X)) == 0)
            //{
            //    Y = 0;
            //}
            //else if ((N - (11 * X)) <= 6)
            //{
            //    Y = 1;
            //}
            //else
            //{
            //    Y = 2;
            //}

            //Console.WriteLine(X * 2 + Y);

            //var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            //var N = line[0];
            //var M = line[1];

            //int[,] RL = new int[N, N];

            //for (int i = 0; i < M; i++)
            //{
            //    var tmp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            //    RL[tmp[0]-1, tmp[1]-1] = 1;
            //    RL[tmp[1]-1, tmp[0]-1] = 1;
            //}

            //bool[] visit = new bool[N];
            //DFSgraph(RL,visit,0);

            //Console.WriteLine(cnt);

            //var line = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            //var N = line[0];
            //var M = line[1];

            //if (N * 2 < M)
            //{
            //    Console.WriteLine(N + (M - 2 * N) /4);
            //}
            //else
            //{
            //    Console.WriteLine(M/2);
            //}
            //var N = int.Parse(Console.ReadLine());
            //var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            //int[,] dp = new int[N + 1, 10001];

            ////for (int i = 0; i < N; i++)
            ////{
            ////    dp[0, line[0]] = line[i];
            ////}

            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < 10001; j++)
            //    {
            //        dp[i + 1, line[i]] = line[i];

            //        if (dp[i,j] != 0)
            //        {
            //            dp[i + 1, j] = dp[i, j];
            //            dp[i + 1, dp[i, j] + line[i]] = line[i] + dp[i, j];
            //        }
            //    }
            //}
            //long ans = 0;
            //for (int i = 0; i < 10001; i++)
            //{
            //    if (dp[N,i] != 0)
            //    {
            //        ans++;
            //    }
            //}

            //Console.WriteLine(ans + 1);

            //var line = Array.ConvertAll(Console.ReadLine().Split(),int.Parse);

            //var A = line[0];
            //var B = line[1];

            //var line2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            //var line3 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            //int[] a = new int[A];
            //int[] b = new int[B];

            //for (int i = 0; i < A; i++)
            //{
            //    a[i] = line2[i];
            //}

            //for (int i = 0; i < B; i++)
            //{
            //    b[i] = line3[i];
            //}

            //int AB = A + B;
            //int[,] dp = new int[A + 1, B + 1];

            //for (int i = 1; i <= A; i++)
            //{
            //    if ((AB - i) % 2 == 0)
            //    {
            //        dp[i, 0] = dp[i - 1, 0] + a[A - i];
            //    }
            //    else
            //    {
            //        dp[i, 0] = dp[i - 1, 0];
            //    }
            //}

            //for (int i = 1; i <= B; i++)
            //{
            //    if ((AB - i) % 2 == 0)
            //    {
            //        dp[0, i] = dp[0, i -1] + b[B - i];
            //    }
            //    else
            //    {
            //        dp[0, i] = dp[0, i -1];
            //    }
            //}

            //for (int i = 1; i <= A; i++)
            //{
            //    for (int j = 1; j <= B; j++)
            //    {
            //        if ((AB - i - j) % 2 == 0)
            //        {
            //            dp[i, j] = Math.Max(dp[i -1,j] + a[A - i],dp[i,j-1] + b[B - j]);
            //        }
            //        else
            //        {
            //            dp[i, j] = Math.Min(dp[i - 1, j] , dp[i, j - 1]);
            //        }

            //    }
            //}

            //Console.WriteLine(dp[A,B]);

            //var N = int.Parse(Console.ReadLine());
            //int[] dp = new int[N + 1];

            //for (int i = 1; i <= N; i++)
            //{
            //    dp[i] = i;
            //}

            //List<int> hai = new List<int>();
            //int loop = 6;

            //while (N>=loop)
            //{
            //    hai.Add(loop);
            //    loop *= 6;
            //}

            //loop = 9;
            //while (N >= loop)
            //{
            //    hai.Add(loop);
            //    loop *= 9;
            //}

            //var hai2 = hai.OrderBy(n => n).ToArray();

            //foreach (var item in hai)
            //{
            //    for (int i = 0; i < N; i++)
            //    {
            //        if (i + item <= N)
            //        {
            //            dp[i + item] = Math.Min(dp[i + item], dp[i] + 1);
            //        }

            //    }
            //}

            //Console.WriteLine(dp[N]);

            //var N = int.Parse(Console.ReadLine());

            //if (N == 1)
            //{
            //    Console.WriteLine(1);
            //    return;
            //}

            //for (int i = 1; i <= N; i++)
            //{
            //    if (2 * N > i * (i + 1))
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        Console.WriteLine(i);
            //        return;
            //    }
            //}

            var N = long.Parse(Console.ReadLine());
            var yaku = getPrime(N).ToArray();

            yakusu(N,0,1,yaku);

            var min = Math.Max(_A.ToString().Length,(N/_A).ToString().Length);
            Console.WriteLine(min);
        }

        public static List<long> getPrime(long n)
        {
            long i = 2;
            long tmp = n;

            List<long> listp = new List<long>();

            while (i * i <= n)
            {
                if (tmp % i == 0)
                {
                    tmp /= i;
                    listp.Add(i);
                }
                else
                {
                    i++;
                }
            }
            if (tmp != 1) listp.Add(tmp);

            return listp;
        }

        public static void yakusu(long N,long num,long A , long[] arr)
        {
            if (num == arr.Length)
            {
                if (Math.Abs(A - N / A) < abs)
                {
                    abs = Math.Min(Math.Abs(A - N / A), abs);
                    _A = A;
                }
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                if (i == 0) yakusu(N,num + 1,A,arr);
                if (i == 1) yakusu(N,num + 1,A * arr[num], arr);
            }

        }

        public static void DFSgraph(int[,] RL,bool[] visit,int v)
        {
            visit[v] = true;

            if (visit.Where(n => n == true).Count() == visit.Length)
            {
                cnt++;
                return;
            }

            for (int i = 0; i < visit.Length; i++)
            {
                if (RL[v,i] == 0) continue;
                if (visit[i]) continue;

                bool[] tmpvisit = new bool[visit.Length];
                visit.CopyTo(tmpvisit,0);

                DFSgraph(RL, tmpvisit, i);
            }
        }

        public static void PrimeFactors(int n,int[] sosuu)
        {
            int i = 2;
            int tmp = n;

            while (i * i <= n) 
            {
                if (tmp % i == 0)
                {
                    tmp /= i;
                    sosuu[i]++;
                }
                else
                {
                    i++;
                }
            }
            if (tmp != 1) sosuu[tmp]++;
        }


        public static void DFSzahyo(int x, int y,int[] s,int[] g)
        {

            if (x == g[0] && y == g[1])
            {
                return;
            }
            miz[x, y] = true;
            for (int i = 0; i < 4; i++)
            {
                if (miz[x + xMove[i], y + yMove[i]] != true)
                {
                    DFSzahyo(x + xMove[i], y + yMove[i],s,g);
                }
            }
        }

        public static void saikiseven(int ope, int sum ,int[] hairetui)
        {
            if (ope == 1)
            {
                sum = hairetui[ope - 1];
            }

            if (ope == 7 && sum == 7)
            {
                int[] dummy = new int[ope];
                hairetui.CopyTo(dummy, 0);
                list.Add(dummy);
                return;
            }
            else if (ope == 7 && sum != 7)
            {
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    sum += hairetui[ope + 1];
                    hairetui[ope] = i;
                    saikiseven(ope + 2, sum, hairetui);
                    sum -= hairetui[ope + 1];
                }
                else
                {
                    sum -= hairetui[ope + 1];
                    hairetui[ope] = i;
                    saikiseven(ope + 2, sum, hairetui);
                }
            }

            return;
        }

        public static void saiki(int soezi,int[] hairetui)
        {
            if (soezi == 10)
            {
                int[] dummy = new int[soezi];
                 hairetui.CopyTo(dummy,0);
                list.Add(dummy);
                return;
            }

            for (int j = 0; j < 2; j++)
            {
                hairetui[soezi] = j;
                saiki(soezi+1, hairetui);
            }

            return;
        }

        public static void DFS(int v,bool[] visited,int[,] dag)
        {
            visited[v] = true;

            for (int i = 0; i < visited.Length; i++)
            {
                if (dag[v, i] == 0) continue;
                if (visited[i]) continue;
                DFS(i,visited,dag);
            }

        }

        public static long LowerBound<T>(T[] arr, long start, long end, T value, IComparer<T> comparer)
        {
            long low = start;
            long high = end;
            long mid;
            while (low < high)
            {
                mid = ((high - low) >> 1) + low;
                if (comparer.Compare(arr[mid], value) < 0)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }

        //????????????
        public static long LowerBound<T>(T[] arr, T value) where T : IComparable
        {
            return LowerBound(arr, 0, arr.Length, value, Comparer<T>.Default);
        }
        public static long UpperBound<T>(T[] arr, long start, long end, T value, IComparer<T> comparer)
        {
            long low = start;
            long high = end;
            long mid;
            while (low < high)
            {
                mid = ((high - low) >> 1) + low;
                if (comparer.Compare(arr[mid], value) <= 0)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }

        //????????????
        public static long UpperBound<T>(T[] arr, T value)
        {
            return UpperBound(arr, 0, arr.Length, value, Comparer<T>.Default);
        }
    }

    /// <summary>
    /// Get min cost between two points
    /// </summary>
    //public class Dijkstra
    //{
    //    private int maxIndex = -1;
    //    private const int INF = Int32.MaxValue;

    //    private int[,] _edgeArray;

    //    /// <summary>
    //    /// Dijkstra, get min cost between two points
    //    /// should not contain negatie cost path
    //    /// </summary>
    //    /// <param name="size">max index of vertices</param>
    //    public Dijkstra(int size)
    //    {
    //        maxIndex = size + 1;
    //        _edgeArray = new int[maxIndex, maxIndex];

    //        for (int i = 0; i < _edgeArray.GetLength(0); i++)
    //        {
    //            for (int j = 0; j < _edgeArray.GetLength(1); j++)
    //            {
    //                _edgeArray[i, j] = INF;
    //                if (i == j) _edgeArray[i, j] = 0;
    //            }
    //        }
    //    }

    //    // Add a path(no direction) with its cost
    //    public void AddPath(int s, int t, int cost)
    //    {
    //        _edgeArray[s, t] = Math.Min(_edgeArray[s, t], cost);
    //        _edgeArray[t, s] = _edgeArray[s, t];
    //    }

    //    //Get the min cost between s and t
    //    //return Int32.MaxValue if no path
    //    public int GetMinCost(int s, int t)
    //    {
    //        int[] cost = new int[maxIndex];
    //        for (int i = 0; i < cost.Length; i++) cost[i] = INF;
    //        cost[s] = 0;

    //        var priorityQueue = new PriorityQueue<ComparablePair<int, int>>(maxIndex);
    //        priorityQueue.Push(new ComparablePair<int, int>(0, s));

    //        while (priorityQueue.Count() > 0)
    //        {
    //            var costDestinationPair = priorityQueue.Pop();
    //            if (cost[costDestinationPair.Item2] < costDestinationPair.Item1) continue;

    //            for (int i = 0; i < maxIndex; i++)
    //            {
    //                int newCostToi = _edgeArray[costDestinationPair.Item2, i] == INF ? INF :
    //                    costDestinationPair.Item1 + _edgeArray[costDestinationPair.Item2, i];
    //                if (newCostToi < cost[i])
    //                {
    //                    cost[i] = newCostToi;
    //                    priorityQueue.Push(new ComparablePair<int, int>(newCostToi, i));
    //                }
    //            }
    //        }

    //        return cost[t];
    //    }
    //}

    //public class ComparablePair<T, U> : IComparable where T : IComparable<T>
    //{
    //    public readonly T Item1;
    //    public readonly U Item2;

    //    public int CompareTo(object obj)
    //    {
    //        ComparablePair<T, U> castedObj = (ComparablePair<T, U>)obj;
    //        return this.Item1.CompareTo(castedObj.Item1);
    //    }

    //    public ComparablePair(T t, U u)
    //    {
    //        Item1 = t;
    //        Item2 = u;
    //    }
    //}



}