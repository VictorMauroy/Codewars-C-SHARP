/* Description:
Implement the function unique_in_order which takes as argument a sequence 
and returns a list of items without any elements with the same value next to each other and preserving the original order of elements.

For example:

uniqueInOrder("AAAABBBCCDAABBB") == {'A', 'B', 'C', 'D', 'A', 'B'}
uniqueInOrder("ABBCcAD")         == {'A', 'B', 'C', 'c', 'A', 'D'}
uniqueInOrder([1,2,2,3,3])       == {1,2,3}
*/

using System.Collections;
using System.Collections.Generic;

public static class Kata
{
  public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
  {
    List<T> groupedList = new();
    IEnumerator<T> enumerator = iterable.GetEnumerator();
    T previousElement = default(T);

    while(enumerator.MoveNext())
    {
      if(groupedList.Count < 1){
        previousElement = enumerator.Current;
        groupedList.Add(previousElement);
        continue;
      } 

      T element = enumerator.Current;
      if(!EqualityComparer<T>.Default.Equals(element, previousElement))
      {
        groupedList.Add(element);
        previousElement = element;
      }
    }

    return groupedList;
  }
}

/* Best practice :
public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) 
{
    T previous = default(T);
    foreach(T current in iterable)
    {
        if (!current.Equals(previous))
        {
        previous = current;
        yield return current;
        }
    }
}

public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) 
{
    var e = iterable.GetEnumerator();
    if (e.MoveNext())
    {
        var c = e.Current;
        while (e.MoveNext())
        {
            if (!e.Current.Equals(c)) yield return c;
            c = e.Current;
        }
        yield return c;
    }
}

public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) 
{
    return iterable.Where((x, i) => i == 0 || !Equals(x, iterable.ElementAt(i-1)));
}
*/