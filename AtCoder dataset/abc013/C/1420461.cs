using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    struct ??????
    {
        public long ??? { get; private set; }
        public long ?? { get; private set; }

        public ??????(long ???, long ??)
        {
            this.??? = ???;
            this.?? = ??;
        }
    }

    static void Main(string[] args)
    {
        string[] str = Console.ReadLine().Split(' ');
        var ??????? = int.Parse(str[0]); //4
        var ??? = long.Parse(str[1]); //5
        str = Console.ReadLine().Split(' ');
        var ???????????? = long.Parse(str[4]); //4
        var ???????? = long.Parse(str[0]); //100
        var ???????????? = long.Parse(str[1]) + ????????????; //4
        var ???????? = long.Parse(str[2]); //60
        var ???????????? = long.Parse(str[3]) + ????????????; //1

        long ?????????????? = ???????????? * ???????; //16
        var ?????? = ?????????????? - ???; // 11

        var ????? = long.MaxValue;

        //var ??????????????? = ?????????????(???????, ????????, ????????????);

        for (var ???????? = 0; ???????? <= ???????; ????????++)
        {
            long ???????? = ???????? * ????????;

            if (???????? > ?????) break;

            var ??????????????? = ???????? * ???????????? - ??????;

            var ???? = ??????? - ????????;

            var ???????????????? = Math.Max(0,(int)Math.Ceiling(0.000000001 + (double)-??????????????? / ????????????));

            if (???????????????? > ????) continue;

            var ???? = ???????? * ???????????????? + ????????;

            if (???? > ?????) continue;

             ????? = ????;
        }
        Console.WriteLine(?????);
    }

    static ??????[] ?????????????(long ??, long ?????, long ?????????)
    {
        ??????[] ???????????? = new ??????[?? + 1];
        ????????????[0] = new ??????(0, 0);

        for (var ????? = 1; ????? <= ??; ?????++)
        {
            ????????????[?????] = new ??????(????????????[????? - 1].??? + ?????????, ????????????[????? - 1].?? + ?????);
        }

        return ????????????;
    }
}