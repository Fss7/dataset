using System;

namespace AtCoderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // ??????1???
            string input = Console.ReadLine();

            // N,M?????
            int n = int.Parse(input.Split(' ')[0]);
            int m = int.Parse(input.Split(' ')[1]);

            // ????(0 or 1)???????????????????
            for(int i = 0; i < 2; i++)
            {
                // ?????????????
                int n2 = n - i;

                // ????????????
                int m2 = m - 3 * i;

                // ????????????????????????
                if(m2 % 2 == 1)
                {
                    continue;
                }

                // ?????????
                int adultLeg = 2 * n2;

                // ???????
                int babyNum = (m2 - adultLeg) / 2;

                // ?????????????
                if (n2 - babyNum >= 0 && babyNum >= 0)
                {
                    Console.WriteLine((n2 - babyNum) + " " + i + " " + babyNum);
                    return;
                }
            }

            // ?????????????
            Console.WriteLine("-1 -1 -1");
        }
    }
}