#include <algorithm>
#include <bitset>
#include <complex>
#include <deque>
#include <exception>
#include <fstream>
#include <functional>
#include <iomanip>
#include <ios>
#include <iosfwd>
#include <iostream>
#include <istream>
#include <iterator>
#include <limits>
#include <list>
#include <locale>
#include <map>
#include <memory>
#include <new>
#include <numeric>
#include <ostream>
#include <queue>
#include <set>
#include <sstream>
#include <stack>
#include <stdexcept>
#include <streambuf>
#include <string>
#include <typeinfo>
#include <utility>
#include <valarray>
#include <vector>
#include <climits>

#define rep(i, m, n) for(int i=int(m);i<int(n);i++)
#define all(c) begin(c),end(c)

template<typename T1, typename T2>
inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }

template<typename T1, typename T2>
inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

//??
typedef long long int ll;
using namespace std;
#define INF (1 << 30) - 1
#define INFl (ll)5e15
#define DEBUG 0 //???????1????
#define dump(x)  cerr << #x << " = " << (x) << endl
#define MOD 1000000007


//????????
class Solve {
public:
    void input() {

    }

    void solve() {
        input();
        int H, W;
        cin >> H >> W;
        vector<string> a(H);
        rep(i, 0, H) cin >> a[i];
        vector<bool> row(H, true);
        vector<bool> col(W, true);
        for (int i = 0; i < H; ++i) {
            bool flag = true;
            for (int j = 0; j < W; ++j) {
                if (a[i][j] == '#') flag = false;
            }
            if (flag) row[i] = false;
        }

        for (int j = 0; j < W; ++j) {
            bool flag = true;
            for (int i = 0; i < H; ++i) {
                if (a[i][j] == '#') flag = false;
            }
            if (flag) col[j] = false;
        }

        for (int i = 0; i < H; ++i) {
            if (!row[i]) continue;
            for (int j = 0; j < W; ++j) {
                if (col[j]) cout << a[i][j];
            }
            cout << endl;
        }
    }
};


int main() {
    cin.tie(0);
    ios::sync_with_stdio(false);
    cout << fixed << setprecision(10);

    Solve().solve();


    return 0;
}