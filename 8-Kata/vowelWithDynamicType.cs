using System.Linq;

public class Kata
{
  public static object[] IsVow(object[] a)
  {
    return a.Select(num => IsNumberVowel((int) num))
            .ToArray();
  }
  
  public static dynamic IsNumberVowel(int numToCheck) {
    string c = "" + (char) numToCheck;
    return "aeiou".Contains(c) ? c : numToCheck;
  }
}