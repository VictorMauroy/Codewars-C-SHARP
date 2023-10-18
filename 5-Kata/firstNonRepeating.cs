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