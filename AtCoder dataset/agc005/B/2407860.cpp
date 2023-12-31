#include <cmath>
#include <iostream>
#include <vector>
#include <queue>
#include <map>
#include <set>
#include <algorithm>
#include <utility>
#include <iomanip>

#define int long long int
#define rep(i, n) for(int i = 0; i < (n); ++i)

using namespace std;

typedef pair<int, int> P;

const int INF = 1e15;
const int MOD = 1e9+7;

signed main(){
    int n;
    cin >> n;

    vector<int> a(n+1);
    rep(i, n){
        int x;
        cin >> x;
        a[x] = i;
    }

    set<int> s;
    s.insert(-1);
    s.insert(n);
    int ans = 0;
    for(int i = 1; i <= n; i++){
        s.insert(a[i]);
        auto it = s.find(a[i]);
        it++;
        int right = *it;
        it--;
        it--;
        int left = *it;
        ans += i * (right - a[i]) * (a[i] - left);
    }
    cout << ans << endl;

    return 0;
}