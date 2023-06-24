/* Description :
    This time no story, no theory. The examples below show you how to write function accum:

    Examples:
    accum("abcd") -> "A-Bb-Ccc-Dddd"
    accum("RqaEzty") -> "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy"
    accum("cwAt") -> "C-Ww-Aaa-Tttt"
    The parameter of accum is a string which includes only letters from a..z and A..Z.
*/

using System;
public class Accumul 
{
	public static String Accum(string str) 
  {
    string[] result = new string[str.Length];    
    for(int i=0; i < str.Length; i++){
      for(int j=0; j <= i; j++) 
        result[i] += j == 0 ? char.ToUpper(str[i]) : char.ToLower(str[i]);
    }
    return String.Join("-", result);
  }
}