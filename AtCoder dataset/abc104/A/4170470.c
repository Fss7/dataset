#include <stdio.h>

int main(void){
  int R;
  scanf("%d",&R);

  if(R < 1200){
    printf("ABC\n");
  }else if(R < 2800){
    printf("ARC\n");
  }else{
    printf("AGC\n");
  }

  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d",&R);
   ^