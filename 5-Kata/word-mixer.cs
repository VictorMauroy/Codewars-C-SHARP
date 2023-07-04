/* Description :
Move the first letter of each word to the end of it, 
then add "ay" to the end of the word. Leave punctuation marks untouched.

Examples
Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
Kata.PigIt("Hello world !");     // elloHay orldway !
*/

using System;
using System.Collections.Generic;

public class Kata
{
  public static string PigIt(string str)
  {
    string[] words = str.Split(' ');
    List<string> mixedWords = new List<string>();
    
    foreach(string word in words){
      if(word != "!"){
        mixedWords.Add(word.Substring(1) + word[0] + "ay");
      } else {
        mixedWords.Add("!");
      }
    }
    
    return String.Join(" ", mixedWords);
    
  }
}

/* Clever :
return string
    .Join(" ", str.Split(' ')
    .Select(w => w.Any(char.IsPunctuation) ? w : w.Substring(1) + w[0] + "ay"));

return Regex.Replace(str, @"((\S)(\S+))", "$3$2ay");
*/