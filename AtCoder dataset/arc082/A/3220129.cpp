#include <iostream>
#include <algorithm>
#include <bitset>
#include <map>
#include <queue>
#include <set>
#include <stack>
#include <string>
#include <utility>
#include <vector>
#include <complex>
#include <valarray>
#include <unordered_map>
#include <array>
#include <fstream>
#include <cassert>
#include <cmath>
#include <functional>
#include <iomanip>
#include <random>
#include <numeric>

#define INIT std::ios::sync_with_stdio(false);std::cin.tie(0);
#define rep(X,Y) for (int (X) = 0;(X) < (Y);++(X))
#define all(X) (X).begin(),(X).end()
#define fi first
#define sc second
using namespace std;
typedef long long ll;
typedef unsigned long long ull;
typedef pair<int,int> Pii;
typedef pair<ll,ll> Pll;
const int INFINT = 1 << 30;                          // 1.07x10^ 9
const ll INFLL = 1LL << 60;                          // 1.15x10^18
const double EPS = 1e-10;
const int MOD = 1000000007;

const int MAX_N = 100000;
int N;
int A[MAX_N];
int C[MAX_N+2];

int main() {
  cin >> N;
  rep(i, N) cin >> A[i];
  
  for (int i = 0; i < N; ++i) {
    C[A[i]]++;
  }

  int ans = 0;
  for (int i = 0; i <= MAX_N; ++i) {
    int tmp = 0;
    if (i-1 >= 0) tmp += C[i-1];
    if (i+1 <= MAX_N) tmp += C[i+1];
    tmp += C[i];
    ans = max(ans, tmp);
  }

  cout << ans << endl;

  return 0;
}