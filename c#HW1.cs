/*
01 Introduction to C# and Data Types – Questions
1.	What type would you choose for the following “numbers”?
o	A person’s telephone number
String

o	A person’s height
double

o	A person’s age
byte

o	A person’s gender (Male, Female, Prefer Not To Answer)
enum

o	A person’s salary
decimal

o	A book’s ISBN
String

o	A book’s price
decimal

o	A book’s shipping weight
double

o	A country’s population
long

o	The number of stars in the universe
BigInteger

o	The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business)
ushort

2.	What are the differences between value type and reference type variables?
Value type store data directly on the stack while reference type store reference on the stack, the data is stored on the heap.
When you do the copy, value type will copy the value and changing copy won’t affect the value. While reference type will change the original value because all the data point to the same memory address. 

3.	What is boxing and unboxing?
boxing wraps a value type to reference type that the value will be stored on the heap, the reference will be stored on the stack.
Unboxing will get reference type data from heap and put it back to stack. 

4.	What is meant by the terms managed resource and unmanaged resource in .NET?
managed resource can be managed by CLR and garbage collector like c# object.
unmanaged resource are outside of CLR that garbage collector cannot release the resource like file handles, network sockets.

5.	What is the purpose of the Garbage Collector in .NET?
Garbage Collector can automatically manage memory after the lifetime of objects. It can prevent memory leak and optimize the program. Developers don’t need to manually allocate memory. 

Controlling Flow and Converting Types – Questions
1.	What happens when you divide an int variable by 0?

it will throw DivideByZeroException
2.	What happens when you divide a double variable by 0?
a positive double divided by 0 will get infinity
a negative double divided by 0 will get negative infinity
0 divided by 0 will get NaN

3.	What happens when you overflow an int variable (assign a value beyond its range)?
it will wrap around to the opposite end of the range.

4.	What is the difference between x = y++; and x = ++y;?
x = y++; will assign x=y then increment
x = ++y, will increment y first, then assign x=y

5.	What is the difference between break, continue, and return when used inside a loop statement?
break will jump out of loop immediately 
Continue will skip the current iteration and moves to next iteration
Return will jump out of the function return to caller

6.	What are the three parts of a for statement and which of them are required?
initialization, condition, iteration
Noe of them are required to run for statement.
7.	What is the difference between the = and == operators?
= used to assign value 
== is the equality operator to check if two value are equal

8.	Does the following statement compile? for ( ; true; ) ;
Yes, it’s an infinite loop
9.	What interface must an object implement to be enumerated by the foreach statement?
IEnumerable interface must be implemented so foreach can iterate, for build-in collections like array, list, .NET has already implemented iEnumerable, so developers don’t need to implement.

*/




// Coding：
// 1. How can we find the minimum and maximum values, as well as the number of bytes, for the following data types: sbyte, byte, short, ushort, int, uint, long, ulong, float, double, and decimal?

using System.Runtime.InteropServices;

class Question1
{    public static void Property()
    {
        Console.WriteLine("For sbyte, Min =  " + sbyte.MinValue + ", Max = " + sbyte.MaxValue + ", size is " + sizeof(sbyte) + " bytes");
        Console.WriteLine("For byte, Min = " + byte.MinValue   + ", Max = " + byte.MaxValue   + ", size = " + sizeof(byte)   + " bytes");
        Console.WriteLine("For short, Min = " + short.MinValue  + ", Max = " + short.MaxValue  + ", size = " + sizeof(short)  + " bytes");
        Console.WriteLine("For ushort, Min = " + ushort.MinValue + ", Max = " + ushort.MaxValue + ", size = " + sizeof(ushort) + " bytes");
        Console.WriteLine("For int, Min = " + int.MinValue    + ", Max = " + int.MaxValue    + ", size = " + sizeof(int)    + " bytes");
        Console.WriteLine("For uint, Min = " + uint.MinValue   + ", Max = " + uint.MaxValue   + ", size = " + sizeof(uint)   + " bytes");
        Console.WriteLine("For long, Min = " + long.MinValue   + ", Max = " + long.MaxValue   + ", size = " + sizeof(long)   + " bytes");
        Console.WriteLine("For ulong, Min = " + ulong.MinValue  + ", Max = " + ulong.MaxValue  + ", size = " + sizeof(ulong)  + " bytes");
        Console.WriteLine("For float, Min = " + float.MinValue  + ", Max = " + float.MaxValue  + ", size = " + sizeof(float)  + " bytes");
        Console.WriteLine("For double, Min = " + double.MinValue + ", Max = " + double.MaxValue + ", size = " + sizeof(double) + " bytes");
        Console.WriteLine("For decimal, Min = " + decimal.MinValue+ ", Max = " + decimal.MaxValue+ ", size = " + sizeof(decimal)+ " bytes");
    }
}


// 2. Write a method in C# called FizzBuzz that takes an integer num and prints numbers from 1 up to num, but:
// Print Fizz if the number is divisible by 3.
// Print Buzz if the number is divisible by 5.
// Print FizzBuzz if the number is divisible by both 3 and 5.
// Otherwise, print the number itself.

class Question2
{
    public static void FizzBuzz(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}

// 3. What will happen if this code executes?
// int max = 500;
// for (byte i = 0; i < max; i++)
// {
//     Console.WriteLine(i);
// }
/*
Since the up bound of byte is 255, i in loop will always smaller than 500, it's an infinite loop. 
i will jump to 0 after increment from 255. so the code will print from 0 to 255 infinitely
*/



// 4. Two Sum
// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
// You may assume that each input would have exactly one solution.
// You may not use the same element twice.
// You can return the answer in any order.
class Question4
{
    public static (int, int) TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    Console.WriteLine($"answer is {nums[i]},{nums[j]}");
                    return (nums[i], nums[i]);
                }
            }
        }
        return (0, 0);
    }
}

class Program
{
    static void Main()
    {
        Question1.Property();
        Question2.FizzBuzz(15);

        int[] nums = [5, 4, 2, 1, 7,9,10,3,15];
        int target = 18;
        Question4.TwoSum(nums, target);

    }
}