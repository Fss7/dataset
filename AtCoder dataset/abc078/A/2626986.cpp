#include<algorithm>
#include<iostream>
#include<math.h>
#include<queue>
#include<stdio.h>
#include<stdlib.h>
#include<stack>
#include<string>
#include<vector>

#define ll long long
#define ull unsigned long long

using namespace std;
int main(void) {

	char A = '\0', B = '\0';
	
	scanf("%c %c", &A, &B);

	if (A - B > 0)
		printf(">\n");
	else if (A - B < 0)
		printf("<\n");
	else
		printf("=\n");
	
	return 0;
}