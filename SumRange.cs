class SumRange
{
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