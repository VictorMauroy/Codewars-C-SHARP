# ***Best practices and good to know***
In this document, I'm adding some tips useful for C# development and some best practices good to know. 

## <span style="color: green"><u>**Functions & Methods**</u></span>

#### **Lambda expression** 
Useful for one line functions </br>
```bash
public static string EvenOrOdd(int number)
=> number%2 == 0 ? "Even": "Odd";
```


Can also be used that way : </br>
```bash
int[] numbers = { 4, 7, 10 };
int product = numbers.Aggregate(1, (interim, next) => interim * next); 
```
That really shines when you don't want to make multiples lines calculations. Here, the aggregate function works like the `Array.reduce()` in Javascript.
</br>

#### **Enumarable.Aggregate**
Applies an accumulator function over a sequence. Usually used for lists or arrays.<br>
<span style="color: red">Require : using System.Linq;</span>


For example, we must get the sum of every number in a given array :
```bash
int[] numbers = { 1, 2, 3, 4, 5 };
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

## <span style="color: green"><u>**Conversions**</u></span>

#### **Int to string**
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