#include <stdio.h>

int main(){
  int a, b;
  scanf("%d %d", &a, &b);
  
  if(b % a == 0){
    printf("%d", a + b);
  }
  else{
    printf("%d", b - a);
  }

  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d %d", &a, &b);
   ^