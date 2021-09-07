using System;
using System.Collections.Generic;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public Direction Direction { get; private set; }

    public int X { get; private set; }

    public int Y { get; private set; }

    private static LinkedList<Direction> tableOfTurns;

    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;

        var nodes = new Direction[] {Direction.North, Direction.East, Direction.South, Direction.West };
        tableOfTurns = new LinkedList<Direction>(nodes);
    }

    public void Move(string instructions)
    {
        if (string.IsNullOrWhiteSpace(instructions)) throw new ArgumentNullException(nameof(instructions));

        foreach (var character in instructions)
            switch (character)
            {
                case 'A': Advance(); break;
                case 'R': TurnRight(); break;
                case 'L': TurnLeft(); break;
            }
    }

    private void Advance()
    {
        if (Direction == Direction.North) Y += 1;
        if (Direction == Direction.South) Y -= 1;
        if (Direction == Direction.East)  X += 1;
        if (Direction == Direction.West)  X -= 1;
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