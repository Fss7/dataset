//?????????????????
//#include "bits/stdc++.h"
//??????
#include <iostream>
//???
#include <string>
//??
#include <vector>
//????
#include <algorithm>
//????
#include <stack>
//????
#include <queue>
//?????
#include <set>
//?????
#include <map>
//??
#include <cmath>
//????
#include <cassert>


//????????
#define ??() main()
#define ?? return
#define ??(a) cin >> a
#define ??(a) cout << a << endl

//??
#define ??(a) if(a)
#define ??(a) else if(a)
#define ?? else

//??
#define ??(s,t) for(?? s = 0; s < ??(t); s += 1)
#define ??(s,t) for(?? s = ??(t) - 1; s >= 0; s -= 1)
#define ??(s,t,u) for(?? s = t; s < ??(u); s += 1)
#define ??(s,t,u) for(?? s = ??(u) - 1; s >= t; s -= 1)
#define ??(a) while(a)
#define ?? break
#define ?? continue

//????
#define ??(h) (h).begin()
#define ??(h) (h).end()
#define ??(h) (h).begin(), (h).end()
#define ??(a,b) sort(a,b)
#define ??(a,b) reverse(a,b)
#define ??(h,a,b) h.erase(a,b)
#define ??(a,b) unique(a,b)
#define ??(a,b,c) lower_bound(a,b,c)
#define ???(a,b,c) upper_bound(a,b,c)
#define ??(h,s) h.resize(s)
#define ??(a,b,c) fill(a,b,c)
#define ???(h) for_each(??(h), [](?? s) {??(s);});

//??
#define ??(a,b) a.push_back(b)
#define ??(a,b) a.push(b)
#define ??(a) a.pop()
#define ??(a,b) make_pair(a,b)
#define ??(a,b) swap(a,b)
#define ??(a,b) a.insert(b)
#define ??(a,b) a.erase(b)

//??
#define ??(a) a.top()
#define ??(a) a.front()
#define ?(a) a.empty()
#define ??(a) a.size()
#define ??(a) a.length()
#define ?(a) a.first
#define ?(a) a.second
#define ?????(m,s,t) m.substr(s,t)
#define ??(a,b) a.find(b)
#define ??(a,b,c) find(a,b,c)
#define ??(a,b) a.at(b)

//???
#define ? true
#define ? false
#define ?? const
#define ???(a) abs(a)
#define ??(a) floor(a)
#define ??(a) ceil(a)
#define ?(a) sqrt(a)
#define ? +
#define ? -
#define ? *
#define ? /
#define ? %
#define ? &&
#define ? &
#define ? ||
#define ? |
#define ? =
#define ??? ==
#define ?? !=
#define ?? >
#define ?? <
#define ??? >=
#define ??? <=
#define ?? <<
#define ?? >>
//#define ? !

//?
#define ??? struct
#define ?? operator
#define ?? auto
#define ??(a) assert(a)
#define ??? iterator

//std?????
using namespace std;

//???????
typedef int ?;
typedef void ?;
typedef long long ??;
typedef vector<??> ????;
typedef vector<????> ???????;
typedef vector<???????> ???????;
typedef long double ??;
typedef vector<long double> ????;
typedef vector<????> ???????;
typedef char ??;
typedef vector<??> ????;
typedef vector<????> ???????;
typedef string ???;
typedef vector<???> ?????;
typedef pair<??,??> ??;
typedef vector<??> ????;
typedef pair<??,??> ??;
typedef vector<??> ????;
typedef vector<????> ???????;
typedef bool ??;
typedef vector<??> ????;
typedef vector<????> ???????;
typedef stack<??> ??;
typedef queue<??> ??;
typedef queue<??> ???;
typedef priority_queue<??> ??????;
typedef greater<??> ???;
typedef priority_queue<??,????,???> ???????;
typedef set<??> ??????;
typedef map<??,??> ???;
typedef map<??,?? ???> ?????;

//?? ?? ???[4] ? {1,0,-1,0};
//?? ?? ???[4] ? {0,1,0,-1};

?? ??(?? ?, ?? ?){?? max(?,?);}
?? ??(?? ?, ?? ?){?? min(?,?);}

//?? ?? ?? = (2e9) + 10;
//?? ?? ? = 1000000007;
//?? ?? ?? = 1e-9;

?? ??,??;
??? ????,????;

?? ?????(?? ?,?? ?)
{
    ??(? ??? 0) ?? ?;
    ?? ?????(?, ? ? ?);
}

? ????()
{
    ??(??);
    ??(??);
    ??(????);
    ??(????);
}

?? ?????()
{
    ?? ??? = ?????(??,??);
    ??(?,???)
    {
        ??(????[??/??? ? ?] ?? ????[??/??? ? ?])
        {
            ?? -1;
        }
    }
    ?? ?? ? ?? ? ???;
}
            

? ??()
{
	????();
    ??(?????());
	?? 0;
}