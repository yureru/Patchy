using System;
/// <summary>
/// Approach to write a recursive FizzBuzz. It's tail recursive, therefore it's TCO, but
/// that depends on the CLR and C# Compiler.
/// </summary>
class Program
{
    static void Main()
    {
        string str = "";
        Console.Write(FizzBuzz(1, str));
    }

    static string FizzBuzz(int num, string str)
    {
        bool flag = false;

        if (num % 3 == 0)
        {
            str += "Fizz";
            flag = true;
        }
        if (num % 5 == 0)
        {
            str += "Buzz";
            flag = true;
        }
        if (!flag)
        {
            str += num.ToString();
        }
        str += "\n";

        if (num < 100)
        {
            return FizzBuzz(num + 1, str);
        }

        return str;
    }
}