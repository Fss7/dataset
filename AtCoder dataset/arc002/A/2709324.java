import java.util.*;
public class Main {
public static void main(String[] args){
Scanner sc = new Scanner(System.in);
int Y=sc.nextInt();

	if((Y % 4 == 0 && Y% 100 != 0) || Y % 400 == 0) {
		System.out.println("YES");
	}else {
		System.out.println("NO");
	}
}
}