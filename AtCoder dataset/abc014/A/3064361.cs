using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {

            // ??
            int iA = int.Parse(Console.ReadLine().Trim());
            int iB = int.Parse(Console.ReadLine().Trim());

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // ??
            int iDf = iA % iB;
            if (iDf > 0) { iDf = iB - iDf; }

            //??
            Console.WriteLine("{0}", iDf.ToString());

            sw.Stop();
#if DEBUG
            Console.WriteLine("{0}", sw.Elapsed.ToString());
            Console.WriteLine("?????????????????????");
            Console.ReadKey();
#endif

    }


}