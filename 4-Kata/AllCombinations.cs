using System;
using System.Collections.Generic;
using System.Linq;

class Permutations
{
  public static List<string> SinglePermutations(string str)
  => PermuteTree("", str).Distinct().ToList(); //Use of GroupBy to remove duplicate values.
  
  public static List<string> PermuteTree(string baseStr, string restStr)
  {
    List<string> branchs = new List<string>();
    if(restStr == "") branchs.Add(baseStr);

    for(int i = 0; i < restStr.Length; i++){
      branchs.AddRange(PermuteTree(
        baseStr + restStr[i],
        (i == 0 ? "" : restStr.Substring(0, i)) + 
          (i+1 >= restStr.Length ? "" : restStr.Substring(i+1))
      ));
    }
    return branchs;
  }
}
