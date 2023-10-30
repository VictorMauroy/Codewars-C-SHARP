/* Description :
Some numbers have funny properties. For example:

89 --> 8¹ + 9² = 89 * 1

695 --> 6² + 9³ + 5⁴= 1390 = 695 * 2

46288 --> 4³ + 6⁴+ 2⁵ + 8⁶ + 8⁷ = 2360688 = 46288 * 51

Given a positive integer n written as abcd... (a, b, c, d... being digits) and a positive integer p

we want to find a positive integer k, if it exists, such that the sum of the digits of n taken to 
the successive powers of p is equal to k * n.

In other words:
Is there an integer k such as : (a ^ p + b ^ (p+1) + c ^(p+2) + d ^ (p+3) + ...) = n * k

If it is the case we will return k, if not return -1.

Note: n and p will always be given as strictly positive integers.

digPow(89, 1) should return 1 since 8¹ + 9² = 89 = 89 * 1
digPow(92, 1) should return -1 since there is no k such as 9¹ + 2² equals 92 * k
digPow(695, 2) should return 2 since 6² + 9³ + 5⁴= 1390 = 695 * 2
digPow(46288, 3) should return 51 since 4³ + 6⁴+ 2⁵ + 8⁶ + 8⁷ = 2360688 = 46288 * 51
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class DigPow 
{
    public static long digPow(int n, int p) 
    {
        List<int> digitsOfN = n.ToString()
            .Select(c => int.Parse(c.ToString()))
            .ToList();
        
        int digitPowSum = digitsOfN
        .Select(d => (int)Math.Pow(d, p++))
        .Aggregate((acc, num) => acc + num);
        
        for(int i = 0, multiple = 0; multiple < digitPowSum; i++){
        multiple = n * i;
        
        if(multiple == digitPowSum)
            return i;
        }
        
        return -1;
	}
}

// Others ideas (not by me)

// Note: Argh, I forgot to use so many things to simplify!

public static long digPow(int n, int p) {
    var sum = Convert.ToInt64(n.ToString().Select(s => Math.Pow(int.Parse(s.ToString()), p++)).Sum());
    return sum % n == 0 ? sum / n : -1;
}

public static long digPow(int n, int p) {
    var value = n.ToString()
        .ToCharArray()
        .Select(c => int.Parse(c.ToString()))
        .Select((d, idx) => Math.Pow(d, idx +p))
        .Sum();
    

    if ((value % n) != 0) return -1;
    return (long)value/n;
}