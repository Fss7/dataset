#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
#include <limits.h>
#define swap(type,a,b) do{type t=a;a=b;b=t;}while(0);
#define MAX(a,b) (((a)>(b))?(a):(b))
#define MIN(a,b) (((a)<(b))?(a):(b))
#define ll long long
#define INF 100000000
#define FOR(i,a,n) for(i=(a);i<(n);i++)
int comp(const void* a,const void* b){
	return *(int*)a-*(int*)b;
}
void fill(int a[],int b,int c){
	int i;
	FOR(i,0,b) a[i]=c;
	return;
}
int a[100000];
int main(void)
{
	int n,i;
	ll sum=0,s1=0,s2=0;
	scanf("%d",&n);
	FOR(i,0,n) scanf("%d",&a[i]);
	FOR(i,0,n){
		sum+=a[i];
		if(i%2==0&&sum<=0){
			s1+=(1-sum);
			sum=1;
		}
		if(i%2&&sum>=0){
			s1+=(sum+1);
			sum=-1;
		}
	}
	sum=0;
	FOR(i,0,n){
		sum+=a[i];
		if(i%2==0&&sum>=0){
			s2+=(sum+1);
			sum=-1;
		}
		if(i%2&&sum<=0){
			s2+=(1-sum);
			sum=1;
		}
	}
	printf("%lld\n",MIN(s1,s2));
	return 0;
} ./Main.c: In function �main�:
./Main.c:25:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d",&n);
  ^
./Main.c:26:13: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  FOR(i,0,n) scanf("%d",&a[i]);
             ^