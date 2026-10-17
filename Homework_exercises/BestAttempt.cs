using System;
using System.Collections.Generic;

class BestAttempt : Ihomework
{
    public struct Attempt
    {
        public int Score;
        public int Day;

        public Attempt (int Score, int Day)
        {
            this.Score = Score;
            this.Day = Day;
        }
    }

    public void Run()
    {
        Console.WriteLine("I was too lazy to make input system for this :3");
        Attempt[] row1Attempts = new Attempt[]
        {
            new Attempt(70, 1),
            new Attempt(90, 2),
            new Attempt(90, 3)
        };
        Attempt[] row2Attempts = new Attempt[]
        {
            new Attempt(50, 5)
        };
        Attempt[] row3Attempts = new Attempt[]
        {
            new Attempt(10, 1),
            new Attempt(15, 2)
        };
        Attempt[][] AllAttempts = new Attempt[][]
        {
            row1Attempts,
            row2Attempts,
            row3Attempts
        };
        Attempt[] BestAttempts = TakeBestAttempts(AllAttempts);
        Console.WriteLine("These are the Best Attempts in each row: \n");

        foreach (var att in BestAttempts)
        {
            Console.WriteLine($"Score - {att.Score}, Day - {att.Day};");
        }
    }

    public static Attempt[] TakeBestAttempts(Attempt[][] attempts)
    {
        var result = new List<Attempt>();
        for (int i = 0; i < attempts.Length; i++)
        {
            var bestAttempt = attempts[i][0];
            for (int j = 1; j < attempts[i].Length; j++)
            {
                if (bestAttempt.Score < attempts[i][j].Score)
                {
                    bestAttempt = attempts[i][j];
                }
            }
            result.Add(bestAttempt);
        }
        return result.ToArray();
    }

}
