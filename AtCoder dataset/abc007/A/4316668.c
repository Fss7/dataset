#include <stdio.h>
int main(void){
int a;
  scanf("%d",&a);
  printf("%d\n",a-1);
  
return 0;
} ./Main.c: In function �main�:
./Main.c:4:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d",&a);
   ^