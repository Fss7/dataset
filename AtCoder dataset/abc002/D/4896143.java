/*
String[]??????????long???????
???split??contains??????"+"??????????????"\\+"???
???????arr1=arr.clone()
HashSet<>[]???????????????
?????????????????????????ex.-1/2=0??????>k??????????????????
???>=k???????????????
toLowerCase()???????????????????????????
ArrayDeque??pop?push?Stack????????
//import static java.lang.System.*; ??????????(??????exit(0)?????)?return;?????
???out.flush()???out.close()??????????
*/
//?????Ctrl+D
import java.util.*;
import java.io.*;
import java.awt.*;
import java.awt.geom.Point2D;
//import static java.lang.System.*;
import static java.lang.Math.*;
public class Main {
    public static void main(String[] $) {
        int n=sc.nextInt(),m=sc.nextInt();
        boolean[][] r=new boolean[n+1][n+1];
        for (int i = 0; i < m; i++) {
            int x=sc.nextInt(),y=sc.nextInt();
            r[x][y]=r[y][x]=true;
        }
        int ans=1;
        for (int i = 0; i < (1 << n); i++) {
            HashSet<Integer> set=new HashSet<>();
            int c=0,d=0;
            for (int j = 0; j < n; j++) {
                if((1&(i>>j))==1){
                    set.add(j+1);
                }
                
                for (Integer k:set){
                    for (Integer l:set){
                        if(k>l){
                            d++;
                            if(r[k][l])c++;
                        }
                    }
                }
                if(c==d)ans=max(ans,set.size());
            }
        }
        out.println(ans);
        out.close();
    }

    static PrintWriter out = new PrintWriter(System.out);

    static class sc {
        static Scanner s = new Scanner(System.in);

        static String next() {
            return s.next();
        }

        static int nextInt() {
            return Integer.parseInt(s.next());
        }

        static long nextLong() {
            return Long.parseLong(s.next());
        }

        static double nextDouble() {
            return Double.parseDouble(s.next());
        }
    }

}