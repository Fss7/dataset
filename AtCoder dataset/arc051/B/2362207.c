#include <stdio.h>
const int ans[] = {1, 1, 3, 2, 5, 3, 8, 5, 13, 8, 21, 13, 34, 21, 55, 34, 89, 55, 144, 89, 233, 144, 377, 233, 610, 377, 987, 610, 1597, 987, 2584, 1597, 4181, 2584, 6765, 4181, 10946, 6765, 17711, 10946, 28657, 17711, 46368, 28657, 75025, 46368, 121393, 75025, 196418, 121393, 317811, 196418, 514229, 317811, 832040, 514229, 1346269, 832040, 2178309, 1346269, 3524578, 2178309, 5702887, 3524578, 9227465, 5702887, 14930352, 9227465, 24157817, 14930352, 39088169, 24157817, 63245986, 39088169, 102334155, 63245986, 165580141, 102334155, 267914296, 165580141};

int main(){
  int K;
  scanf("%d", &K);
  int t = (--K)<<1;
  printf("%d %d\n",ans[t], ans[t+1]);
  return 0;
} ./Main.c: In function �main�:
./Main.c:6:3: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
   scanf("%d", &K);
   ^