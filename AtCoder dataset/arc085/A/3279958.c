main(n,m){scanf("%d%d",&n,&m)<printf("%d",n*100+m*1800<<m);} ./Main.c:1:1: warning: return type defaults to �int� [-Wimplicit-int]
 main(n,m){scanf("%d%d",&n,&m)<printf("%d",n*100+m*1800<<m);}
 ^
./Main.c: In function �main�:
./Main.c:1:1: warning: type of �n� defaults to �int� [-Wimplicit-int]
./Main.c:1:1: warning: type of �m� defaults to �int� [-Wimplicit-int]
./Main.c:1:11: warning: implicit declaration of function �scanf� [-Wimplicit-function-declaration]
 main(n,m){scanf("%d%d",&n,&m)<printf("%d",n*100+m*1800<<m);}
           ^
./Main.c:1:11: warning: incompatible implicit declaration of built-in function �scanf�
./Main.c:1:11: note: include �<stdio.h>� or provide a declaration of �scanf�
./Main.c:1:31: warning: implicit declaration of function �printf� [-Wimplicit-function-declaration]
 main(n,m){scanf("%d%d",&n,&m)<printf("%d",n*100+m*1800<<m);}
                               ^
./Main.c:1:31: warning: incompatible implicit declaration of built-in function �printf�
./Main.c:1:31: note: include �<stdio.h>� or provide a declaration of �printf�