#include<stdio.h>

int main(void) {
	int a,b;
	scanf("%d %d",&a,&b);
	printf("%s",(a*b)%2 ? "Odd":"Even");
} ./Main.c: In function �main�:
./Main.c:5:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d %d",&a,&b);
  ^