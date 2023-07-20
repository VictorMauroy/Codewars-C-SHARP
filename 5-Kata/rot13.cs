/* Description :
ROT13 is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in the alphabet. 
ROT13 is an example of the Caesar cipher.

Create a function that takes a string and returns the string ciphered with Rot13. 
If there are numbers or special characters included in the string, they should be returned as they are. 
Only letters from the latin/english alphabet should be shifted, like in the original Rot13 "implementation".
*/

using System;
using System.Linq;
using System.Collections.Generic;

public class Kata
{
  public static string Rot13(string message)
  => String.Join("", message.Select(c => Char.IsLetter(c) ? ((char)(((int)Char.ToUpper(c) - 65 + 13) < 26 ? (int)c + 13 : (int)c + 13 - 26)) : c ));
}

// Extended version:

using System;

public class Kata
{
  public static string Rot13(string message)
  {
    string messageRot13 = "";
    foreach(char c in message){
      char updatedChar = c;
      if(Char.IsLetter(c)){
        updatedChar = 
          (char)(((int)Char.ToUpper(c) - 65 + 13) < 26 ? (int)c + 13 : (int)c + 13 - 26);
      } 
      messageRot13 += updatedChar;
    }
    
    return messageRot13;
  }
}




/* Best:

public static string Rot13(string message)
{
    string result = "";
    foreach (var s in message)
    {
        if ((s >= 'a' && s <= 'm') || (s >= 'A' && s <= 'M'))
            result += Convert.ToChar((s + 13)).ToString();
        else if ((s >= 'n' && s <= 'z') || (s >= 'N' && s <= 'Z'))
            result += Convert.ToChar((s - 13)).ToString();
        else result += s;
    }
    return result;
}
*/