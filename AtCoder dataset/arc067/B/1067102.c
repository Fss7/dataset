//Date:12-11-17

#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<stdbool.h>
#include<float.h>
#include<math.h>
#include<ctype.h>
#include<limits.h>
#include<time.h>
#define ll long long
#define For(i,n)	for(i=0;i<n;i++)
#define rep(i ,a ,b)	for(i=(a);i<=(b);i++)
#define mset(a ,value)	memset(a ,value ,sizeof(a))
#define s(a)	scanf("%d" ,&a);
#define ls(a)	scanf("%ld" ,&a)
#define lls(a)	scanf("%lld" ,&a)
#define reg(i)	register int i
#define infinite INT_MAX
#define MAX 1001
int min(int a,int b){	return (a<b?a:b);	}
int max(int a,int b){	return (a>b?a:b);	}
const int mod = 1e9+7;
int n;
bool prime[1001];
ll power(ll a, ll b, ll mod){
	ll x = 1, y = a;
	while (b){
		if (b%2)	x = (x*y)%mod;
		y = (y*y)%mod;
		b /= 2;
	}
	return x%mod;
}	

void sieve(){
	ll i ,j;
	mset(prime ,1);
	prime[1] =false;
	for(i=2;i<=1000;i++){
		if(prime[i]==true){
			j=i*i;
			while(j<=1000){
				prime[j] = false;	j+=i;
			}
		}
	}
}

main(){
	int n ,a ,b ,i;
	s(n);	s(a);	 s(b);
	ll p[n];
	For(i ,n)	lls(p[i]);
	ll f=0;
	rep(i ,1 ,n-1){
		if((p[i]-p[i-1])*a>b)	f+=b;
		else f+=((p[i]-p[i-1])*a	);
	}
	printf("%lld" ,f);
	return 0;
} ./Main.c:51:1: warning: return type defaults to �int� [-Wimplicit-int]
 main(){
 ^
./Main.c: In function �main�:
./Main.c:16:14: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
 #define s(a) scanf("%d" ,&a);
              ^
./Main.c:53:2: note: in expansion of macro �s�
  s(n); s(a);  s(b);
  ^
./Main.c:16:14: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
 #define s(a) scanf("%d" ,&a);
              ^
./Main.c:53:8: note: in expansion of macro �s�
  s(n); s(a);  s(b);
        ^
./Main.c:16:14: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
 #define s(a) scanf("%d" ,&a);
              ^
./Main.c:53:15: note: in expansion of macro �s�
  s(n); s(a);  s(b);
               ^
./Main.c:18:16: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
 #define lls(a) scanf("%lld" ,&a)
            ...