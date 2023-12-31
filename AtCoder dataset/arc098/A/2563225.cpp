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
//#define EACH(i, c) for (auto &(i): c)
#define all(c) begin(c),end(c)
//#define EXIST(s, e) ((s).find(e)!=(s).end())
//#define SORT(c) sort(begin(c),end(c))
//#define pb emplace_back
//#define MP make_pair
//#define SZ(a) int((a).size())

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

    string s, tmp;
    cin >> tmp;
    s += 'E';
    s += tmp;
    s += 'W';

    vector<int> ecost(N + 2), wcost(N + 2);

    for (int i = 0; i < s.size(); i++) {
        if (s[i] == 'W') {
            ecost[i] = 1;
        } else {
            wcost[i] = 1;
        }
    }
    rep(i, 1, s.size()) {
        ecost[i] += ecost[i - 1];
        wcost[i] += wcost[i - 1];
    }

    ll lowcost = INFl;
    rep(i, 1, s.size() - 1) {
        ll tmp = 0;
        tmp += ecost[i - 1];
        tmp += (wcost[s.size() - 1] - wcost[i]);
        lowcost = min(lowcost, tmp);
    }

    cout << lowcost << endl;


    return 0;
}