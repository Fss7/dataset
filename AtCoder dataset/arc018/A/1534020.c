#include <stdio.h>

int main(){
	double h, b;
	scanf("%lf%lf", &h, &b);
	printf("%lf\n", b * (h / 100) * (h / 100));
	return 0;
} ./Main.c: In function �main�:
./Main.c:5:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%lf%lf", &h, &b);
  ^