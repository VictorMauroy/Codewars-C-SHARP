





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