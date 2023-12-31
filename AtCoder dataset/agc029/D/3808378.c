#include <stdio.h>
#include <limits.h>
typedef unsigned int uint;

inline static uint gl(void){
    uint x = 0;
    for(;;){
        const uint c = getchar_unlocked() - 48;
        if(c < 10){
            x = x*10 + c;
        }else{
            break;
        }
    }
    return x;
}

uint v[200000];
int main(void){
    const uint h = gl();
    gl();
    const uint n = gl();
    for(uint i=0; i<h; i++){ v[i] = i+2; }
    for(uint i=0; i<n; i++){
        uint x = gl()-1;
        uint y = gl();
        v[x] = y<v[x] ? y : v[x];
    }
    uint right = 1;
    for(uint x=1; x<h; x++){
        if(v[x]<right+1){
            printf("%d\n", x);
            return 0;
        }else if(v[x]>right+1){
            right++;
        }
    }
    printf("%d\n", h);
    return 0;
}