#include <stdio.h>
int main(void){
    int n,k;
    scanf("%d %d",&n,&k);
    if(k*2<=n)printf("YES\n");
    else printf("NO\n");
    return 0;
} ./Main.c: In function �main�:
./Main.c:5:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d %d",&n,&k);
     ^