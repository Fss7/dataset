#include <vector>
#include <list>
#include <map>
#include <set>
#include <queue>
#include <deque>
#include <stack>
#include <bitset>
#include <algorithm>
#include <functional>
#include <numeric>
#include <utility>
#include <sstream>
#include <iostream>
#include <iomanip>
#include <cstdio>
#include <cmath>
#include <cstdlib>
#include <cctype>
#include <string>
#include <cstring>
#include <ctime>
#include <climits>

#define int long long
#define FOR(i, a, b) for (int i = (a); i < (b); ++i)
#define REP(i, n) FOR(i, 0, n)
#define ALL(a) (a).begin(), (a).end()
#define SZ(a) (signed)((a).size())
#define EACH(i, c) for (typeof((c).begin()) i = (c).begin(); i != (c).end(); ++i)
#define EXIST(s, e) ((s).find(e) != (s).end())
#define SORT(c) sort((c).begin(), (c).end())

using namespace std;

typedef vector<int> VI;
typedef vector<VI> VVI;
typedef vector<string> VS;
typedef pair<int, int> PII;

const int MOD = 1000000007;

#define dump(x) cerr << #x << " = " << (x) << endl;
#define debug(x) cerr << #x << " = " << (x) << " (L" << __LINE__ << ")"  << " " << __FILE__ << endl;

signed main(void) {
    ios::sync_with_stdio(false);
    cout.setf(ios::fixed, ios::floatfield);
    cout.precision(10);
    cin.tie(0);

    int n;
    cin >> n;
    VI a(n);
    REP(i, n) {
        cin >> a[i];
    }

    VI ans(2, 0);
    REP(i, 2) {
        int temp = 0;
        REP(j, n) {
            if (j % 2 == i) {
                if (temp + a[j] <= 0) {
                    ans[i] += 1 - (temp + a[j]);
                    temp = 1;
                } else {
                    temp += a[j];
                }
            } else {
                if (temp + a[j] >= 0) {
                    ans[i] += (temp + a[j]) - (-1);
                    temp = -1;
                } else {
                    temp += a[j];
                }
            }
        }
    }

    cout << *min_element(ALL(ans)) << endl;

    return 0;
}