#include <stdio.h>

int main(void){
  int N;
  scanf("%d",&N);

  printf("%d\n",N);
  for(int i = 0;i < N;i++) printf("1\n");

  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d",&N);
   ^