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
#define EACH(i, c) for (auto &(i): c)
#define all(c) begin(c),end(c)
#define EXIST(s, e) ((s).find(e)!=(s).end())
#define SORT(c) sort(begin(c),end(c))
#define pb emplace_back
#define MP make_pair
#define SZ(a) int((a).size())

//#define LOCAL 0
//#ifdef LOCAL
//#define DEBUG(s) cout << (s) << endl
//#define dump(x)  cerr << #x << " = " << (x) << endl
//#define BR cout << endl;
//#else
//#define DEBUG(s) do{}while(0)
//#define dump(x) do{}while(0)
//#define BR
//#endif


//??
typedef long long int ll;
using namespace std;
#define INF (1 << 30) - 1
#define INFl (ll)5e15
#define DEBUG 0 //???????1????
#define dump(x)  cerr << #x << " = " << (x) << endl
#define MOD 1000000007
//????????


int main() {
    cin.tie(0);
    ios::sync_with_stdio(false);

    int N;
    cin >> N;
    vector<pair<ll, ll> > vpp(N);
    rep(i, 0, N) {
        cin >> vpp[i].first >> vpp[i].second;
    }
    ll ans = 0LL;
    rep(i, 0, N) {
        if (vpp[i].first != vpp[i].second) {
            break;
        }
        if (i == N - 1) {
            cout << 0 << endl;
            return 0;
        }
    }

    rep(i, 0, N) {
        if (vpp[i].first <= vpp[i].second) {
            vpp[i].second -= vpp[i].first;
            ans += vpp[i].first;
            vpp[i].first = 0;
        }
    }
    sort(all(vpp));
//    int pt = 0;
//    rep(i, 0, N) {
//        if (vpp[i].first > 0 && vpp[i].second != 0) {
//            pt = i + 1;
//            break;
//        }
//    }

    ll minb = INFl;
    rep(i,0,N){
        if(vpp[i].first > 0){
            minb = min(minb,vpp[i].second);
        }
        ans += vpp[i].second;
    }
    ans -= minb;
    cout << ans << endl;

//    if (pt == N) {
//        ans += (vpp[N - 1].first - vpp[N - 1].second);
//        cout << ans << endl;
//    } else {
//        pt--;
//        ans += (vpp[pt].first - vpp[pt].second);
//        for (int i = pt + 1; i < N; i++) {
//            ans += (vpp[i].first);
//        }
//        cout << ans << endl;
//
//    }

//        pt--;
//        ans += (vpp[pt].first - vpp[pt].second);
//        for (int i = pt + 1; i < N; i++) {
//            ans += (vpp[i].first);
//        }
//        cout << ans << endl;

    return 0;
}