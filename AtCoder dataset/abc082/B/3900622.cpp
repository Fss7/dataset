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
    
    string S,T;
    cin >> S >> T;
    sort(S.begin(), S.end());
    sort(T.begin(), T.end());
    reverse(T.begin(), T.end());
    if(S < T) cout << "Yes" << endl;
    else cout << "No" << endl;
    
    return 0;
}


/*

int main(){
    iostream::sync_with_stdio(false);
    
    
    
    return 0;
}
*/

/*

int main(){
    iostream::sync_with_stdio(false);
    
    
    
    return 0;
}
*/