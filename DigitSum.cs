class DigitSum
{
    public static int Calculate(int num)
    {
        if (num == 0)
        {
            return 0;
        }
        return (num%10 + Calculate(num/10));
    }
}