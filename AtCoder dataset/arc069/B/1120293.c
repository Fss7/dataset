W=87,i,n;char a[100001],s[100001];f(x,y){*a=x;a[1]=y;for(i=1;i<n-1;i++)a[i+1]=a[i]==W^a[i-1]==W^s[i]=='o'?83:W;if(*a==W^*s=='o'^a[n-1]==a[1]|a[n-1]==W^s[n-1]=='o'^a[n-2]==*a)return;puts(a);exit(0);}main(){scanf("%d%s",&n,&s);f(83,83);f(83,W);f(W,83);f(W,W);puts("-1");} ./Main.c:1:1: warning: data definition has no type or storage class
 W=87,i,n;char a[100001],s[100001];f(x,y){*a=x;a[1]=y;for(i=1;i<n-1;i++)a[i+1]=a[i]==W^a[i-1]==W^s[i]=='o'?83:W;if(*a==W^*s=='o'^a[n-1]==a[1]|a[n-1]==W^s[n-1]=='o'^a[n-2]==*a)return;puts(a);exit(0);}main(){scanf("%d%s",&n,&s);f(83,83);f(83,W);f(W,83);f(W,W);puts("-1");}
 ^
./Main.c:1:1: warning: type defaults to �int� in declaration of �W� [-Wimplicit-int]
./Main.c:1:6: warning: type defaults to �int� in declaration of �i� [-Wimplicit-int]
 W=87,i,n;char a[100001],s[100001];f(x,y){*a=x;a[1]=y;for(i=1;i<n-1;i++)a[i+1]=a[i]==W^a[i-1]==W^s[i]=='o'?83:W;if(*a==W^*s=='o'^a[n-1]==a[1]|a[n-1]==W^s[n-1]=='o'^a[n-2]==*a)return;puts(a);exit(0);}main(){scanf("%d%s",&n,&s);f(83,83);f(83,W);f(W,83);f(W,W);puts("-1");}
      ^
./Main.c:1:8: warning: type defaults to �int� in declaration of �n� [-Wimplicit-int]
 W=87,i,n;char a[100001],s[100001];f(x,y){*a=x;a[1]=y;for(i=1;i<n-1;i++)a[i+1]=a[i]==W^a[i-1]==W^s[i]=='o'?83:W;if(*a==W^*s=='o'^a[n-1]==a[1]|a[n-1]...