#include <map>
#include <set>
#include <list>
#include <cmath>
#include <queue>
#include <stack>
#include <cstdio>
#include <string>
#include <vector>
#include <complex>
#include <cstdlib>
#include <cstring>
#include <numeric>
#include <sstream>
#include <iostream>
#include <algorithm>
#include <functional>
  
#define mp       make_pair
#define pb       push_back
#define all(x)   (x).begin(),(x).end()
#define rep(i,n) for(int i=0;i<(n);i++)
  
using namespace std;
  
typedef    long long          ll;
typedef    unsigned long long ull;
typedef    vector<bool>       vb;
typedef    vector<int>        vi;
typedef    vector<vb>         vvb;
typedef    vector<vi>         vvi;
typedef    pair<int,int>      pii;
  
const long long int INF= (long long int)1e15 + 1;
const double EPS=1e-9;
  
const int dx[]={1,0,-1,0,1,1,-1,-1},dy[]={0,-1,0,1,1,-1,-1,1};
 
int main() {
    int N;
    cin >> N;
    vector<vector<long long int>> D(N, vector<long long int>(N, 0));
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            cin >> D[i][j];
        }
    }
 
    long long int ans = 0;
    bool invalid = false;
    for (int i = 0; i < N; i++) {
        for (int j = i + 1; j < N; j++) {
            ans += D[i][j];
            for (int k = 0; k < N; k++) {
                if (i == k || j == k) continue;
                if (D[i][k] + D[k][j] < D[i][j]) {
                    invalid = true;
                    break;
                }
                if (D[i][k] + D[k][j] == D[i][j]) {
                    ans -= D[i][j];
                    break;
                }
            }
            if (invalid) break;
        }
        if (invalid) break;
    }
 
    if (invalid) {
        cout << -1 << endl;
    } else {
        cout << ans << endl;
    }
 
    return 0;
}