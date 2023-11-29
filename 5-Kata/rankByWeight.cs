/* on-going kata, still searching for the bug*/

using System;
using System.Collections.Generic;
using System.Linq;

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