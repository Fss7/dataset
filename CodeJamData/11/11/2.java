import java.util.InputMismatchException;
import java.math.BigInteger;
import java.io.*;

/**
 * Generated by Contest helper plug-in
 * Actual solution is at the bottom
 */
public class Main {
	public static void main(String[] args) {
		try {
			System.setIn(new FileInputStream("a.in"));
			System.setOut(new PrintStream(new FileOutputStream("a.out")));
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
		InputReader in = new StreamInputReader(System.in);
		PrintWriter out = new PrintWriter(System.out);
		run(in, out);
	}

	public static void run(InputReader in, PrintWriter out) {
		Solver solver = new TaskA();
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

interface Solver {
	public void solve(int testNumber, InputReader in, PrintWriter out);
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

class TaskA implements Solver {
	public void solve(int testNumber, InputReader in, PrintWriter out) {
		long maxGamesToday = in.readInt();
		int percentToday = in.readInt();
		int percentTotal = in.readInt();
		out.print("Case #" + testNumber + ": ");
		if (percentTotal == 100 || percentTotal == 0) {
			if (percentToday == percentTotal)
				out.println("Possible");
			else
				out.println("Broken");
			return;
		}
		for (int i = 1; i <= 100 && i <= maxGamesToday; i++) {
			if (percentToday * i % 100 == 0) {
				out.println("Possible");
				return;
			}
		}
		out.println("Broken");
	}
}

