#include <stdio.h>

int main(){
	int n;
	scanf("%d", &n);
	printf("%d\n", n);
	for(int i = 0; i < n; i++)
		printf("1\n");
	return 0;
} ./Main.c: In function �main�:
./Main.c:5:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d", &n);
  ^