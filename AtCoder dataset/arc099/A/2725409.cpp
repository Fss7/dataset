#include <algorithm>
#include <cassert>
#include <cfloat>
#include <cmath>
#include <cstdio>
#include <cstdlib>
#include <deque>
#include <iostream>
#include <limits>
#include <map>
#include <queue>
#include <set>
#include <stack>
#include <string>
#include <tuple>
#include <unordered_map>
#include <unordered_set>
#include <vector>
 
#define FOR(i,k,n) for (int (i)=(k); (i)<(n); ++(i))
#define rep(i,n) FOR(i,0,n)
#define all(v) begin(v), end(v)
#define debug(x) cerr<< #x <<": "<<x<<endl
#define debug2(x,y) cerr<< #x <<": "<< x <<", "<< #y <<": "<< y <<endl
 
using namespace std;
typedef long long ll;
typedef pair<int, int> pii;
typedef vector<int> vi;
typedef vector<vector<int> > vvi;
typedef vector<ll> vll;
typedef vector<vector<ll> > vvll;
typedef deque<bool> db;
template<class T> using vv=vector<vector< T > >;

int main() {
  int n, k;
  scanf("%d %d", &n, &k);
  int ind = -1;
  rep (i, n) {
    int tmp;
    scanf("%d", &tmp);
    if (tmp == 1) {
      ind = i;
    }
  }
  int ans = 0;
  int a = ind;
  int b = n - 1 - ind;
  if (a > b) {
    swap(a, b);
  }
  ans += (a / (k - 1));
  b += (a % (k - 1));
  ans += ((b + k - 2) / (k - 1));
  printf("%d\n", ans);

  return 0;
}