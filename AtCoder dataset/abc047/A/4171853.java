import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		try {
			int a = sc.nextInt();
			int b = sc.nextInt();
			int c = sc.nextInt();

			int max = a >= b ? (a >= c ? a : c) : (b >= c ? b : c);

			if ((a + b + c) == max * 2) {
				System.out.println("Yes");
			} else {
				System.out.println("No");
			}

		} finally {
			sc.close();
		}
	}
}