using System;
public class Queen
{
    public Queen(int row, int column)
    {
        if (row < 0 || row >= 8 || column < 0 || column >= 8)
            throw new ArgumentOutOfRangeException("Queen should be placed on board");
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
        return white.Row == black.Row || white.Column == black.Column || OnDiagonal();
        bool OnDiagonal()
        {
            var rowDifference = Math.Abs(white.Row - black.Row);
            var columnDifference = Math.Abs(white.Column - black.Column);
            return rowDifference == columnDifference;
        }
    }
    public static Queen Create(int row, int column)
    {
        return new Queen(row, column);
    }
}