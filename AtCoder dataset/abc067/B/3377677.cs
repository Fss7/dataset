using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
            // ??
            string[] sS = Console.ReadLine().Trim().Split(' ');
            int iN = int.Parse(sS[0]);
            int iK = int.Parse(sS[1]);
            sS = Console.ReadLine().Trim().Split(' ');
            List<int> lstInp = new List<int>();
            for (int i = 0; i < sS.Length; i++) { lstInp.Add(int.Parse(sS[i])); }

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // ??
            lstInp.Sort(delegate (int mca1, int mca2) { return (int)(mca2 - mca1); });      // ??
            int iOut = 0;
            for (int i = 0; i < iK; i++) { iOut += lstInp[i]; }

            //??
            Console.WriteLine("{0}", iOut.ToString().Trim());

            sw.Stop();
#if DEBUG
            Console.WriteLine();
            Console.WriteLine("{0}", sw.Elapsed.ToString());
            Console.WriteLine("?????????????????????");
            Console.ReadKey();
#endif
    }
}