#include<stdio.h>
int main(){
	int y,m,d;
	scanf("%d %d %d",&y,&m,&d);
	if(m<3){
		y--;
		m+=12;
	}
	printf("%d\n", 735369-(365*y+y/4-y/100+y/400+306*(m+1)/10+d-429));
	return 0;	
} ./Main.c: In function �main�:
./Main.c:4:2: warning: ignoring return value of �scanf�, declared with attribute warn_unused_result [-Wunused-result]
  scanf("%d %d %d",&y,&m,&d);
  ^