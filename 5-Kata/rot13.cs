using System;
using System.Linq;
using System.Collections.Generic;

public class Kata
{
  public static string Rot13(string message)
  =>  String.Join("", message.Select(c => Char.IsLetter(c) ? ((char)(((int)Char.ToUpper(c) - 65 + 13) < 26 ? (int)c + 13 : (int)c + 13 - 26)) : c ));
}