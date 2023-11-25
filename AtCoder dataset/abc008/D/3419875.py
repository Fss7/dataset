def d_nugget_game(W, H, N, M):  # ?????????????????????
    def dp(l, r, t, b):  # left,right,top,bottom
        if l > r or t > b:
            # ?????????(???????????)
            return 0

        key = (l, r, t, b)
        if key in memo:
            return memo[key]

        memo[key] = 0
        for x, y in M:
            if l <= x <= r and t <= y <= b:
                # ???????l,r,t,b?????????????
                memo[key] = max(memo[key],
                                r - l + b - t + 1
                                + dp(l, x - 1, t, y - 1)
                                + dp(x + 1, r, t, y - 1)
                                + dp(l, x - 1, y + 1, b)
                                + dp(x + 1, r, y + 1, b))
                # ?1?????????????????????
                # ??????????4??????????????
                # 4????????????"??/??/??/??"????DP???
        return memo[key]

    memo = {}  # ???????????
    ans = dp(1, W, 1, H)  # ??????????.??????????????
    return ans

W, H = [int(i) for i in input().split()]
N = int(input())
M = [[int(i) for i in input().split()] for j in range(N)]
print(d_nugget_game(W, H, N, M))