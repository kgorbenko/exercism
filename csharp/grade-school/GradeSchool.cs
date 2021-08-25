using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly IDictionary<int, List<string>> roster = new Dictionary<int, List<string>>();

    public void Add(string student, int grade)
    {
        if (roster.ContainsKey(grade))
        {
            roster[grade].Add(student);
        }
        else
        {
            roster.Add(grade, new List<string> { student });
        }
    }

    public IEnumerable<string> Roster() =>
        roster.OrderBy(x => x.Key)
              .SelectMany(x => x.Value.OrderBy(y => y));

    public IEnumerable<string> Grade(int grade) =>
        roster.ContainsKey(grade)
            ? roster[grade].OrderBy(x => x)
            : Enumerable.Empty<string>();
}