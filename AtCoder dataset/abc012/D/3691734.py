from scipy.sparse import*;f=lambda*z:map(int,input().split());N,M=f();a,b,c=zip(*map(f,[0]*M));l=csgraph.dijkstra(csr_matrix((c,(a,b)),[N+1]*2),0);print(int(min(max(i[1:])for i in l)))