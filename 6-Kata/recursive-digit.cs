using System;
using System.Linq;

public class Number
{
  public static int DigitalRoot(long num)
  {
    if(num < 10) return num;
    
    string[] digitsCharacters = num
      .ToString()
      .Split("");
    
    int digitSum = digitsCharacters
      .Select(str => Convert.ToInt32(str))
      .Aggregate(0, (acc, num) => acc + num);
    
    return DigitalRoot( digitSum );
  }
}

using System;
using System.Linq;
using System.Collections.Generic;

public class Number
{
  public static int DigitalRoot(long num)
  {
    if(num < 10) return (int)num;
    
    List<int> waitingQueue = new List<int>();
    waitingQueue.Add((int)num);
    
    while( waitingQueue.Count > 0 ){
      var digits = waitingQueue[0]
        .ToString()
        .Split("")
        .Select(str => int.Parse(str));
      
      int sum = digits.Aggregate(0, (acc, numb) => acc + numb);
      if(sum < 10) return sum;
      
      waitingQueue.RemoveAt(0);
      waitingQueue.Add(sum);
    }
    return 0;
  }
}