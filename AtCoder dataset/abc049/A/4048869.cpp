#include <iostream>
using namespace std;

using uint = unsigned int;
using ll = long long;
using ull = unsigned long long;
#include <string>
#include <cstdio>
#include <algorithm>
#include <vector>
#include <cmath>
#include <climits>
#include <bitset>
#include <array>
#include <deque>
#include <queue>
#include <map>
#define all(x) (x).begin(),(x).end()

const int MOD = 1e9 + 7;

void solve(){

}
int main(){
    char c;
    cin >> c;
    string ans;
    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'){
        ans = "vowel";
    } else {
        ans = "consonant";
    }
    cout << ans << endl;


    return 0;
}