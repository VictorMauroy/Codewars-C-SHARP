/* On-going work on that kata */
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