/* Description:

*/

public class RangeExtraction
{
    public static string Extract(int[] numArray)
    {
      string result = "";
      int range = 0;
      int rangeStart = 0;
      
      for(int i = 0; i < numArray.Length; i++)
      {
        //When it reach the end of the array.
        if(i+1 == numArray.Length) {
          if(range > 1){
            result += rangeStart + "-" + numArray[i];
          } else if(range > 0) {
            result += numArray[i-1] + "," + numArray[i];
          } else {
            result += numArray[i];
          }
          break;
        }
        
        if(numArray[i]+1 == numArray[i+1])
        {
          if(range == 0){
            rangeStart = numArray[i];
          }
          range++;
        } 
        else 
        {
          if(range == 0){
            result += numArray[i] + ",";
          } else if(range == 1){
            result += numArray[i-1] + "," + numArray[i] + ",";
          } else {
            result += rangeStart + "-" + numArray[i]  + ",";
          }
          range = 0;
        }
        
      }
      
      return result;
    }
}