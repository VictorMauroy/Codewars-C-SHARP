/* Description 
A pangram is a sentence that contains every single letter of the alphabet at least once. 
For example, the sentence "The quick brown fox jumps over the lazy dog" is a pangram, 
because it uses the letters A-Z at least once (case is irrelevant).

Given a string, detect whether or not it is a pangram. Return True if it is, False if not. Ignore numbers and punctuation.
*/

using System;
using System.Linq;

public static class Kata
{
  public static bool IsPangram(string str)
  {
    string alphabet = "abcdefghijklmnopqrstuvwxyz";
    bool[] matchingChar = new bool[alphabet.Length];
    
    for(int i =0; i < str.Length; i++){
      int letterIndex = alphabet.IndexOf(char.ToLower(str[i]));
      if(letterIndex != -1)
        matchingChar[letterIndex] = true;
    }
    
    return (matchingChar.ToList().Where(b => b).Count()) == alphabet.Length;
  }
}




/* Other solutions (not by me) */
public static bool IsPangram(string str)
{
    return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;
}

public static bool IsPangram(string str)
{
    return "abcdefghijklmnopqrstuvwxyz".All(x => str.ToLower().Contains(char.ToLower(x)));
}