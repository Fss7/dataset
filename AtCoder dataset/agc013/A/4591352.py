import numpy

N = int(input())
AN = list(map(int,input().split()))

ans = 1				#??????????1??????1
beforeDiff = 0				#??????????????
chgFlag = True				#???????????0??????????????True

for i in range(1,N):			#i-1???????1????
	diff = AN[i] - AN[i-1]
	
	if chgFlag or beforeDiff==0:	#?????(???????????0)
		beforeDiff = diff	#?????????????(???????)
		chgFlag = False	#?????
		continue
		
	if (numpy.sign(beforeDiff) == 1 and numpy.sign(diff) == -1) or (numpy.sign(beforeDiff) == -1 and numpy.sign(diff) == 1):		#????????????
		chgFlag = True		#???
		ans += 1
		
print(ans)