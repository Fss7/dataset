#include <stdio.h>

int main(void){
  char s[19];
  scanf("%s",s);

  s[5] = ' ';
  s[13] = ' ';

  printf("%s\n",s);
  return 0;
} ./Main.c: In function �main�:
./Main.c:5:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%s",s);
   ^