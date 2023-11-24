/* Description :
Given an array (arr) as an argument complete the function countSmileys that should return the total number of smiling faces.

Rules for a smiling face:

Each smiley face must contain a valid pair of eyes. Eyes can be marked as : or ;
A smiley face can have a nose but it does not have to. Valid characters for a nose are - or ~
Every smiling face must have a smiling mouth that should be marked with either ) or D
No additional characters are allowed except for those mentioned.

Valid smiley face examples: :) :D ;-D :~)
Invalid smiley faces: ;( :> :} :]

Example
countSmileys([':)', ';(', ';}', ':-D']);       // should return 2;
countSmileys([';D', ':-(', ':-)', ';~)']);     // should return 3;
countSmileys([';]', ':[', ';*', ':$', ';-D']); // should return 1;
Note
In case of an empty array return 0. You will not be tested with invalid input (input will always be an array). 
Order of the face (eyes, nose, mouth) elements will always be the same.
*/

// Final code
public static int CountSmileys(string[] smileys) 
  => smileys.Aggregate( 
    0, (acc, smileyStr) => acc + (Regex.IsMatch(smileyStr, @"(:|;)(-|~)?(\)|D)") ? 1 : 0)
  );



// FIRST TRY
public static class Kata
{
  public static int CountSmileys(string[] smileys) 
  {    
    int validCount = 0;
    for(int i = 0; i < smileys.Length; i++) {
      
      if(smileys[i][0] == ':' || smileys[i][0] == ';'){ // Has valid eyes ?
        
        if(smileys[i].Length > 2 && smileys[i].Length < 4){ // Has nose ?
          if((smileys[i][1] == '-' || smileys[i][1] == '~') && 
              (smileys[i][2] == ')' || smileys[i][2] == 'D')) { // Mouth and nose valid ? 
            validCount++;
          }
          else if(smileys[i].Length == 2 && 
            (smileys[i][1] == ')' || smileys[i][1] == 'D')) { // Valid mouth ?
          validCount++; 
          }
        }
      }
    }
    return validCount;
  }
}
