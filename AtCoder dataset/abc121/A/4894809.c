#include<stdio.h>

int main(void)
{
        int a, b, c, d;

        scanf("%d%d%d%d", &a,&b,&c,&d);

        printf("%d", (a*b)-(c*b)-(d*a)+(c*d));
        return 0;

} ./Main.c: In function �main�:
./Main.c:7:9: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
         scanf("%d%d%d%d", &a,&b,&c,&d);
         ^