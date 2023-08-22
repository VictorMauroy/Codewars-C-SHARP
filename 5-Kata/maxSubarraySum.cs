/* Description:
The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:

maxSequence [-2, 1, -3, 4, -1, 2, 1, -5, 4]
-- should be 6: [4, -1, 2, 1]
Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array. 
If the list is made up of only negative numbers, return 0 instead.

Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.
*/

public static class Kata
{
  public static int MaxSequence(int[] arr) 
  { 
    int maxSum = 0;
    for(int i = 0; i < arr.Length; i++) {
      int sum = arr[i];
      if(maxSum < sum)
        maxSum = sum;
      
      for(int j = i+1; j < arr.Length; j++) {
        sum += arr[j];
        if(maxSum < sum)
          maxSum = sum;
      }
    }
    
    return maxSum > 0 ? maxSum : 0;
  }
}

/* Interesting ideas (not by me) */
public static int MaxSequence(int[] arr)
{
    int max = 0, res = 0, sum = 0;
    foreach(var item in arr)
    {
        sum += item;
        max = sum > max ? max : sum;
        res = res > sum - max ? res : sum - max;
    }
    return res;
}