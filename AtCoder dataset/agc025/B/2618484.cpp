/*
                   _ooOoo_
                  o8888888o
                  88" . "88
                  (| -_- |)
                  O\  =  /O
               ____/`---'\____
             .'  \\|     |//  `.
            /  \\|||  :  |||//  \
           /  _||||| -:- |||||-  \
           |   | \\\  -  /// |   |
           | \_|  ''\---/''  |   |
           \  .-\__  `-`  ___/-. /
         ___`. .'  /--.--\  `. . ___
      ."" '<  `.___\_<|>_/___.'  >'"".
     | | :  `- \`.;`\ _ /`;.`/ - ` : | |
     \  \ `-.   \_ __\ /__ _/   .-` /  /
======`-.____`-.___\_____/___.-`____.-'======
                   `=---='
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
         ���汣��       ����BUG
*/
//use readint!
#pragma GCC optimize(1)
#pragma G++ optimize(1)
#pragma GCC optimize(2)
#pragma G++ optimize(2)
#pragma GCC optimize(3)
#pragma G++ optimize(3)
#pragma GCC optimize(4)
#pragma G++ optimize(4)
#pragma GCC optimize(5)
#pragma G++ optimize(5)
#pragma GCC optimize(6)
#pragma G++ optimize(6)
#pragma GCC optimize(7)
#pragma G++ optimize(7)
#pragma GCC optimize(8)
#pragma G++ optimize(8)
#pragma GCC optimize(9)
#pragma G++ optimize(9)
#pragma GCC optimize("-funsafe-loop-optimizations")
#pragma GCC optimize("-funroll-loops")
#pragma GCC optimize("-fwhole-program")
#pragma GCC optimize("Ofast,no-stack-protector")
#pragma GCC optimize("-fthread-jumps")
#pragma GCC optimize("-falign-functions")
#pragma GCC optimize("-falign-jumps")
#pragma GCC optimize("-falign-loops")
#pragma GCC optimize("-falign-labels")
#pragma GCC optimize("-fcaller-saves")
#pragma GCC optimize("-fcrossjumping")
#pragma GCC optimize("-fcse-follow-jumps")
#pragma GCC optimize("-fcse-skip-blocks")
#pragma GCC optimize("-fdelete-null-pointer-checks")
#pragma GCC optimize("-fdevirtualize")
#pragma GCC optimize("-fexpensive-optimizations")
#pragma GCC optimize("-fgcse")
#pragma GCC optimize("-fgcse-lm")
#pragma GCC optimize("-fhoist-adjacent-loads")
#pragma GCC optimize("-finline-small-functions")
#pragma GCC optimize("-findirect-inlining")
#pragma GCC optimize("-fipa-sra")
#pragma GCC optimize("-foptimize-sibling-calls")
#pragma GCC optimize("-fpartial-inlining")
#pragma GCC optimize("-fpeephole2")
#pragma GCC optimize("-freorder-blocks")
#pragma GCC optimize("-freorder-functions")
#pragma GCC optimize("-frerun-cse-after-loop")
#pragma GCC optimize("-fsched-interblock")
#pragma GCC optimize("-fsched-spec")
#pragma GCC optimize("-fschedule-insns")
#pragma GCC optimize("-fschedule-insns2")
#pragma GCC optimize("-fstrict-aliasing")
#pragma GCC optimize("-fstrict-overflow")
#pragma GCC optimize("-ftree-switch-conversion")
#pragma GCC optimize("-ftree-tail-merge")
#pragma GCC optimize("-ftree-pre")
#pragma GCC optimize("-ftree-vrp")
#pragma GCC target("avx")
#include<map>
#include<iostream>
#include<iomanip>
#include<algorithm>
#include<vector>
#include<set>
#include<cmath>
#include<stdio.h>
#include<fstream>
#include<assert.h>
#include<time.h>
#include<queue>
#include<deque>
#include<stack>
#include<list>
#include<string.h>
#define mp make_pair
#define all(v) v.begin(),v.end()
#define memset(a,b) memset(a,b,sizeof(a))
typedef long long ll;
using namespace std;
const int INF=1e9;
inline int pt(int a[],int l,int r){
	int p,i,j;
	p=a[l];
	i=l;
	j=r+1;
	for(;;){
		while(a[++i]<p) if(i>=r) break;
		while(a[--j]>p) if(j<=l) break;
		if(i>=j) break;
		else swap(a[i],a[j]);
	}
	if(j==l) return j;
	swap(a[l],a[j]);
	return j;
}
inline void q_sort(int a[],int l,int r){
	int q;
	if(r>l){
		q=pt(a,l,r);
		q_sort(a,l,q-1);
		q_sort(a,q+1,r);
	}
}
inline void rd(long long &val){
    long long x=0;
    int f=1;
    char ch=getchar();
    while((ch<'0'||ch>'9')&&ch!='-') ch=getchar();
	if(ch=='-'){
		f=-1;
		ch=getchar();
	}
    while(ch>='0'&&ch<='9'){
        x=x*10+ch-'0';
        ch=getchar();
    }
    val=x*f;
}
inline void quickSort(int s[],int l,int r)  {
    if(l<r){
        int i=l,j=r,x=s[l];
        while(i<j){
            while(i<j&&s[j]>=x) j--;
            if(i<j) s[i++]=s[j];
            while(i<j&&s[i]<x) i++;
            if(i<j) s[j--] = s[i];
        }
        s[i]=x;
        quickSort(s, l, i - 1);
        quickSort(s, i + 1, r);
    }
}
ll N,A,B,K,a,b;
const ll MD=998244353;
ll ans=0;
inline ll inc(ll a,ll b){
	a+=b;
	if(a>=MD) a-=MD;
        return a;
}
inline ll mul(ll a,ll b){
	a*=b;
	if(a>=MD) a%=MD;
	return a;
}

inline ll gjc(ll a){
	a%=MD;
	if(a<0) a+=MD;
	ll b=MD;
	ll x=0,y=1;
	while(a){
    	int t=b/a;
    	b-=t*a;
		swap(a,b);
    	x-=t*y;
		swap(x,y);
	}
	if(x<0) x+=MD;
	return x;
}
int main(){
	ios_base::sync_with_stdio(false);
	ll i,j,t;
	cin>>N>>A>>B>>K;
	vector<ll> jc(N+1);
	jc[0]=1ll;
	for(i=1;i<=N;i++) jc[i]=mul(jc[i-1],mul(N-i+1,gjc(i)));
	for(a=0;a<=N;a++){
		t=K-a*A;
		if(t<0||t%B!=0) continue;
		b=t/B;
		if(b>=0&&b<=N){
			ans=inc(ans,mul(jc[b],jc[a]));
		}
//		cout<<ans<<endl;
	}
	cout<<ans<<endl;
	return 0;
}