using System;

class Program
{
  /// <summary>
  ///   1~x??????????x????????????�1??????
  /// </summary>
  [STAThread]
  public static void Main(string[] args)
  {
    int n = int.Parse(Console.ReadLine());
    int sum = 0;
    for (int i = 1; i <= n; i ++)//i?????1???????????
    {
      sum += 10000 * i;
    }
    Console.WriteLine(sum/n);
  }
}