#include<stdio.h>

int main(){
	int n;
	scanf("%d",&n);
	printf("%d\n",n*(n+1)/2);
	return 0;
} ./Main.c: In function �main�:
./Main.c:5:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d",&n);
  ^