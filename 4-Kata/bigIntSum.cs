// That one was way too easy for a level 4-kata. I guess it's thanks to the BigInteger class in C#.

/* Description:
Given the string representations of two integers, return the string representation of the sum of those integers.

For example:

sumStrings('1','2') // => '3'
A string representation of an integer will contain no characters besides the ten numerals "0" to "9".

I have removed the use of BigInteger and BigDecimal in java

Python: your solution need to work with huge numbers (about a milion digits), converting to int will not work.
*/

using System;
using System.Numerics;
public static class Kata
{
    public static string sumStrings(string a, string b)
    {
      BigInteger firstNum = a != string.Empty ? BigInteger.Parse(a) : 0;
      BigInteger secondNum = b != string.Empty ? BigInteger.Parse(b) : 0;
      return (firstNum + secondNum).ToString();
    }
}





// Solutions by others:
public static string sumStrings(string a, string b)
{
    BigInteger.TryParse(a, out BigInteger bigA);
    BigInteger.TryParse(b, out BigInteger bigB);

    return (bigA + bigB).ToString();
} // Safer


//That's interesting how the guy modified the parameters (two strings to an array of strings).
public static string sumStrings(params string[] numbers)
{
    return numbers
    .Select(s => String.IsNullOrEmpty(s)
        ? BigInteger.Zero
        : BigInteger.Parse(s)).Aggregate((a, b) => a + b)
    .ToString();
}