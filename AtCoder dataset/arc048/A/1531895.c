#include <stdio.h>

int main(){
	int A, B;
	scanf("%d%d", &A, &B);
	if(A < 0 && 0 < B){
		printf("%d\n", B - A - 1);
	}
	else{
		printf("%d\n", B - A);
	}
	return 0;
} ./Main.c: In function �main�:
./Main.c:5:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d%d", &A, &B);
  ^