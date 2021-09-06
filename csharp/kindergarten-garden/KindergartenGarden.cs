using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private readonly string diagram;

    public KindergartenGarden(string diagram)
    {
        this.diagram = diagram ?? throw new ArgumentNullException(nameof(diagram));
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var offset = (student[0] - 'A') * 2;

        return diagram.Split(separator: '\n')
                      .SelectMany(x => x[offset..(offset + 2)])
                      .Select(plant => plant switch {
                          'G' => Plant.Grass,
                          'C' => Plant.Clover,
                          'R' => Plant.Radishes,
                          'V' => Plant.Violets,
                          _ => throw new ArgumentException("Unknown plant.")
                      });
    }
}