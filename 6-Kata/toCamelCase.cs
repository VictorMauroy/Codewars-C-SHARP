/* Description :
Complete the method/function so that it converts dash/underscore delimited 
words into camel casing. The first word within the output should be capitalized 
only if the original word was capitalized (known as Upper Camel Case, also often 
referred to as Pascal case). The next words should be always capitalized.

Examples
"the-stealth-warrior" gets converted to "theStealthWarrior"

"The_Stealth_Warrior" gets converted to "TheStealthWarrior"

"The_Stealth-Warrior" gets converted to "TheStealthWarrior"
*/

using System;
using System.Collections.Generic;

public class Kata
{
  public static string ToCamelCase(string str)
  {
    List<char> camelCaseArr = new List<char>();
    
    for( int i =0; i < str.Length; i++ ) {
      if(str[i] == '-' || str[i] == '_') {
        camelCaseArr.Add(char.ToUpper(str[i+1]));
        i+= 1;
      }
      else 
      {
        camelCaseArr.Add(str[i]);
      }
    }
    return new string(camelCaseArr.ToArray());
  }
}

/* Best :
public static string ToCamelCase(string str)
{
    return string.Concat(str.Split('-','_').Select((s, i) => i > 0 ? char.ToUpper(s[0]) + s.Substring(1) : s));
}
*/