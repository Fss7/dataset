#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <stdbool.h>
#include <math.h>
 
int main(void){

  int N, A, B;

  scanf("%d%d%d", &N, &A, &B);

  if(N % (A + B) <= A && N % (A + B) > 0){
    printf("Ant\n");
  }else{
    printf("Bug\n");
  }
  
  return 0;
} ./Main.c: In function �main�:
./Main.c:11:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d%d%d", &N, &A, &B);
   ^