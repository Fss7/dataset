import java.util.Scanner;

public class Main {
	
	public static void main(String[] args) {
		new Main().solve();
	}
	
	void solve(){
		Scanner sc=new Scanner(System.in);
		
		int N=sc.nextInt();
		int M=sc.nextInt();
		boolean[][] path=new boolean[N][N];
		
		for(int i=0;i<M;i++){
			int x=sc.nextInt()-1;
			int y=sc.nextInt()-1;
			path[x][y]=true;
		}
		
		int BIT_SIZE=1<<N; //?????????
		long[] dp=new long[BIT_SIZE];
		dp[0]=1;
		
		for(int i=0;i<BIT_SIZE;i++){ //????i????
			if(dp[i]==0)continue; //i????????????
			
			for(int j=0;j<N;j++){
				if((i>>j&1) == 0){ // ????i?j???0??(????i?j??????)
					boolean flag=true;
					
					for(int k=0;k<N;k++){ 
						if((i>>k & 1)==1 && path[j][k]==true){ 
							//????i?k???1(????i?j?????k) ?? 
							//j??k???????
							flag=false;
							break;
						}
					}
					//??j???????????????
					if(flag){
						//????i?j????????i???
						dp[i|1<<j]+=dp[i];
					}
				}
			}
		}
		System.out.println(dp[(1<<N)-1]);
		
	}
}