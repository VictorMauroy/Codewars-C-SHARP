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