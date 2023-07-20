/* Description:
A format for expressing an ordered list of integers is to use a comma separated list of either

individual integers
or a range of integers denoted by the starting integer separated from the end integer in the range by a dash, '-'. 
The range includes all integers in the interval including both endpoints. It is not considered a range unless it spans at least 3 numbers. For example "12,13,15-17"
Complete the solution so that it takes a list of integers in increasing order and returns a correctly formatted string in the range format.

Example:

solution([-10, -9, -8, -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20]);
// returns "-10--8,-6,-3-1,3-5,7-11,14,15,17-20"
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


/* best practices */
public class RangeExtraction
{
    public int Value, Count;
    public int NextValue => Value + Count;

    public RangeExtraction(int value)
    {
        Value = value;
        Count = 1;
    }

    public override string ToString()
        => Count == 1 ? $"{Value}" :
           Count == 2 ? $"{Value},{Value + 1}" :
                        $"{Value}-{NextValue-1}";

    public static string Extract(int[] args)
    {
        var list = new List<RangeExtraction>();
        
        foreach (var n in args)
            if (list.LastOrDefault()?.NextValue == n) list.Last().Count++;
            else list.Add(new RangeExtraction(n));

        return string.Join(",", list);
    }
}




using System.Text;
public class RangeExtraction {
    public static string Extract(int[] args) {
        var result = new StringBuilder();
        for (int i = 0; i < args.Length; i++) {
            var startAt = args[i];
            while (i+1 < args.Length && args[i+1] - args[i] == 1) ++i;
            var endAt = args[i];
            
            if (endAt == startAt) {
                result.Append(startAt+",");
            } else if (endAt - startAt == 1) {
                result.Append($"{startAt},{endAt},");
            } else {
                result.Append($"{startAt}-{endAt},");
            }
        }
        return result.ToString().TrimEnd(',');
    }
}