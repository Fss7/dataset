using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Test
{	
    public static void Main()
	{
	    double [] n = Console.ReadLine().Split(' ').Select(s=>double.Parse(s)).ToArray();
	    
	    if(n[0]+n[1] > n[2]+n[3]) Console.WriteLine("Left");
	    else if(n[0]+n[1] < n[2]+n[3]) Console.WriteLine("Right");
	    else Console.WriteLine("Balanced");
	    
	} 
}