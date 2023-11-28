/* on-going kata, still searching for the bug*/

using System;
using System.Collections.Generic;
using System.Linq;

public class WeightSort {
	
	public static string orderWeight(string str) {
		List<int> numbers = str.Split(" ").Select(num => int.Parse(num)).ToList();
    Dictionary<int, int> rankedNumbers = new Dictionary<int, int>();
    
    foreach(int num in numbers){
      rankedNumbers[num] = num.ToString().Length;
    }
    
    return string.Join(
      " ", 
      rankedNumbers
      .OrderBy(x => x.Key)
      .ThenBy(c => c.Value)
      .Select(c => c.Key)
      .ToList());
	}
}