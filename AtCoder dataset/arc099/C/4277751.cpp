#include <algorithm>
#include <cassert>
#include <cctype>
#include <climits>
#include <cmath>
#include <complex>
#include <cstdio>
#include <cstring>
#include <deque>
#include <functional>
#include <iomanip>
#include <iostream>
#include <map>
#include <numeric>
#include <queue>
#include <random>
#include <set>
#include <stack>
#include <string>
#include <tuple>
#include <unordered_map>
#include <vector>
#include <bitset>
#define rep(i, n) for (int i = 0; i < (int)(n); ++i)
#define show(x) cout << #x << " = " << (x) << endl;
using namespace std;
using ll = long long;
using pii = pair<int,int>;
bool a[705][705];
vector<int>g[705];
bool dp[705][705];
void dfs(int s, int &a,int &b,vector<int>&dist){
    if(dist[s]%2)a++;
    else b++;
    for(int x:g[s]){
        if(dist[x] == -1){
            dist[x] = dist[s] + 1;
            dfs(x,a,b,dist);
        }else{
            if(dist[x]%2==dist[s]%2){
                cout << -1 << endl;
                exit(0);
            }
        }
    }
}
int main(){
    int n,m;
    cin >> n >> m;
    rep(i,m){
        int c,d;
        cin >> c >> d;
        c--,d--;
        a[c][d] = true;
        a[d][c] = true;
    }
    rep(i,n)a[i][i] = true;
    rep(i,n)rep(j,n)if(!a[i][j])g[i].push_back(j);
    vector<pii>vec;
    vector<int>dist(n,-1);
    rep(i,n){
        if(dist[i] == -1){
            dist[i] = 0;
            int a,b;
            a = b = 0;
            dfs(i,a,b,dist);
            vec.emplace_back(a,b);
        }
    }
    dp[0][0] = true;
    rep(i,vec.size()){
        rep(j,n+1){
            if(dp[i][j]){
                dp[i+1][j+vec[i].first] = true;
                dp[i+1][j+vec[i].second] = true;
            }
        }
    }
//    set<int>st;
//    set<int>st2;
//    rep(i,vec.size()){
//        auto x = vec[i];
//        if(i==0){
//            if(x.first)st2.insert(x.first);
//            if(x.second)st2.insert(x.second);
//        }else{
//            for(int y:st){
//                st2.insert(y + x.first);
//                st2.insert(y + x.second);
//            }
//        }
//        swap(st,st2);
//    }
    int ans = INT_MAX;
    rep(x,n+1)if(dp[vec.size()][x]){
        ans = min(ans, x*(x-1)/2 + (n-x)*(n-x-1)/2);
    }
    cout << ans << endl;
}