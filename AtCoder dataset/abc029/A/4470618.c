#include <stdio.h>
int main(void){
char s[100];
  scanf("%s",&s);
  printf("%s",s);
  printf("s\n");
return 0;
} ./Main.c: In function �main�:
./Main.c:4:9: warning: format �%s� expects argument of type �char *�, but argument 2 has type �char (*)[100]� [-Wformat=]
   scanf("%s",&s);
         ^
./Main.c:4:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%s",&s);
   ^