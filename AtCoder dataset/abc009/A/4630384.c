#include <stdio.h>
int main(){
int a;
scanf("%d",&a);
if(a%2==0){printf("%d\n",a/2);}
else{printf("%d\n",a/2+1);}


return 0;
} ./Main.c: In function �main�:
./Main.c:4:1: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
 scanf("%d",&a);
 ^