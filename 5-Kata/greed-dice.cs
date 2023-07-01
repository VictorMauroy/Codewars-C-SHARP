/* 
Greed is a dice game played with five six-sided dice. 
Your mission, should you choose to accept it, is to score a throw according to these rules. 
You will always be given an array with five six-sided dice values.

 Three 1's => 1000 points
 Three 6's =>  600 points
 Three 5's =>  500 points
 Three 4's =>  400 points
 Three 3's =>  300 points
 Three 2's =>  200 points
 One   1   =>  100 points
 One   5   =>   50 point
A single die can only be counted once in each roll. For example, a given "5" can only count as part of a triplet 
(contributing to the 500 points) or as a single 50 points, but not both in the same roll.

Example scoring

 Throw       Score
 ---------   ------------------
 5 1 3 4 1   250:  50 (for the 5) + 2 * 100 (for the 1s)
 1 1 1 3 1   1100: 1000 (for three 1s) + 100 (for the other 1)
 2 4 4 5 4   450:  400 (for three 4s) + 50 (for the 5)
*/

using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static int Score(int[] dice) {
    int points = 0;
    
    Array.Sort(dice);
    
    int occurenceCounter = 0;
    int tripletDice = -1;
    int previousDice = -1;
    for(int i = 0; i < dice.Length; i++) {
      if(previousDice == dice[i]){
        occurenceCounter+=1;
        tripletDice = dice[i];
        if(occurenceCounter >= 2) break; //Found a triplet, leave.
      } else {
        occurenceCounter = 0;
      }
      previousDice = dice[i];
    }
    
    List<int> dicesList = new List<int>(dice);
    
    //if triplet, increase points and remove it from the dices left to count.
    if(occurenceCounter >= 2) {
      points += tripletDice == 1 ? 1000 : tripletDice * 100;
      
      int diceToRemove = 3;
      for(int i = 0; i < dice.Length; i++) {
        if(diceToRemove > 0 && dice[i] == tripletDice) {
          dicesList.Remove(dice[i]);
          diceToRemove--;
        }
      }
    }
    
    //Count the dices left
    foreach(int diceElt in dicesList) {
      if(diceElt == 5) points+=50;
      if(diceElt == 1) points += 100;
    }
    
    return points;
  }
}

/* Clever :
public static int Score(int[] dice)
{
    int[] tripleValue =  {0, 1000, 200, 300, 400, 500, 600};
    int[] singleValue =  {0, 100, 0, 0, 0, 50, 0};

    int value = 0;
    for (int dieSide = 1; dieSide <= 6; dieSide++)
    {
        int countRolls = dice.Where(outcome => outcome == dieSide).Count();
        value += tripleValue[dieSide] * (countRolls / 3) + singleValue[dieSide] * (countRolls % 3);                
    }
    return value;
}

private static int[] _threes = new int[] { 0, 1000, 200, 300, 400, 500, 600 };
private static int[] _singles = new int[] { 0, 100, 0, 0, 0, 50, 0};
public static int Score(int[] dice)
{
    return dice
        .GroupBy(d => d)
        .Select(gr => new { num = gr.Key, count = gr.Count() })
        .Sum(n => (n.count / 3) * _threes[n.num] + (n.count % 3) * _singles[n.num]);
}
*/