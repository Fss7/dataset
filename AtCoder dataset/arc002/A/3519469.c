#include <stdio.h>

int main(void)
{
    int year;
    
    scanf("%d%*c", &year);
    if(year % 400 == 0){
        printf("YES\n");
    }else if(year % 100 == 0){
        printf("NO\n");
    }else if(year % 4 == 0){
        printf("YES\n");
    }else{
        printf("NO\n");
    }
    
    return 0;
} ./Main.c: In function �main�:
./Main.c:7:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d%*c", &year);
     ^