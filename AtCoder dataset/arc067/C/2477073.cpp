//????????????????????????????????????????????????????????
//??????????????????????????????????????
//?????????????????n, ?????????m??????????????O(N^2)?DP?????
//?????m??????0 or C?D?????
#include <iostream>
#define int long long
#define rep(i, n) for (i = 0; i < n; i++)
using namespace std;

int powmod(int a, int n, int mod) {
	if (n == 0) return 1;
	if (n & 1) return (a * powmod(a, n - 1, mod)) % mod;
	return powmod((a * a) % mod, n / 2, mod);
}

int mod = 1000000007;
int comb[1001][1001];
int fact[1001];
int factInv[1001];
int powFactInv[1001][1001];

void init() {
	int i, j;
	comb[0][0] = 1;
	for (i = 1; i < 1001; i++) {
		for (j = 0; j < 1001; j++) {
			if (j == 0) comb[i][j] = 1;
			else comb[i][j] = (comb[i - 1][j - 1] + comb[i - 1][j]) % mod;
		}
	}
	
	fact[0] = 1;
	factInv[0] = 1;
	for (i = 1; i < 1001; i++) {
		fact[i] = (fact[i - 1] * i) % mod;
		factInv[i] = powmod(fact[i], mod - 2, mod);
	}
	for (i = 0; i < 1001; i++) {
		for (j = 0; j < 1001; j++) {
			powFactInv[i][j] = powmod(factInv[i], j, mod);
		}
	}
}

int n, a, b, c, d;
int dp[1001][1001];	//dp[i][j] = ??n??, ??????????m???, ?????????

int dfs(int n, int m) {
	if (n == 0){ return 1; }
	if (m > b) { return 0; }
	if (dp[n][m] != -1) return dp[n][m];
	
	int ret = dfs(n, m + 1);
	for (int x = c; x <= d; x++) {
		if (n < m * x) break;
		//n??????m??????x???
		int way = fact[n] * factInv[n - m * x] % mod * powFactInv[m][x] % mod * factInv[x] % mod;
		int res = dfs(n - m * x, m + 1);
		ret += way * res;
		ret %= mod;
	}
	return dp[n][m] = ret;
}

signed main() {
	int i, j, k, l;
	
	init();
	rep(i, 1001) rep(j, 1001) dp[i][j] = -1;
	
	cin >> n >> a >> b >> c >> d;
	cout << dfs(n, a) << endl;
	return 0;
}