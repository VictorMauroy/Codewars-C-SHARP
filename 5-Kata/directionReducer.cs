/* Description :
Once upon a time, on a way through the old wild mountainous west,…
… a man was given directions to go from one point to another. The directions were "NORTH", "SOUTH", "WEST", "EAST". Clearly "NORTH" and "SOUTH" are opposite, 
"WEST" and "EAST" too.

Going to one direction and coming back the opposite direction right away is a needless effort. Since this is the wild west, 
with dreadful weather and not much water, it's important to save yourself some energy, otherwise you might die of thirst!

How I crossed a mountainous desert the smart way.
The directions given to the man are, for example, the following (depending on the language):

["NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"].
or
{ "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
or
[North, South, South, East, West, North, West]
You can immediately see that going "NORTH" and immediately "SOUTH" is not reasonable, better stay to the same place! 
So the task is to give to the man a simplified version of the plan. A better plan in this case is simply:

["WEST"]
or
{ "WEST" }
or
[West]
Other examples:
In ["NORTH", "SOUTH", "EAST", "WEST"], the direction "NORTH" + "SOUTH" is going north and coming back right away.

The path becomes ["EAST", "WEST"], now "EAST" and "WEST" annihilate each other, therefore, the final result is [] (nil in Clojure).

In ["NORTH", "EAST", "WEST", "SOUTH", "WEST", "WEST"], "NORTH" and "SOUTH" are not directly opposite but they become directly 
opposite after the reduction of "EAST" and "WEST" so the whole path is reducible to ["WEST", "WEST"].

Task
Write a function dirReduc which will take an array of strings and returns an array of strings with the needless directions removed (W<->E or S<->N side by side).

The Haskell version takes a list of directions with data Direction = North | East | West | South.
The Clojure version returns nil when the path is reduced to nothing.
The Rust version takes a slice of enum Direction {North, East, West, South}.
See more examples in "Sample Tests:"
Notes
Not all paths can be made simpler. The path ["NORTH", "WEST", "SOUTH", "EAST"] is not reducible. "NORTH" and "WEST", "WEST" and "SOUTH", "SOUTH" and "EAST" are not directly opposite of each other and can't become such. Hence the result path is itself : ["NORTH", "WEST", "SOUTH", "EAST"].
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class DirReduction {
  
    public static string[] dirReduc(String[] arr) {
      string[] result = arr;
      
      for(int i = 0; i < arr.Length-1; i++){
        if(DirReduction.NextIsOpposite(arr[i], arr[i+1])){
          result = dirReduc(
            i+2 < arr.Length ? 
              arr[0..i].Concat(arr[(i+2)..]).ToArray() :
              arr[0..i]
          );
          break;
        }
      }
      return result;
    }
  
    private static bool NextIsOpposite(string current, string next){
      string currentWord = current.ToString().ToUpper();
      string nextWord = next.ToString().ToUpper();
      
      if(currentWord == "NORTH" && nextWord == "SOUTH" 
          || currentWord == "SOUTH" && nextWord == "NORTH"
          || currentWord == "EAST" && nextWord == "WEST"
          || currentWord == "WEST" && nextWord == "EAST")
        return true;
      
      return false;
    }
}





/* Interesting ideas (not by me) */

public static String[] dirReduc(String[] arr) 
{
  Stack<String> stack = new Stack<String>();

  foreach (String direction in arr) {
      String lastElement = stack.Count > 0 ? stack.Peek().ToString() : null;

      switch(direction) {
          case "NORTH": if ("SOUTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
          case "SOUTH": if ("NORTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
          case "EAST":  if ("WEST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
          case "WEST":  if ("EAST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
      }
  }
  String[] result = stack.ToArray();        
  Array.Reverse(result);
  
  return result;               
}


public static string[] dirReduc(String[] arr) {
  var dir = String.Join(" ",arr);
  var dir2 = dir.Replace("NORTH SOUTH","").Replace("SOUTH NORTH","").Replace("EAST WEST","").Replace("WEST EAST","");
  var dir3 = dir2.Split(" ").Where(s=>!string.IsNullOrEmpty(s)).ToArray();
  return dir3.Length < arr.Length ? dirReduc(dir3): dir3;
}