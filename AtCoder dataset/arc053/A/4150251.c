#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <stdbool.h>
#include <math.h>
 
int main(void){

  int H, W;

  scanf("%d%d", &H, &W);

  printf("%d\n", (H - 1) * W + H * (W - 1));
  
  return 0;
} ./Main.c: In function �main�:
./Main.c:11:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d%d", &H, &W);
   ^