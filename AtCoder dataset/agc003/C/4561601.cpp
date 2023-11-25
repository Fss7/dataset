#include <iostream>
#include <vector>
#include <algorithm>
#include <map>
#include <math.h>
using namespace std;

using lli = long long int;
using Vint = vector<int>;
using Vlli = vector<lli>;
using Wint = vector<Vint>;
using Wlli = vector<Vlli>;
using pii = pair<int, int>;
using pll = pair<lli, lli>;

const int MOD = 1e9 + 7;
const int INFi = 2e9 + 1;
const lli INFl = (lli)(9e18) + 1;
const vector<pii> DXDY = {make_pair(1, 0), make_pair(-1, 0), make_pair(0, 1), make_pair(0, -1)};
const char BR = '\n';

#define FOR(i, a, b) for(int (i) = (a); (i) < (b); (i)++)
#define FOReq(i, a, b) for(int (i) = (a); (i) <= (b); (i)++)
#define rFOR(i, a, b) for(int (i) = (b); (i) >= (a); i--)
#define FORstep(i, a, b, step) for(int (i) = (a); i < (b); i += (step))
#define REP(i, n) FOR(i, 0, n)
#define rREP(i, n) rFOR(i, 0, (n-1))
#define vREP(i, vec) for(auto &(i) : (vec))
#define SORT(A) std::sort((A).begin(), (A).end())


template <class T> inline int argmin(vector<T> vec){return min_element(vec.begin(), vec.end()) - vec.begin();}
template <class T> inline int argmax(vector<T> vec){return max_element(vec.begin(), vec.end()) - vec.begin();}
template <class T> inline void chmax(T &a, T b){a = max(a, b);}
template <class T> inline void chmin(T &a, T b){a = min(a, b);}
inline int toInt(string &s){int res = 0; for(char a : s) res = 10 * res + (a - '0'); return res;}
inline int toInt(const string s){int res = 0; for(char a : s) res = 10 * res + (a - '0'); return res;}
inline long long int toLong(string &s){lli res = 0; for(char a : s) res = 10 * res + (a - '0'); return res;}
inline long long int toLong(const string s){lli res = 0; for(char a : s) res = 10 * res + (a - '0'); return res;}
template <class T> inline std::string toString(T n){
  if(n == 0) return "0";
  std::string res = "";
  if(n < 0){n = -n;while(n != 0){res += (char)(n % 10 + '0'); n /= 10;} std::reverse(res.begin(), res.end()); return '-' + res;}
  while(n != 0){res += (char)(n % 10 + '0'); n /= 10;} std::reverse(res.begin(), res.end()); return res;
}

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

int find_idx(Vint &A, int k){
  // A(i) = k?? i ?????????
  int lb = -1, ub = A.size() - 1;
  while(ub - lb > 1){
    int m = (lb + ub) / 2;
    if(A.at(m) > k) ub = m;
    else if(A.at(m) < k) lb = m;
    else return m;
  }
  return ub;
}

int main(void){
  cin.tie(NULL);
  ios::sync_with_stdio(false);
  int n; cin >> n;
  Vint A(n), sorted_A(n);
  REP(i, n){
    cin >> A.at(i);
    sorted_A.at(i) = A.at(i);
  }
  SORT(sorted_A);
  int cnt = 0;
  REP(i, n){
    int idx = find_idx(sorted_A, A.at(i));
    if( ((idx - i) & 1) != 0) cnt++;
  }
  cout << cnt / 2 << BR;
  return 0;
}