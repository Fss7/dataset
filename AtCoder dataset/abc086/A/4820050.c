#include<stdio.h>
int main(void){
	int a,b,c;
	scanf("%d %d",&a,&b);
	c=a*b;
	if(c%2==0){
		printf("Even\n");
	}else{
		printf("Odd\n");
	}
	return 0;
} ./Main.c: In function �main�:
./Main.c:4:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d %d",&a,&b);
  ^