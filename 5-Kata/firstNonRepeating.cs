/* Description :
Write a function named first_non_repeating_letter that takes a string input, 
and returns the first character that is not repeated anywhere in the string.

For example, if given the input 'stress', the function should return 't', 
since the letter t only occurs once in the string, and occurs first in the string.

As an added challenge, upper- and lowercase letters are considered the same character, 
but the function should return the correct case for the initial letter. For example, the input 'sTreSS' should return 'T'.

If a string contains all repeating characters, it should return an empty string ("") or None -- see sample tests.
*/

using System;
using System.Collections.Generic;

public class Kata
{
  public static string FirstNonRepeatingLetter(string s)
  {
    Dictionary<char, int> characterOccurence = new Dictionary<char, int>();
    
    for(int i = 0; i < s.Length; i++){
      char currentChar = s[i];
      
      if(characterOccurence.TryGetValue(Char.ToLower(currentChar), out _)){
        characterOccurence[Char.ToLower(currentChar)] ++;
      } 
      else if(characterOccurence.TryGetValue(Char.ToUpper(currentChar), out _)){
        characterOccurence[Char.ToUpper(currentChar)] ++;
      } 
      else {
        characterOccurence.Add(currentChar, 1);
      }
    }
    
    foreach(KeyValuePair<char, int> kvp in characterOccurence){
      if(kvp.Value == 1)
        return kvp.Key.ToString();
    }
    
    return "";
  }
}


/* Interesting ideas */

public static string FirstNonRepeatingLetter(string s)
{
    return s.GroupBy(char.ToLower)
        .Where(gr => gr.Count() == 1)
        .Select(x => x.First().ToString())
        .DefaultIfEmpty("")
        .First();
}

public static string FirstNonRepeatingLetter(string s)
{
    return s.GroupBy(c => c.ToString(), StringComparer.InvariantCultureIgnoreCase)
        .Where(g => g.Count() == 1)
        .Select(g => g.Key)
        .DefaultIfEmpty("")
        .FirstOrDefault();
}