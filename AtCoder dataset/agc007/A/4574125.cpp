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
#include <cstdio>
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
    int h, w;
    string ans = "Possible";
    cin >> h >> w;
    vector<string> a(h);
    for (int i=0; i<h; ++i){
        cin >> a[i];
    }
    int nh, nw;
    nh = 0;
    nw = 0;
    while(!(nh == h-1 && nw == w-1)){
        a[nh][nw] = '.';
        if(nh + 1 < h && a[nh + 1][nw] == '#'){
            nh++;
            continue;
        }
        else if(nw + 1 < w && a[nh][nw + 1] == '#'){
            nw++;
            continue;
        }
        else {
            break;
        }
    }
    a[nh][nw] = '.';
    for (int i=0; i<h; ++i){
        for (int j=0; j<w; ++j){
            if(a[i][j] == '#'){
                ans = "Impossible";
                break;
            }
        }
    }
    cout << ans << "\n";
    return 0;
}