#include <limits.h>
#include <algorithm>
#include <bitset>
#include <cctype>
#include <cmath>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <ctime>
#include <deque>
#include <functional>
#include <iomanip>
#include <iostream>
#include <list>
#include <map>
#include <numeric>
#include <set>
#include <sstream>
#include <stack>
#include <string>
#include <utility>
#include <vector>
#include <queue>

#define int long long
#define REP(i, n) for (int i = 0, i##_len = (n); i < i##_len; ++i)
#define REPS(i, n) for (int i = 1, i##_len = (n); i <= i##_len; ++i)
#define FOR(i, a, b) for (int i = (a), i##_len = (b); i <= i##_len; ++i)
#define REV(i, a, b) for (int i = (a); i >= (b); --i)
#define CLR(a, b) memset((a), (b), sizeof(a))
#define DUMP(x) cout << #x << " = " << (x) << endl;
#define INF 1001001001001001001ll
#define fcout cout << fixed << setprecision(10)

using namespace std;

typedef pair<int, int> P;

signed main() {
    ios::sync_with_stdio(false);
    cin.tie(nullptr);
    cout.tie(nullptr);

    int N;
    cin >> N;

    vector<pair<int, int>> e;

    int n = N;
    if (N % 2 == 1) n--;

    FOR(i, 1, n) {
        int t = n - i + 1;
        FOR(j, i + 1, n) {
            if (j == t) continue;
            e.push_back({i, j});
        }
    }

    if (N % 2 == 1) {
        FOR(i, 1, N - 1) {
            e.push_back({i, N});
        }
    }

    cout << e.size() << endl;

    for (auto kv: e) {
        cout << kv.first << " " << kv.second << endl;
    }
    return 0;
}