#include<stdio.h>
#include<string.h>
int main(void){
int A,B,C,D,E,N,M,x,y,cou=0,cou2,v[1000000],w[1000000],min_i,en=0;
    char S[100],W[100],s[10],X,Y;
   scanf("%d %d",&A,&B);
   if((A*(B+1))<=((A+1)*B)){
       printf("%d\n",(A+1)*B);
   }else{
       printf("%d\n",A*(B+1));
   }
   return 0;
} ./Main.c: In function �main�:
./Main.c:6:4: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
    scanf("%d %d",&A,&B);
    ^