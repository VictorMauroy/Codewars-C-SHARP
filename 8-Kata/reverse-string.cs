/* Description :
Complete the solution so that it reverses the string passed into it.

'world'  =>  'dlrow'
'word'   =>  'drow'
*/

using System;

public static class Kata
{
    public static string Solution(string str) 
    {
    char[] charArray = str.ToCharArray();
    Array.Reverse(charArray);
    return string.Join("", charArray);
    }
}

// Best practice : return new string(str.ToArray().Reverse().ToArray());
// A better one : return string.Concat(str.Reverse());