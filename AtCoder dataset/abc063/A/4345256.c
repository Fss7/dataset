#include <stdio.h>

int main(void)
{
	int a,b;
	scanf("%d %d",&a,&b);
	
	if(a+b>=10){
		printf("error\n");
	}else{
		printf("%d\n",a+b);
	}
	
	return 0;
} ./Main.c: In function �main�:
./Main.c:6:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d %d",&a,&b);
  ^