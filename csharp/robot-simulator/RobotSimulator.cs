using System;
using System.Collections.Generic;
using System.Linq;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public int X { get; private set; }

    public int Y { get; private set; }

    public Direction Direction { get; private set; }

    private static readonly LinkedList<Direction> tableOfTurns = new(Enum.GetValues<Direction>());

    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public void Move(string instructions)
    {
        if (string.IsNullOrWhiteSpace(instructions))
        {
            throw new ArgumentNullException(nameof(instructions));
        }

        foreach (var character in instructions)
        {
            switch (character)
            {
                case 'A': Advance(); break;
                case 'R': TurnRight(); break;
                case 'L': TurnLeft(); break;
            }
        }
    }

    private void Advance()
    {
        switch (Direction)
        {
            case Direction.North: Y += 1; break;
            case Direction.South: Y -= 1; break;
            case Direction.East: X += 1; break;
            case Direction.West: X -= 1; break;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    private void TurnRight()
    {
        var nextDirection = tableOfTurns.Find(Direction).Next?.Value;

        Direction = nextDirection ?? Direction.North;
    }

    private void TurnLeft()
    {
        var nextDirection = tableOfTurns.Find(Direction).Previous?.Value;

        Direction = nextDirection ?? Direction.West;
    }
}