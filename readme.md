# ***Best practices and good to know in C#***
In this document, I'm adding some tips useful for C# development and some best practices good to know. 

## <span style="color: green"><u>**Lambda expression**</u></span>

Useful for one line functions </br>
```bash
public static string EvenOrOdd(int number)
=> number%2 == 0 ? "Even": "Odd";
```


Some methods also use it : </br>
```bash
int[] numbers = [ 4, 7, 10 ];
int product = numbers.Aggregate(1, (interim, next) => interim * next); 
```
That really shines when you don't want to make multiples lines calculations. Here, the aggregate function works like the `Array.reduce()` in Javascript.
</br><br>

## <span style="color: green"><u>**Switch expression**</u></span>
### **Traditionnal switch case**

**Switch utility:** The switch case expression allows to do specific actions depending of a given value. In some case, it could be a good idea to replace an `if{} else if{} else{}` by a switch case.

Note that the traditionnal switch case can only work with `integer`, `enum`, `char` and `string`.

```csharp
enum Behavior {
    Agressive,
    Passive
}

Behavior enemyBehavior = Behavior.Agressive;

switch(enemyBehavior)
{
    case Behavior.Agressive:
        // Do something
        break;
    
    case Behavior.Passive:
        // Do something else
        break;
    
    default:
        //Do something when it did not matched any cases
        break;
}
```
`switch` => depending of (your value). <br>
`case` => in case your value is equal to (a value). <br>
`default` => default action if it didn't matched any case.

### **Enhanced switch expression**
Introduced in C# 8.0. The switch expression is an enhancement over the traditional switch statement, which can only be used to evaluate discrete values.
```csharp
int number = 2;
string result = number switch
{
    1 => "One",
    2 => "Two",
    3 => "Three",
    _ => "Other"
};
```
The above expression will return a different string depending of the number we gave it. Currently, it will return "Two" because we gave it an integer with the value 2. 

It can be used to **switftly return a result for a function** :
```csharp
public static string GetStringValue(int number) => c switch
{
    15 => "Quinze",
    29 => "Vingt-neuf",
    _ => "Other"
};
```
```csharp
int data = 42;
string result = GetDataStatus(data);

static string GetDataStatus(int data)
{
    return data switch
    {
        int value when value > 0 && value <= 100 => "Valid data",
        int value when value > 100 => "Out of range",
        int value when value <= 0 => "Invalid data",
        string str when string.IsNullOrEmpty(str) => "Empty string",
        string str => $"String with {str.Length} characters",
        _ => "Unknown data"
    };
}
```
`when` is a keyword that can be used when doing specific operations, likes returning a new variable that is yet to be set.

## <span style="color: green"><u>**Arrays methods**</u></span>

### **Enumarable.Aggregate**

Applies an accumulator function over a sequence. Usually used for lists or arrays.<br>
<span style="color: red">Require : using System.Linq;</span>


For example, we must get the sum of every number in a given array :
```bash
int[] numbers = [ 1, 2, 3, 4, 5 ];
```
We can do that with the aggregate method :
```bash
int sum = numbers.Aggregate((acc, num) => acc + num);
```
The aggregate function works with a lambda expression.<br>
`int sum` will receive the result of the calculation.<br>
`acc` is the accumulator, it will progressively receive the result of each operation and accumulate it.<br>
`num` is the current number to process (1 then 2, then 3, etc.)
<br>
<br> <u>Multiplication with aggregate</u><br>
```bash
int product = numbers.Aggregate(1, (acc, num) => acc * num);
```
`Aggregate(1, ...)` 1 is the default value of the accumulator, if not set, the default value is 0. (That's a huge problem for a multiplication... !)

### **Enumarable.Select**
Return an array or a list with each element modified depending of your instuction inside the Select brackets.<br>
<span style="color: red">Require : using System.Linq;</span>

For example, we must multiply each element of an array by 2.
```bash
int[] numbers = [ 1, 2, 3, 4, 5 ];
```
We can do that with the Select method :
```bash
var multipliedNumbers = numbers.Select(num => num * 2);
```

### **Enumarable.Where**
Return an array or a list filtered by a given condition.<br>
<span style="color: red">Require : using System.Linq;</span>
For example, we must multiply each element of an array by 2, <u>but</u> only the ones that are multiples of 2.
```bash
int[] numbers = [ 1, 2, 3, 4, 5 ];
```
We can do that with the Select and Where methods :
```bash
var filteredAndMultipliedNumbers = numbers
    .Where(num => num % 2 == 0) //The condition is modulo 2
    .Select(num => num * 2);
```
The result will be a list {4, 8}. (2x2 and 4x2).

### **Merge string array values**
A few methods to merge values of an array.<br>
```bash
String.Concat(yourArray);
```
```bash
String.Join("", yourArray);
//Where "" is the separator that must appear between each element.
```

### **Get a range of values**
We want to obtain values at index 3 to 7 from an array of 10 values :
```bash
int[] numbers = [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ];
```
After C# 8. It is possible to use the range operator :
```bash
int[] middleNumbers = numbers[3..8];
// ==> middleNumbers = [4, 5, 6, 7, 8]
```
Note that the first value is included but the second one is excluded.
<br>

## <span style="color: green"><u>**Dictionaries**</u></span>

Dictionaries are interesting to save values in a different way than arrays or lists. <br>
It allows to save a **value** for a special **key** index. <br>
Where the key can be anything, usually a string or a int and the value can also be a string, int or an array, a list, etc.
<br>
<br>
Require : using System.Collections.Generic;

### **Creating a new dictionary**
```bash
IDictionary<int, int> numberOccurence = new Dictionary<int, int>(); 
// One integer and its occurence count 
```
```bash
IDictionary<string, string[]> citiesPeoples = new Dictionary<string, string[]>(); 
// One city name for many people names
```

### **Adding and updating values**
```bash
myDictionary.Add("txt", "notepad.exe");
```
```bash
myDictionary["txt"] = "notepad.exe";
```
### **Checking key or values**
```bash
if(myDictionary.TryGetValue("txt", out theValue)) {}
```

```bash
if(myDictionary.ContainsKey("txt")) {}
```
```bash
if(myDictionary.ContainsValue("notepad.exe")) {}
```

### **Iteration on dictionaries**
Require : using System.Linq; to use ElementAt(index)
```bash
for(int i =0; i < numberOccurence.Count; i++) 
{
    if(numberOccurence.ElementAt(i).Value % 2 != 0) 
        return numberOccurence.ElementAt(i).Key;
}
```
```bash
foreach( KeyValuePair<string, string> kvp in openWith )
{
    Console.WriteLine(
        "Key = {0}, Value = {1}",
        kvp.Key, kvp.Value
    );
}
```

<details>
<summary>Acces keys or values distinctly </summary>
<br>

An exemple with a simple dictionary : 
```bash
Dictionary<string, string> openWith =
    new Dictionary<string, string>();
```

**Itering on the values (only)**
```bash
Dictionary<string, string>.ValueCollection valueColl =
    openWith.Values;

// The elements of the ValueCollection are strongly typed
// with the type that was specified for dictionary values.
Console.WriteLine();
foreach( string s in valueColl )
{
    Console.WriteLine("Value = {0}", s);
}
```
<br>

**Itering on the keys (only)**

```bash
// To get the keys alone, use the Keys property.
Dictionary<string, string>.KeyCollection keyColl =
    openWith.Keys;

// The elements of the KeyCollection are strongly typed
// with the type that was specified for dictionary keys.
Console.WriteLine();
foreach( string s in keyColl )
{
    Console.WriteLine("Key = {0}", s);
}
```

</details>
<br>

## <span style="color: green"><u>**Conversions**</u></span>

### **Int to string**
Where `i` is the integer to convert.
```bash
string a = i.ToString();
string b = Convert.ToString(i);
string c = string.Format("{0}", i);
string d = $"{i}";
string e = "" + i;
string f = string.Empty + i;
string g = new StringBuilder().Append(i).ToString();
```