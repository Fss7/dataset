#include <stdio.h>

int main(void){
  int A,B;
  scanf("%d%d",&A,&B);

  printf("%d\n",(B+A-1)/A);

  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d%d",&A,&B);
   ^