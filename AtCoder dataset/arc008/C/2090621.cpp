#define _USE_MATH_DEFINES
#include<iostream>
#include<string>
#include<cmath>
#include<queue>
#include<map>
#include<set>
#include<list>
#include<iomanip>
#include<vector>
#include<random>
#include<functional>
#include<algorithm>
#include<cstdio>
#include<unordered_map>
using namespace std;
//---------------------------------------------------
//????????????
typedef long long ll;
typedef long double ld;
#define str string
#define rep(i,j) for(ll i=0;i<(long long)(j);i++)
const ll Mod = 1000000007;
const ll gosenchou = 5000000000000000;
short gh[2][4] = { { 0,0,-1,1 },{ -1,1,0,0 } };
struct P {
	ll pos;
	ld cost;
};
bool operator<(P a, P b) { return a.cost < b.cost; }
bool operator>(P a, P b) { return a.cost > b.cost; }
struct B {//???????
	ll to;
	ld cost;
};
struct E {//??????????
	ll from, to, cost;
};
bool operator<(E a, E b) {
	return a.cost < b.cost;
}
struct H {
	ld x, y;
};
bool operator<(H a, H b) {
	if (a.x != b.x) return a.x < b.x;
	return a.y < b.y;
}
bool operator>(H a, H b) {
	if (a.x != b.x) return a.x > b.x;
	return a.y > b.y;
}
bool operator==(H a, H b) {
	return a.x == b.x&&a.y == b.y;
}
bool operator!=(H a, H b) {
	return a.x != b.x || a.y != b.y;
}
ll gcm(ll i, ll j) {//?????
	if (i > j) swap(i, j);
	if (i == 0) return j;
	return gcm(j%i, i);
}
ld rad(H a, H b) {
	return sqrt(pow(a.x - b.x, 2.0) + pow(a.y - b.y, 2.0));
}//rad?????2?????
ll ari(ll a, ll b, ll c) {
	return (a + b)*c / 2;
}//??????
bool suf(ld a, ld b, ld c, ld d) {
	if (b <= c || d <= a) return 0;
	return 1;
}//[a,b),[c,d)
ll fact(ll i, ll z) {
	ll sum = 1;
	for (ll j = max(z, 2LL); j <= i; j++)
		sum = (sum* j) % Mod;
	return sum;
}//??(??
ll mod_pow(ll x, ll n, ll p) {
	ll res = 1;
	while (n > 0) {
		if (n & 1) res = res*x%Mod;
		x = x*x%p;
		n >>= 1;
	}
	return res;
}
#define int long long
const long long inf = 4523372036854775807;
const int iinf = 1500000000;
//----------------------------------------------------
//++++++++++++++++++++++++++++++++++++++++++++++++++++
int n;
H a[1000];
int t[1000], r[1000];
vector<B>e[1000];
ld b[1000];
signed main() {
	cin >> n;
	for (int i = 0; i < n; i++) {
		cin >> a[i].x >> a[i].y >> t[i] >> r[i];
		b[i] = inf;
	}
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			if (i != j) {
				e[i].push_back(B{ j,rad(a[i],a[j]) / min(t[i],r[j]) });
			}
		}
	}
	priority_queue<P, vector<P>, greater<P>>p;
	b[0] = 0;
	p.push(P{ 0,0 });
	while (!p.empty()) {
		P t = p.top(); p.pop();
		for (int i = 0; i < e[t.pos].size(); i++) {
			B y = e[t.pos][i];
			if (b[y.to] > b[t.pos] + y.cost) {
				b[y.to] = b[t.pos] + y.cost;
				p.push(P{ y.to,b[y.to] });
			}
		}
	}
	sort(b, b + n);
	ld ans = 0;
	for (int i = n - 1; i > 0; i--) {
		ans = max(ans, b[i] + abs(i - n + 1));
	}
	printf("%.15LF\n", ans);
	getchar(); getchar();
}