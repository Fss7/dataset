#include <algorithm>
#include <cmath>
#include <complex>
#include <iomanip>
#include <iostream>
#include <string>
#include <utility>
#include <vector>
#include <queue>

using namespace std;

using ll = long long int;
const int MOD = 1e9 + 7;
const int INF = 1e9 + 373;

#define rep(i, n) for (int i = 0; i < (n); ++i)

template <typename T>
using vector2 = vector<vector<T>>;
template <typename T>
vector2<T> init_vector2(size_t n0, size_t n1, T e = T()) {
    return vector2<T>(n0, vector<T>(n1, e));
}

template <typename T>
using vector3 = vector<vector<vector<T>>>;
template <typename T>
vector3<T> init_vector3(size_t n0, size_t n1, size_t n2, T e = T()) {
    return vector3<T>(n0, vector2<T>(n1, vector<T>(n2, e)));
}

int main() {
    typedef pair<int, int> P;
    priority_queue<P> q;

    int n, k;
    cin >> n >> k;

    vector<int> a(n);
    rep(i, n){
        cin >> a[i];
    }

    rep(i, k){
        q.push(make_pair(a[i], i));
    }

    cout << q.top().second + 1 << endl;

    for(int i = k; i < n; i++){
        q.push(make_pair(a[i], i));
        q.pop();
        cout << q.top().second + 1 << endl;
    }

    return 0;
}