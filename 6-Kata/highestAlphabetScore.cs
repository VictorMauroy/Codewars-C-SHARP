/* Description :
Given a string of words, you need to find the highest scoring word.

Each letter of a word scores points according to its position in the alphabet: a = 1, b = 2, c = 3 etc.

For example, the score of abad is 8 (1 + 2 + 1 + 4).

You need to return the highest scoring word as a string.

If two words score the same, return the word that appears earliest in the original string.

All letters will be lowercase and all inputs will be valid.
*/

using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static string High(string sentence)
  {
    List<string> words = sentence.Split(' ').ToList();
    int highestScore = 0;
    string bestWord = "";
    
    foreach(string word in words) {
      int score = word
                  .Select(c => (int)c - 96) // -96 to reset ASCII position
                  .Aggregate((acc, c) => acc + c );
      
      if(score > highestScore) {
        highestScore = score;
        bestWord = word;
      }
    }
    
    return bestWord;
  }
}

// Answers by other peoples :
public static string High(string s)
{
    return s.Split(' ').OrderBy(a => a.Select(b => b - 96).Sum()).Last();
}
// Note : that was my original idea but I forgot to reset ASCII score at the beginning.