#include <stdio.h>

int main(void)
{
	int n,k;
	scanf("%d %d",&n,&k);
	
	if(n%k!=0){
		printf("1\n");
	}else{
		printf("0\n");
	}
	
	return 0;
} ./Main.c: In function �main�:
./Main.c:6:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d %d",&n,&k);
  ^