

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