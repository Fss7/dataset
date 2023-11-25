H, W = map(int, input().split())
Ss = [input() for _ in range(H)]

# ????????????????????????????
def dfs(iR):
    # ?????????????
    if iR < 0:
        return check()

    # ??????????
    iF = flgs.index(False)
    Rs[iR] = iF - offset
    flgs[iF] = True

    # ???????????????????
    ans = False
    for iF2, flg in enumerate(flgs):
        if not flg:
            Rs[H - 1 - iR] = iF2 - offset
            flgs[iF2] = True
            ans = ans or dfs(iR - 1)
            flgs[iF2] = False

    flgs[iF] = False

    return ans


# ??????????????????????????????????????????
def check():

    Ts = [Ss[R] for R in Rs]
    Ts = list(map(list, zip(*Ts)))

    # (W+1)/2???????????
    if W % 2: flgCenter = True
    else: flgCenter = False

    # ????????????
    Used = [False] * W
    for j, T in enumerate(Ts):
        if Used[j]: continue
        for j2, T2 in enumerate(Ts[j + 1:], j + 1):
            # ???????????????????????????
            if not Used[j2] and T[::-1] == T2:
                Used[j2] = True
                break
        else:
            # ???????????(W+1)/2???????????????
            if T[::-1] == T and flgCenter == True:
                flgCenter = False
            else:
                # ??????????????????
                return False

    return True


if H % 2:
    # H????????????????
    flgs = [False] * (H + 1)
    offset = 1
else:
    flgs = [False] * H
    offset = 0

Rs = [-1] * H
if dfs((H - 1) // 2):
    print('YES')
else:
    print('NO')