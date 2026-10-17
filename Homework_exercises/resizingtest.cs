using System;

class resz
{
    static void Add(ref int[] arr, int j)
    {
        int arr1 = new int[2];
        {
            arr1[0] = arr[arr.Length-1];
            arr1[1] = j;
        }
        arr[arr.Length - 1] = ref arr1;
    }
    foreach (var num in arr)
    {
        Console.WriteLine(num);
    }
}
