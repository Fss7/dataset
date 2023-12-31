#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <algorithm>
#include <string>
#include <sstream>
#include <complex>
#include <vector>
#include <list>
#include <queue>
#include <deque>
#include <stack>
#include <map>
#include <set>
#include <climits>

using namespace std;
typedef long long unsigned int ll;
typedef pair<int, int> P;

#define EPS (1e-7)
#define INF (1e9)
#define PI (acos(-1))

#define amari (x) x % 1000000007;

#define fillInt(xs, x)        \
  for (int i = 0; i < x; i++) \
    scanf("%d", &xs[i]);
#define fillLong(xs, x)       \
  for (int i = 0; i < x; i++) \
    scanf("%ld", &xs[i]);
#define fillString(xs, x)       \
  for (int i = 0; i < x; i++) \
    cin >> xs[i];
#define sortv(xs) sort(xs.begin(), xs.end());
#define sortvdi(xs) sort(xs.begin(), xs.end(), std::greater<int>());
#define lbv(xs, x) lower_bound(xs.begin(), xs.end(), x) - xs.begin();
#define ubv(xs, x) upper_bound(xs.begin(), xs.end(), x) - xs.begin();

#define rep(i,n) for(int i=0; i<(int)(n); i++)
#define isValidPoint(x, y, mx, my) x >= 0 && x  < mx && y >= 0 && y < my

int dx[4] = {1, 0, -1, 0}, dy[4] = {0, 1, 0, -1};

int N, M;
int sx, sy;
int gx, gy;
char maze[500][500];
int d[500][500];

int bfs() {
  queue<P> que;
  que.push(P(sx, sy));
  d[sx][sy] = 0;

  while (que.size()) {
    P p = que.front();
    que.pop();
    if (p.first == gx && p.second == gy) {

    } else {
      rep(i , 4) {
        int nx = p.first + dx[i];
        int ny = p.second + dy[i];
        if (isValidPoint(nx, ny, N, M) && maze[nx][ny] == '.' && d[nx][ny] > d[p.first][p.second]) {
          que.push(P(nx, ny));
          d[nx][ny] = d[p.first][p.second];
        } else if (isValidPoint(nx, ny, N, M) && maze[nx][ny] == '#' && d[nx][ny] > d[p.first][p.second] + 1 && d[p.first][p.second] < 2) {
          que.push(P(nx, ny));
          d[nx][ny] = d[p.first][p.second] + 1;
        }
      }
    }
  }
  return d[gx][gy];
}

int main()
{
  cin.tie(0);
  ios::sync_with_stdio(false);

  cin >> N >> M;

  vector<string> x(N);
  fillString(x, N);

  rep(i, N)
  rep(j, M)
  {
    maze[i][j] = x[i][j];
    d[i][j] = INF;
    if (x[i][j] == 's') {
      sx = i;
      sy = j;
    }
    if (x[i][j] == 'g') {
      gx = i;
      gy = j;
      maze[i][j] = '.';
    }
  }

  if (bfs() <= 2) {
    printf("YES\n");
  } else {
    printf("NO\n");
  }

  return 0;
}