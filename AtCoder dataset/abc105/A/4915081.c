#include <stdio.h>
int main(void){
   int i,N,K;
   
   scanf("%d %d",&N,&K);
   if(N%K==0)
   printf("0");
   else
   printf("1");
   
       return(0);
   } ./Main.c: In function �main�:
./Main.c:5:4: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
    scanf("%d %d",&N,&K);
    ^