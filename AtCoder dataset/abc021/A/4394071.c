#include <stdio.h>
int main(void){
	int n,i;
	scanf("%d",&n);
	printf("%d\n",n);
	for(i=0;i<n;i++){
		printf("%d\n",1);
	}
	return 0;
} ./Main.c: In function �main�:
./Main.c:4:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d",&n);
  ^