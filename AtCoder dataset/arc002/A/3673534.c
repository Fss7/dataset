#include <stdio.h>

int main()
{
    int y;

    scanf("%d", &y);

    if (y % 100 == 0) {
        if (y % 400 == 0) {
            printf("YES\n");
        } else {
            printf("NO\n");
        }   
    } else if (y % 4 == 0) {
        printf("YES\n");
    } else {
        printf("NO\n");
    }   

    return 0;
} ./Main.c: In function �main�:
./Main.c:7:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d", &y);
     ^