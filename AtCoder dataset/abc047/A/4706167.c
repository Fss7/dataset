#include <stdio.h>
int main(){
    int a,b,c;
    scanf("%d%d%d",&a,&b,&c);
    if(a-(b+c)==0 || b-(a+c)==0 || c-(a+b)==0)printf("Yes\n");
    else printf("No\n");
} ./Main.c: In function �main�:
./Main.c:4:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d%d%d",&a,&b,&c);
     ^