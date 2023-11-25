import sys
read = sys.stdin.readline
sys.setrecursionlimit(1 << 25)


def readln():
    return list(map(int, read().split()))


N, M = readln()
visited = [False] * N  # ??????


# ???????????
from collections import defaultdict
edge = defaultdict(lambda: set())  # ??????????????????????????
for _ in range(M):
    u, v = readln()
    edge[v-1].add(u-1)
    edge[u-1].add(v-1)


def dfs(node, prev):
    '''
    ???????????????????

    ??????????????0??????
    ???????????(?????)1????
    '''
    if visited[node]:
        # ??????????????!
        # return0???
        return 0

    # print(node, prev)
    visited[node] = True
    # dfs!
    for n in edge[node]:
        if n == prev:
            continue  # ??node?????????????
        if dfs(n, node) == 0:
            return 0
    return 1  # ???????????????????1????


ans = 0
for i in range(N):
    if not visited[i]:
        ans += dfs(i, -1)

print(ans)