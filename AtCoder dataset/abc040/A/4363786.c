#include <stdio.h>
#include <math.h>
int main(void){
  int x,y;
  scanf("%d %d",&x,&y);
  printf("%d",(int)fmin(x-y,y-1));
  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d %d",&x,&y);
   ^