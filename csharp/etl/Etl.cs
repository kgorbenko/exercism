using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
        => old.SelectMany(pair => pair.Value.Select(y => (Key: y, Value: pair.Key)))
              .ToDictionary(x => x.Key.ToLower(), x => x.Value);
}