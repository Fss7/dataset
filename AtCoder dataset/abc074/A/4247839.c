#include <stdio.h>

int main()
{
  int n,a;
  scanf("%d%d",&n,&a);
  printf("%d\n",n*n-a);

  return 0;
} ./Main.c: In function �main�:
./Main.c:6:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d%d",&n,&a);
   ^