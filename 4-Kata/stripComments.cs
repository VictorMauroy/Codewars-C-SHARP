

/* First attempt */
using System.Linq;
using System.Text.RegularExpressions;

public class StripCommentsSolution
{
    public static string StripComments(string text, string[] commentSymbols)
    {
      string[] lines = Regex.Split(text, @"\n");
      string[] editedLines = new string[lines.Length];

      for(int i = 0; i < lines.Length; i++) {
        string pattern = @"\s*([" + string.Concat(commentSymbols) + @"].*)|(\s*$)";
        editedLines[i] = Regex.Replace(lines[i], pattern, "");
      }
      
      return string.Join("\n", editedLines);
    }
}


/* Second attempt => shortened */
using System.Linq;
using System.Text.RegularExpressions;
public static string StripComments(string text, string[] commentSymbols)
    => string.Join("\n", Regex.Split(text, @"\n")
          .Select(line => Regex.Replace(
            line, 
            @"\s*([" + string.Concat(commentSymbols) + @"].*)|(\s*$)",
            "")));


/* Made by other peoples : */

// Without using Regular expressions.
using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class StripCommentsSolution
{
        public static string StripComments(string text, string[] commentSymbols)
        {
           return String.Join('\n', text.Split('\n').Select(str => str.Split(commentSymbols, 0)[0].TrimEnd()));
        }
}