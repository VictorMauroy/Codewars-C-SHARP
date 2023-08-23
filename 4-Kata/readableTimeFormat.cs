/*
Your task in order to complete this Kata is to write a function which formats a duration, given as a number of seconds, in a human-friendly way.

The function must accept a non-negative integer. If it is zero, it just returns "now". 
Otherwise, the duration is expressed as a combination of years, days, hours, minutes and seconds.

It is much easier to understand with an example:

* For seconds = 62, your function should return 
    "1 minute and 2 seconds"
* For seconds = 3662, your function should return
    "1 hour, 1 minute and 2 seconds"
For the purpose of this Kata, a year is 365 days and a day is 24 hours.

Note that spaces are important.

Detailed rules
The resulting expression is made of components like 4 seconds, 1 year, etc. 
In general, a positive integer and one of the valid units of time, separated by a space. The unit of time is used in plural if the integer is greater than 1.

The components are separated by a comma and a space (", "). Except the last component, which is separated by " and ", just like it would be written in English.

A more significant units of time will occur before than a least significant one. Therefore, 1 second and 1 year is not correct, but 1 year and 1 second is.

Different components have different unit of times. So there is not repeated units like in 5 seconds and 1 second.

A component will not appear at all if its value happens to be zero. Hence, 1 minute and 0 seconds is not valid, but it should be just 1 minute.

A unit of time must be used "as much as possible". It means that the function should not return 61 seconds, but 1 minute and 1 second instead. 
Formally, the duration specified by of a component must not be greater than any valid more significant unit of time.
*/

using System;
using System.Collections.Generic;

public class HumanTimeFormat{
  
  public static string formatDuration(int duration)
  {
    if(duration == 0)
      return "now";
    
    // Split durations
    int seconds = duration % 60;
    int minutes = (int) (duration / 60) % 60;
    int hours = (int) (duration / 3600) % 24;
    int days = (int) (duration / 86400) % 365;
    int years = (int) (duration / (86400 * 365));
    
    // Build the sentence
    List<string> sentences = new List<string>();
    if( years > 0 ) 
      sentences.Add( $"{years} year" + (years > 1 ? "s" : "") );
    if( days > 0 ) 
      sentences.Add( $"{days} day" + (days > 1 ? "s" : "") );
    if( hours > 0 )
      sentences.Add( $"{hours} hour" + (hours > 1 ? "s" : "") );
    if( minutes > 0 )
      sentences.Add( $"{minutes} minute" + (minutes > 1 ? "s" : "") );
    if( seconds > 0 )
      sentences.Add( $"{seconds} second" + (seconds > 1 ? "s" : "") );
    
    string sentence = "";
    
    for(int i = 0; i < sentences.Count; i++){
      sentence += sentences[i];
      if (i == sentences.Count - 2)
      {
        sentence += " and ";
      } else if(i < sentences.Count -2) {
        sentence += ", ";
      }
    }
    
    return sentence;
  }
  
}


/* Other ideas  (not by me) */
public static string formatDuration(int sec)
{
    if (sec == 0) return "now";
    var L = new List<string>();
    var t = TimeSpan.FromSeconds(sec);
    int y = t.Days / 365;
    int d = t.Days % 365;
    int h = t.Hours;
    int m = t.Minutes;
    int s = t.Seconds;
    if (y > 0) L.Add(y+" year"+(y>1?"s":""));
    if (d > 0) L.Add(d+" day"+(d>1?"s":""));
    if (h > 0) L.Add(h+" hour"+(h>1?"s":""));
    if (m > 0) L.Add(m+" minute"+(m>1?"s":""));
    if (s > 0) L.Add(s+" second"+(s>1?"s":""));
    
    return string.Join(", ", L.Take(L.Count() - 1)) + (L.Count()>1?" and ":"") + L.Last(); ;

}