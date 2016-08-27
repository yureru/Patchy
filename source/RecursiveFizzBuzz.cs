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
        Console.Write(FizzBuzz(1, str, 100));
    }

    static string FizzBuzz(int num, string str, int upTo)
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

        if (num < upTo)
        {
            return FizzBuzz(num + 1, str, upTo);
        }

        return str;
    }
}