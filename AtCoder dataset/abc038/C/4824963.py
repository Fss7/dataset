from __future__ import print_function
import sys





def eprint(*args, **kwargs):
    print(*args, file=sys.stderr, **kwargs)

n = int(input())
# array = [int(input()) for _ in range(n)]
array = [0] + list(map(int,input().split()))
# for _ in range(1,n+1):
#     array[ _ ] = int(input())




right = 1
left = 1
length_s = 0
ans=0
cnt=0

temp_x =0
while True:
    # 
    # 
    # 
    # 

    
    if right == n+1 and left == n+1:
        cnt+= int(length_s * (length_s + 1)/2)
        break

    if right == n+1:
        # if rigt == left:
        #     cnt += int(length_s * (length_s +1)/2)
        while left<right:
            left+=1
    else:
        if  temp_x < array[right]:
            temp_x = array[right]
            right+=1
            # 
            # 
            # 
            
            
            
            
            
            length_s = right-left
            
            
            
        elif right==left:
            cnt += int(length_s * (length_s + 1)/2)
            
            
            temp_x=0
            


        else:
            left+=1
            



print(cnt)

# ??array
# N???
# 
# [??]
#     1 < N < 10^5
#     1 < array_i < 10^5
# 
# [??]
# ??a_l ?? a_r ???????????????[l,r]?????????
# ??a_l ?? a_r ???????????????[l.r]??????????
# ??a_l ?? a_r ???????????????[l,r]??????????
# 
# [??]
# left == right == 1 ???????????????????0???????
# 
# ???right?????????????????????????????????right?array[right]??????????????????????????array[right-1]????????????????????????????????????????????????????right?????????????????????????????????
# 
# ???right??????????????????????????????????????????????left < right?????????????left??????????????????????????
# ?
# ?right???????????????????????????????????????????????????????left == right?????????left?right?????1????????????
# 
# 
# 
#