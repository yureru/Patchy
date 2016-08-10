using System;
/// <summary>
/// My first attempt ever to make a fizzbuzz.
/// </summary>
class Program
{
    static void Main()
    {
        for (int i = 1; i <= 100; ++i)
        {
            bool flag = false;
            if (i % 3 == 0)
            {
                Console.Write("Fizz");
                flag = true;
            }
            if (i % 5 == 0)
            {
                Console.Write("Buzz");
                flag = true;
            }
            if (!flag)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}