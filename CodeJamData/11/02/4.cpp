//#include<iostream>
#include<cstdio>
#include<cctype>
#include<cmath>
#include<cstdlib>
#include<algorithm>
#include<vector>
#include<string>
#include<list>
#include<deque>
#include<map>
#include<set>
#include<queue>
#include<stack>
#include<utility>
#include<sstream>
#include<cstring>
#include<numeric>
using namespace std;

#define FOR(I,A,B) for(int I=(A);I<=(B);I++)
#define FORD(I,A,B) for(int I=(A);I>=(B);I--)
#define REP(I,N) for(int I=0;I<(N);I++)
#define ALL(X) (X).begin(),(X).end()
#define PB push_back
#define MP make_pair
#define FI first
#define SE second
#define INFTY 100000000
#define VAR(V,init) __typeof(init) V=(init)
#define FORE(I,C) for(VAR(I,(C).begin());I!=(C).end();I++)
#define SIZE(x) ((int)(x).size())

typedef vector<int> VI;
typedef pair<int,int> PII;
typedef long long ll;
typedef vector<string> VS;

ll nwd(ll a,ll b) { return !b?a:nwd(b,a%b); }
inline int CEIL(int a,int b) { return a%b ? a/b+1 : a/b; }
template <class T> inline T sqr(const T&a) { return a*a; }

VS parse(string s)
{
  string a;
  VS wyn;
  REP(i,(int)s.size())
    if (s[i]!=' ') a+=s[i];
    else if (!a.empty()) { wyn.PB(a); a=""; }
  if (!a.empty()) wyn.PB(a);
  return wyn;
}

int toi(char ch) { return int(ch)-int('0'); }

int chg(char ch) { return int(ch)-int('a'); }

int los(int m)
{
  return (int)((double)m*(rand()/(RAND_MAX+1.0)));
}

void wypisz(PII p)
{
  printf("(%d %d)\n",p.FI,p.SE);
}
void wypisz(VI t)
{
  REP(i,SIZE(t)) printf("%d ",t[i]); puts("");
}
void wypisz(vector<PII> t)
{
  REP(i,SIZE(t)) printf("(%d %d) ",t[i].FI,t[i].SE); puts("");
}
void wypisz(VS t)
{
  REP(i,SIZE(t)) printf("%s\n",t[i].c_str());
}
void wypisz(vector<VI> t)
{
  REP(i,SIZE(t)) wypisz(t[i]);
}


int ILE;
int c,d,n;
char t[300][300];
bool t1[300][300];
char st[200];

int main()
{
  scanf("%d",&ILE);
  FOR(iii,1,ILE)
  {
    printf("Case #%d: ",iii);
    fprintf(stderr,"Case #%d: \n",iii);
    memset(t,0,sizeof(t));
    memset(t1,0,sizeof(t1));
    scanf("%d",&c);
    REP(i,c)
    {
      scanf("%s",st);
      t[st[0]][st[1]]=t[st[1]][st[0]]=st[2];
    }
    scanf("%d",&d);
    REP(i,d)
    {
      scanf("%s",st);
      t1[st[0]][st[1]]=t1[st[1]][st[0]]=1;
    }
    scanf("%d%s",&n,st);

    vector<char> tab;
    REP(i,n)
    {
      if (tab.empty())
      {
        tab.PB(st[i]);
        continue;
      }
      tab.PB(st[i]);
      int j=SIZE(tab)-1;
      while (j>0)
      {
        char ch;
        if ((ch=t[tab[j]][tab[j-1]]))
        {
          tab.pop_back(); tab.pop_back();
          tab.PB(ch);
          j--;
        } else break;
      }
      REP(k,SIZE(tab)) if (t1[tab[k]][tab.back()])
      {
        tab.clear();
        break;
      }
    }

    putchar('[');
    REP(i,SIZE(tab))
    {
      if (i>0) printf(", ");
      putchar(tab[i]);
    }
    putchar(']');
    puts("");
  }
  return 0;
}
