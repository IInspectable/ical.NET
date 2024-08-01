using System.Text.RegularExpressions;

namespace iCalNET;

public class CalendarParameter {

    const string NameValuePattern = "(.+?):(.+)";

    public static CalendarParameter FromString(string source) {

        var unfold         = source.UnfoldAndUnescape();
        var nameValueMatch = Regex.Match(unfold, NameValuePattern);

        return new() {
            Name  = nameValueMatch.Groups[1].ToString().Trim(),
            Value = nameValueMatch.Groups[2].ToString().Trim()
        };

    }

    public required string Name  { get; init; }
    public required string Value { get; init; }

}