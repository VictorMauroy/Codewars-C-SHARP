/* Description :
Write a function that accepts an array of 10 integers (between 0 and 9), that returns a string of those numbers in the form of a phone number.

Example
Kata.CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}) // => returns "(123) 456-7890"
The returned format must be correct in order to complete this challenge.

Don't forget the space after the closing parentheses!
*/

using System;
public class Kata
{
  public static string CreatePhoneNumber(int[] numbers)
  {
    string firstPart = '(' + String.Join("", numbers[0..3]) + ") ";
    string secondPart = String.Join("", numbers[3..6]) + '-' + String.Join("", numbers[6..10]);
    return firstPart + secondPart;
  }
}

/* Interesting solutions :

return long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");

return string.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}",numbers.Select(x=>x.ToString()).ToArray());

public static string CreatePhoneNumber(int[] numbers) =>
    new Regex("(...)(...)(....)").Replace(String.Concat(numbers), "($1) $2-$3");
*/