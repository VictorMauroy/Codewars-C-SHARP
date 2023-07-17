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


/*            string result = "List with { ";
        for (int i = 0; i < snailList.Count; i++)
        {
            result += snailList[i].ToString() + ", ";
        }
        result += " }";
        Console.WriteLine(result); //DEBUG*/

        return snailList.ToArray();
    }
}