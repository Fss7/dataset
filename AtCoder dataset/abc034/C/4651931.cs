using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Convert;
using static System.Math;
//using static System.Globalization.CultureInfo;

class Program
{ 
    static void Main(string[] args)
    {
        var wh = Input.ar;
        var com = new Calculation.Combination(wh[0] + wh[1] - 2);
        WriteLine(com.Comb(wh[0] + wh[1] - 2, wh[0] - 1));
    }
}

public class Input
{
    public static string read => ReadLine();
    public  static int[] ar => Array.ConvertAll(read.Split(' '), int.Parse);
    public  static int num => ToInt32(read);
    public static long[] arL => Array.ConvertAll(read.Split(' '), long.Parse);
    public  static long numL => ToInt64(read);
    public static int[][] twodim(int num)
        => Enumerable.Repeat(0, num).Select(v => ar).ToArray();
    public static long[][] twodimL(int num)
        => Enumerable.Repeat(0, num).Select(v => arL).ToArray();
    public const double eps = 1e-11;
    public  const string Alfa = "abcdefghijklmnopqrstuvwxyz";
    public  const int MOD = 1000000007;
}

public class Calculation
{
    public static int LCM(int num1, int num2)
    {
        return num1 / GCD(num1, num2) * num2;
    }

    public static long LCM(long num1, long num2)
    {
        return num1 / GCD(num1, num2) * num2;
    }

    public static int GCD(int num1, int num2)
    {
        return num1 < num2 ? GCD(num2, num1) :
            num2 > 0 ? GCD(num2, num1 % num2) : num1;
    }

    public static long GCD(long num1, long num2)
    {
        return num1 < num2 ? GCD(num2, num1) :
            num2 > 0 ? GCD(num2, num1 % num2) : num1;
    }

    private static int Multiple(int num1, int num2)
        => (int)(BigMul(num1, num2) % Input.MOD);
    
    public static int Pow(int m,int n)
    {
        if (n == 0) return 1;
        if (n % 2 == 0) return Pow(Multiple(m, m), n / 2);
        else return Multiple(Pow(Multiple(m, m), n / 2), m);
    }

    public static int Div(int a, int b)
        => Multiple(a, Pow(b, Input.MOD - 2));

    public class Combination
    {
        private int[] _fac;
        public Combination(int num)//??????
        {
            _fac = new int[num + 1];
            _fac[0] = 1;
            for (var i = 1; i <= num; i++)
                _fac[i] = Multiple(_fac[i - 1], i);
        }
        public int Comb(int n,int r)
        {
            if (n < r) return 0;
            if (n == r) return 1;
            var calc = _fac[n];
            calc = Div(calc, _fac[r]);
            calc = Div(calc, _fac[n - r]);
            return calc;
        }
    }
}