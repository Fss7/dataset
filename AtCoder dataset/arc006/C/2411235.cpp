#include <iostream>
#include <fstream>
#include <string> 
#include <cstring>
#include <cmath>  
#include <cstdlib>
#include <ctime>
#include <vector>
#include <algorithm>
#include <numeric>
#include <map>
#include <set>
#include <stack>
#include <queue>
#include <deque>
#include <functional>
#include <cctype>
#include <list>
//#include <boost/multiprecision/cpp_int.hpp>

#define BIT(a) (1 << (a))
#define EPS (1e-10)

using namespace std;
//using namespace boost::multiprecision;

const long long MOD = 1000000007;
const int COUNTER_CLOCKWISE = 1;
const int CLOCKWISE = -1;
const int ONLINE_BACK = 2;
const int ONLINE_FRONT = -2;
const int ON_SEGMENT = 0;

class Point{
    public:
    double x, y;

    Point(double x = 0, double y = 0): x(x), y(y) {}
    
    Point operator+(Point p){return Point(x + p.x, y + p.y);}
    Point operator-(Point p){return Point(x - p.x, y - p.y);}
    Point operator*(double a){return Point(a * x, a * y);}
    Point operator/(double a){return Point(x / a, y / a);}

    bool operator < (const Point &p) const {
        return y != p.y ? y < p.y : x < p.x;
    }

    double norm(){return x * x + y * y;}
};
typedef Point Vector;
typedef vector<Vector> Polygon;

double cross(Vector a, Vector b){
    return a.x*b.y - a.y*b.x;
}

double dot(Vector a, Vector b){
    return a.x * b.x + a.y * b.y;
}

int ccw(Point p0, Point p1, Point p2){
    Vector a = p1 - p0;
    Vector b = p2 - p0;
    if (cross(a, b) > EPS)return COUNTER_CLOCKWISE;
    if (cross(a, b) > -EPS)return CLOCKWISE;
    if (dot(a, b) < -EPS)return ONLINE_BACK;
    if (a.norm() < b.norm())return ONLINE_FRONT;

    return ON_SEGMENT;
}

Polygon andrewScan(Polygon s){
    Polygon u, l;
    if (s.size() < 3) return s;
    sort(s.begin(), s.end());
    u.push_back(s[0]);
    u.push_back(s[1]);
    l.push_back(s[s.size()-1]);
    l.push_back(s[s.size()-2]);
    
    for (size_t i = 2; i < s.size(); i++){
        for (size_t n = u.size(); n >= 2 && ccw(u[n-2], u[n-1], s[i]) == COUNTER_CLOCKWISE; n--){
            u.pop_back();
        }
        u.push_back(s[i]);
    }

    for (int i = (int)s.size() - 3; i >= 0; i--){
        for (size_t n = l.size(); n >= 2 && ccw(l[n-2], l[n-1], s[i]) == COUNTER_CLOCKWISE; n--){
            l.pop_back();
        }
        l.push_back(s[i]);
    }

    reverse(l.begin(), l.end());
    for (size_t i = u.size() - 2; i >= 1; i--) l.push_back(u[i]);

    return l;
}

long long mod_pow(long long x, long long n){
    long long res = 1;
    for(int i = 0;i < 60; i++){
        if(n >> i & 1) res = res * x % MOD;
        x = x * x % MOD;
    }
    return res;
}

set<int> box;

int main(void){
    int N;
    cin >> N;
    for (int i = 0; i < N; i++){
        int x;
        cin >> x;

        if(!i)box.insert(x);

        int flag = 1;
        for (auto itr = box.begin(); itr != box.end(); itr++){
            if (*itr >= x){
                box.erase(*itr);
                box.insert(x);
                flag = 0;
                break;
            }
        }
        if (flag) box.insert(x);
    }
    cout << box.size() << endl;
    
}