#include <algorithm>
#include <cstdio>
#include <deque>
#include <iostream>
#include <queue>
#include <stack>
#include <utility>
#include <vector>
using std::cin;
using std::cout;
using std::endl;

int main(void) {
    int n;
    cin >> n;
    int number = n;
    int sum    = 0;
    while (n > 0) {
        int digit = n % 10;
        sum += digit;
        n /= 10;
    }

    cout << (number % sum == 0 ? "Yes" : "No") << endl;

    return 0;
}