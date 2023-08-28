/* Description: 
Your task, is to create a NxN spiral with a given size.

For example, spiral with size 5 should look like this:

00000
....0
000.0
0...0
00000


and with the size 10:

0000000000
.........0
00000000.0
0......0.0
0.0000.0.0
0.0..0.0.0
0.0....0.0
0.000000.0
0........0
0000000000
Return value should contain array of arrays, of 0 and 1, with the first row being composed of 1s. For example for given size 5 result should be:

[[1,1,1,1,1],[0,0,0,0,1],[1,1,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
Because of the edge-cases for tiny spirals, the size will be at least 5.

General rule-of-a-thumb is, that the snake made with '1' cannot touch to itself.
*/

using System;
using System.Collections.Generic;

public class Spiralizor
{
    public static int[,] Spiralize(int size)
    {
      int[,] spiralArr = new int[size, size];
      
      int topLimit = 0;
      int rightLimit = size-1;
      int bottomLimit = size-1;
      int leftLimit = 0;
      
      // Spiral creation
      int sideCycle = 0;
      for(int i = 0; i < size; i++) {
        
        switch(sideCycle) {
          case 0: // TOP
            for(int t = leftLimit; t <= rightLimit; t++){
              spiralArr[topLimit, t] = 1;
            }
            if(i > 3)
              leftLimit += 2;
            break;
            
          case 1: // RIGHT
            for(int r = topLimit; r <= bottomLimit; r++){
              spiralArr[r, rightLimit] = 1;
            }
            topLimit += 2;
            break;
            
          case 2: // BOTTOM
            for(int b = leftLimit; b <= rightLimit; b++){
              spiralArr[bottomLimit, b] = 1;
            }
            rightLimit -= 2;
            break;
            
          case 3: // LEFT
            for(int l = topLimit; l <= bottomLimit; l++){
              spiralArr[l, leftLimit] = 1;
            }
            bottomLimit -= 2;
            break;
        }
        
        sideCycle = sideCycle+1 > 3 ? 0 : sideCycle+1;
      }
      
      return spiralArr;
    }
}



/* Others ideas (not by me) */

// Summerized
public static int[,] Spiralize(int size)
{
    int[,] result = new int[size, size];
    for (int s = 0; s < (size + 1) / 2; s++)
        for (int i = s; i < size - s; i++)
            for (int j = s; j < size - s; j++)
                result[i, j] = (i != s + 1 || j != s || (s * 2 + 2 == size && s % 2 == 1)) ? (s + 1) % 2 : s % 2;
    return result;
}

// Interesting
public static int[,] Spiralize(int size)
{
    //it does 'size' number of turns!
    int[,] spiral = new int[size, size];
    (int, int)[] moves = new (int, int)[] {(0, 1), (1, 0), (0, -1), (-1, 0)};
    (int, int) coordinates = (0, 0);

    spiral[0,0] = 1;
    for (int turn = 0; turn < size; turn++){
        (int, int) move = moves[turn % 4];
        //size - 1, size - 1, size - 1, size - 3, size - 3, size - 5, size - 5, size - 7...
        for (int i = ((turn == 0) ? (size - 1) : (size - ((turn - 1) | 1))); i > 0; i--){
            coordinates.Item1 += move.Item1;
            coordinates.Item2 += move.Item2;
            spiral[coordinates.Item1, coordinates.Item2] = 1;
        }
    }

    return spiral;
}