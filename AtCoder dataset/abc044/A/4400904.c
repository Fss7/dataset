#include <stdio.h>

int main(){
    int n,k,x,y,sum=0;
    scanf("%d%d%d%d",&n,&k,&x,&y);
    for (int i=0; i<n; i++) {
        if (i<k) {
            sum+=x;
        }else{
            sum+=y;
        }
    }
    printf("%d\n",sum);
} ./Main.c: In function �main�:
./Main.c:5:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d%d%d%d",&n,&k,&x,&y);
     ^