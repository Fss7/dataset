main(a,b,c){scanf("%d%d",&a,&b);for(c=b;c;a*=10)c/=10;c=sqrt(a+=b);puts(c*c-a?"No":"Yes");} ./Main.c:1:1: warning: return type defaults to �int� [-Wimplicit-int]
 main(a,b,c){scanf("%d%d",&a,&b);for(c=b;c;a*=10)c/=10;c=sqrt(a+=b);puts(c*c-a?"No":"Yes");}
 ^
./Main.c: In function �main�:
./Main.c:1:1: warning: type of �a� defaults to �int� [-Wimplicit-int]
./Main.c:1:1: warning: type of �b� defaults to �int� [-Wimplicit-int]
./Main.c:1:1: warning: type of �c� defaults to �int� [-Wimplicit-int]
./Main.c:1:13: warning: implicit declaration of function �scanf� [-Wimplicit-function-declaration]
 main(a,b,c){scanf("%d%d",&a,&b);for(c=b;c;a*=10)c/=10;c=sqrt(a+=b);puts(c*c-a?"No":"Yes");}
             ^
./Main.c:1:13: warning: incompatible implicit declaration of built-in function �scanf�
./Main.c:1:13: note: include �<stdio.h>� or provide a declaration of �scanf�
./Main.c:1:57: warning: implicit declaration of function �sqrt� [-Wimplicit-function-declaration]
 main(a,b,c){scanf("%d%d",&a,&b);for(c=b;c;a*=10)c/=10;c=sqrt(a+=b);puts(c*c-a?"No":"Yes");}
                                                        ...