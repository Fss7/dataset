using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
            // ??
            string sS = Console.ReadLine().Trim();

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // ??
            string sOut = "None";
            for (int i = 'a'; i <= 'z'; i++)
            {
                if (!sS.Contains((char)i)) { sOut = ((char)i).ToString(); break; };
            }

            //??
            Console.WriteLine("{0}", sOut.ToString().Trim());
            sw.Stop();
#if DEBUG
            Console.WriteLine();
            Console.WriteLine("{0}", sw.Elapsed.ToString());
            Console.WriteLine("?????????????????????");
            Console.ReadKey();
#endif
    }
}