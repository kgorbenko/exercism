using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

public class Markdown
{
    private static Dictionary<string, string> SimpleTags = new Dictionary<string, string>()
    {
        {"__", "strong"}, {"_", "em" }
    };

    public static string Parse(string markdown)
    {
        var lines = markdown.Split("\n");
        var result = "";

        foreach (var line in lines)
            result += ParseLine(line);

        if (result.Contains("<li>"))
            result = WrapListItems(result);

        return result;
    }

    private static string ParseLine(string line)
    {
        line = ParseSimpleTags(line);

        if (line.StartsWith("#"))
            line = ParseHeader(line);

        else if (line.StartsWith("*"))
            line = ParseListItem(line);

        else line = $"<p>{line}</p>";

        return line;
    }

    private static string ParseHeader(string line)
    {
        int headerLevel = 0;

        while (line.StartsWith("#"))
        {
            line = line.Remove(0, 1);
            headerLevel += 1;
        }

        return Wrap(line.TrimStart(), $"h{headerLevel}");
    }

    private static string ParseListItem(string line)
    {
        line = line.Remove(0, 1);

        return Wrap(line.TrimStart(), "li");
    }

    private static string WrapListItems(string line)
    {
        var firstOccurrance = line.IndexOf("<li>");
        var lastOccurrance = line.LastIndexOf("</li>");

        var undertag = line.Substring(firstOccurrance, lastOccurrance - firstOccurrance + 5);

        return line.Replace(undertag, $"<ul>{undertag}</ul>");
    }

    private static string ParseSimpleTags(string line)
    {
        foreach (var pair in SimpleTags)
        {
            if (line.Contains(pair.Key))
            {
                var undertag = ExtractUndertag(line, pair.Key);

                var wrappedText = Wrap(undertag, pair.Value);

                var textToReplace = $"{pair.Key}{undertag}{pair.Key}";

                line = line.Replace(textToReplace, wrappedText);
            }
        }

        return line;
    }

    private static string ExtractUndertag(string line, string tag)
    {
        var firstOccurrance = line.IndexOf(tag);
        var secondOccurrance = line.IndexOf(tag, firstOccurrance + tag.Length);

        return line.Substring(firstOccurrance + tag.Length, secondOccurrance - firstOccurrance - tag.Length);
    }

    private static string Wrap(string text, string tag)
    {
        return $"<{tag}>{text}</{tag}>";
    }
}