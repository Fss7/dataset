# include <stdio.h>
# include <stdlib.h>

int main(){
  int x,a,b;
  scanf("%d %d %d",&x,&a,&b);
  if(abs(x-a)>abs(x-b)) puts("B");
  else puts("A");

  return 0;
} ./Main.c: In function �main�:
./Main.c:6:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d %d %d",&x,&a,&b);
   ^