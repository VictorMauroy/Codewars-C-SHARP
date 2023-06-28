/* Description :
Write a function that takes an integer as input, and returns the number of bits that are equal 
to one in the binary representation of that number. You can guarantee that input is non-negative.

Example: The binary representation of 1234 is 10011010010, so the function should return 5 in this case
*/

using System;
using System.Linq;

public class Kata
{
  public static int CountBits(int number)
  {
    string binaryValue = Convert.ToString(number, 2);
    string[] bitArrayStr = binaryValue.ToCharArray().Select(c => c.ToString()).ToArray();
    var bitArrayNum = bitArrayStr.Select(
        int.Parse
    );
    return bitArrayNum.Aggregate(
        0, 
        (acc, num) => acc + num
    );
  }
}

/* Best :
return Convert.ToString(n, 2).Count(x => x == '1');
*/