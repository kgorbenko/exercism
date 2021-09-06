using System;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private string diagram;
    private Dictionary<char, Plant> PlantMap;

    public KindergartenGarden(string diagram)
    {
        this.diagram = diagram;
        PlantMap = new Dictionary<char, Plant>
        {
            {'G', Plant.Grass }, {'C', Plant.Clover }, {'R', Plant.Radishes }, {'V', Plant.Violets }
        };
    }

    public IEnumerable<Plant> Plants(string student)
    {
        int numberInRow = 0;

        for (int i = 65; i <= 76; i++)
            if (student.StartsWith((char)i)) numberInRow = i - 65;

        string currentDiagram = diagram.Substring(numberInRow * 2, 2) + 
                                diagram.Substring(diagram.Length / 2 + numberInRow * 2 + 1, 2);

        Plant subPlant;
        for (int i = 0; i < 4; i++)
        {
            PlantMap.TryGetValue(currentDiagram[i], out subPlant);
            yield return subPlant;
        }
    }
}