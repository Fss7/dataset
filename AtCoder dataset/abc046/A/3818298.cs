using System;
using System.Linq;
class A{
  static void Main(){
    Console.WriteLine(Console.ReadLine().Split().ToArray().Distinct().Count());
  }
}