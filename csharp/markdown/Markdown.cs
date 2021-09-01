using System;
using System.Linq;
using System.Collections.Generic;

public class Markdown
{
    private static readonly Dictionary<string, string> simpleTags = new()
    {
        {"__", "strong"},
        {"_", "em" }
    };

    public static string Parse(string markdown)
    {
        var lines = markdown.Split("\n")
                            .Select(ParseLine)
                            .ToArray();

        var text = string.Join("", lines);
        return text.Contains("<li>")
            ? WrapListItems(text)
            : text;
    }

    private static string ParseLine(string line)
    {
        return ParseSimpleTags(line) switch {
            var s when s.StartsWith("#") => ParseHeader(s),
            var s when s.StartsWith("*") => ParseListItem(s),
            var s => Wrap(text: s, tag: "p")
        };
    }

    private static string ParseHeader(string line)
    {
        var headersLength = line.TakeWhile(x => x == '#').Count();
        var innerHtml = new string(line.Skip(headersLength).ToArray()).TrimStart();

        return Wrap(innerHtml, $"h{headersLength}");
    }

    private static string ParseListItem(string line)
    {
        var innerHtml = new string(line.Skip(count: 1).ToArray()).TrimStart();

        return Wrap(innerHtml, "li");
    }

    private static string WrapListItems(string line)
    {
        var firstOccurrence = line.IndexOf("<li>", StringComparison.Ordinal);
        var lastOccurrence = line.LastIndexOf("</li>", StringComparison.Ordinal);
        var innerHtml = line.Substring(firstOccurrence, lastOccurrence - firstOccurrence + "</li>".Length);

        return line.Replace(innerHtml, Wrap(text: innerHtml, tag: "ul"));
    }

    private static string ParseSimpleTags(string line)
    {
        if (!simpleTags.Keys.Any(line.Contains))
        {
            return line;
        }

        var (markdownTag, htmlTag) = simpleTags.First(x => line.Contains(x.Key));
        var innerHtml = ExtractInnerHtml(line, markdownTag);
        var wrappedHtml = Wrap(innerHtml, htmlTag);
        var textToReplace = $"{markdownTag}{innerHtml}{markdownTag}";

        return ParseSimpleTags(line.Replace(textToReplace, wrappedHtml));
    }

    private static string ExtractInnerHtml(string line, string tag)
    {
        var firstOccurrence = line.IndexOf(tag, StringComparison.Ordinal);
        var secondOccurrence = line.IndexOf(tag, firstOccurrence + tag.Length, StringComparison.Ordinal);

        return line.Substring(firstOccurrence + tag.Length, secondOccurrence - firstOccurrence - tag.Length);
    }

    private static string Wrap(string text, string tag)
        => $"<{tag}>{text}</{tag}>";
}