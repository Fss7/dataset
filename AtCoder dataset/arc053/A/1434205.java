import java.util.*;

public class Main {        
    
  public static void main(String[] args) {              
     
      Scanner sc = new Scanner(System.in);                                    
     
      int H = sc.nextInt();
      int W = sc.nextInt();
      
      System.out.println((W-1)*H + (H-1)*W);            
      
  }     
}