#include <cstdio>
#include <cstdlib>
#include <iostream>
#include <fstream>
#include <sstream>
#include <set>
#include <map>
#include <vector>
#include <list>
#include <algorithm>
#include <cstring>
#include <cmath>
#include <string>
#include <queue>
#include <bitset>     //UWAGA - w czasie kompilacji musi byc znany rozmiar wektora - nie mozna go zmienic
#include <cassert>
#include <iomanip>        //do setprecision
#include <ctime>
#include <complex>
using namespace std;

#define FOR(i,b,e) for(int i=(b);i<(e);++i)
#define FORQ(i,b,e) for(int i=(b);i<=(e);++i)
#define FORD(i,b,e) for(int i=(b)-1;i>=(e);--i)
#define REP(x, n) for(int x = 0; x < (n); ++x)

#define ST first
#define ND second
#define PB push_back
#define MP make_pair
#define LL long long
#define ULL unsigned LL
#define LD long double

const double pi = 3.141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342;
const int mod=1000000007;

int main(){
	int n,k,q,a[2222]={},ans=mod;
	cin>>n>>k>>q;
	FOR(i,0,n)cin>>a[i];
	FOR(i,0,n){
		int th=a[i];
		priority_queue<int> pq;
		priority_queue<int> pq2;
		FOR(j,0,n){
			if(a[j]<th){
				while(pq2.size()>=k){
					pq.push(pq2.top());
					pq2.pop();
				}
				priority_queue<int> newpq;
				pq2=newpq;
			}else{
				pq2.push(-a[j]);
			}
		}
		while(pq2.size()>=k){
			pq.push(pq2.top());
			pq2.pop();
		}
		if(pq.size()<q)continue;
		FOR(i,0,q-1){
			pq.pop();
		}
		int x=-pq.top();
		ans=min(ans,x-th);
	}
	cout<<ans;
    return 0;
}