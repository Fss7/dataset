#include <stdio.h>
int main(void){
    // Your code here!
    int n;
    scanf("%d",&n);
    if(n%2==0)
        printf("%d\n",n-1);
    else
        printf("%d\n",n+1);
} ./Main.c: In function �main�:
./Main.c:5:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d",&n);
     ^