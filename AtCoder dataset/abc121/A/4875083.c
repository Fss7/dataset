#include<stdio.h>

int main(void)
{
	int H, W, h, w;
	scanf("%d%d%d%d", &H, &W, &h, &w);
	printf("%d", (H*W) - (h*W + H * w - h * w));
	return 0;
} ./Main.c: In function �main�:
./Main.c:6:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d%d%d%d", &H, &W, &h, &w);
  ^