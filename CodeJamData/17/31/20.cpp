
#include <bits/stdc++.h>

#define FOR(i,b,e) for(int i=(b); i <= (e); ++i)
#define FORD(i,b,e) for(int i=(b); i >= (e); --i)
#define SIZE(c) (int) (c).size()
#define FORE(i,c) FOR(i,0,SIZE(c)-1)
#define FORDE(i,c) FORD(i,SIZE(c)-1,0)

#define pb push_back
#define mp make_pair
#define st first
#define nd second


using namespace std;

typedef long long ll;
typedef pair <int,int> pii;
typedef pair <ll,ll> pll;

typedef vector <int> VI;
typedef vector <bool> VB;
typedef vector <pii> VP;
typedef vector <ll> VL;
typedef vector <pll> VPL;

typedef vector <VI> VVI;
typedef vector <VL> VVL;
typedef vector <VB> VVB;
typedef vector <VP> VVP;

const int MOD = 1000000007;
const int INF = 1000000001;
const ll LINF = 1000000000000000001LL;

/*************************************************************************/

struct cake {
    double r, h, circArea, sideArea;
};

double solve() {
    int n, k;
    cin >> n >> k;
    
    vector <cake> cakes(n);
    FOR(i,0,n-1) {
        cin >> cakes[i].r >> cakes[i].h;
        
        cakes[i].circArea = M_PI * cakes[i].r * cakes[i].r;
        cakes[i].sideArea = 2.0 * M_PI * cakes[i].r * cakes[i].h;
    }
    
    sort(cakes.begin(), cakes.end(), [](const cake &a, const cake &b) {
        return a.r < b.r;
    });
    
    double dp[n+1][k+1], dpTake[n+1][k+1];
    FOR(i,0,n) FOR(j,0,k) {
        dp[i][j] = dpTake[i][j] = 0.0;
    }
    
    FOR(i,1,n) FOR(j,0,k) {
        if (j) {
            dpTake[i][j] = dp[i-1][j-1] + cakes[i-1].sideArea;
        }
        
        dp[i][j] = max(dp[i-1][j], dpTake[i][j]);
    }
    
    double ans = 0.0;
    FOR(i,1,n) {
        ans = max(ans, dpTake[i][k] + cakes[i-1].circArea);
    }
    
    return ans;
}

/*************************************************************************/

int main() {
    ios_base::sync_with_stdio(0);
    cout << setprecision(9) << fixed;
    
    int t;
    cin >> t;
    
    FOR(i,1,t) {
        cout << "Case #" << i << ": " << solve() << '\n';
    }

    return 0;
}

/*************************************************************************/

