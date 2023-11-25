#include <iostream>
#include <vector>
#include <cstdio>
#include <string>
#include <algorithm>
using namespace std;

class UnionFind{
public:
  //?????????????????-(????????)
  //vector??????
  vector<int> Parent;

  //????Parent?????-1???
  //??????????????
  //???????
  UnionFind(int N){
    Parent = vector<int>(N, -1);
  }

  //A?????????????????
  int root(int A){
    if (Parent[A] < 0) return A;
    return Parent[A] = root(Parent[A]);
  }

  //?????
  int size(int A){
    return -Parent[root(A)];//????????
  }

  //A?B??????
  bool connect(int A, int B){
    //A?B????????????roo(A)?root(B)??????
    A = root(A);
    B = root(B);
    if (A == B){
      //??????????????????
      return false;
    }

    //????(A)?????(B)???????
    //??????????????????
    if (size(A) < size(B)) swap(A, B);

    //A?????????
    Parent[A] += Parent[B];
    Parent[B] = A;

    return true;
  }
};


int main(){
  int N, M;
  cin >> N >> M;
  vector<int> A(M), B(M);
  for (int i = 0; i < M; i++){
    cin >> A[i] >> B[i];
    A[i]--;
    B[i]--;
  }

  vector<long long> ans(M);
  ans[M - 1] = (long long)N * (N - 1) / 2;

  UnionFind Uni(N);

  for (int i = M -1; i >= 1; i--){

    ans[i - 1] = ans[i];
    //???????????????
    if (Uni.root(A[i]) != Uni.root(B[i])){
      ans[i -1] -= (long long)Uni.size(A[i]) * Uni.size(B[i]);
    Uni.connect(A[i], B[i]);
    }
  }
  for (int i= 0; i < M; i++){
    cout << ans[i] << endl;
  };
}