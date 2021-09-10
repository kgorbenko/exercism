using System;

public class Queen
{
    public Queen(int row, int column)
    {
        if (row is < 0 or >= 8)
        {
            throw new ArgumentOutOfRangeException(nameof(row));
        }
        if (column is < 0 or >= 8)
        {
            throw new ArgumentOutOfRangeException(nameof(column));
        }

        Row    = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        var onSameRow = white.Row == black.Row;
        var onSameColumn = white.Column == black.Column;
        var onDiagonal = Math.Abs(white.Row - black.Row) ==
                         Math.Abs(white.Column - black.Column);

        return onSameRow || onSameColumn || onDiagonal;
    }

    public static Queen Create(int row, int column) => new(row, column);
}