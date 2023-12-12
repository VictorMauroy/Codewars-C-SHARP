/* Description:
In this example you have to validate if a user input string is alphanumeric. 
The given string is not nil/null/NULL/None, so you don't have to check that.

The string has the following conditions to be alphanumeric:

At least one character ("" is not valid)
Allowed characters are uppercase / lowercase latin letters and digits from 0 to 9
No whitespaces / underscore
*/


using System.Text.RegularExpressions;

public class Kata
{
  public static bool Alphanumeric(string str)
  => (str != "") ? !Regex.IsMatch(str, @"(\W|_)") : false;
}



// Other solutions (not by me)

public static bool Alphanumeric(string str)
{
    return str.All(c => Char.IsLetterOrDigit(c)) && !string.IsNullOrEmpty(str);
}

public class Kata
{
  public static bool Alphanumeric(string str) =>
    new Regex("^[a-zA-Z0-9]+$").Match(str).Success;
}
// I knew I could have done it without the str != "" condition