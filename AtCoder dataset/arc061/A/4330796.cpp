//??????????????????????????
#include <algorithm>
#define ?(?, ?, ?) fill(?, ?, ?)
//#define ?(?, ?, ?) find(?, ?, ?)
#define ?(??) for_each(?(??), [](? ?) { ?(?) << " "; })
#define ??(?, ?, ??) lower_bound(?, ?, ??)
#define ??(?, ?) max_element(?, ?)
//#define ?(??, ??, ??, ??) merge(??, ??, ??, ??, back_inserter(?))
#define ??(?, ?) min_element(?, ?)
#define ?(?, ?) reverse(?, ?)
#define ?(?, ?) sort(?, ?)
#define ??(?, ?) sort(?, ?, greater<?>())
#define ?(?, ?) unique(?, ?)
#define ??(?, ?, ??) upper_bound(?, ?, ??)

//??,???????????????
#include <cmath>
#define ??(?) abs(?)
#define ??(?) floor(?)
#define ??(?) ceil(?)
#define ?(?) sqrt(?)
#define ??(??) sin(??)
#define ??(??) cos(??)

//??????
#include <iostream>
#define ??(?) cin >> ?
#define ??(?) cout << ?

//???
#include <iterator>
#define ?(???) (???).begin()
#define ?(???) (???).end()

//??,??????????????????????????
#include <map>
#define ?(?) count(?);

//??,????????????????????
#include <queue>
#define ?(??) ??.pop()
#define ?(??, ?) ??.push(?)
#define ?(??) ??.front()

//?,???????????
#include <stack>
#define ?(??) ??.top()

//?,????????,???
#include <set>
//#define ?(?, ?) ?.find(?)

//???????????????
#include <string>
#define ?(??) ??.length()
#define ??(??, ?, ?) ??.substr(?, ?)

//??,????????????????????????
#include <utility>
#define ?(?, ?) make_pair(?, ?)
#define ?(?, ?) swap(?, ?)

//??,????????
#include <vector>
#define ?(??) (??).clear()
#define ?(??) ??.empty()
#define ?(??, ?) ??.erase(?)
#define ?(??, ?) ??.insert(?)
#define ?(??, ?) ??.push_back(?)
#define ??(??, ?) ??.resize(?)

//??
#define ?(??) if (??)
#define ??(??) else if (??)
#define ? else

//??
#define ?(??, ?, ?) for (? ?? ? ?; ?? <= ?; ?? ? ?? + 1)
#define ??(??, ?, ?) for (? ?? ? ?; ?? >= ?; ?? ? ?? - 1)
#define ?(??) while (??)
#define ? break
#define ? continue

//??
#define ?() main()
#define ? return

//???
#define ? =
#define ? ==
#define ? &&
#define ? ||
#define ? &
#define ? <<
#define ?? >>

#define ? struct
#define ? const
#define ? true
#define ? false
#define ?? endl

//???
using namespace std;

//????
typedef int ??;
typedef void ?;
typedef long long ?;
typedef vector<?> ??;
typedef vector<??> ???;
typedef vector<???> ????;
typedef double ?;
typedef vector<?> ??;
typedef vector<??> ???;
typedef char ?;
typedef vector<?> ??;
typedef vector<??> ???;
typedef string ??;
typedef vector<??> ???;
typedef pair<?, ?> ??;
typedef vector<??> ???;
typedef pair<?, ?> ??;
typedef vector<??> ???;
typedef vector<???> ????;
typedef pair<?, ?> ???;
typedef vector<???> ????;
typedef bool ?;
typedef vector<?> ??;
typedef vector<??> ???;
typedef stack<?> ??;
typedef queue<?> ??;
typedef queue<??> ???;
typedef priority_queue<?> ??;
typedef set<?> ??;
typedef map<?, ?> ??;
typedef map<?, ??> ??;

? ? { ? ?, ?; };
typedef vector<?> ?;

? ??(? ?, ? ?) { ? max(?, ?); }
? ??(? ?, ? ?) { ? min(?, ?); }

//? ? ?? = (2e9) + 10;
//? ? ? = 1000000007;
//? ? ?? = 1e-9;
//? ? ?? = acos(-1.0);
//? ? ? = 100;
//? ? ? = 1000;
//? ? ? = 10000;
//? ? ? = 100000000;
//? ? ???[5] = {0,1,0,-1,0};
//? ? ???[5] = {0,0,1,0,-1};
?? s;

? ????()
{
    ??(s);
}

? ??()
{
    ? ? ? 0;
    for (int ?? = 0; ?? < (1 << (s.size() - 1)); ??++)
    {
        ? num ? s[0] - '0';
        for (int ? = 0; ? < ?(s) - 1; ?++)
        {
            if (?? & (1 << ?))
            {
                ? ? ? + num;
                num ? 0;
            }
            num ? num * 10 + s[? + 1] - '0';
        }
        ? ? ? + num;
    }
    ? ?;
}

?? ?()
{
    ????();
    ??(??()) << ??;
    ? 0;
}