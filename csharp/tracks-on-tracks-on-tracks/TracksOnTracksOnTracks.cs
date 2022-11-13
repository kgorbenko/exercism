using System.Collections.Generic;
using System.Linq;

public static class Languages {
    public const string CSharp = "C#";

    public static List<string> NewList() => new();

    public static List<string> GetExistingLanguages() =>
        new[] {CSharp, "Clojure", "Elm"}.ToList();

    public static List<string> AddLanguage(List<string> languages, string language) =>
        new(languages) { language };

    public static int CountLanguages(List<string> languages) =>
        languages.Count;

    public static bool HasLanguage(List<string> languages, string language) =>
        languages.Contains(language);

    public static List<string> ReverseList(List<string> languages) =>
        languages.AsEnumerable()
                 .Reverse()
                 .ToList();

    public static bool IsExciting(List<string> languages) =>
        (languages.Count > 0 && languages[0] is CSharp) ||
        (languages.Count is 2 or 3 && languages[1] is CSharp);

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        var newList = new List<string>(languages);
        newList.Remove(language);
        return newList;
    }

    public static bool IsUnique(List<string> languages) =>
        languages.Distinct().Count() == languages.Count;
}