/* Description
You are given an array (which will have a length of at least 3, but could be very large) containing integers. 
The array is either entirely comprised of odd integers or entirely comprised of even integers except for a single integer N.
Write a method that takes the array as an argument and returns this "outlier" N.

Examples
[2, 4, 0, 100, 4, 11, 2602, 36]
Should return: 11 (the only odd number)

[160, 3, 1719, 19, 11, 13, -21]
Should return: 160 (the only even number)
*/

using System.Collections.Generic;
using System.Linq;
using System;

public class Kata
{
  public static int Find(int[] integers)
  {
    List<int> evenNumbers = integers.Where(n => n % 2 == 0).ToList();
    List<int> oddNumbers = integers.Where(n => n % 2 != 0).ToList();
    if(evenNumbers.Count > oddNumbers.Count)
      return oddNumbers[0];
    return evenNumbers[0];
  }
}




/* Others solutions (not by me) */
public static int Find(int[] integers)
{
    return integers.Count(a=>a%2==1)>1?integers.Single(a=>a%2==0):integers.Single(a=>a%2==1);
}
