#include <stdio.h>

int main(void)
{
	int x,a,b;
	
	scanf("%d %d %d",&x,&a,&b);
	
	if(a>=b){
		printf("delicious\n");
	}else if(b-a<=x){
		printf("safe\n");
	}else{
		printf("dangerous\n");
	}
	
	return 0;
} ./Main.c: In function �main�:
./Main.c:7:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d %d %d",&x,&a,&b);
  ^