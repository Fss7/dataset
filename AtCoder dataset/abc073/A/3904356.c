#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define ll long long
#define rep(i,l,r)for(ll i=(l);i<(r);i++)
#define max(p,q)((p)>(q)?(p):(q))
#define min(p,q)((p)<(q)?(p):(q))

int main(){
	int n;
	scanf("%d",&n);
	puts(n/10==9||n%10==9?"Yes":"No");
} ./Main.c: In function �main�:
./Main.c:11:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d",&n);
  ^