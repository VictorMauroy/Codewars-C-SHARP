/* Description :
My friend John and I are members of the "Fat to Fit Club (FFC)". 
John is worried because each month a list with the weights of members is published 
and each month he is the last on the list which means he is the heaviest.

I am the one who establishes the list so I told him: "Don't worry any more, I will modify the order of the list". 
It was decided to attribute a "weight" to numbers. The weight of a number will be from now on the sum of its digits.

For example 99 will have "weight" 18, 100 will have "weight" 1 so in the list 100 will come before 99.

Given a string with the weights of FFC members in normal order can you give this string ordered by "weights" of these numbers?

Example:
"56 65 74 100 99 68 86 180 90" ordered by numbers weights becomes: 

"100 180 90 56 65 74 68 86 99"
When two numbers have the same "weight", let us class them as if they were strings (alphabetical ordering) and not numbers:

180 is before 90 since, having the same "weight" (9), it comes before as a string.

All numbers in the list are positive numbers and the list can be empty.
*/

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


// Made by other peoples :
using System.Linq;

public class WeightSort 
{
    public static string orderWeight(string s)
    {
        return string.Join(" ", s.Split(' ')
            .OrderBy(n => n.ToCharArray()
            .Select(c => (int)char.GetNumericValue(c)).Sum()) //Good to know, we can get the numeric value easily. Avoid reseting ASCII value.
            .ThenBy(n => n));
  	}
}