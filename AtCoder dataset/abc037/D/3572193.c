//r;p;M=1e9+7;a[1<<20];c[1<<20];u[4]={1,-1};f(v,w){int*z=c+v,x=v%w,y=v/w,s,t,d=4;if(*z<0)for(*z=1;d--;~s&~t&s-w&t-*a&&a[t*w+s+2]>a[v+2]?*z=(*z+f(t*w+s,w))%M:0)s=x+u[d],t=y+u[3-d];return*z;}main(){for(;~scanf("%d",a+p);)--c[p++];for(p-=2;p--;)r=(r+f(p,a[1]))%M;printf("%d",r);}
p;M=1e9+7;long r,c[1<<20];a[1<<20];u[4]={1,-1};
f(v,w,s,t,d){if(c[v]<0)for(c[v]=1,d=4;d--;~s&~t&s-w&t-*a&&a[t*w+s+2]>a[v+2]?c[v]+=f(t*w+s,w,0,0,0):0)s=v%w+u[d],t=v/w+u[3-d];return c[v]%=M;}main(){for(;~scanf("%d",a+p);)--c[p++];for(p-=2;p--;)r+=f(p,a[1],0,0,0);printf("%d",r%M);} ./Main.c:2:1: warning: data definition has no type or storage class
 p;M=1e9+7;long r,c[1<<20];a[1<<20];u[4]={1,-1};
 ^
./Main.c:2:1: warning: type defaults to �int� in declaration of �p� [-Wimplicit-int]
./Main.c:2:3: warning: data definition has no type or storage class
 p;M=1e9+7;long r,c[1<<20];a[1<<20];u[4]={1,-1};
   ^
./Main.c:2:3: warning: type defaults to �int� in declaration of �M� [-Wimplicit-int]
./Main.c:2:27: warning: data definition has no type or storage class
 p;M=1e9+7;long r,c[1<<20];a[1<<20];u[4]={1,-1};
                           ^
./Main.c:2:27: warning: type defaults to �int� in declaration of �a� [-Wimplicit-int]
./Main.c:2:36: warning: data definition has no type or storage class
 p;M=1e9+7;long r,c[1<<20];a[1<<20];u[4]={1,-1};
                                    ^
./Main.c:2:36: warning: type defaults to �int� in declaration of �u� [-Wimplicit-int]
./Main.c:3:1: warning: return type defaults to �int� [-Wimplicit-int]
 f(v,w,s,t,d){if(c[v]<0)for(c[v]=1,d=4;d--;~s&~t&s-w&t-*a&&a[t*...