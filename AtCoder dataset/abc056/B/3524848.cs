using System.Collections.Generic;
using static System.Console;

class Program {
	static void Main() {
		var W = NextInt();
		var a = NextInt();
		var b = NextInt();

		if (b > a + W) {
			WriteLine(b - a - W);
		} else if (a > b + W) {
			WriteLine(a - b - W);
		} else {
			WriteLine(0);
		}
	}

	static int NextInt() {
		return int.Parse(NextString());
	}

	static string NextString() {
		var result = new List<char>();
		while (true) {
			int next = Read();
			if (next < 0)
				break;
			var nextChar = (char)next;
			if (!char.IsWhiteSpace(nextChar))
				result.Add(nextChar);
			else if (nextChar != '\r')
				break;
		}
		return string.Join("", result);
	}
}