using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    private static int GetRowCount(int[,] matrix) => matrix.GetLength(0);
    private static int GetColumnCount(int[,] matrix) => matrix.GetLength(1);

    private static IEnumerable<IEnumerable<int>> GetRows(int[,] matrix)
        => Enumerable.Range(0, GetRowCount(matrix))
                     .Select(_ => Enumerable.Range(0, GetColumnCount(matrix)))
                     .Select((x, i) => x.Select(j => matrix[i, j]));

    private static IEnumerable<IEnumerable<int>> GetColumns(int[,] matrix)
        => Enumerable.Range(0, GetColumnCount(matrix))
                     .Select(_ => Enumerable.Range(0, GetRowCount(matrix)))
                     .Select((x, i) => x.Select(j => matrix[j, i]));

    private static IEnumerable<(int i, int j)> GetIndexes(int[,] matrix)
        => Enumerable.Range(0, GetRowCount(matrix))
                     .SelectMany(x => Enumerable.Range(0, GetColumnCount(matrix)).Select(y => (x, y)));

    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var maxValuesInRows = GetRows(matrix).Select(x => x.Max()).ToArray();
        var minValuesInColumns = GetColumns(matrix).Select(x => x.Min()).ToArray();

        return GetIndexes(matrix).Where(x => maxValuesInRows[x.i] == minValuesInColumns[x.j])
                                .Select(x => (x.i + 1, x.j + 1));
    }
}