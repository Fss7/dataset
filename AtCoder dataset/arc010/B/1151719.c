m[]={0,0,31,60,91,121,152,182,213,244,274,305,335},s[999],a,b;main(i){for(;i<367;i++)s[i]=i%7<2;for(gets(&a);~scanf("%d/%d",&a,&b);s[i]=1)for(i=m[a]+b;s[i];i++);for(a=i=0;i<367;a=a<b?b:a)b+=s[i++]?:-b;printf("%d",a);} ./Main.c:1:1: warning: data definition has no type or storage class
 m[]={0,0,31,60,91,121,152,182,213,244,274,305,335},s[999],a,b;main(i){for(;i<367;i++)s[i]=i%7<2;for(gets(&a);~scanf("%d/%d",&a,&b);s[i]=1)for(i=m[a]+b;s[i];i++);for(a=i=0;i<367;a=a<b?b:a)b+=s[i++]?:-b;printf("%d",a);}
 ^
./Main.c:1:1: warning: type defaults to �int� in declaration of �m� [-Wimplicit-int]
./Main.c:1:52: warning: type defaults to �int� in declaration of �s� [-Wimplicit-int]
 m[]={0,0,31,60,91,121,152,182,213,244,274,305,335},s[999],a,b;main(i){for(;i<367;i++)s[i]=i%7<2;for(gets(&a);~scanf("%d/%d",&a,&b);s[i]=1)for(i=m[a]+b;s[i];i++);for(a=i=0;i<367;a=a<b?b:a)b+=s[i++]?:-b;printf("%d",a);}
                                                    ^
./Main.c:1:59: warning: type defaults to �int� in declaration of �a� [-Wimplicit-int]
 m[]={0,0,31,60,91,121,152,182,213,244,274,305,335},s[999],a,b;main(i){for(;i<367;i++)s[i]=i%7<2;for(gets(&a);~scanf("%d/%d",&a,&b);s[i]=1)for(i=m[a]+b;s[i];i++);for(a=i=0;i<367;a=a<b?b:a)b+=s[i++]?:-b;pr...