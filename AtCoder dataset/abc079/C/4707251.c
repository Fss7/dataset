#include <stdio.h>
#include <math.h>
#include <string.h>
long long int i,j;

int main(void){
    char s[10];
    scanf("%s",s);
    int a=s[0]-'0',b=s[1]-'0',c=s[2]-'0',d=s[3]-'0';
    if(a+b+c+d==7) printf("%d+%d+%d+%d=7\n",a,b,c,d);
    else if(a+b+c-d==7) printf("%d+%d+%d-%d=7\n",a,b,c,d);
    else if(a+b-c+d==7) printf("%d+%d-%d+%d=7\n",a,b,c,d);
    else if(a-b+c+d==7) printf("%d-%d+%d+%d=7\n",a,b,c,d);
    else if(a-b-c-d==7) printf("%d-%d-%d-%d=7\n",a,b,c,d);
    else if(a+b-c-d==7) printf("%d+%d-%d-%d=7\n",a,b,c,d);
    else if(a-b-c+d==7) printf("%d-%d-%d+%d=7\n",a,b,c,d);
    else if(a-b+c-d==7) printf("%d-%d+%d-%d=7\n",a,b,c,d);
    return 0;
} ./Main.c: In function �main�:
./Main.c:8:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%s",s);
     ^