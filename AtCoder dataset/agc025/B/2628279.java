import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.PrintWriter;
import java.util.Arrays;
import java.util.InputMismatchException;


public class Main
{
	InputStream is;
	PrintWriter out;
	String INPUT = "";
	
	void solve()
	{
		int N = ni(), A = ni(), B = ni();
		long K = nl();
		int mod = 998244353;
		long ans = 0;
		int[][] fif = enumFIF(700000,mod);
		for(int i = 0; i <= N; i++) {
			long rem = K - (long)i*A;
			if(rem >=0 && rem % B ==0 && rem/B <= N) {
				long a = i;
				long b = rem/B;
				long ret = C(N,(int)a,mod,fif) * C(N,(int)b,mod,fif) % mod;
				ans+=ret;
			}
		}
		out.println(ans%mod);
	}
	
	
	public static long C(int n, int r, int mod, int[][] fif) {
		if (n < 0 || r < 0 || r > n)
			return 0;
		return (long) fif[0][n] * fif[1][r] % mod * fif[1][n - r] % mod;
	}

	public static int[][] enumFIF(int n, int mod) {
		int[] f = new int[n + 1];
		int[] invf = new int[n + 1];
		f[0] = 1;
		for (int i = 1; i <= n; i++) {
			f[i] = (int) ((long) f[i - 1] * i % mod);
		}
		long a = f[n];
		long b = mod;
		long p = 1, q = 0;
		while (b > 0) {
			long c = a / b;
			long d;
			d = a;
			a = b;
			b = d % b;
			d = p;
			p = q;
			q = d - c * q;
		}
		invf[n] = (int) (p < 0 ? p + mod : p);
		for (int i = n - 1; i >= 0; i--) {
			invf[i] = (int) ((long) invf[i + 1] * (i + 1) % mod);
		}
		return new int[][] { f, invf };
	}
			
	void run() throws Exception
	{
		is = INPUT.isEmpty() ? System.in : new ByteArrayInputStream(INPUT.getBytes());
		out = new PrintWriter(System.out);
		
		long s = System.currentTimeMillis();
		solve();
		out.flush();
		if(!INPUT.isEmpty())tr(System.currentTimeMillis()-s+"ms");
	}
	
	public static void main(String[] args) throws Exception 
	{ new Main().run(); }
	
	private byte[] inbuf = new byte[1024];
	public int lenbuf = 0, ptrbuf = 0;
	
	private int readByte()
	{
		if(lenbuf == -1)throw new InputMismatchException();
		if(ptrbuf >= lenbuf)
		{
			ptrbuf = 0;
			try 
			{ lenbuf = is.read(inbuf); } 
			catch (IOException e) 
			{ throw new InputMismatchException(); }
			if(lenbuf <= 0)return -1;
		}
		return inbuf[ptrbuf++];
	}
	
	private boolean isSpaceChar(int c)
	{ return !(c >= 33 && c <= 126); }
	private int skip() 
	{ int b; while((b = readByte()) != -1 && isSpaceChar(b)); return b; }
	
	private double nd() 
	{ return Double.parseDouble(ns()); }
	private char nc()
	{ return (char)skip(); }
	
	private String ns()
	{
		int b = skip();
		StringBuilder sb = new StringBuilder();
		while(!(isSpaceChar(b)))
		{ // when nextLine, (isSpaceChar(b) && b != ' ')
			sb.appendCodePoint(b);
			b = readByte();
		}
		return sb.toString();
	}
	
	private String nsl()
	{
		int b = skip();
		StringBuilder sb = new StringBuilder();
		while(!(isSpaceChar(b) && b != ' '))
		{ // when nextLine, (isSpaceChar(b) && b != ' ')
			sb.appendCodePoint(b);
			b = readByte();
		}
		return sb.toString();
	}
	
	private char[] ns(int n)
	{
		char[] buf = new char[n];
		int b = skip(), p = 0;
		while(p < n && !(isSpaceChar(b)))
		{
			buf[p++] = (char)b;
			b = readByte();
		}
		return n == p ? buf : Arrays.copyOf(buf, p);
	}
	
	private char[][] nm(int n, int m)
	{
		char[][] map = new char[n][];
		for(int i = 0;i < n;i++)map[i] = ns(m);
		return map;
	}
	
	private int[] na(int n)
	{
		int[] a = new int[n];
		for(int i = 0;i < n;i++)a[i] = ni();
		return a;
	}
	
	private int ni()
	{
		int num = 0, b;
		boolean minus = false;
		while((b = readByte()) != -1 && !((b >= '0' && b <= '9') || b == '-'));
		if(b == '-')
		{
			minus = true;
			b = readByte();
		}
		
		while(true)
		{
			if(b >= '0' && b <= '9')
			{
				num = num * 10 + (b - '0');
			}else
			{
				return minus ? -num : num;
			}
			b = readByte();
		}
	}
	
	private long nl()
	{
		long num = 0;
		int b;
		boolean minus = false;
		while((b = readByte()) != -1 && !((b >= '0' && b <= '9') || b == '-'));
		if(b == '-')
		{
			minus = true;
			b = readByte();
		}
		
		while(true){
			if(b >= '0' && b <= '9')
			{
				num = num * 10 + (b - '0');
			}else
			{
				return minus ? -num : num;
			}
			b = readByte();
		}
	}
	
	private static void tr(Object... o) 
	{ System.out.println(Arrays.deepToString(o)); }
}