#include <stdio.h>
int main(){
  int a,b;
  scanf("%d %d",&a,&b);
  if(a<=b){
    printf("%d",a);
  }
  else{
    printf("%d",a-1);
  }
  return 0;
} ./Main.c: In function �main�:
./Main.c:4:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d %d",&a,&b);
   ^