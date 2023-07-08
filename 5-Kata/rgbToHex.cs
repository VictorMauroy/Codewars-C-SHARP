/* 
The rgb function is incomplete. Complete it so that passing in RGB decimal values will 
result in a hexadecimal representation being returned. Valid decimal values for RGB are 0 - 255. 
Any values that fall out of that range must be rounded to the closest valid value.

Note: Your answer should always be 6 characters long, the shorthand with 3 will not work here.

The following are examples of expected output values:

Rgb(255, 255, 255) # returns FFFFFF
Rgb(255, 255, 300) # returns FFFFFF
Rgb(0,0,0) # returns 000000
Rgb(148, 0, 211) # returns 9400D3
*/

public class Kata
{
  public static string Rgb(int r, int g, int b) 
  {
    int[] rgb = new int[3];
    rgb[0] = r <= 255 ? (r > 0 ? r : 0) : 255;
    rgb[1] = g <= 255 ? (g > 0 ? g : 0) : 255;
    rgb[2] = b <= 255 ? (b > 0 ? b : 0) : 255;
    
    string[] rgbValues = new string[3];
    
    for(int i =0; i < rgb.Length; i ++)
    {
      string secondChar = ConvertIntToHex(rgb[i] % 16);
      string firstChar = ConvertIntToHex((rgb[i]/16) % 16);
      rgbValues[i] = firstChar + secondChar;
    }
    
    return string.Join("", rgbValues);
  }
  
  
  
  public static string ConvertIntToHex(int num)
  {
    if(num < 10 ){
      return num.ToString();
    } else {
      string letter = "";
      switch(num){
          case 10 :
            letter = "A";
            break;
          case 11 :
            letter = "B";
            break;
          case 12 :
            letter = "C";
            break;
          case 13 :
            letter = "D";
            break;
          case 14 :
            letter = "E";
            break;
          case 15 :
            letter = "F";
            break;
      }
      return (string)letter;
    }
  }
}


/* Clever:
public static string Rgb(int r, int g, int b) 
{
    r = Math.Max(Math.Min(255, r), 0);
    g = Math.Max(Math.Min(255, g), 0);
    b = Math.Max(Math.Min(255, b), 0);
    return String.Format("{0:X2}{1:X2}{2:X2}", r, g, b);
}



public static string Rgb(int r, int g, int b)
{
    return limitValue(r) + limitValue(g) + limitValue(b);
}

public static string limitValue(int n)
{
    if (n < 0) n = 0;
    if (n > 255) n = 255;
    return n.ToString("X2");

*/