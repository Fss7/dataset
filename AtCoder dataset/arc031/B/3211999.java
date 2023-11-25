import java.util.*;
import java.awt.*;
import static java.lang.System.*;
import static java.lang.Math.*;
public class Main {
    public static void main(String[] args){
        Scanner sc = new Scanner(in);
        //??a[x???][y???]
        char[][] a=new char[10][10];
        //??
        int[] dx={-1,0,1,0};
        int[] dy={0,-1,0,1};
        //????(sx,sy)???
        int sx=0,sy=0;
        //???
        int c=0;
        //????(1)?(0)?????(-1) ???100????????????
        int[][][] map=new int[100][10][10];
        //a??????map[0][][]?????
        for (int i = 0; i < 10; i++) {
            String s=sc.next();
            for (int j = 0; j < 10; j++) {
                a[j][i]=s.charAt(j);
                if(a[j][i]=='o'){
                    c++;
                    map[0][j][i]=1;
                }else{
                    map[0][j][i]=0;
                }
            }
        }
        //map?[0]?[1]?[99]??????
        for (int i = 1; i < 100; i++) {
            for (int j = 0; j < 10; j++) {
                for (int k = 0; k < 10; k++) {
                    map[i][k][j]=map[0][k][j];
                }
            }
        }
        //count?0?99 (?????????map????????????)
        int count=0;
        //'o'????????
        Queue<Point> q=new ArrayDeque<>();
        //??????????????a[j][i]??????'o'????????
        //????a????????????????????map??????(?????100?????)        
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                //map[count][j][i]?1(????)??????
                map[count][j][i]=1;
                //????????????????????????????????????
                //???????????????????????
                int island=0;
                //???????????(a[sx][sy]??????????)
                sx=j;
                sy=i;
                //????????????????-1??? island???????????????
                map[count][sx][sy]=-1;
                //???????
                q.add(new Point(sx,sy));
                while(q.size()>0){
                    Point p=q.poll();
                    for (int k = 0; k < 4; k++) {
                        int x=p.x+dx[k];
                        int y=p.y+dy[k];
                        if(0<=x&&x<10&&0<=y&&y<10&&map[count][x][y]==1){
                            map[count][x][y]=-1;
                            island++;
                            q.add(new Point(x,y));
                        }
                    }
                }
                //???????????????????????
                //island??????
                //???????????????????????????????????-1
                if(a[sx][sy]=='o'){
                    if(island==c-1){
                        out.println("YES");
                        //???????
                        exit(0);
                    }
                //?????????????????????????????????????????
                }else{
                    if(island==c){
                        out.println("YES");
                        //???????
                        exit(0);
                    }
                }
                //map????????
                count++;
                //q?????
                q.clear();
            }
        }
        //???????????????????????????????????????????YES????????????
        out.println("NO");
    }
}