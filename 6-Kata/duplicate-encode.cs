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