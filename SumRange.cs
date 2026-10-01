using System;

class SumRange : Ihomework
{
    public void Run()
    {
        System.Console.WriteLine("Enter the first number: ");
        int num1;
        while (!Int32.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Please enter valid number...");
        }
        System.Console.WriteLine("Enter the second number: ");
        int num2;
        while (!Int32.TryParse(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Please enter valid number...");
        }
        Console.WriteLine(Calculate(num1, num2));
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