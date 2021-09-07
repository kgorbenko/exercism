using System;
using System.Collections.Generic;

public class SaddlePoints
{
    private int[,] matrix;

    public SaddlePoints(int[,] values)
    {
        matrix = values;
    }

    public IEnumerable<(int, int)> Calculate()
    {
        var points = new List<(int, int)>();

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (IsSaddle((i, j))) points.Add((i, j));
            }

        return points;
    }

    private bool IsSaddle((int, int) point)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[point.Item1, j] > matrix[point.Item1, point.Item2]) return false; 
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, point.Item2] < matrix[point.Item1, point.Item2]) return false;
        }

        return true;
    }
}