#include<stdio.h>
int a,b;
int main(void){
    scanf("%d%d",&a,&b);
    if(a>=b){
        printf("%d",a);
    }else{
        printf("%d",b);
    }
  printf("\n");
    return 0;
} ./Main.c: In function �main�:
./Main.c:4:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d%d",&a,&b);
     ^