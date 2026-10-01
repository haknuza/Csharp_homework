using System;
class DigitSum : Ihomework
{
    public void Run()
    {
        System.Console.WriteLine("Enter a number to sum the digits of that number: ");
        int num;
        while (!Int32.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine("Please enter valid number...");
        }
        Console.WriteLine(Calculate(num));
    }
    public static int Calculate(int num)
    {
        if (num == 0)
        {
            return 0;
        }
        return (num%10 + Calculate(num/10));
    }
}