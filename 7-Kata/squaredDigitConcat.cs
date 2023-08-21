using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static int SquareDigits(int n)
  {
    return String.Join(
      "", 
      n.ToString()
        .Split("")
        .Select(num => (int.Parse(num) * int.Parse(num)))
        .Select(n => $"{n}")
    );  
  }
}