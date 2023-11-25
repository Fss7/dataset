#include <iostream>
#include <vector>
using namespace std;

// Disjoint Set
template<typename T>
class UnionFind {
 private:
  T _size;
  vector<T> _parent; // ????????????????????????

 public:
  // n?????
  explicit UnionFind(T n) : _size{n}, _parent{vector<T>(n, -1)} {}

  // ???????
  T find(T x) {
    if (x < 0 || x >= _size) {
      return x;
    }

    if (_parent[x] < 0) {
      return x;
    }

    return _parent[x] = find(_parent[x]);
  }

  // x?y???????????
  bool unite(T x, T y) {
    if (x < 0 || x >= _size || y < 0 || y >= _size) {
      return false;
    }

    x = find(x);
    y = find(y);
    if (x == y) {
      return false;
    }

    if (size(x) > size(y)) {
      _parent[x] += _parent[y];
      _parent[y] = x;
    } else {
      _parent[y] += _parent[x];
      _parent[x] = y;
    }

    return true;
  }

  // x?y??????????
  bool same(T x, T y) {
    return find(x) == find(y);
  }

  // x?????????????
  T size(T x) {
    if (x < 0 || x >= _size) {
      return 1;
    }

    return -_parent[find(x)];
  }

  // ?????????
  T size() {
    return _size;
  }
};

constexpr int MAX_N = 1e5;
constexpr int MAX_M = 1e5;
long A[MAX_M];
long B[MAX_M];
long dp[MAX_N + 1];

int main() {
  long N, M;
  cin >> N >> M;
  for (long i{}; i < M; ++i) {
    cin >> A[i];
    --A[i];
    cin >> B[i];
    --B[i];
  }
  UnionFind<long> uf(N);

  dp[M - 1] = N * (N - 1) / 2;
  for (long i{M - 1}; i >= 1; --i) {
    dp[i - 1] = dp[i];
    if (uf.find(A[i]) != uf.find(B[i])) {
      dp[i - 1] -= uf.size(A[i]) * uf.size(B[i]);
      uf.unite(A[i], B[i]);
    }
  }

  for (int i{}; i < M; ++i) {
    cout << dp[i] << endl;
  }
  return 0;
}