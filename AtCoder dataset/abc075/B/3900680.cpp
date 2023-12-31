#include <iostream>
#include <fstream>
#include <stdio.h>
#include <math.h>
#include <time.h>
#include <string>
#include <tuple>
#include <vector>
#include <map>
#include <unordered_map>
#include <list>
#include <set>
#include <stack>
#include <queue>
#include <cstdlib>
#include <algorithm>
#include <random>
#include <cassert>
using namespace std;
#define LL long long
#define MP(a, b) make_pair(a, b)
#define MMP(a, b, c) make_pair(make_pair(a, b), c)
#define MAX 1000000000
#undef INT_MIN
#undef INT_MAX
#define INT_MIN -2147483647
#define INT_MAX 2147483647
#define LL_MIN (LL)-9223372036854775807
#define LL_MAX (LL)9223372036854775807
#define PI 3.14159265359

int main(){
    iostream::sync_with_stdio(false);
    
    int H,W;
    cin >> H >> W;
    string S[50];
    for(int i=0; i<H; i++) cin >> S[i];
    for(int i=0; i<H; i++){
        for(int j=0; j<W; j++){
            if(S[i][j] == '#') continue;
            int tmp = 0;
            if(i-1>=0 && S[i-1][j]=='#') tmp++;
            if(i-1>=0 && j-1>=0 && S[i-1][j-1]=='#') tmp++;
            if(i-1>=0 && j+1<W && S[i-1][j+1]=='#') tmp++;
            if(j-1>=0 && S[i][j-1]=='#') tmp++;
            if(j+1<W && S[i][j+1]=='#') tmp++;
            if(i+1<H && S[i+1][j]=='#') tmp++;
            if(i+1<H && j-1>=0 && S[i+1][j-1]=='#') tmp++;
            if(i+1<H && j+1<W && S[i+1][j+1]=='#') tmp++;
            S[i][j] = '0' + tmp;
        }
    }
    for(int i=0; i<H; i++) cout << S[i] << endl;
    
    return 0;
}