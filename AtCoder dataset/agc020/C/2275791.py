# -*- coding: utf-8 -*-
# ??????????
# A?? + not(A)?? = ?A??????????ceil(?A / 2)????????????
# dp[i][j] = A_1?A_i????j??????????, O(max(A_i) * N^2)?????????????.
# ???dp[i][j]????????, ??????????????????????????
# python???????????�??????????????????????????c++??????????
# for????????????????(??c++?50??????????????????????????????????????

n = int(input())
a = [int(i) for i in input().split()]
dp = 1
for i in range(0, len(a)):
	dp = (dp | (dp << a[i]))

asum = 0
for i in range(0, len(a)):
	asum += a[i]

for i in range(int((asum + 1) / 2), asum + 1):
	if (dp >> i) & 1:
		print(i)
		break