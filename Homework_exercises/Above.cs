using System;
using System.Collections.Generic;

class Above : Ihomework
{
    public void Run()
    {
        Console.WriteLine("This program gets an input matrix and integer limit, returning a 1D array of values greater than the limit.\n");

        int rows;
        Console.Write("Enter number of rows: ");
        while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
        {
            Console.Write("Invalid input. Please enter a positive integer for rows: ");
        }

        int columns;
        Console.Write("Enter number of columns: ");
        while (!int.TryParse(Console.ReadLine(), out columns) || columns <= 0)
        {
            Console.Write("Invalid input. Please enter a positive integer for columns: ");
        }

        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            bool validRow = false;
            while (!validRow)
            {
                Console.WriteLine($"Enter row {i + 1} values ({columns} numbers separated by spaces):");
                string[] rowInts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (rowInts.Length != columns)
                {
                    Console.WriteLine($"Error: Expected exactly {columns} numbers, but got {rowInts.Length}. Try again.");
                    continue;
                }

                bool allNumbersValid = true;
                for (int j = 0; j < columns; j++)
                {
                    if (!int.TryParse(rowInts[j], out matrix[i, j]))
                    {
                        allNumbersValid = false;
                        break;
                    }
                }

                if (!allNumbersValid)
                {
                    Console.WriteLine("Error: Invalid Number Entrie. Try again.");
                }
                else
                {
                    validRow = true;
                }
            }
        }

        int limit;
        Console.Write("Enter the limit: ");
        while (!int.TryParse(Console.ReadLine(), out limit))
        {
            Console.Write("Invalid input. Please enter a valid integer for the limit: ");
        }

        int[] result = AboveArr(matrix, rows, columns, limit);

        Console.WriteLine($"\nValues greater than the limit {limit}:");
        if (result.Length == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            Console.WriteLine(string.Join(", ", result));
        }
    }
    public static int[] AboveArr(int[ , ] matrix, int rows, int colums, int limit)
    {
        List<int> resultArr = new List<int>();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < colums; j++)
            {
                if (matrix[i, j] > limit)
                {
                    resultArr.Add(matrix[i, j]);
                }
            }
        }
        return resultArr.ToArray();
    }
}
