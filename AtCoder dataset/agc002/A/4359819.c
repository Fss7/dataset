#include<stdio.h>
int main()
{
    int a, b;
    scanf("%d %d", &a, &b);
    if (a<1 && b>-1)
        printf("Zero\n");
    else if (a > 0)
        printf("Positive\n");
    else if ((b - a) % 2 == 0)
        printf("Negative\n");
    else
        printf("Positive\n");
    return 0;
} ./Main.c: In function �main�:
./Main.c:5:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d %d", &a, &b);
     ^