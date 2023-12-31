#include <algorithm>
#include <cmath>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <iomanip>
#include <iostream>
#include <map>
#include <queue>
#include <set>
#include <sstream>
#include <string>
#include <vector>

using namespace std;

#define bublic public
#define clr(x) memset((x), 0, sizeof(x))
#define all(x) (x).begin(), (x).end()
#define pb push_back
#define mp make_pair
#define sz size()
#define For(i, st, en) for(__typeof(en) i=(st); i<=(en); i++)
#define Ford(i, st, en) for(int i=(st); i>=(int)(en); i--)
#define forn(i, n) for(__typeof(n) i=0; i<(n); i++)
#define ford(i, n) for(int i=(n)-1; i>=0; i--)
#define fori(it, x) for (__typeof((x).begin()) it = (x).begin(); it != (x).end(); it++)

template <class _T> inline _T sqr(const _T& x) { return x * x; }
template <class _T> inline string tostr(const _T& a) { ostringstream os(""); os << a; return os.str(); }
template <class _T> inline istream& operator << (istream& is, const _T& a) { is.putback(a); return is; }

typedef long double ld;

// Constants
const ld PI = 3.1415926535897932384626433832795;
const ld EPS = 1e-11;

// Types
typedef signed   long long i64;
typedef unsigned long long u64;
typedef set < int > SI;
typedef vector < ld > VD;
typedef vector < int > VI;
typedef vector < bool > VB;
typedef vector < string > VS;
typedef map < string, int > MSI;
typedef pair < int, int > PII;

int qq, n, k;
bool a[128][128];
int pa[128];
bool u[128];
int b[1024][1024];

bool find(int k)
{
	u[k] = true;
	forn(i, n)
	{
		if (a[k][i] && (pa[i] == -1 || !u[pa[i]] && find(pa[i])))
		{
			pa[i] = k;
			return true;
		}
	}

	return false;
}

int main()
{
#ifdef ROOM_311
	freopen("input.txt", "rt", stdin);
	freopen("output.txt", "wt", stdout);
#endif
	cout << setiosflags(ios::fixed) << setprecision(10);

	scanf("%d", &qq);
	forn(ii, qq)
	{
		scanf("%d%d", &n, &k);
		forn(i, n)
		{
			forn(j, k)
			{
				scanf("%d", &b[i][j]);
			}
		}

		clr(a);
		forn(i, n)
		{
			forn(j, n)
			{
				bool bb = true;
				forn(l, k)
				{
					if (b[i][l] >= b[j][l]) bb = false;
				}
				a[i][j] = a[i][j] || bb;
			}
		}

		int ans = n;
		memset(pa, 0xff, sizeof(pa));
		forn(i, n)
		{
			clr(u);
			ans -= find(i);
		}

		printf("Case #%d: %d\n", ii+1, ans);
	}

	return 0;
}
