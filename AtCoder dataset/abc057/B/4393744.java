import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.util.StringTokenizer;

/**
 * Built using CHelper plug-in Actual solution is at the top
 */

public class Main {
	public static void main(String[] args) {
		InputStream inputStream = System.in;
		OutputStream outputStream = System.out;
		InputReader in = new InputReader(inputStream);
		PrintWriter out = new PrintWriter(outputStream);
		Task solver = new Task();
		solver.solve(1, in, out);
		out.close();
	}

	static class Task {
		public void solve(int testNumber, InputReader in, PrintWriter out) {
			int N = in.nextInt();
			int M = in.nextInt();
			int[] a = new int[N];
			int[] b = new int[N];
			int[] c = new int[M];
			int[] d = new int[M];
			for(int i = 0; i < N; i++) {
				a[i] = in.nextInt();
				b[i] = in.nextInt();
			}
			for(int i = 0; i < M; i++) {
				c[i] = in.nextInt();
				d[i] = in.nextInt();
			}

			for(int i = 0; i < N; i++) {
				long min = Long.MAX_VALUE;
				int  ans = 0;
				for(int j = 0; j < M; j++) {
					long tmp = Math.abs(a[i] - c[j]) + Math.abs(b[i] - d[j]);
					if(tmp < min) {
						min = tmp;
						ans = j + 1;
					}
				}
				out.println(ans);
			}
		}
	}

	static class InputReader {
		public BufferedReader reader;
		public StringTokenizer tokenizer;

		public InputReader(InputStream stream) {
			reader = new BufferedReader(new InputStreamReader(stream), 32768);
			tokenizer = null;
		}

		public String next() {
			while (tokenizer == null || !tokenizer.hasMoreTokens()) {
				try {
					tokenizer = new StringTokenizer(reader.readLine());
				} catch (IOException e) {
					throw new RuntimeException(e);
				}
			}
			return tokenizer.nextToken();
		}

		public char nextChar() {
			return next().charAt(0);
		}

		public int nextInt() {
			return Integer.parseInt(next());
		}

		public long nextLong() {
			return Long.parseLong(next());
		}

		public double nextDouble() {
			return Double.parseDouble(next());
		}

	}
}