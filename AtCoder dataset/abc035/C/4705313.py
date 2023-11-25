# https://qiita.com/_-_-_-_-_/items/34f933adc7be875e61d0
# abcde	s=input()	s='abcde'
# abcde	s=list(input())	s=['a', 'b', 'c', 'd', 'e']
# 5(1???)	a=int(input())	a=5
# 1 2	| x,y = s_inpl()   |	x=1,y=2
# 1 2 3 4 5 ... n ?	li = input().split()	li=['1','2','3',...,'n']
# 1 2 3 4 5 ... n ?	li = inpl()	li=[1,2,3,4,5,...,n]
# FFFTFTTFF ?	li = input().split('T')	li=['FFF', 'F', '', 'FF']

# INPUT
# 3
# hoge
# foo
# bar
# ANSWER
# n=int(input())
# string_list=[input() for i in range(n)]

import math
import numpy as np
import copy
from collections import defaultdict, Counter
from itertools import product
from bisect import bisect_left, bisect_right

def s_inpl(): return map(int,input().split())
def inpl(): return list(map(int, input().split()))

N, Q = s_inpl()

imos = [ 0 for _ in range(N+1) ]

for _ in range(Q):
    li, ri = s_inpl()
    li -= 1
    ri -= 1
    imos[li] += 1
    imos[ri+1] -= 1


res = [str(i % 2) for i in np.cumsum(imos)[:-1]]

print("".join(res))