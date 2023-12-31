/*
???  ??????
?? ?�????)?????/???????????????????
?? ??y:::::???? [?]??????????????????????????????????
?? |:?:|:::::|???|??|
?????????????????|?????????????????
???????????????|??  ??????????????????????????????
???????????????|
???????????????.?|????????????????????????????????
????????????? ??  |??????????????????????????
??????????|???  |?????????????????????????????????
?????????????? |????????????????????
???(??)?(??)?(??)??|
?    ||?? ||??||??|??? ????????????
??.?|???|? ?|?
*/

#include <iostream>
#include <cstdlib>
#include <algorithm>
#include <array>
#include <bitset>
#include <climits>
#include <cmath>
#include <list>
#include <map>
#include <numeric>
#include <queue>
#include <set>
#include <string>
#include <vector>
using namespace std;
#define fst first
#define snd second
#define ALL(obj) (obj).begin(),(obj).end()
#define debug(x) cerr << #x << " -> " << x << " (line:" << __LINE__ << ")" << '\n';
#define debugpair(x, y) cerr << "(" << #x << ", " << #y << ") -> (" << x << ", " << y << ") (line:" << __LINE__ << ")" << '\n';
typedef long long lint;
typedef priority_queue<int> p_que;
typedef priority_queue<int, vector<int>, greater<int>()> p_que_rev;
const int INF = INT_MAX;
const lint LINF = LLONG_MAX;
const int MOD = 1000000000 + 7;
const double EPS = 1e-9;
const double PI = acos(-1);
const int di[]{0, -1, 0, 1, -1, -1, 1, 1};
const int dj[]{1, 0, -1, 0, 1, -1, -1, 1};

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(false);
    string s;
    cin >> s;
    int len = s.length();
    const string ABC = "ABC";
    lint dp[len+1][4];
    for (int i=0; i<=len; ++i){
        for (int j=0; j<=3; ++j){
            dp[i][j] = 0;
        }
    }
    dp[0][0] = 1;
    int p, q;
    for (int i=0; i<=len; ++i){
        for (int j=0; j<=3; ++j){
            if(i == 0 && j == 0){
                continue;
            }
            else if(i == 0){
                dp[i][j] = 0;
            }
            else if(j == 0){
                if(s[i-1] == '?'){
                    q = 3;
                }
                else {
                    q = 1;
                }
                dp[i][j] = (q * dp[i-1][j]) % MOD;
            }
            else {
                if(s[i-1] == '?'){
                    q = 3;
                }
                else {
                    q = 1;
                }
                if(s[i-1] == ABC[j-1] || s[i-1] == '?'){
                    p = 1;
                }
                else {
                    p = 0;
                }
                dp[i][j] = (p * dp[i-1][j-1]) % MOD + (q * dp[i-1][j]) % MOD;
                dp[i][j] = dp[i][j] % MOD;
            }
        }
    }
    cout << dp[len][3] << endl;
    return 0;
}