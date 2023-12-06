/* On-going work on that kata */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class TopWords
{
    public static List<string> Top3(string text)
      {
          List<string> words = Regex.Split(text, @"[^\w']+").ToList();
          return (from word in words
                  group word.ToLower() by word into newGroup
                  orderby newGroup.Count() descending
                  select newGroup.Key).Take(3).ToList();
      }
}