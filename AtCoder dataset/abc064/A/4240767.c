#include <stdio.h>

int main(void)
{
	int r,g,b,num;
	scanf("%d%d%d",&r,&g,&b);
	num = 100*r+10*g+b;
	if(num%4 == 0)
		{printf("YES");}
	else
		{printf("NO");}
	return 0;
} ./Main.c: In function �main�:
./Main.c:6:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d%d%d",&r,&g,&b);
  ^