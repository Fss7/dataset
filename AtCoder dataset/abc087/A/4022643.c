#include <stdio.h>
int main(void){
    int x,a,b;
    scanf("%d%d%d",&x,&a,&b);
    x-=a;
    int bs=(x/b)*b;
    printf("%d",x-bs);
    return 0;
} ./Main.c: In function �main�:
./Main.c:4:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d%d%d",&x,&a,&b);
     ^