#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<math.h>

int main()
{
    freopen("B-small-attempt1.in","r",stdin);
    freopen("B-small-attempt1.out","w",stdout);
    int i,T,n,r,o,y,g,b,v,j;
    int cha,count;
    
    scanf("%d",&T);
    for(i=1;i<=T;i++)
    {
        
        scanf("%d%d%d%d%d%d%d",&n,&r,&o,&y,&g,&b,&v);
        printf("Case #%d: ",i);
        if(r+y<b||r+b<y||b+y<r)
          printf("IMPOSSIBLE");
        else
        {
            count=0;
            if(r>=y&&r>=b)
            {
               if(y>=b) 
               {
                 cha=y-b;
                 for(j=0;j<cha;j++)
                    printf("RY");
                 y-=cha;
                 r-=cha;             
               } 
               else
               {
                 cha=b-y;
                 for(j=0;j<cha;j++)
                    printf("RB");
                 b-=cha;
                 r-=cha;  
               }
               count=0;
               while(r>0)
               {
                    printf("R");
                    r--;
                    count++;
                    if(count%2)
                    {
                       printf("Y");
                       y--;        
                    }
                    else
                    {
                        printf("B");
                        b--;
                    }     
               }
               while(y>0||b>0)
               {
                    count++;
                    if(count%2)
                    {
                       printf("Y");
                       y--;        
                    }
                    else
                    {
                        printf("B");
                        b--;
                    }          
               }             
            }
          
       else if(y>=r&&y>=b)
            {
               if(r>=b) 
               {
                 cha=r-b;
                 for(j=0;j<cha;j++)
                    printf("YR");
                 y-=cha;
                 r-=cha;             
               } 
               else
               {
                 cha=b-r;
                 for(j=0;j<cha;j++)
                    printf("YB");
                 b-=cha;
                 y-=cha;  
               }
               count=0;
               while(y>0)
               {
                    printf("Y");
                    y--;
                    count++;
                    if(count%2)
                    {
                       printf("R");
                       r--;        
                    }
                    else
                    {
                        printf("B");
                        b--;
                    }     
               }
               while(r>0||b>0)
               {
                    count++;
                    if(count%2)
                    {
                       printf("R");
                       r--;        
                    }
                    else
                    {
                        printf("B");
                        b--;
                    }          
               }             
            }
          
            else
            {
               if(y>=r) 
               {
                 cha=y-r;
                 for(j=0;j<cha;j++)
                    printf("BY");
                 y-=cha;
                 b-=cha;             
               } 
               else
               {
                 cha=r-y;
                 for(j=0;j<cha;j++)
                    printf("BR");
                 b-=cha;
                 r-=cha;  
               }
               count=0;
               while(b>0)
               {
                    printf("B");
                    b--;
                    count++;
                    if(count%2)
                    {
                       printf("Y");
                       y--;        
                    }
                    else
                    {
                        printf("R");
                        r--;
                    }     
               }
               while(y>0||r>0)
               {
                    count++;
                    if(count%2)
                    {
                       printf("Y");
                       y--;        
                    }
                    else
                    {
                        printf("R");
                        r--;
                    }          
               }             
            }
          
          
            
        }  

        printf("\n");
    }


    //system("pause");
    return 0;
}
