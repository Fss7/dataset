from math import ceil

N = int(input())
As = list(map(int, input().split()))

# dp????(j+1)????: ??j??????????????1
dp = 1
for A in As:
    dp |= dp << A

# ??j????????????(?A/2)??????j???
ans = ceil(sum(As) / 2)
dp >>= ans
while not (dp & 1):
    dp >>= 1
    ans += 1

print(ans)