#include <stdio.h>

int main(void){
  int N,A;
  scanf("%d%d",&N,&A);

  printf("%d\n",N*N-A);

  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d%d",&N,&A);
   ^