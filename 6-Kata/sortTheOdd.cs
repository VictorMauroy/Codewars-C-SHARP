/*
Task
You will be given an array of numbers. 
You have to sort the odd numbers in ascending order while leaving the even numbers at their original positions.

Examples
[7, 1]  =>  [1, 7]
[5, 8, 6, 3, 4]  =>  [3, 8, 6, 5, 4]
[9, 8, 7, 6, 5, 4, 3, 2, 1, 0]  =>  [1, 8, 3, 6, 5, 4, 7, 2, 9, 0]
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static int[] SortArray(int[] array)
    {
        List<int> oddIndexes = array.Where(x => x % 2 != 0).OrderBy(x => x).ToList();    
        int i = 0;
        return array.Select(num => num % 2 != 0 ? oddIndexes[i++] : num).ToArray();
    }
}