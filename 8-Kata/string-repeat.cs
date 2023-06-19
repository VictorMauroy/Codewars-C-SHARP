/* Description :
Write a function that accepts an integer n and a string s as parameters, 
and returns a string of s repeated exactly n times.

Examples (input -> output)
6, "I"     -> "IIIIII"
5, "Hello" -> "HelloHelloHelloHelloHello"
*/

namespace Solution
{
    using System;
    using System.Linq;

  public static class Program
  {
    public static string RepeatStr(int count, string str)
    => String.Join("", Enumerable.Repeat(str, count));
  }
}