using System;

class SumRange : Ihomework
{
    public void Run()
    {
        System.Console.WriteLine("~This program calculates the sum of all the numbers in given range~");

        System.Console.WriteLine("Enter the first number: ");
        int num1;
        while (!Int32.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Please enter valid number...");
        }
        System.Console.WriteLine("Enter the second number: ");
        int num2;
        while (!Int32.TryParse(Console.ReadLine(), out num2) || num2 < num1)
        {
            Console.WriteLine("Please enter valid number...");
        }
        Console.WriteLine($"The sum of the range [{num1}; {num2}] is {Calculate(num1, num2)}");
    }
    public static int Calculate(int start, int end)
    {
        int sum = 0;
        for (;start <= end; start++)
        {
            sum += start;
        }
        return sum;
    }
}   