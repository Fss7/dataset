#include<stdio.h>

int main(void){
  int n;
  scanf("%d",&n);
  
  if((n%2)==0){
    printf("%d\n",(n/2)*(n/2));
  }else{
    printf("%d\n",(n/2)*(n/2+1));
  }
  
  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d",&n);
   ^