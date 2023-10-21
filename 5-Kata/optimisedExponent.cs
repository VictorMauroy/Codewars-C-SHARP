
/* At first, I found that idea. It was pretty good at doing exponent computation but...
It couldn't handle extremely large computations. The estimated limit for quick result is around 6 digits exponent power.*/

using System.Numerics;
class LastDigit
{
public static int GetLastDigit(BigInteger n1, BigInteger n2)
{
    if (n1 == 0 && n2 == 0)
        return 1;
    
    if(n1 == 10)
    return 0;

    BigInteger expResult = SquareExponent(n1, n2);

    string expStr = expResult.ToString();
    return int.Parse(expStr.Substring(expStr.Length - 1));
}

public static BigInteger SquareExponent(BigInteger num, BigInteger exp)
{
    if (exp == 1)
        return num;

    if (exp == 0)
        return 1;

    if (exp % 2 == 0)
    {
        BigInteger halfExp = SquareExponent(num, exp / 2);
        return halfExp * halfExp;
    }
    else
    {
        BigInteger halfExp = SquareExponent(num, exp / 2);
        return halfExp * halfExp * num;
    }
}
}