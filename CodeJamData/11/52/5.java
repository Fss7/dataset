import java.util.ArrayList;
import java.util.InputMismatchException;
import java.math.BigInteger;
import java.io.*;
import java.util.List;

/**
 * Generated by Contest helper plug-in
 * Actual solution is at the bottom
 */
public class Main {
	public static void main(String[] args) {
		try {
			System.setIn(new FileInputStream("b.in"));
			System.setOut(new PrintStream(new FileOutputStream("b.out")));
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
		InputReader in = new StreamInputReader(System.in);
		PrintWriter out = new PrintWriter(System.out);
		run(in, out);
	}

	public static void run(InputReader in, PrintWriter out) {
		Solver solver = new TaskB();
		int testCount = in.readInt();
		for (int i = 1; i <= testCount; i++)
			solver.solve(i, in, out);
		Exit.exit(in, out);
	}
}

abstract class InputReader {
	private boolean finished = false;

	public abstract int read();

	public int readInt() {
		int c = read();
		while (isSpaceChar(c))
			c = read();
		int sgn = 1;
		if (c == '-') {
			sgn = -1;
			c = read();
		}
		int res = 0;
		do {
			if (c < '0' || c > '9')
				throw new InputMismatchException();
			res *= 10;
			res += c - '0';
			c = read();
		} while (!isSpaceChar(c));
		return res * sgn;
	}

	public String readString() {
		int c = read();
		while (isSpaceChar(c))
			c = read();
		StringBuffer res = new StringBuffer();
		do {
			res.appendCodePoint(c);
			c = read();
		} while (!isSpaceChar(c));
		return res.toString();
	}

	private boolean isSpaceChar(int c) {
		return c == ' ' || c == '\n' || c == '\r' || c == '\t' || c == -1;
	}

	public void setFinished(boolean finished) {
		this.finished = finished;
	}

	public abstract void close();
}

class StreamInputReader extends InputReader {
	private InputStream stream;
	private byte[] buf = new byte[1024];
	private int curChar, numChars;

	public StreamInputReader(InputStream stream) {
		this.stream = stream;
	}

	public int read() {
		if (numChars == -1)
			throw new InputMismatchException();
		if (curChar >= numChars) {
			curChar = 0;
			try {
				numChars = stream.read(buf);
			} catch (IOException e) {
				throw new InputMismatchException();
			}
			if (numChars <= 0)
				return -1;
		}
		return buf[curChar++];
	}

	public void close() {
		try {
			stream.close();
		} catch (IOException ignored) {
		}
	}
}

class Exit {
	private Exit() {
	}

	public static void exit(InputReader in, PrintWriter out) {
		in.setFinished(true);
		in.close();
		out.close();
	}
}

interface Solver {
	public void solve(int testNumber, InputReader in, PrintWriter out);
}

class TaskB implements Solver {
	public void solve(int testNumber, InputReader in, PrintWriter out) {
		int cardCount = in.readInt();
		int[] count = new int[10002];
		for (int i = 0; i < cardCount; i++)
			count[in.readInt()]++;
		List<Integer> starts = new ArrayList<Integer>();
		List<Integer> ends = new ArrayList<Integer>();
		for (int i = 0; i <= 10000; i++) {
			if (count[i] < count[i + 1]) {
				for (int j = 0; j < count[i + 1] - count[i]; j++)
					starts.add(i);
			}
			if (count[i] > count[i + 1]) {
				for (int j = 0; j < count[i] - count[i + 1]; j++)
					ends.add(i);
			}
		}
		int answer = Integer.MAX_VALUE;
		for (int i = 0; i < ends.size(); i++)
			answer = Math.min(answer, ends.get(i) - starts.get(i));
		if (answer == Integer.MAX_VALUE)
			answer = 0;
		out.println("Case #" + testNumber + ": " + answer);
	}
}

