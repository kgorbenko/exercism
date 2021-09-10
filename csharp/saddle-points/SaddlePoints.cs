using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
                         .SelectMany(x => Enumerable.Range(0, matrix.GetLength(1)).Select(y => (x, y)))
                         .Where(x => IsSaddle(x, matrix))
                         .Select(x => (x.x + 1, x.y + 1));
    }

    private static bool IsSaddle((int x, int y) point, int[,] matrix)
    {
        var value = matrix[point.x, point.y];
        var isLeastInColumn = GetColumn(point.y, matrix).All(x => x >= value);
        var isLargestInRow = GetRow(point.x, matrix).All(x => x <= value);

        return isLeastInColumn && isLargestInRow;
    }

    private static IEnumerable<int> GetRow(int rowNumber, int[,] matrix)
        => Enumerable.Range(0, matrix.GetLength(1))
                     .Select(y => matrix[rowNumber, y]);

    private static IEnumerable<int> GetColumn(int columnNumber, int[,] matrix)
        => Enumerable.Range(0, matrix.GetLength(0))
                     .Select(x => matrix[x, columnNumber]);
}