def d_wall(H, W, C, A):
    import scipy.sparse
    # cost[i][j]:??i??j?????????????(float64??????)
    cost = scipy.sparse.csgraph.floyd_warshall(C)
    # ???????????????1?????????????????????
    return int(sum(cost[A[h][w]][1] for h in range(H) for w in range(W) if A[h][w] != -1))

H, W = [int(i) for i in input().split()]
C = [[int(i) for i in input().split()] for j in range(10)]
A = [[int(i) for i in input().split()] for j in range(H)]
print(d_wall(H, W, C, A))