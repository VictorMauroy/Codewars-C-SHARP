/* Description :
Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric 
digits that occur more than once in the input string. The input string can be assumed to contain only 
alphabets (both uppercase and lowercase) and numeric digits.

Example
"abcde" -> 0 # no characters repeats more than once
"aabbcde" -> 2 # 'a' and 'b'
"aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
"indivisibility" -> 1 # 'i' occurs six times
"Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
"aA11" -> 2 # 'a' and '1'
"ABBA" -> 2 # 'A' and 'B' each occur twice
*/

using System;
using System.Linq;
using System.Collections.Generic;

public class Kata
{
  public static int DuplicateCount(string str)
  {
    IDictionary<char, int> characterOccurence = new Dictionary<char, int>();
    
    for(int i = 0; i < str.Length; i++){
      char currentChar = Char.ToLower(str[i]);
      if(characterOccurence.TryGetValue(currentChar, out _)){
        characterOccurence[currentChar] ++;
      } else {
        characterOccurence[currentChar] = 1;
      }
    }
    
    int sum = 0;
    for(int i =0; i < characterOccurence.Count; i++) 
    {
        if(characterOccurence.ElementAt(i).Value > 1) 
            sum++;
    }
    return sum;
  }
}

// Best: return str.ToLower().GroupBy(c => c).Where(g => g.Count() > 1).Count();