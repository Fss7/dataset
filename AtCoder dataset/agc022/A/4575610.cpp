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
    string s, ans;
    const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    cin >> s;
    if(s.length() == 26){
        if(s == "zyxwvutsrqponmlkjihgfedcba"){
            ans = "-1";
        }
        else {
            int d;
            vector<char> l(26);
            for (int i=0; i<26; ++i){
                l[i] = s[i];
            }
            next_permutation(ALL(l));
            for (int i=0; i<26; ++i){
                ans = ans + l[i];
                if(l[i] != s[i]){
                    break;
                }
            }
        }
    }
    else {
        set<int> letter;
        for (int i=0; i<(int)s.length(); ++i){
            letter.insert(s[i]);
        }
        ans = s;
        for (int i=0; i<26; ++i){
            if(letter.count(alphabet[i]) == 0){
                ans = ans + alphabet[i];
                break;
            }
        }
    }
    cout << ans << "\n";
    return 0;
}