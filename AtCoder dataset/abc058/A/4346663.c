#include <stdio.h>

int main(void)
{
	int a,b,c;
	
	scanf("%d %d %d",&a,&b,&c);
	
	if((b-a)==(c-b)){
		printf("YES\n");
	}else{
		printf("NO\n");
	}
	
	return 0;
} ./Main.c: In function �main�:
./Main.c:7:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d %d %d",&a,&b,&c);
  ^