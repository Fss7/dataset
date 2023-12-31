#include <iostream>
using namespace std;

int main() {
    int N, M, Q, l[200000], r[200000], p[100000], q[100000], map[501][501] = {}, sum_map[501][501] = {};
    cin >> N >> M >> Q;
    for (int i = 0; i < M; i++) {
        cin >> l[i] >> r[i];
        map[l[i]][r[i]]++;
    }
    for (int i = 0; i < Q; i++) cin >> p[i] >> q[i];

    for (int i = 1; i <= N; i++) {
        for (int j = 1; j <= N; j++) {
            sum_map[i][j] = sum_map[i][j - 1] + map[i][j];
        }
    }
    for (int num = 0; num < Q; num++) {
        int ans = 0;
        for (int i = p[num]; i <= q[num]; i++) {
            ans += sum_map[i][q[num]] - sum_map[i][p[num] - 1];
        }
        cout << ans << endl;
    }
}