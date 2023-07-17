/* Description:
Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

array = [[1,2,3],
         [4,5,6],
         [7,8,9]]
snail(array) #=> [1,2,3,6,9,8,7,4,5]
For better understanding, please follow the numbers of the next array consecutively:

array = [[1,2,3],
         [8,9,4],
         [7,6,5]]
snail(array) #=> [1,2,3,4,5,6,7,8,9]

NOTE: The idea is not sort the elements from the lowest value to the highest; 
the idea is to traverse the 2-d array in a clockwise snailshell pattern.

NOTE 2: The 0x0 (empty matrix) is represented as en empty array inside an array [[]].
*/

public static class SnailSort
{
    public static int[] Snail(int[][] array)
    {
        List<int> snailList = new();
        if (array[0].Length == 0) return snailList.ToArray();

        //Where the given array always is a square.
        int nbIteration = array.Length * 2 - 1;

        int minLine = 0, minCol = 0, maxLine, maxCol;
        maxLine = array.GetLength(0) - 1;
        maxCol = maxLine;

        int selector = 0;
        for (int index = 0; index < nbIteration; index++)
        {
            switch (selector)
            {
                case 0: //First Line
                    for (int i = minCol; i <= maxCol; i++)
                    {
                        snailList.Add(array[minLine][i]);
                    }

                    minLine++;
                    break;

                case 1: // Last Column
                    for (int i = minLine; i <= maxLine; i++)
                    {
                        snailList.Add(array[i][maxCol]);
                    }

                    maxCol--;
                    break;

                case 2: // Last Line
                    for (int i = maxCol; i >= minCol; i--)
                    {
                        snailList.Add(array[maxLine][i]);
                    }

                    maxLine--;
                    break;

                case 3: // First Column
                    for (int i = maxLine; i >= minLine; i--)
                    {
                        snailList.Add(array[i][minCol]);
                    }

                    minCol++;
                    break;
            }

            selector++;
            if (selector > 3) selector = 0;
        }

        return snailList.ToArray();
    }
}


/* Good ideas:
*
public static IEnumerable<int> Snail(int[][] a, int r = 0)
{
    int n = a[0].Length - 1 - 2 * r;
    if (n < 0) return new int[0];
    if (n == 0) return new []{a[r][r]};
    
    var sides = new []{
    a[r],                             // Top
    a.Select(x => x[r+n]),            // Right
    a[r+n].Reverse(),                 // Bottom
    a.Select(x => x[r]).Reverse()     // Left
    }
    .SelectMany(x => x.Skip(r).Take(n));

    return (n == 1) ? sides : sides.Concat(Snail(a, r+1));
}




public static int[] Snail(int[][] array)
{
    int l = array[0].Length;
    int[] sorted = new int[l * l];
    Snail(array, -1, 0, 1, 0, l, 0, sorted);
    return sorted;
}
public static void Snail(int[][] array, int x, int y, int dx, int dy, int l, int i, int[] sorted)
{
    if (l == 0)
        return;
    for (int j = 0; j < l; j++)
    {
        x += dx;
        y += dy;
        sorted[i++] = array[y][x];
    }
    Snail(array, x, y, -dy, dx, dy == 0 ? l - 1 : l, i, sorted);
}

*/