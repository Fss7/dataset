#include <stdio.h>

int min(int a,int b){
	if (a>b){
		return b;
	}
	return a;
}

int main(void){
	int D,G,p[11],c[11];
	scanf("%d %d",&D,&G);
	int i;
	for(i=0;i<D;i++){
		scanf("%d %d",&p[i],&c[i]);
	}
	int ans = 1e9;
	for(int mask=0;mask<(1<<D);++mask){	// 1<<D???2^D??????????
		int s=0,num=0,rest_max=1;
		for(i=0;i<D;++i){		//???????????????
			if(mask>>i & 1){	//??????????????????????????????
				s += 100* (i+1) * p[i] + c[i];//s????????
				num += p[i];	//num????????????????????????
			}else{
				rest_max = i;	//i???????????????????
			}
		}
		if(s<G){//????????????????????????
			int s1 = 100*(rest_max + 1);//s1??????????????????????????????(?????????)
			int need = (G-s+s1-1)/s1;//need??????????????????
			if(need >= p[rest_max]){//??????????????
				continue;//??for????????
			}
			num += need;
		}
		ans = min(ans,num);
	}
	printf("%d",ans);
	return 0;
} ./Main.c: In function �main�:
./Main.c:12:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d %d",&D,&G);
  ^
./Main.c:15:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d %d",&p[i],&c[i]);
   ^