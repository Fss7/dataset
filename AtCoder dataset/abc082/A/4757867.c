#include <stdio.h>
#include <string.h>
int main(){
  int a,b;
  scanf("%d %d",&a,&b);
  
  if(a == b) printf("%d\n",a);
  else if((a+b)%2 == 0) printf("%d\n",(a+b)/2);
  else printf("%d\n",(a+b)/2+1);
  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d %d",&a,&b);
   ^