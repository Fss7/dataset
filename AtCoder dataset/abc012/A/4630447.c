#include <stdio.h>
int main(){
int a,b;
scanf("%d%d",&a,&b);
printf("%d %d\n",b,a);


return 0;
} ./Main.c: In function �main�:
./Main.c:4:1: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
 scanf("%d%d",&a,&b);
 ^