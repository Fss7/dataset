#include <iostream>
#include <algorithm>
#include <vector>
#include <set>
#include <string>
using namespace std;
#define ll long long int

bool solve(string s){
  if(s[5] == '1') 
  {
    return true;
  }
  else
  {
    if(s[6] == '4' || s[6] == '3' || s[6] == '2' || s[6] == '1' )return false;
    else return true;
  }
}

void output(bool ok){
  if(ok)cout<<"TBD"<<endl;
  else cout<<"Heisei"<<endl;  
}

int main(){ 
  string s;
  cin >> s;
  bool ok = solve(s);
  output(ok);
  return 0;
}