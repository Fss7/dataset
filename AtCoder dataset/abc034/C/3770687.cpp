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
class Combination {

public:
    vector<ll> fact;

    Combination(int max_n) {
        //1 ~ n!?????mod????
        int n = max_n;
        vector<ll> fact(n + 1);
        fact[0] = 1;
        for (int i = 1; i <= n; i++) {
            fact[i] = (fact[i - 1] * i) % MOD;
        }
        this->fact = fact;
    }

    template<typename T>
    //template????????
    ll pow(T x, int y) {
        if (y == 0) return 1;
        if (y == 1) return x;
        if (y == 2) return (x * x) % MOD;
//        if (y % 2 == 1) return pow(x, y / 2) * pow(x, y / 2) % MOD;
        if (y % 2 == 1) return pow(pow(x, y / 2), 2) * x % MOD;
//        return pow(x, y / 2) * pow(x, y / 2) % MOD;
        return pow(pow(x, y / 2), 2) % MOD;
    }

    ll nCk(int n, int k) {
//        return (fact[n] * pow(fact[n-k],MOD-2) * pow(fact[k],MOD-2)) % MOD;
        return (((fact[n] * pow(fact[n - k], MOD - 2)) % MOD) * pow(fact[k], MOD - 2)) % MOD;
    }

    /**
     * x ^ -1????
     */
    template<typename T>
    ll inv(T x) {
        return pow(x, MOD - 2);
    }
};

class Solve {
public:
    void input() {

    }

    void solve() {
        input();
        ll W,H;
        cin >> W >> H;
        ll a = W + H - 2;
        ll b = W - 1;
        Combination cmb(a + 5);

        ll ans = cmb.nCk(a,b);
        cout << ans << endl;

    }
};


int main() {
    cin.tie(0);
    ios::sync_with_stdio(false);

    Solve().solve();


    return 0;
}