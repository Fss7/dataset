#include <stdio.h>
int main(void){
    int n;
    scanf("%d",&n);
    if (n%10>=7){
        n+=10-n%10;
    }
    printf("%d\n",n/10*100+n%10*15);
    return 0;
} ./Main.c: In function �main�:
./Main.c:4:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d",&n);
     ^