

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
