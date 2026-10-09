using System;
using System.Collections.Generic;

class ColderThan : Ihomework
{
    public struct Reading
    {
        public int Temperature;
        public bool Fault;
        public Reading(int temperature, bool fault)
        {
            Temperature = temperature;
            Fault = fault;
        }
    }

    public struct Hit
    {
        public int Temperature;
        public int Row;
        public int Col;

        public Hit (int T, int R, int C)
        {
           Temperature = T;
           Row = R;
           Col = C;
        }
    }

    public void Run()
    {
        Reading[][] readings = new Reading[][]
        {
            new Reading[] { new Reading(15, false), new Reading(5, false), new Reading(20, true) },
            new Reading[] { new Reading(2, true), new Reading(18, false) }
        };

        int limit = 10;

        Hit[] hits = isColderThan(readings, limit);

        Console.WriteLine($"Readings below {limit}°C (without faults): \n");
        foreach (var hit in hits)
        {
            Console.WriteLine($"Temp: {hit.Temperature}°C at Row {hit.Row}, Col {hit.Col}");
        }
    }

    public static Hit[] isColderThan(Reading[][] readings, int limit)
    {
        var result = new List<Hit>();
        for (int i = 0; i < readings.Length; i++)
        {
            if (readings[i] == null) continue;

            for (int j = 0; j < readings[i].Length; j++)
            {
                if (readings[i][j].Fault == true && readings[i][j].Temperature < limit)
                {
                    var hit = new Hit(readings[i][j].Temperature, i, j);
                    result.Add(hit);
                }
            }
        }
        return result.ToArray();
    }

}
