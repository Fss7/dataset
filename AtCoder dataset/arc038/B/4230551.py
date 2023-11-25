def b_grid(H, W, Grid):
    memo = [[None] * W for _ in [0] * H]

    def can_move(r, c):
        return 0 <= r < H and 0 <= c < W and Grid[r][c] == '.'

    def is_first_move_win(r, c):
        """???Grid[r][c]????????????????????????"""
        # ??????????????????
        # ?????????????????????????
        if not can_move(r, c):
            return True

        if memo[r][c] is not None:
            return memo[r][c]

        # ????????????????????????????
        result = True if not all([is_first_move_win(r + 1, c),
                                  is_first_move_win(r + 1, c + 1),
                                  is_first_move_win(r, c + 1)]) else False
        memo[r][c] = result
        return result
    return 'First' if is_first_move_win(0, 0) else 'Second'

H, W = [int(i) for i in input().split()]
Grid = [input() for _ in [0] * H]
print(b_grid(H, W, Grid))