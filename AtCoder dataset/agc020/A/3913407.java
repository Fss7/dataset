import java.util.*;

public class Main {
  public static void main(String[] args) {
    Scanner sc = new Scanner(System.in);
    int N = sc.nextInt();
    int A = sc.nextInt();
    int B = sc.nextInt();
    int sub = Math.abs(A - B);
    if (sub % 2 == 0) {
      System.out.println("Alice");
    } else {
      System.out.println("Borys");
    }
  }
}