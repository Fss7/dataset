from datetime import date,timedelta
x=[]
ans = 0
for i in range(3):
    x.append(int(input()))
dt=date(year=x[0],month=x[1],day=x[2])#?????date?????
q=1
while q:
    if dt.year!=2014 or dt.month!= 5 or dt.day!=17:#??????????????
        dt+=timedelta(days=1)#????????????????????????
        ans+=1
    else:
        break
print(ans)