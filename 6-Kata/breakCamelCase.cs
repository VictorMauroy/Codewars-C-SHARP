/* Description :
Complete the solution so that the function will break up camel casing, using a space between words.

Example
"camelCasing"  =>  "camel Casing"
"identifier"   =>  "identifier"
""             =>  ""
*/

using System.Linq;

public class Kata
{
  public static string BreakCamelCase(string str)
  => str.Aggregate("", (acc, c) => acc + (char.IsUpper(c) ? " " + c : c));
} 
// Note: I wanted to try that solution but it should be more optimized to use String Builders.


/* Other ideas */

public class Kata
{
  public static string BreakCamelCase(string str) =>
    new Regex("([A-Z])").Replace(str, " $1");
}

public static string BreakCamelCase(string str)
{
    return string.Concat(str.Select(c => Char.IsUpper(c) ? " " + c : c.ToString()));
}


// Note2: yeah, like that one
public static string BreakCamelCase(string str)
{
    var res = new StringBuilder();
    foreach (var ch in str)
    {
        if (ch >= 'A' && ch <= 'Z')
        {
            res.Append(" ");
        }
        res.Append(ch);
    }
    return res.ToString();
}