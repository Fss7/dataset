#include<stdio.h>
long long gcd(long long a,long long b){
  if(a%b==0) return b;
  return gcd(b,a%b);
}
int main(void){
  int n,i;
  long long ans,t;
  
  scanf("%d%lld",&n,&ans);
  for(i=0;i<n-1;i++){
    scanf("%lld",&t);
    ans=ans/gcd(ans,t)*t;
  }
  printf("%lld\n",ans);
  
  return 0;
} ./Main.c: In function �main�:
./Main.c:10:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d%lld",&n,&ans);
   ^
./Main.c:12:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%lld",&t);
     ^