import java.io.*;
import java.util.*;
import java.util.stream.Stream;

/**
 * @author baito
 */
class P implements Comparable<P>
{
    int x, y;

    P(int a, int b)
    {
        x = a;
        y = b;
    }

    @Override
    public boolean equals(Object o)
    {
        if (this == o) return true;
        if (!(o instanceof P)) return false;
        P p = (P) o;
        return x == p.x && y == p.y;
    }

    @Override
    public int hashCode()
    {
        return Objects.hash(x, y);
    }

    @Override
    public int compareTo(P p)
    {
        return x == p.x ? y - p.y : x - p.x; //x???????
        //return (x == p.x ? y - p.y : x - p.x) * -1; //x???????
        //return y == p.y ? x - p.x : y - p.y;//y???????
        //return (y == p.y ? x - p.x : y - p.y)*-1;//y???????
    }
}

@SuppressWarnings("unchecked")
public class Main
{
    static StringBuilder sb = new StringBuilder();
    static int INF = 1234567890;
    static int MINF = -1234567890;
    static long LINF = 123456789123456789L;
    static long MLINF = -123456789123456789L;
    static long MOD = 1000000007;
    static int[] y4 = {0, 1, 0, -1};
    static int[] x4 = {1, 0, -1, 0};
    static int[] y8 = {0, 1, 0, -1, -1, 1, 1, -1};
    static int[] x8 = {1, 0, -1, 0, 1, -1, 1, -1};
    static long[] Fa;//factorial
    static boolean[] isPrime;
    static int[] primes;
    static char[][] map;
    static long maxRes = MLINF;
    static long minRes = LINF;
    static long startTime = 0;
    static long endTime = 0;

    static int N;
    static int[] A;

    public static void main(String[] args)
    {
        //long???????????????
        startTime = System.currentTimeMillis();
        int R = ni();
        int G = ni();
        int B = ni();
        PrimalDual p = new PrimalDual(1200);
        int s = 1160;
        int t = 1161;
        int rid = 1162;
        int gid = 1163;
        int bid = 1164;
        p.addEdge(s, rid, R, 0);
        p.addEdge(s, gid, G, 0);
        p.addEdge(s, bid, B, 0);
        for (int pos = -500; pos < 500; pos++)
        {
            int plus = 504;
            p.addEdge(rid, pos + plus, 1, abs(-100 - pos));
            p.addEdge(gid, pos + plus, 1, abs(0 - pos));
            p.addEdge(bid, pos + plus, 1, abs(100 - pos));
            p.addEdge(pos + plus, t, 1, 0);
        }
        System.out.println(p.solve(s, t, R + G + B));

        endTime = System.currentTimeMillis();
        System.err.println(endTime - startTime);
    }

    static class PrimalDual//?????
    {
        static ArrayList<Edge>[] edges;

        PrimalDual(int n)
        {
            edges = Stream.generate(ArrayList::new).limit(n).toArray(ArrayList[]::new);
        }

        public static void addEdge(int f, int t, long ca, long co)
        {
            edges[f].add(new Edge(t, ca, co, edges[t].size()));
            edges[t].add(new Edge(f, 0, -co, edges[f].size() - 1));
        }

        static class Dist implements Comparable<Dist>
        {
            int v;
            long dist;

            Dist(long a, int b)
            {
                dist = a;
                v = b;
            }

            @Override
            public boolean equals(Object o)
            {
                if (this == o) return true;
                if (!(o instanceof Dist)) return false;
                Dist d = (Dist) o;
                return dist == d.dist && v == d.v;
            }

            @Override
            public int hashCode()
            {
                return Objects.hash(dist, v);
            }

            @Override
            public int compareTo(Dist d)
            {
                return dist > d.dist ? 1 : -1; //x???????
                //return (dist == d.dist ? v - d.v : dist - d.dist) * -1; //x???????
                //return v == d.v ? dist - d.dist : v - d.v;//y???????
                //return (v == d.v ? dist - d.dist : v - d.v)*-1;//y???????
            }
        }

        //??????
        static long solve(int s, int t, long f)
        {
            int V = edges.length;
            int[] prevv = new int[V];
            int[] preve = new int[V];
            long[] dist = new long[V];
            long[] h = new long[V];
            long res = 0;
            while (f > 0)
            {
                Arrays.fill(dist, LINF);
                dist[s] = 0;
                PriorityQueue<Dist> que = new PriorityQueue<>();
                que.add(new Dist(0, s));
                while (!que.isEmpty())
                {
                    Dist d = que.poll();
                    int v = d.v;
                    if (dist[v] < d.dist) continue;
                    for (int i = 0; i < edges[v].size(); i++)
                    {
                        Edge e = edges[v].get(i);
                        if (e.cap > 0 && dist[e.to] > d.dist + e.cost + h[v] - h[e.to])
                        {
                            dist[e.to] = d.dist + e.cost + h[v] - h[e.to];
                            prevv[e.to] = v;
                            preve[e.to] = i;
                            que.add(new Dist(dist[e.to], e.to));
                        }
                    }
                }
                if (dist[t] == INF) return -1;
                for (int i = 0; i < V; i++) h[i] += dist[i];
                long d = f;
                for (int v = t; v != s; v = prevv[v])
                {
                    d = Math.min(d, edges[prevv[v]].get(preve[v]).cap);
                }
                f -= d;
                res += d * h[t];
                for (int v = t; v != s; v = prevv[v])
                {
                    Edge e = edges[prevv[v]].get(preve[v]);
                    e.cap -= d;
                    edges[v].get(e.rev).cap += d;
                }
            }
            return res;
        }

        static class Edge
        {
            int to, rev;
            long cap, cost;

            Edge(int t, long ca, long co, int r)
            {
                to = t;
                cap = ca;
                cost = co;
                rev = r;
            }
        }
    }

    public static void chMax(long v)
    {
        maxRes = Math.max(maxRes, v);
    }

    public static void chMin(long v)
    {
        minRes = Math.min(minRes, v);
    }

    public static boolean solve(long v)
    {
        return true;
    }

    //?????????????????????
    static long binarysearch(long ok, long ng)
    {
        //int ok = 0; //??????
        //int ng = N; //???????
        while (Math.abs(ok - ng) > 1)
        {
            long mid;
            if (ok < 0 && ng > 0 || ok > 0 && ng < 0) mid = (ok + ng) / 2;
            else mid = ok + (ng - ok) / 2;

            if (solve(mid))
            {
                ok = mid;
            }
            else
            {
                ng = mid;
            }
        }
        return ok;
    }

    public static boolean bitGet(BitSet bit, int keta)
    {
        return bit.nextSetBit(keta) == keta;
    }

    public static boolean bitGet(long bit, int keta)
    {
        return ((bit >> keta) & 1) == 1;
    }

    public static int restoreHashA(long key)
    {
        return (int) (key >> 32);
    }

    public static int restoreHashB(long key)
    {
        return (int) (key & -1);
    }

    //?????
    public static long getHashKey(int a, int b)
    {
        return (long) a << 32 | b;
    }

    public static long sqrt(long v)
    {
        long res = (long) Math.sqrt(v);
        while (res * res > v) res--;
        return res;
    }

    public static int u0(int a)
    {
        if (a < 0) return 0;
        return a;
    }

    public static long u0(long a)
    {
        if (a < 0) return 0;
        return a;
    }

    public static Integer[] toIntegerArray(int[] ar)
    {
        Integer[] res = new Integer[ar.length];
        for (int i = 0; i < ar.length; i++)
        {
            res[i] = ar[i];
        }
        return res;
    }

    //k???????????????? ????????? 110110 -> 111001
    public static int nextCombSizeK(int comb, int k)
    {
        int x = comb & -comb; //????1
        int y = comb + x; //??????1????????
        return ((comb & ~y) / x >> 1) | y;
    }

    public static int keta(long num)
    {
        int res = 0;
        while (num > 0)
        {
            num /= 10;
            res++;
        }
        return res;
    }


    public static boolean isOutofIndex(int x, int y)
    {
        if (x < 0 || y < 0) return true;
        if (map[0].length <= x || map.length <= y) return true;
        return false;
    }

    public static void setPrimes()
    {
        int n = 100001;
        isPrime = new boolean[n];
        List<Integer> prs = new ArrayList<>();
        Arrays.fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i * i <= n; i++)
        {
            if (!isPrime[i]) continue;
            prs.add(i);
            for (int j = i * 2; j < n; j += i)
            {
                isPrime[j] = false;
            }
        }
        primes = new int[prs.size()];
        for (int i = 0; i < prs.size(); i++)
            primes[i] = prs.get(i);
    }

    public static void revSort(int[] a)
    {
        Arrays.sort(a);
        reverse(a);
    }

    public static void revSort(long[] a)
    {
        Arrays.sort(a);
        reverse(a);
    }

    public static int[][] copy(int[][] ar)
    {
        int[][] nr = new int[ar.length][ar[0].length];
        for (int i = 0; i < ar.length; i++)
            for (int j = 0; j < ar[0].length; j++)
                nr[i][j] = ar[i][j];
        return nr;
    }

    /**
     * <h1>???????????????????</h1>
     * <p>????????????????</p>
     *
     * @return<b>int</b> ? ???????????????????
     * ?????????????????????
     */
    public static int lowerBound(final int[] arr, final int value)
    {
        int low = 0;
        int high = arr.length;
        int mid;

        while (low < high)
        {
            mid = ((high - low) >>> 1) + low;    //(low + high) / 2 (?????????)
            if (arr[mid] < value)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }
        return low;
    }

    /**
     * <h1>?????????????????????</h1>
     * <p>????????????????</p>
     *
     * @return<b>int</b> ? ????????????????????
     * ?????????????????????
     */
    public static int upperBound(final int[] arr, final int value)
    {
        int low = 0;
        int high = arr.length;
        int mid;
        while (low < high)
        {
            mid = ((high - low) >>> 1) + low;    //(low + high) / 2 (?????????)
            if (arr[mid] <= value)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }
        return low;
    }

    /**
     * <h1>???????????????????</h1>
     * <p>????????????????</p>
     *
     * @return<b>int</b> ? ???????????????????
     * ????????????????????
     */
    public static long lowerBound(final long[] arr, final long value)
    {
        int low = 0;
        int high = arr.length;
        int mid;
        while (low < high)
        {
            mid = ((high - low) >>> 1) + low;    //(low + high) / 2 (?????????)
            if (arr[mid] < value)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }
        return low;
    }

    /**
     * <h1>?????????????????????</h1>
     * <p>????????????????</p>
     *
     * @return<b>int</b> ? ????????????????????
     * ????????????????????
     */
    public static long upperBound(final long[] arr, final long value)
    {
        int low = 0;
        int high = arr.length;
        int mid;
        while (low < high)
        {
            mid = ((high - low) >>> 1) + low;    //(low + high) / 2 (?????????)
            if (arr[mid] <= value)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }
        return low;
    }

    //????????????????false???
    public static boolean nextPermutation(int A[])
    {
        int len = A.length;
        int pos = len - 2;
        for (; pos >= 0; pos--)
        {
            if (A[pos] < A[pos + 1]) break;
        }
        if (pos == -1) return false;

        //pos??????????????
        int ok = pos + 1;
        int ng = len;
        while (Math.abs(ng - ok) > 1)
        {
            int mid = (ok + ng) / 2;
            if (A[mid] > A[pos]) ok = mid;
            else ng = mid;

        }

        swap(A, pos, ok);
        reverse(A, pos + 1, len - 1);


        return true;
    }

    //????????????????false???
    public static boolean prevPermutation(int A[])
    {
        int len = A.length;
        int pos = len - 2;
        for (; pos >= 0; pos--)
        {
            if (A[pos] > A[pos + 1]) break;
        }
        if (pos == -1) return false;

        //pos??????????????
        int ok = pos + 1;
        int ng = len;
        while (Math.abs(ng - ok) > 1)
        {
            int mid = (ok + ng) / 2;
            if (A[mid] < A[pos]) ok = mid;
            else ng = mid;

        }

        swap(A, pos, ok);
        reverse(A, pos + 1, len - 1);


        return true;
    }

    //?nCr?mod???????????***factorial(N)????????***
    static long ncr(int n, int r)
    {
        if (n < r) return 0;
        else if (r == 0) return 1;

        factorial(n);
        return Fa[n] / (Fa[n - r] * Fa[r]);
    }

    static long ncr2(int a, int b)
    {
        if (b == 0) return 1;
        else if (a < b) return 0;
        long res = 1;
        for (int i = 0; i < b; i++)
        {
            res *= a - i;
            res /= i + 1;
        }
        return res;
    }

    static long ncrdp(int n, int r)
    {
        if (n < r) return 0;
        long[][] dp = new long[n + 1][r + 1];
        for (int ni = 0; ni < n + 1; ni++)
        {
            dp[ni][0] = dp[ni][ni] = 1;
            for (int ri = 1; ri < ni; ri++)
            {
                dp[ni][ri] = dp[ni - 1][ri - 1] + dp[ni - 1][ri];
            }
        }
        return dp[n][r];
    }

    static long modNcr(int n, int r)
    {
        if (n < r) return 0;
        long result = Fa[n];
        result = result * modInv(Fa[n - r]) % MOD;
        result = result * modInv(Fa[r]) % MOD;
        return result;
    }

    public static long modSum(long... lar)
    {
        long res = 0;
        for (long l : lar)
            res = (res + l % MOD) % MOD;
        if (res < 0) res += MOD;
        res %= MOD;
        return res;
    }

    public static long modDiff(long a, long b)
    {
        long res = a % MOD - b % MOD;
        if (res < 0) res += MOD;
        res %= MOD;
        return res;
    }

    public static long modMul(long... lar)
    {
        long res = 1;
        for (long l : lar)
            res = (res * l % MOD) % MOD;
        if (res < 0) res += MOD;
        res %= MOD;
        return res;
    }

    public static long modDiv(long a, long b)
    {
        long x = a % MOD;
        long y = b % MOD;
        long res = (x * modInv(y)) % MOD;
        return res;
    }

    static long modInv(long n)
    {
        return modPow(n, MOD - 2);
    }

    static void factorial(int n)
    {
        Fa = new long[n + 1];
        Fa[0] = Fa[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            Fa[i] = (Fa[i - 1] * i) % MOD;
        }

    }

    static long modPow(long x, long n)
    {
        long res = 1L;
        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                res = res * x % MOD;
            }
            x = x * x % MOD;
            n >>= 1;
        }
        return res;
    }

    //?nCr?mod?????????

    static int gcd(int n, int r)
    {
        return r == 0 ? n : gcd(r, n % r);
    }

    static long gcd(long n, long r)
    {
        return r == 0 ? n : gcd(r, n % r);
    }

    static <T> void swap(T[] x, int i, int j)
    {
        T t = x[i];
        x[i] = x[j];
        x[j] = t;
    }

    static void swap(int[] x, int i, int j)
    {
        int t = x[i];
        x[i] = x[j];
        x[j] = t;
    }

    public static void reverse(int[] x)
    {
        int l = 0;
        int r = x.length - 1;
        while (l < r)
        {
            int temp = x[l];
            x[l] = x[r];
            x[r] = temp;
            l++;
            r--;
        }
    }

    public static void reverse(long[] x)
    {
        int l = 0;
        int r = x.length - 1;
        while (l < r)
        {
            long temp = x[l];
            x[l] = x[r];
            x[r] = temp;
            l++;
            r--;
        }
    }

    public static void reverse(char[] x)
    {
        int l = 0;
        int r = x.length - 1;
        while (l < r)
        {
            char temp = x[l];
            x[l] = x[r];
            x[r] = temp;
            l++;
            r--;
        }
    }

    public static void reverse(int[] x, int s, int e)
    {
        int l = s;
        int r = e;
        while (l < r)
        {
            int temp = x[l];
            x[l] = x[r];
            x[r] = temp;
            l++;
            r--;
        }
    }

    static int length(int a)
    {
        int cou = 0;
        while (a != 0)
        {
            a /= 10;
            cou++;
        }
        return cou;
    }

    static int length(long a)
    {
        int cou = 0;
        while (a != 0)
        {
            a /= 10;
            cou++;
        }
        return cou;
    }

    static int cou(boolean[] a)
    {
        int res = 0;
        for (boolean b : a)
        {
            if (b) res++;
        }
        return res;
    }

    static int cou(String s, char c)
    {
        int res = 0;
        for (char ci : s.toCharArray())
        {
            if (ci == c) res++;
        }
        return res;
    }

    static int countC2(char[][] a, char c)
    {
        int co = 0;
        for (int i = 0; i < a.length; i++)
            for (int j = 0; j < a[0].length; j++)
                if (a[i][j] == c) co++;
        return co;
    }

    static int countI(int[] a, int key)
    {
        int co = 0;
        for (int i = 0; i < a.length; i++)
            if (a[i] == key) co++;
        return co;
    }

    static int countI(int[][] a, int key)
    {
        int co = 0;
        for (int i = 0; i < a.length; i++)
            for (int j = 0; j < a[0].length; j++)
                if (a[i][j] == key) co++;
        return co;
    }

    static void fill(int[][] a, int v)
    {
        for (int i = 0; i < a.length; i++)
            for (int j = 0; j < a[0].length; j++)
                a[i][j] = v;
    }

    static void fill(char[][] a, char c)
    {
        for (int i = 0; i < a.length; i++)
            for (int j = 0; j < a[0].length; j++)
                a[i][j] = c;
    }

    static void fill(long[][] a, long v)
    {
        for (int i = 0; i < a.length; i++)
            for (int j = 0; j < a[0].length; j++)
                a[i][j] = v;
    }

    static void fill(int[][][] a, int v)
    {
        for (int i = 0; i < a.length; i++)
            for (int j = 0; j < a[0].length; j++)
                for (int k = 0; k < a[0][0].length; k++)
                    a[i][j][k] = v;
    }

    static int max(int... a)
    {
        int res = Integer.MIN_VALUE;
        for (int i : a)
        {
            res = Math.max(res, i);
        }
        return res;
    }

    static long min(long... a)
    {
        long res = Long.MAX_VALUE;
        for (long i : a)
        {
            res = Math.min(res, i);
        }
        return res;
    }

    static int max(int[][] ar)
    {
        int res = Integer.MIN_VALUE;
        for (int i[] : ar)
            res = Math.max(res, max(i));
        return res;
    }

    static int min(int... a)
    {
        int res = Integer.MAX_VALUE;
        for (int i : a)
        {
            res = Math.min(res, i);
        }
        return res;
    }


    static int min(int[][] ar)
    {
        int res = Integer.MAX_VALUE;
        for (int i[] : ar)
            res = Math.min(res, min(i));
        return res;
    }

    static int sum(int[] a)
    {
        int cou = 0;
        for (int i : a)
            cou += i;
        return cou;
    }

    static int abs(int a)
    {
        return Math.abs(a);
    }

    //FastScanner

    static BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
    static StringTokenizer tokenizer = null;

    public static String next()
    {
        if (tokenizer == null || !tokenizer.hasMoreTokens())
        {
            try
            {
                tokenizer = new StringTokenizer(reader.readLine());
            } catch (IOException e)
            {
                throw new RuntimeException(e);
            }
        }
        return tokenizer.nextToken();
    }

    /*public String nextChar(){
        return (char)next()[0];
    }*/
    public static String nextLine()
    {
        if (tokenizer == null || !tokenizer.hasMoreTokens())
        {
            try
            {
                return reader.readLine();
            } catch (IOException e)
            {
                throw new RuntimeException(e);
            }
        }

        return tokenizer.nextToken("\n");
    }

    public static long nl()
    {
        return Long.parseLong(next());
    }

    public static int ni()
    {
        return Integer.parseInt(next());
    }

    public static double nd()
    {
        return Double.parseDouble(next());
    }

    public static int[] nia(int n)
    {
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = ni();
        }
        return a;
    }

    //1-index
    public static int[] niao(int n)
    {
        int[] a = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
        {
            a[i] = ni();
        }
        return a;
    }

    public static int[] niad(int n)
    {
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = ni() - 1;
        }
        return a;
    }

    public static int[][] nit(int h, int w)
    {
        int[][] a = new int[h][w];
        for (int hi = 0; hi < h; hi++)
        {
            for (int wi = 0; wi < w; wi++)
            {
                a[hi][wi] = ni();
            }
        }
        return a;
    }

    public static int[][] nitd(int h, int w)
    {
        int[][] a = new int[h][w];
        for (int hi = 0; hi < h; hi++)
        {
            for (int wi = 0; wi < w; wi++)
            {
                a[hi][wi] = ni() - 1;
            }
        }
        return a;
    }

    //??????????
    public static void nia2(int[] a, int[] b, int[] c)
    {
        for (int i = 0; i < a.length; i++)
        {
            a[i] = ni();
            b[i] = ni();
            c[i] = ni();
        }
    }

    //??????????
    public static void nia3(int[] a, int[] b, int[] c)
    {
        for (int i = 0; i < a.length; i++)
        {
            a[i] = ni();
            b[i] = ni();
            c[i] = ni();
        }
    }

    public static char[] nca(int n)
    {
        char[] a = next().toCharArray();

        return a;
    }

    public static char[][] nct(int h, int w)
    {
        char[][] a = new char[h][w];
        for (int i = 0; i < h; i++)
        {
            a[i] = next().toCharArray();
        }
        return a;
    }

    //????????????
    public static char[][] ncts(int h, int w)
    {
        char[][] a = new char[h][w];
        for (int i = 0; i < h; i++)
        {
            a[i] = nextLine().replace(" ", "").toCharArray();
        }
        return a;
    }

    public static char[][] nctp(int h, int w, char c)
    {
        char[][] a = new char[h + 2][w + 2];
        //char c = '*';
        int i;
        for (i = 0; i < w + 2; i++)
            a[0][i] = c;
        for (i = 1; i < h + 1; i++)
        {
            a[i] = (c + next() + c).toCharArray();
        }
        for (i = 0; i < w + 2; i++)
            a[h + 1][i] = c;
        return a;
    }

    //???????????
    public static char[][] nctsp(int h, int w, char c)
    {
        char[][] a = new char[h + 2][w + 2];
        //char c = '*';
        int i;
        for (i = 0; i < w + 2; i++)
            a[0][i] = c;
        for (i = 1; i < h + 1; i++)
        {
            a[i] = (c + nextLine().replace(" ", "") + c).toCharArray();
        }
        for (i = 0; i < w + 2; i++)
            a[h + 1][i] = c;
        return a;
    }

    public static long[] nla(int n)
    {
        long[] a = new long[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = nl();
        }
        return a;
    }

    public static long[][] nlt(int h, int w)
    {
        long[][] a = new long[h][w];
        for (int hi = 0; hi < h; hi++)
        {
            for (int wi = 0; wi < w; wi++)
            {
                a[hi][wi] = nl();
            }
        }
        return a;
    }
}