#include <stdio.h>

int main(void){
  int h1,w1,h2,w2;
  scanf("%d%d%d%d",&h1,&w1,&h2,&w2);
  if(h1==h2||h1==w2||w1==h2||w1==w2) puts("YES");
  else puts("NO");
  return 0;  
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d%d%d%d",&h1,&w1,&h2,&w2);
   ^