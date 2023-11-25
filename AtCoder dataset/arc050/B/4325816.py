def b_bouquet(R, B, X, Y):
    """
    ????R??????B?????????2??????????
    ?X??????1???????????(???????)
    ?1??????Y???????????(???????)
    ?????????????????????????????
    """

    # K?????????????????????
    # ??????/?????????1?????????R, B??K????
    # ?????1????????????X-1???????1????????????Y-1???????
    # ?????????????? (R-K)//(X-1) ?, (B-K)//(Y-1) ?????????
    # ???????????K??????????????
    # ??????????????K?????????????
    def can_make_bouquet(k):
        if k > R or k > B:
            return False
        return (R - k) // (X - 1) + (B - k) // (Y - 1) >= k

    lower, upper = 0, R + B  # ???????????upper???????
    while upper - lower > 1:
        mid = (lower + upper) // 2
        if can_make_bouquet(mid):
            lower = mid
        else:
            upper = mid
    return lower

R, B = [int(i) for i in input().split()]
X, Y = [int(i) for i in input().split()]
print(b_bouquet(R, B, X, Y))