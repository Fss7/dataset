#include <stdio.h>

int main(){
	int H, W;
	scanf("%d%d", &H, &W);
	printf("%d\n", H * (W - 1) + (H - 1) * W);
	return 0;
} ./Main.c: In function �main�:
./Main.c:5:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d%d", &H, &W);
  ^