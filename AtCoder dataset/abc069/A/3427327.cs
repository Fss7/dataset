using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
 
public class Hello{
    public static void Main(){
        string[] input = ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
//        int b = int.Parse(input[2]);
//        string temp = ReadLine();
//        int a = int.Parse(ReadLine());
        WriteLine((n-1)*(m-1));
    }
}