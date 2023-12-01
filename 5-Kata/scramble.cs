

// First try that almost works :
public static bool Scramble(string str1, string str2) 
{
    var orderedStr = str2;
    Console.WriteLine(string.Concat(orderedStr));
    
    var intersection = str1.Intersect(str2);
    Console.WriteLine(string.Concat(intersection));
    
    return orderedStr.Count() == intersection.Count();
}