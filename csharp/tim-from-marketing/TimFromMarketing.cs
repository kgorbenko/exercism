using System.Collections.Generic;

public static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        return string.Join(" - ", GetBadgeParts(id, name, department));
    }

    private static IEnumerable<string> GetBadgeParts(int? id, string name, string? department)
    {
        if (id is not null)
            yield return $"[{id}]";

        yield return name;
        yield return department is not null ? department.ToUpperInvariant() : "OWNER";
    }
}