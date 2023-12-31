// @author peter50216
// lots of default code (especially dump/R/W) borrowed from shik, thanks!
// #includes {{{
#include <bits/stdc++.h>
using namespace std;
// }}}
// {{{ custom namespace, to avoid name collision.
// stupid macro so that vim doesn't get one more indent...
#define MYSPACE namespace zone_of_peter50216{
#define MYSPACE_END }

MYSPACE
// }}}
// #defines & template magics {{{
#define SZ(x) ((int)(x).size())
#define ALL(x) begin(x), end(x)
#define REP(i,n) for (int i=0; i<(n); i++ )
#define REP1(i,a,b) for (int i=(a); i<=(b); i++ )
#define PER(i,n) for (int i=(n)-1; i>=0; i--)
#define PER1(i,a,b) for (int i=(a); i>=(b); i--)
#define FOR(it,c) for (auto it=(c).begin(); it!=(c).end(); it++)
#define MS0(x) memset(x,0,sizeof(x))
#define MS1(x) memset(x,-1,sizeof(x))
#define SEP(x) ((x)?'\n':' ')
using namespace std;
typedef int64_t LL;
typedef uint64_t ULL;
typedef pair<int,int> PII;
typedef vector<int> VI;

#ifdef SHIK
template<typename T>
void _dump( const char* s, T&& head ) { cerr<<s<<"="<<head<<endl; }

template<typename T, typename... Args>
void _dump( const char* s, T&& head, Args&&... tail ) {
  int c=0;
  while ( *s!=',' || c!=0 ) {
    if ( *s=='(' || *s=='[' || *s=='{' ) c++;
    if ( *s==')' || *s==']' || *s=='}' ) c--;
    cerr<<*s++;
  }
  cerr<<"="<<head<<", ";
  _dump(s+1,tail...);
}

#define dump(...) do { \
  fprintf(stderr, "%s:%d - ", __PRETTY_FUNCTION__, __LINE__); \
  _dump(#__VA_ARGS__, __VA_ARGS__); \
} while (0)

template<typename Iter>
ostream& _out( ostream &s, Iter b, Iter e ) {
  s<<"[";
  for ( auto it=b; it!=e; it++ ) s<<(it==b?"":" ")<<*it;
  s<<"]";
  return s;
}

template<typename A, typename B>
ostream& operator <<( ostream &s, const pair<A,B> &p ) { return s<<"("<<p.first<<","<<p.second<<")"; }
template<typename T>
ostream& operator <<( ostream &s, const vector<T> &c ) { return _out(s,ALL(c)); }
template<typename T, size_t N>
ostream& operator <<( ostream &s, const array<T,N> &c ) { return _out(s,ALL(c)); }
template<typename T>
ostream& operator <<( ostream &s, const set<T> &c ) { return _out(s,ALL(c)); }
template<typename A, typename B>
ostream& operator <<( ostream &s, const map<A,B> &c ) { return _out(s,ALL(c)); }
#else
#define dump(...)
#endif

template<typename T>
void _R( T &x ) { cin>>x; }
void _R( int &x ) { scanf("%d",&x); }
void _R( int64_t &x ) { scanf("%" PRId64,&x); }
void _R( double &x ) { scanf("%lf",&x); }
void _R( char &x ) { scanf(" %c",&x); }
void _R( char *x ) { scanf("%s",x); }

void R() {}
template<typename T, typename... U>
void R( T& head, U&... tail ) {
  _R(head);
  R(tail...);
}

#define DRI(...) int __VA_ARGS__; R(__VA_ARGS__)
#define CASET DRI(t);for(int cas=1;cas<=t;cas++)

template<typename T>
void _W( const T &x ) { cout<<x; }
void _W( const int &x ) { printf("%d",x); }
template<typename T>
void _W( const vector<T> &x ) {
  for ( auto i=x.cbegin(); i!=x.cend(); i++ ) {
    if ( i!=x.cbegin() ) putchar(' ');
    _W(*i);
  }
}

void W() {}
template<typename T, typename... U>
void W( const T& head, const U&... tail ) {
  _W(head);
  putchar(sizeof...(tail)?' ':'\n');
  W(tail...);
}

inline string ssprintf(const char* format, ...) {
  static char buf[1000000]; // who cares about buffer overflow :P
  va_list args;
  va_start(args, format);
  vsprintf(buf, format, args);
  va_end(args);
  return buf;
}

// }}}
//
double pi[210];
double pos[210][210];
double vv[210];
int main() {
  CASET{
    DRI(n,k);
    REP(i,n)R(pi[i]);
    sort(pi,pi+n);
    double ans=0;
    REP1(l,0,k){
      int r=k-l;
      int vc=0;
      REP(i,l)vv[vc++]=pi[i];
      REP(i,r)vv[vc++]=pi[n-1-i];
      MS0(pos);
      pos[0][0]=1;
      REP(i,k){
        REP1(j,0,i){
          pos[i+1][j]+=pos[i][j]*(1-vv[i]);
          pos[i+1][j+1]+=pos[i][j]*vv[i];
        }
      }
      ans=max(ans,pos[k][k/2]);
    }
    printf("Case #%d: %.10f\n",cas,ans);
  }
  return 0;
}

// {{{ END
MYSPACE_END
int main() { return zone_of_peter50216::main(); }
// }}}
// vim: fdm=marker:commentstring=\ \"\ %s:nowrap:autoread

