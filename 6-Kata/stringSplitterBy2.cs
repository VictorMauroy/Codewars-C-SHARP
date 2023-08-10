/* Description
Complete the solution so that it splits the string into pairs of two characters. 
If the string contains an odd number of characters then it should replace 
the missing second character of the final pair with an underscore ('_').

Examples:

* 'abc' =>  ['ab', 'c_']
* 'abcdef' => ['ab', 'cd', 'ef']
*/

using System;
using System.Linq;
using System.Collections.Generic;

public class SplitString
{
  public static string[] Solution(string str)
  {
    int index = 0;
    return str
        .Where(_ => index++ % 2 == 0)
        .Select( i => "" + str[index-1] + (index < str.Length ? str[index] : "_") )
        .ToArray();
  } 
}



/* Other solutions (not by me)*/
public static string[] Solution(string str)
{
    return Regex.Matches(str + "_", @"\w{2}").Select(x => x.Value).ToArray();
}