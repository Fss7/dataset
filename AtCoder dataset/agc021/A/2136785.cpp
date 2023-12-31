#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <algorithm>
#include <numeric>
#include <map>
#include <set>
#include <queue>
#include <stack>
#include <cstdio>
#include <cstring>
#include <cmath>
#include <bitset>
#include <climits>
#define REP(i,n) for (int i=0;i<(n);i++)
#define FOR(i,a,b) for (int i=(a);i<(b);i++)
#define RREP(i,n) for (int i=(n)-1;i>=0;i--)
#define RFOR(i,a,b) for (int i=(a)-1;i>=(b);i--)
#define ll long long
#define ull unsigned long long
int dx[4] = {1, 0, -1, 0};
int dy[4] = {0, 1, 0, -1};
const int INF = 1e9;
const ll LL_INF = 1e18;
const int MOD = 1e9 + 7;

using namespace std;

string s;
int N;
int ans = 0;
void dfs(int i, bool mode, int res){
  if(i == N){
    ans = max(res, ans);
    return;
  }
  
  if(mode){
    dfs(i + 1, mode, res + 9);
  }else{
    if(s[i] > '0'){
      dfs(i + 1, true, res + s[i] - '0' - 1);
    }
    dfs(i + 1, false, res + s[i] - '0');
  }
}

int main(){
  cin.tie(0);
  ios::sync_with_stdio(false);
  cin >> s;
  N = s.size();
  dfs(0, false, 0);
  cout << ans << endl;
  return 0;
}