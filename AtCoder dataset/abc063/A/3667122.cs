using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Test
{	
    public static void Main()
	{
	    int[] nums = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

        if(nums[0]+nums[1] >= 10) Console.WriteLine("error");
        else Console.WriteLine(nums[0]+nums[1] );
	} 
}