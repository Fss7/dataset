#include<stdio.h>

int main(void)
{
    int r;
    scanf("%d",&r);
    if (r<1200){
        printf("ABC");
    } else if (r<2800)
    {
        printf("ARC");
    }
    else
    {
        printf("AGC");
    }
    
} ./Main.c: In function �main�:
./Main.c:6:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d",&r);
     ^