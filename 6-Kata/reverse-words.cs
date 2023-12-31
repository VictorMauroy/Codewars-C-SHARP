/* Description :
Write a function that takes in a string of one or more words, and returns the same string, but with all five or more letter words reversed (Just like the name of this Kata). Strings passed in will consist of only letters and spaces. Spaces will be included only when more than one word is present.

Examples:

spinWords( "Hey fellow warriors" ) => returns "Hey wollef sroirraw" 
spinWords( "This is a test") => returns "This is a test" 
spinWords( "This is another test" )=> returns "This is rehtona test"
*/

using System.Collections.Generic;
using System.Linq;
using System;

public class Kata
{
  public static string SpinWords(string sentence)
  {
    var words = sentence
      .Split(" ")
      .Select(
        word => word.Length >= 5 ? ReverseWord(word) : word
      );
    
    return String.Join(' ', words);
  }
  
  public static string ReverseWord(string word){
    char[] reverseWord = word.ToCharArray();
    Array.Reverse(reverseWord);
    return String.Concat(reverseWord);
  }
}

/* Clever one :
public static string SpinWords(string sentence)
{
    return String.Join(" ", sentence.Split(' ').Select(str => str.Length >= 5 ? new string(str.Reverse().ToArray()) : str));
}
*/