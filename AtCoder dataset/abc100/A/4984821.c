#include <stdio.h>

int main(){
	int A, B;
	scanf("%d%d", &A, &B);
	
	if(A<=8 && B<=8)
		printf("Yay!");
	else
		printf(":(");
	return 0;
} ./Main.c: In function �main�:
./Main.c:5:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d%d", &A, &B);
  ^