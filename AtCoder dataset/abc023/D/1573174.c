#include<stdio.h>
#include<stdlib.h>
//#include<windows.h>

int main(void){
    int N, H[100001], S[100001]; //??
    long long int kijun;  //????????????????
    long long int left, right;   //?????????
    int t[100001], tMax;
    int i, cnt;
    scanf("%d", &N);
    for(i=0;i<N;i++){
        scanf("%d %d", &H[i], &S[i]);
    }
    left = 0;
    right = 1000000000ll+1000000000ll*N;
    while(left!=right){
        kijun=(left+right)/2; //??????
        //printf("%lld %lld %lld\n", left, kijun, right);
        //Sleep(200);
        for(i=0;i<=N+1;i++){
            t[i]=0;
        }
        for(i=0;i<N;i++){
            if(kijun<H[i]){
                t[N+1]=1;   //???????????????????????
                break;
            }(kijun-H[i])/S[i];   //???????????
            if((kijun-H[i])/S[i]>N){
                tMax=N;   //??N-1?????????N???
            }else{
                tMax=(kijun-H[i])/S[i];
            }
            //printf("tMax=%d\n", tMax);
            t[tMax]++;  //?????????????????????????
        }
        if(t[N+1]){
            left=kijun+1; //??????????????
            continue;
        }
        cnt=0;
        for(i=0;i<N;i++){
            //printf("t[%d]=%d\n", i, t[i]);
            cnt++;  //1???????????1???
            cnt-=t[i];  //?????????????????
            if(cnt<0){
                left=kijun+1; //????????????????????????????????????
                break;
            }
            if(i==N-1){
                right=kijun;    //????????????????????????
            }
        }

    }
    printf("%lld\n",left);
    return 0;
} ./Main.c: In function �main�:
./Main.c:11:5: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
     scanf("%d", &N);
     ^
./Main.c:13:9: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
         scanf("%d %d", &H[i], &S[i]);
         ^