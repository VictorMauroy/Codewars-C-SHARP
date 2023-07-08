/* 
Write a function, which takes a non-negative integer (seconds) as input and returns the time in a human-readable format (HH:MM:SS)

HH = hours, padded to 2 digits, range: 00 - 99
MM = minutes, padded to 2 digits, range: 00 - 59
SS = seconds, padded to 2 digits, range: 00 - 59
The maximum time never exceeds 359999 (99:59:59)
*/
public static class TimeFormat
{
    public static string GetReadableTime(int duration)
    {
      int seconds = duration % 60 ;
      int minutes = (int) (duration / 60) % 60;
      int hours = (int) (duration / 3600);
      
      return 
        (hours > 10 ? hours : "0" + hours ) + 
        ":" + 
        (minutes > 10 ? minutes : "0" + minutes) + 
        ":" + 
        (seconds > 10 ? seconds : "0" + seconds);
    }
}

/* More interesting
return string.Format("{0:d2}:{1:d2}:{2:d2}", seconds / 3600, seconds / 60 % 60, seconds % 60);

var t = TimeSpan.FromSeconds(seconds);
        return string.Format("{0:00}:{1:00}:{2:00}", (int)t.TotalHours, t.Minutes, t.Seconds);

int sec = (seconds % 60);
      int min = ((seconds-sec)/60)%60;
      int hour = (seconds-sec-(60*min))/(60*60);
      
      return (hour.ToString("00")+":"+min.ToString("00")+":"+sec.ToString("00"));
*/