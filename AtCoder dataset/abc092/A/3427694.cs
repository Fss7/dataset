using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
 
public class Hello{
    public static void Main(){
/*        string[] input = ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int a = int.Parse(input[2]);
//        int b = int.Parse(input[3]);*/
//        string temp = ReadLine();
        int a = int.Parse(ReadLine());
        int b = int.Parse(ReadLine());
        int c = int.Parse(ReadLine());
        int d = int.Parse(ReadLine());
//        string a = ReadLine();
//        string b = ReadLine();
//        string c = ReadLine();
        a = Min(a,b);
        c = Min(c,d);
        WriteLine(a+c);
    }
}