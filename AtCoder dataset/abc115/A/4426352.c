#include <stdio.h>
int main(void){
	int d;
	scanf("%d",&d);
	printf("Christmas");
	while(d!=25){
		printf(" Eve");
		d++;
	}
	printf("\n");
	return 0;
} ./Main.c: In function �main�:
./Main.c:4:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d",&d);
  ^