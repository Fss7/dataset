m=list(map(int,input().split()))
k=int(input())
m.append(max(m)*2**k)
m.remove(sorted(m)[-2])
print(sum(m))