"""
s = 'abc'
t = 'def'

# ???????????????
print(s, ',', t) # -> abc , def
print(s, '另', t) # -> abc 另 def

# ??????????????????????sep?????????
print(s, ',', t, sep='') # -> abc,def
print(s, '另', t, sep='') # -> abc另def

# ??????????end?????????
print(s, ',', t, sep='', end='') # -> abc,def??????
print(s, '另', t, sep='', end='') # -> abc另def??????
"""
s = list(input())
count_char=0
head_char=s[0]
for i in range(len(s)):
    if s[i] == head_char:
        count_char +=1
    else:
        print("{}{}".format(head_char, count_char), end = "")
        count_char = 1
        head_char = s[i]
print("{}{}".format(head_char, count_char))