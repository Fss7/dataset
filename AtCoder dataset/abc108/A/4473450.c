#include<stdio.h>
#include<stdlib.h>
#include<limits.h>
#include<string.h>

int main(){
    int K;
    scanf("%d",&K);
    printf("%d",(K/2)*((K+1)/2));
    return 0;
} ./Main.c: In function �main�:
./Main.c:8:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d",&K);
     ^