using System;

class Program
{
  /// <summary>
  ///   The main entry point for the application
  /// </summary>
  [STAThread]
  public static void Main(string[] args)
  {
    string a = Console.ReadLine();
    if (a.Length == 1)
    {
      if (a == "a") Console.WriteLine("-1");
      else Console.WriteLine("a");
    }
    else
    {
      Console.WriteLine("a");
    }
  }
}