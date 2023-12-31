using System;
using System.Collections.Generic;
using System.Linq;

namespace Project {
    class Program {
        static void Main(string[] args) {
            var cr = new CR();
            var K = cr.i;
            var S = cr.i;

            var ans = 0;
            for (int x = 0; x <= K; x++) {
                for (int y = x; y <= K; y++) {
                    for (int z = y; z <= K; z++) {
                        if (x + y + z == S) {
                            if (x == y && x == z)
                                ans++;
                            else if (x == y || x == z || y == z)
                                ans += 3;
                            else
                                ans += 6;
                        }
                    }
                }
            }
            Console.WriteLine(ans);
        }

        private class CR {
            System.IO.TextReader _r;
            Queue<string> _d;
            public CR() { _r = Console.In; _d = new Queue<string>(); }
            string Read() {
                while (_d.Count == 0)
                    foreach (var v in _r.ReadLine().Split(' '))
                        if (v != "")_d.Enqueue(v);
                return _d.Dequeue();
            }
            public int i { get { return int.Parse(Read()); } }
            public string s { get { return Read(); } }
        }
    }
}