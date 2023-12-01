/* Description :
Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, 
otherwise returns false.

Notes:

Only lower case letters will be used (a-z). No punctuation or digits will be included.
Performance needs to be considered.
Examples
scramble('rkqodlw', 'world') ==> True
scramble('cedewaraaossoqqyt', 'codewars') ==> True
scramble('katas', 'steak') ==> False
*/

// First try that almost works :
public static bool Scramble(string str1, string str2) 
{
    var orderedStr = str2;
    Console.WriteLine(string.Concat(orderedStr));
    
    var intersection = str1.Intersect(str2);
    Console.WriteLine(string.Concat(intersection));
    
    return orderedStr.Count() == intersection.Count();
}

// Final answer :
using System.Collections.Generic;
using System;
using System.Linq;

public class Scramblies 
{
    
    public static bool Scramble(string str1, string str2) 
    {
      int matchCount = 0;
      List<char> letters = str1.Select(c => c).ToList();
      
      foreach(char c in str2){
        if(letters.Contains(c)){
          matchCount++;
          letters.Remove(c);
        }
      }
      
      return matchCount == str2.Length;
    }
}




// Solutions by others :
public static bool Scramble(string str1, string str2) 
{
    return str2.All(x=>str1.Count(y=>y==x)>=str2.Count(y=>y==x));
}


//Mine but simplified
public static bool Scramble(string str1, string str2)
{
    var possible = str1.ToList();

    foreach (var c in str2)
    {
        if (!possible.Remove(c))
            return false;
    }

    return true;
}


public static bool Scramble(string str1, string str2) 
{
    return str2.GroupBy(c => c).All(g => str1.Where(c => c == g.Key).Count() >= g.Count());
}