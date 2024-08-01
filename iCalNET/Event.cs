using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace iCalNET;

public class Event {

    const string       EventContentPattern      = "BEGIN:VEVENT\\r\\n(.+)\\r\\nEND:VEVENT";
    const RegexOptions EventContentRegexOptions = RegexOptions.Singleline;

    const string       ContentLinePattern       = "(.+?):(.+?)(?=\\r\\n[A-Z]|$)";
    const RegexOptions ContentLineTRegexOptions = RegexOptions.Singleline;

    public static Event FromString(string source) {

        var contentMatch = Regex.Match(source, EventContentPattern, EventContentRegexOptions);
        var content      = contentMatch.Groups[1].ToString();
        var matches      = Regex.Matches(content, ContentLinePattern, ContentLineTRegexOptions);

        var contentLines = new Dictionary<string, ContentLine>();

        foreach (Match match in matches) {
            var contentLineString = match.Groups[0].ToString();
            var contentLine       = ContentLine.FromString(contentLineString);

            contentLines[contentLine.Name] = contentLine;
        }

        return new Event {
            ContentLines = contentLines.ToImmutableDictionary()
        };

    }

    public required ImmutableDictionary<string, ContentLine> ContentLines { get; init; }

}