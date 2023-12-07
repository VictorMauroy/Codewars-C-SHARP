/* Description:
Write a function that, given a string of text (possibly with punctuation and line-breaks), 
returns an array of the top-3 most occurring words, in descending order of the number of occurrences.

Assumptions:
A word is a string of letters (A to Z) optionally containing one or more apostrophes (') in ASCII.
Apostrophes can appear at the start, middle or end of a word ('abc, abc', 'abc', ab'c are all valid)
Any other characters (e.g. #, \, / , . ...) are not part of a word and should be treated as whitespace.
Matches should be case-insensitive, and the words in the result should be lowercased.
Ties may be broken arbitrarily.
If a text contains fewer than three unique words, then either the top-2 or top-1 words should be returned, 
or an empty array if a text contains no words.

Examples:
"In a village of La Mancha, the name of which I have no desire to call to
mind, there lived not long since one of those gentlemen that keep a lance
in the lance-rack, an old buckler, a lean hack, and a greyhound for
coursing. An olla of rather more beef than mutton, a salad on most
nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra
on Sundays, made away with three-quarters of his income."

--> ["a", "of", "on"]


"e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"

--> ["e", "ddd", "aa"]


"  //wont won't won't"

--> ["won't", "wont"]
Bonus points (not really, but just for fun):
Avoid creating an array whose memory footprint is roughly as big as the input text.
Avoid sorting the entire array of unique words.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class TopWords
{
    public static List<string> Top3(string text)
    {
      var words = Regex.Matches(text, @"([a-zA-Z]+'{0,1}[a-zA-Z]*)").Select(m => m.Value.ToLower());
      return (from word in words
              where !string.IsNullOrWhiteSpace(word)
              group word by word into newGroup
              orderby newGroup.Count() descending
              select newGroup.Key).Take(3).ToList();
    }
}






// Solutions by other peoples :
public static List<string> Top3(string s)
{
    return Regex.Matches(s.ToLowerInvariant(), @"('*[a-z]'*)+")
        .GroupBy(match => match.Value)
        .OrderByDescending(g => g.Count())
        .Select(p => p.Key)
        .Take(3)
        .ToList();
}


// Not really easy to read but uses linq query syntax
public static List<string> Top3(string s) {
    return (from m in Regex.Matches(Regex.Replace(s.ToLower(), @"-\s+([a-z])", "$1"), "[a-z]+[a-z\']*") let w = m.Value group w by w into g orderby g.Count() descending select g.Key).Take(3).ToList();
  }