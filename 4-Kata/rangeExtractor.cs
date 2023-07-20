// Ongoing

public class RangeExtraction
{
    public static string Extract(int[] numArray)
    {
      string result = numArray[0].ToString();
      int range = 0; 
      
      for(int i = 1; i < numArray.Length; i++)
      {
        if(numArray[i-1]+1 == numArray[i]){
          range++;
          if(range < 2 && i == numArray.Length-1){
            result += "," + numArray[i];
          } else if(i == numArray.Length-1){
           result += "-" + numArray[i];
          }
        } 
        else {
          if(range > 1){
            range = 0;
            result += "-" + numArray[i-1] + "," + numArray[i];
          } else if(range == 1) 
          {
            result += "," + numArray[i-1] + "," + numArray[i];
          } 
          else 
          {
            result += "," + numArray[i];
          }
        }
      }
      
      return result;
    }
}