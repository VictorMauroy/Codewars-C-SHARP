/* Description :
The Fibonacci numbers are the numbers in the following integer sequence (Fn):

0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ...

such as

F(n) = F(n-1) + F(n-2) with F(0) = 0 and F(1) = 1.

Given a number, say prod (for product), we search two Fibonacci numbers F(n) and F(n+1) verifying

F(n) * F(n+1) = prod.

Your function productFib takes an integer (prod) and returns an array:

[F(n), F(n+1), true] or {F(n), F(n+1), 1} or (F(n), F(n+1), True)
depending on the language if F(n) * F(n+1) = prod.

If you don't find two consecutive F(n) verifying F(n) * F(n+1) = prodyou will return

[F(n), F(n+1), false] or {F(n), F(n+1), 0} or (F(n), F(n+1), False)
F(n) being the smallest one such as F(n) * F(n+1) > prod.

Some Examples of Return:
(depend on the language)

productFib(714) # should return (21, 34, true), 
                # since F(8) = 21, F(9) = 34 and 714 = 21 * 34

productFib(800) # should return (34, 55, false), 
                # since F(8) = 21, F(9) = 34, F(10) = 55 and 21 * 34 < 800 < 34 * 55
-----
productFib(714) # should return [21, 34, true], 
productFib(800) # should return [34, 55, false], 
-----
productFib(714) # should return {21, 34, 1}, 
productFib(800) # should return {34, 55, 0},        
-----
productFib(714) # should return {21, 34, true}, 
productFib(800) # should return {34, 55, false}, 
*/


/* FINAL SOLUTION 
I removed the recursive calls that were all useless and prefered to save the last 2 values.
*/
using System.Collections.Generic;

public class ProdFib {
    public static ulong[] productFib(ulong prod) {
      ulong lastProduct = 0;
      List<ulong> lastNumbers = new List<ulong> {0, 1};
      
      do
      {
        lastNumbers.Add( lastNumbers[0] + lastNumbers[1] );
        lastProduct = lastNumbers[1] * lastNumbers[2];
        lastNumbers.RemoveAt(0);
      } while (lastProduct < prod);
      
      ulong[] result = {
        lastNumbers[0],
        lastNumbers[1],
        (ulong) ((lastProduct == prod) ? 1 : 0)
      };
        
      return result;
    }    
}



/* First attemp : REALLY SLOW 
There were too much recursive calls.
*/
public class ProdFib {
    public static ulong[] productFib(ulong prod) {
      ulong[] result = new ulong[3];
      ulong lastChecked = prod > 1000 ? prod / 200 : 0;
      ulong lastProduct = 0;
      
      // Procéder avec une file d'attente.
      
      do
      {
        lastProduct = GetFibonacci(lastChecked) * GetFibonacci(lastChecked + 1);
        lastChecked++;
      } while(lastProduct < prod);
      
      result[0] = GetFibonacci(lastChecked -1);
      result[1] = GetFibonacci(lastChecked);
      result[2] = (ulong) ((lastProduct == prod) ? 1 : 0);
      
      return result;
    }
  
    public static ulong GetFibonacci(ulong number){
      if(number == 0)
        return 0;
      
      if(number == 1)
        return 1;
      
      return GetFibonacci(number - 1) + GetFibonacci(number -2);
    }
}



/* NOT BY ME : Interesting ideas */
public static ulong[] productFib(ulong prod)
{
(ulong a, ulong b) = (0, 1);

while (prod > a * b)
{
    (a, b) = (b, a + b);
}

return new[] { a, b, (ulong)(prod == a * b ? 1 : 0) };
}