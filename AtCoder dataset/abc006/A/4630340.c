#include <stdio.h>
int main(){
int a;
scanf("%d",&a);
if(a%3==0){printf("YES\n");}
else{printf("NO\n");}


return 0;
} ./Main.c: In function �main�:
./Main.c:4:1: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
 scanf("%d",&a);
 ^