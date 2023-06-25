/* Description :
Given an array of integers, find the one that appears an odd number of times.

There will always be only one integer that appears an odd number of times.

Examples
[7] should return 7, because it occurs 1 time (which is odd).
[0] should return 0, because it occurs 1 time (which is odd).
[1,1,2] should return 2, because it occurs 1 time (which is odd).
[0,1,0,1,0] should return 0, because it occurs 3 times (which is odd).
[1,2,2,3,3,3,4,3,3,3,2,2,1] should return 4, because it appears 1 time (which is odd).
*/

using System.Collections.Generic;
using System.Linq;
namespace Solution
{
  class Kata
  {
    public static int find_it(int[] seq) 
    {
      IDictionary<int, int> numberOccurence = new Dictionary<int, int>();

      foreach(int num in seq){
        if(numberOccurence.TryGetValue(num, out _)){
          numberOccurence[num] ++;
        } else {
          numberOccurence[num] = 1;
        }
      }

      for(int i =0; i< numberOccurence.Count; i++){
        if(numberOccurence.ElementAt(i).Value % 2 != 0) 
          return numberOccurence.ElementAt(i).Key;
      }
      return 0;
    }

  }
}

// NOTE : It looks like I did something really complicated for nothing... Let's see the best practices :

/*
public static int find_it(int[] seq) 
{
    return seq.GroupBy(x => x).Single(g => g.Count() % 2 == 1).Key;
}

public static int find_it(int[] seq) 
{
    return  seq.First(x => seq.Count(s => s == x) % 2 == 1);
}

public static int find_it(int[] seq)
{
    return seq.ToList()
        .GroupBy(x => x) //Group by each element in the array
        .Where(x => (x.Count() % 2) != 0) //Find grouped odd numbers
        .Select(x => x.First())
        .FirstOrDefault(); //since array will only contain 1 odd number, get first one
}

public static int find_it(int[] seq) 
{
    return seq.Aggregate(0, (a, b) => a ^ b);
}
*/

// NOTE : That hurts.