#include <iostream>
#include <cstring>
#include <cstdlib>
#include <cmath>
#include <algorithm>
#include <functional>
#include <vector>
#include <queue>
#include <stack>
#include <map>
#include <set>
#include <bitset>
#include <cassert>
#include <exception>
using namespace std;
typedef long long ll;
typedef unsigned long long ull;
typedef pair<string,ll> P;
typedef vector<int> vi;
typedef vector<ll> vll;
typedef vector<string> vs;
typedef vector<P> vp;
#define rep(i,a,n) for(ll i = (a);i < (n);i++)
#define per(i,a,n) for(ll i = (a);i > (n);i--)
#define lep(i,a,n) for(ll i = (a);i <= (n);i++)
#define pel(i,a,n) for(ll i = (a);i >= (n);i--)
#define clr(a,b) memset((a),(b),sizeof(a))
#define pb push_back
#define mp make_pair
#define all(c) (c).begin(),(c).end()
#define sz size()
#define print(X) cout << (X) << endl
const ll INF = 1e+8+7;
ll n,m,l;
string s,t;
int d[100000],dp[10001][101];

int main(){
  ll p;
  cin >> n >> m >> l >> p;
  ll a,b,c;
  a = n * l;
  b = m * (l-(l%p))/p + n * (l%p);
  c = l / p;
  if(l % p != 0)c++;
  c *= m;
  //cout << a << " " << b << " " << c << endl;
  print(min(min(a,b),c));
  return 0;
}