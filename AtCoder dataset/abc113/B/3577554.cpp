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
//????
#include <map>
//??
#include <cmath>
//????
#include <cassert>
//?????
#include <tuple>

//????????
#define ??() main()
#define ?? return
#define ??(?) cin >> ?
#define ??(?) cout << ? << endl

//??
#define ??(??) if(??)
#define ??(??) else if(??)
#define ?? else

//??
#define ??(??,?,?) for(?? ?? = ?;?? <= ?;?? += 1)
#define ??(??,?,?) for(?? ?? = ?;?? >= ?;?? -= 1)
#define ???(??) while(??)
#define ?? break
#define ?? continue

//????
#define ??(??) (??).begin()+1
#define ??(??) (??).end()
#define ??(??) (??).begin(), (??).end()
#define ??(?,?) sort(?,?)
#define ??(?,?) reverse(?,?)
#define ??(??,?,?) ??.erase(?,?)
#define ??(?,?) unique(?,?)
#define ??(??,?) ??.resize(?)
#define ??(?,?,?) fill(?,?,?)
#define ???(??) for_each(??(??), [](?? ?) {??(?);});
#define ??(????,????,????,????,???) merge(????,????,????,????,???)

//??
#define ??(??,?) ??.push_back(?)
#define ??(??,?) ??.push(?)
#define ??(??) ??.pop()
#define ??(?,?) make_pair(?,?)
#define ??(?,?) swap(?,?)
#define ??(??,?) ??.insert(?)
#define ??(??,?) ??.erase(?)
#define ????(?,?,?) make_tuple(?,?,?)

//??
#define ??(??) ??.top()
#define ??(??) ??.front()
#define ???(??) ??.empty()
#define ??(??) ??.size()
#define ??(??) ??.length()
#define ?(??) ??.first
#define ?(??) ??.second
#define ?????(??,?,?) ??.substr(?,?)
#define ??(??,?) ??.find(?)
#define ??(?,?,?) find(?,?,?)
#define ??(??,??) ??.at(??)
#define ??(??,????) get<??-1>(????)

//???
#define ? true
#define ? false
#define ?? const
#define ???(?) abs(?)
#define ??(?) floor(?)
#define ??(?) ceil(?)
#define ?(a) sqrt(a)
#define ??(??) sin(??)
#define ??(??) cos(??)
#define ?(?,?) (?+?)
#define ?(?,?) (?-?)
#define ?(?,?) (?*?)
#define ?(?,?) (?/?)
#define ?(?,?) (?%?)
#define ? -
#define ? &&
#define ? ||
#define ? =
#define ??? ==
#define ? !
#define ?? !=
#define ?? >
#define ?? <
#define ??? >=
#define ??? <=
#define ??(??,?) (??<<?)
#define ??(??,?) (??>>?)
#define ????(??) (?? & -??)

//?????
#define ? &
#define ? |
#define ? ~
#define ? ^

//???
#define ???(??) decltype(??)::iterator
#define ??(?,?,???) lower_bound(?,?,???)
#define ???(?,?,???) upper_bound(?,?,???)
#define ???(?,?,???) max_element(?,?,???)
#define ???(?,?,???) min_element(?,?,???)

//?
#define ??? struct
#define ?? operator
#define ?? auto
#define ??(??) assert(??)

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
typedef greater<??> ????;
typedef priority_queue<??,????,???> ???????;
typedef priority_queue<??,????,????> ????????;
typedef set<??> ??????;
typedef map<??,??> ???;
typedef map<??,???> ?????;

??? ???{?? ??,??,??;};
typedef vector<???> ?????;

//?? ?? ???[5] ? {0,1,0,-1,0};
//?? ?? ???[5] ? {0,0,1,0,-1};

?? ??(?? ?, ?? ?){?? max(?,?);}
?? ??(?? ?, ?? ?){?? min(?,?);}
?? ??(?? ?, ?? ?){?? max(?,?);}
?? ??(?? ?, ?? ?){?? min(?,?);}
?? ??(?? ?, ?? ?){?? max(?,?);}
?? ??(?? ?, ?? ?){?? min(?,?);}

?? ?? ?? = (2e9) + 10;
//?? ?? ? = 1000000007;
//?? ?? ?? = 1e-9;
//?? ?? ?? = acos(-1.0);
?? ?? ? = 100;
?? ?? ? = 1000;
//?? ?? ? = 10000;
//?? ?? ? = 100000000;
?? ?? ??????? = ?+?;
?? ?????, ??, ????;
???? ??(???????);

 
? ????()
{
    ??(?????);
    ??(??);
    ??(????);
    ??(???,1,?????)
    {
        ??(??[???]);
    }
}

?? ????(?? ??,?? ??)
{
    ?? ?? - ?(??,0.006);
}
 
? ?????()
{
    ?? ????? = ??;
    ?? ????;
    ??(???,1,?????)
    {
        ??(  ???( ????(??,??[???])-???? ) < ?????  )
        {
            ????? = ???( ????(??,??[???])-???? );
            ???? = ???;
        }
    }
    
    ??(????);
}

? ??()
{
	????();
    ?????();
	?? 0;
}