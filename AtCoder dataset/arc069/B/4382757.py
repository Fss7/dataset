# python template for atcoder1
import sys
sys.setrecursionlimit(10**9)
input = sys.stdin.readline

N = int(input())
s = input()[:-1]
ans = [1]*(N+2)


def print_ans(l: list):
    ret = ""
    for a in l[1:-1]:
        ret += "S" if a else "W"
    print(ret)


def next(ind: int, isSame: bool, isSheep: bool)->bool:
    return isSame ^ isSheep ^ ans[ind-1]


def check(first: bool, last: bool)->list:
    ans[0] = last
    ans[1] = first
    for i in range(1, N+1):
        ans[i+1] = next(i, s[i-1] == "o", ans[i])

    return ans[0] == ans[N] and ans[1] == ans[N+1]


for first in [True, False]:
    for last in [True, False]:
        if check(first, last):
            print_ans(ans)
            exit()
print("-1")