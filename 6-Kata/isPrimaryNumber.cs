/* Description :
Define a function that takes an integer argument and returns a logical value true or false depending on if the integer is a prime.

Per Wikipedia, a prime number ( or a prime ) is a natural number greater than 1 that has no positive divisors other than 1 and itself.

Requirements
You can assume you will be given an integer input.
You can not assume that the integer will be only positive. You may be given negative numbers as well ( or 0 ).
NOTE on performance: There are no fancy optimizations required, but still the most trivial solutions might time out. 
Numbers go up to 2^31 ( or similar, depending on language ). Looping all the way up to n, or n/2, will be too slow.
Example
is_prime(1)  --> false
is_prime(2)  --> true
is_prime(-1) --> false
*/


/* Remarque (FR) :
Pour déterminer si un nombre entier naturel n supérieur ou égal 2 est un nombre premier, 
on doit chercher un diviseur de n parmi les nombres premiers successifs (2, 3, 5, 7, 11 …) jusqu'à la valeur √n.

En effet, si n n'admet aucun diviseur parmi les nombres premiers successifs jusqu'à la valeur √n, 
il n'en admettra pas non plus entre √n et n car les diviseurs d'un nombre vont par paires : l'un compris entre 2 et √n, 
et l'autre compris entre √n et n.
Si n n'admet aucun diviseur parmi les nombres premiers successifs jusqu'à la valeur √n, c'est donc un nombre premier.
*/

using System;

public static class Kata
{
  public static bool IsPrime(int n)
  {
    if(n <= 1)
      return false;
    
    for(int i = 2; i <= (int)Math.Sqrt(n); i++){
      if(n % i == 0)
        return false;
    }
    
    return true;
  }
}

//Nice. It could only be optimized by not using the Math.Sqrt method.
// I could have wrote i*i < n instead.