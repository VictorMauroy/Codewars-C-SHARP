/* Description :
The goal of this exercise is to convert a string to a new string where each character 
in the new string is "(" if that character appears only once in the original string, or ")" 
if that character appears more than once in the original string. Ignore capitalization when determining if a character is a duplicate.

Examples
"din"      =>  "((("
"recede"   =>  "()()()"
"Success"  =>  ")())())"
"(( @"     =>  "))((" 
*/

using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static string DuplicateEncode(string word)
  {
    word = word.ToLower();
    Dictionary<char, int> characterOccurence = new Dictionary<char, int>();
    
    for(int i = 0; i < word.Length; i++){
      char currentChar = word[i];

      if(characterOccurence.TryGetValue(currentChar, out _)){
        characterOccurence[currentChar] ++;
      }
      else {
        characterOccurence.Add(currentChar, 1);
      }
    }
    
    return string.Concat(word
               .Select(c => characterOccurence[c] > 1 ? ")" : "(").ToList());
  }
}


/* Interesting ideas */
public static string DuplicateEncode(string word)
{  
    return new string(word.ToLower().Select(ch => word.ToLower().Count(innerCh => ch == innerCh) == 1 ? '(' : ')').ToArray());
} //One line but uh... that seems pretty heavy
