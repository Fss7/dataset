#include <stdio.h>

int main(void){
  int N;
  scanf("%d",&N);

  if(N%3 == 0) printf("YES\n");
  else printf("NO\n");

  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d",&N);
   ^