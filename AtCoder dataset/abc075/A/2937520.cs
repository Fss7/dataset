using System;

class Program
{
  static void Main(string[] args)
  {
    string[] input = Console.ReadLine().Split(' ');
    int a = int.Parse(input[0]);
    int b = int.Parse(input[1]);
    int c = int.Parse(input[2]);
    
    if(a == b) Console.WriteLine("{0}", c);
    if(a == c) Console.WriteLine("{0}", b);
    if(b == c) Console.WriteLine("{0}", a);
  }
}