#include <stdio.h>

int main(void){
  int N,i;
  scanf("%d",&N);
  for(i=N;i<1000;i++){
    if(i%111==0) break;
  }
  printf("%d\n",i);
  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d",&N);
   ^