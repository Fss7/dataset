#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(){
    int a, b, c, d;
    scanf("%d%d%d%d", &a, &b, &c, &d);
    int ans;
    if(a > b){
        ans = b;
    }else{
        ans = a;
    }
    if(c > d){
        ans += d;
    }else{
        ans += c;
    }
    printf("%d\n",ans);
    return 0;
} ./Main.c: In function �main�:
./Main.c:7:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d%d%d%d", &a, &b, &c, &d);
     ^