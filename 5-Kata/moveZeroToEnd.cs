/* Description :
Write an algorithm that takes an array and moves all of the zeros 
to the end, preserving the order of the other elements.

Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}) 
=> new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}
*/
using System.Collections.Generic;
using System.Linq;

/* Second solution founded, cleaner way */
public class Kata
{
  public static int[] MoveZeroes(int[] arr)
  {
    List<int> zeroList, numExceptZero = new List<int>();
    zeroList = arr.Where(num => num == 0).ToList();
    numExceptZero = arr.Where(num => num != 0).ToList();
    
    return Enumerable.Concat(numExceptZero, zeroList).ToArray();
  }
}

/* // First try, simple way
public class Kata
{
  public static int[] MoveZeroes(int[] arr)
  {
    List<int> numbersExceptZero = new List<int>();
    int zeroCount = 0;
    
    foreach(int num in arr)
    {
      if(num != 0){
        numbersExceptZero.Add(num);
      } else {
        zeroCount++;
      }
    }
    
    for(int i = 0; i < zeroCount; i++) 
      numbersExceptZero.Add(0);
    
    return numbersExceptZero.ToArray();
  }
}*/



/* Best practice :

return arr.OrderBy(x => x==0).ToArray();

or

return arr.Where(x=>x!=0).Concat(arr.Where(x=>x==0)).ToArray();
 */