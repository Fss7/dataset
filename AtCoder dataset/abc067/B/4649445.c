// Ver19.03
#include <math.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#define INF 1 << 29
#define LLINF 4545454545454545454
#define MOD 1000000007
#define ll long long
#define ull unsigned long long
#define MAX(a, b) ((a) > (b) ? (a) : (b))
#define MIN(a, b) ((a) < (b) ? (a) : (b))
int upll(const void *a, const void *b) { return *(ll *)a < *(ll *)b ? -1 : *(ll *)a > *(ll *)b ? 1 : 0; }
int downll(const void *a, const void *b) { return *(ll *)a < *(ll *)b ? 1 : *(ll *)a > *(ll *)b ? -1 : 0; }
void sortup(ll *a, int n) { qsort(a, n, sizeof(ll), upll); }
void sortdown(ll *a, int n) { qsort(a, n, sizeof(ll), downll); }

ll a[55];
int main()
{
  ll n, k, ans = 0;
  scanf("%lld%lld", &n, &k);
  for (int i = 0; i < n; i++)
  {
    scanf("%lld", &a[i]);
  }
  sortdown(a, n);
  for (int i = 0; i < k; i++)
  {
    ans += a[i];
  }
  printf("%lld\n", ans);
  return 0;
} ./Main.c: In function �main�:
./Main.c:22:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%lld%lld", &n, &k);
   ^
./Main.c:25:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%lld", &a[i]);
     ^