#include <iostream>
#include <string.h>
#include <stdio.h>
#include <map>
#include <vector>
#include <math.h>
#include <algorithm>
#include <queue>
#include <set>
using namespace std;

#define rep(i,a) for(int i=0; i<a; i++)
#define rrep(i,a) for(int i=a; i>=0; i--)
#define loop3(i,j,k,a) for(int i=0; i<a; i++)for(int j=0; j<a; j++)if(i!=j)for(int k=0; k<a; k++)if(i!=k&&j!=k)
#define loop4(i,j,k,l,a) for(int i=0; i<a; i++)for(int j=0; j<a; j++)if(i!=j)for(int k=0; k<a; k++)if(i!=k&&j!=k)for(int l=0; l<a; l++)if(i!=l&&j!=l&&k!=l)
#define rep1(i,a) for(int i=1; i<=a; i++)

#define scnd1(a) scanf("%d", &a)
#define scnd2(a,b) scanf("%d%d", &a,&b)
#define scnd3(a,b,c) scanf("%d%d%d", &a,&b,&c)
#define scnd4(a,b,c,d) scanf("%d%d%d%d", &a,&b,&c,&d)

#define cin1(a) cin >> a;
#define cin2(a,b) cin >> a >> b;
#define cin3(a,b,c) cin >> a >> b >> c;
#define cin4(a,b,c,d) cin >> a >> b >> c >> d;
#define cout1(a) cout << a << endl;
#define cout2(a,b) cout << a << " " << b << endl;
#define cout3(a,b,c) cout << a << " " << b << " " << c << endl;
#define cout4(a,b,c,d) cout << a << " " << b << " " << c << " " << d << endl;
#define prtd1(a) printf("%d\n", a)
#define prtd2(a,b) printf("%d %d\n", a,b)
#define prtd3(a,b,c) printf("%d %d %d\n", a,b,c)
#define prtd4(a,b,c,d) printf("%d %d %d %d\n", a,b,c,d)

#define mem(a,n) memset( a, n, sizeof(a))
#define INF 1000000000
typedef long long ll;

int store[109];
int nums[109][19];

int main() {
    int N;
    cin >> N;
    mem(store,0);
    mem(nums,0);
    
    int n;
    rep(i,N) {
        rep(j,10) {
            store[i] *= 2;
            cin >> n;
            store[i] += n;
        }
    }
    
    rep(i,N) {
        rep(j,11) {
            cin >> nums[i][j];
            //cout<<nums[i][j];
        }
        //cout<<endl;
    }
    //cout<<store[1]<<endl;
    
    ll maxn=-10000000000000;
    rep1(i,(2<<9)-1) {
        ll m=0;
        rep(j,N) {
            int v = store[j]&i;
            int c=0;
            while(v>0) {
                if( (v&1)==1)c++;
                v/=2;
            }
            m += nums[j][c];
        }
        //cout2(i,m);
        maxn = max( maxn, m);
    }
    
    cout1(maxn);
}