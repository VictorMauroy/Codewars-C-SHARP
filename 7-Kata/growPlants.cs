/* Description :
Task
Each day a plant is growing by upSpeed meters. 
Each night that plant's height decreases by downSpeed meters due to the lack of sun heat. 
Initially, plant is 0 meters tall. We plant the seed at the beginning of a day. 
We want to know when the height of the plant will reach a certain level.
*/

namespace myjinxin
{
    using System;
    
    public class Kata
    {
        public int GrowingPlant(int UpSpeed, int DownSpeed, int DesiredHeight){
          for(int currentHeight = 0, dayCount = 1; currentHeight <= DesiredHeight; dayCount++)
          {
            currentHeight += UpSpeed;
            if(currentHeight >= DesiredHeight) 
              return dayCount;
            currentHeight -= DownSpeed;
          }
          return 0;
        }
    }
}

/* Interesting :
public int GrowingPlant(int UpSpeed, int DownSpeed, int DesiredHeight)
{
    return Enumerable.Range(1, 1000).First(x => x * UpSpeed - (x-1) * DownSpeed >= DesiredHeight);        
}
 */