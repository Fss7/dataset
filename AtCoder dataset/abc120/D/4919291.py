n, m = map(int, input().split())
par = [-1] * n  # ???????-(????????)


# x?????????????????
def find(x):
    if par[x] < 0:
        return x
    else:
        par[x] = find(par[x])
        return find(par[x])


# ???????????
def size(x):
    return -par[find(x)]


# x?y?????????
def unite(x, y):
    # ????
    x, y = find(x), find(y)

    # ????
    if x == y:
        return

    # ???????????????
    if size(x) < size(y):
        x, y = y, x

    # x???????
    par[x] += par[y]
    # y???x???
    par[y] = x


# ???????????
def same(x, y):
    return find(x) == find(y)


bridges = [list(map(int, input().split())) for _ in range(m)]
bridges.reverse()
huben = n * (n - 1) // 2
ans = []
for i in range(m):
    ans.append(huben)
    a, b = bridges[i]
    a, b = a - 1, b - 1
    if same(a, b):
        continue
    else:
        huben -= size(a) * size(b)
        unite(a, b)
ans.reverse()
for i in range(m):
    print(ans[i])