#include <stdio.h>

int main(){
    
    int r;
    scanf("%d",&r);
    if(r < 1200 ){
        printf("ABC\n");
    }else if(r >= 2800){
        printf("AGC\n");
    }else{
        printf("ARC\n");
    }
    return 0;
} ./Main.c: In function �main�:
./Main.c:6:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d",&r);
     ^