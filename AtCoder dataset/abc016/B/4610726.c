#include<stdio.h>

int main(void)
{
  int a,b,c;
  scanf("%d%d%d",&a,&b,&c);

  if(c==a+b&&c!=a-b){
    printf("+\n");
  }else if(c!=a+b&&c==a-b){
    printf("-\n");
  }else if(c==a+b&&c==a-b){
    printf("?\n");
  }else if(c!=a+b&&c!=a-b){
    printf("!\n");
  }

  return 0;
} ./Main.c: In function �main�:
./Main.c:6:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d%d%d",&a,&b,&c);
   ^