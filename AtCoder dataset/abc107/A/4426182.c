#include <stdio.h>
int main(void){
	int n,i;
	scanf("%d%d",&n,&i);
	printf("%d\n",n-i+1);
	return 0;
} ./Main.c: In function �main�:
./Main.c:4:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d%d",&n,&i);
  ^