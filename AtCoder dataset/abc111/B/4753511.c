#include <stdio.h>
int main(void){
    int n;
    scanf("%d",&n);
    printf("%d\n",n%111==0?n:n+(111-n%111));
    return 0;
} ./Main.c: In function �main�:
./Main.c:4:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d",&n);
     ^