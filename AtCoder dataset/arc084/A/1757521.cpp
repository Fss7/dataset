#include<deque>
#include<queue>
#include<vector>
#include<algorithm>
#include<iostream>
#include<set>
#include<cmath>
#include<tuple>
#include<string>
#include<chrono>
#include<functional>
#include<iterator>
#include<random>
#include<unordered_set>
#include<unordered_map>
#include<array>
#include<map>
#include<iomanip>
using namespace std;
typedef long long int llint;
typedef long double lldo;
#define mp make_pair
#define mt make_tuple
#define pub push_back
#define puf push_front
#define pob pop_back
#define pof pop_front
#define fir first
#define sec second
#define res resize
#define ins insert
#define era erase
#define dme cout<<-1<<endl;return 0
//ios::sync_with_stdio(false);
//std::cin.tie(0);
//<< setprecision(20)
const int mod=1e9+7;

const int big=1e6+100;
const long double pai=3.141592653589793238462643383279502884197;
const long double ena=2.71828182845904523536;
const long double eps=1e-7;
template <class T,class U>void mineq(T& a,U b){if(a>b){a=b;}}
template <class T,class U>void maxeq(T& a,U b){if(a<b){a=b;}}
llint gcd(llint a,llint b){if(a%b==0){return b;}else return gcd(b,a%b);}
llint lcm(llint a,llint b){return a/gcd(a,b)*b;}
int main(void){
	int n,i;cin>>n;
	vector<int>a(n);
	vector<int>b(n);
	vector<int>c(n);
	for(i=0;i<n;i++){cin>>a[i];}
	sort(a.begin(),a.end());
	for(i=0;i<n;i++){cin>>b[i];}
	sort(b.begin(),b.end());
	for(i=0;i<n;i++){cin>>c[i];}
	sort(c.begin(),c.end());
	llint ans=0;
	for(i=0;i<n;i++){
		ans+=(llint)(lower_bound(a.begin(),a.end(),b[i])-a.begin())*(n-(upper_bound(c.begin(),c.end(),b[i])-c.begin()));
	}
	cout<<ans<<endl;
	return 0;
}