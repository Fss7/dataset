#https://atcoder.jp/contests/abc075/submissions/2242350
N,K=map(int,input().split())

points=[tuple(map(int,input().split())) for i in range(N)]
answer=10**19
sortx=sorted(points)
numberx = list(enumerate(sortx))

#n-k+1???????????????????????
for left,(x1,y1) in numberx[:N-K+1]:
  #left+K-1??????????????????????????
  for right,(x2,y2) in numberx[left+K-1:]:
    dx=x2-x1
    #left-right???y????sort
    sorty=sorted(y for x,y in sortx[left:right+1])
    #K???????????????
    for y3,y4 in zip(sorty,sorty[K-1:]):
      if y3<=y1 and y3<=y2 and y4>=y1 and y4>=y2:
        answer=min(answer,dx*(y4-y3))
         
print(answer)