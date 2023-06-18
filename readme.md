# ***Best practices and good to know***
In this document, I'm adding some tips useful for C# development and some best practices good to know. 

## <span style="color: green"><u>**Functions**</u></span>
#### **Lambda expression**
Useful for one line functions </br>
`public static string EvenOrOdd(int number)` </br>
`=> number%2 == 0 ? "Even": "Odd";`
</br>

Can also be used that way : </br>
`int[] numbers = { 4, 7, 10 };` </br>
`int product = numbers.Aggregate(1, (interim, next) => interim * next);` </br>
That really shines when you don't want to make multiples lines calculations. Here, the aggregate function works like the `Array.reduce()` in Javascript.
</br>
