int m[2000][2000];
main(){
	int N,K;
	for(scanf("%d%d",&N,&K);N--;){
		int x,y;char c;
		scanf("%d%d%*c%c",&x,&y,&c);
		if(c=='W'){x+=K;}
		for(int i=0;i<2;++i){
			x%=2*K;
			y%=2*K;
			++m[y][x];
			--m[y][(x+K)%(2*K)];
			--m[(y+K)%(2*K)][x];
			++m[(y+K)%(2*K)][(x+K)%(2*K)];
			if(x>=K){
				++m[y][0];
				--m[(y+K)%(2*K)][0];
			}
			if(y>=K){
				++m[0][x];
				--m[0][(x+K)%(2*K)];
			}
			if(x>=K&&y>=K){
				++m[0][0];
			}
			x+=K;
			y+=K;
		}
	}
	for(int y=0;y<2*K;++y){
		for(int x=1;x<2*K;++x){
			m[y][x]+=m[y][x-1];
		}
	}
	int z=0;
	for(int x=0;x<2*K;++x){
		for(int y=0;y<2*K;++y){
			if(y){
				m[y][x]+=m[y-1][x];
			}
			if(m[y][x]>z){
				z=m[y][x];
			}
		}
	}
	printf("%d",z);
} ./Main.c:2:1: warning: return type defaults to �int� [-Wimplicit-int]
 main(){
 ^
./Main.c: In function �main�:
./Main.c:4:6: warning: implicit declaration of function �scanf� [-Wimplicit-function-declaration]
  for(scanf("%d%d",&N,&K);N--;){
      ^
./Main.c:4:6: warning: incompatible implicit declaration of built-in function �scanf�
./Main.c:4:6: note: include �<stdio.h>� or provide a declaration of �scanf�
./Main.c:46:2: warning: implicit declaration of function �printf� [-Wimplicit-function-declaration]
  printf("%d",z);
  ^
./Main.c:46:2: warning: incompatible implicit declaration of built-in function �printf�
./Main.c:46:2: note: include �<stdio.h>� or provide a declaration of �printf�