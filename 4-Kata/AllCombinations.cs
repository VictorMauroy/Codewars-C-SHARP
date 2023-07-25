/* 
In this kata, your task is to create all permutations of a non-empty input string and remove duplicates, if present.

Create as many "shufflings" as you can!

Examples:

With input 'a':
Your function should return: ['a']

With input 'ab':
Your function should return ['ab', 'ba']

With input 'abc':
Your function should return ['abc','acb','bac','bca','cab','cba']

With input 'aabb':
Your function should return ['aabb', 'abab', 'abba', 'baab', 'baba', 'bbaa']
Note: The order of the permutations doesn't matter.
*/

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


/* BEST OR CLEVER */
public static List<string> SinglePermutations(string s) => $"{s}".Length < 2 ?
  	new List<string> { s } :
  	SinglePermutations(s.Substring(1))
  		.SelectMany(x => Enumerable.Range(0, x.Length + 1)
  			.Select((_, i) => x.Substring(0, i) + s[0] + x.Substring(i)))
  		.Distinct()
  		.ToList();
    

public static List<string> SinglePermutations( string s ) {
        if ( s.Length < 2 ) {
            return new List<string> {s};
        }
        var result = new HashSet<string>( );
        foreach ( var sub in SinglePermutations( s.Substring( 1 ) ) ) {
            for ( int i = 0; i <= sub.Length; i++ ) {
                result.Add( sub.Substring( 0, i ) + s [ 0 ] + sub.Substring( i ) );
            }
        }
        return result.ToList( );
    }