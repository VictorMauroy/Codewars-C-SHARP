/* on-going kata, still searching for the bug*/

using System;
using System.Collections.Generic;
using System.Linq;

// First try for that kata.
public class WeightSort {
    public static string orderWeight(string str) {
        List<string> numbers = str.Split(" ").ToList();
        Dictionary<string, int> rankedNumbers = new Dictionary<string, int>();

        foreach (string num in numbers)
        {
            rankedNumbers[num] = num.ToString().Select(x => (int)x -48).Sum();
            Console.WriteLine("Key: " + num + ", value: " + rankedNumbers[num]);
        }

        return string.Join(
          " ",
          rankedNumbers
          .OrderBy(x => x.Value)
          .ThenBy(c => c.Key.ToString())
          .Select(c => c.Key)
          .ToList());
    }
}

// Second solution that I found (it was originaly my first idea but I lost a lot of time because I misunderstood the kata description )
public static string orderWeight(string str) {
    return string.Join(
      " ", 
      str.Split(" ")
         .OrderBy(number => number.Select(x => (int)x - 48).Sum() )
         .ThenBy(num => num.ToString() )
    );
}

