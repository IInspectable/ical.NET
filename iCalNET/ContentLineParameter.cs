using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace iCalNET;

public class ContentLineParameter {

    const string NameValuePattern = "(.+?)=(.+)";
    const string ValueListPattern = "([^,]+)(?=,|$)";

    public static ContentLineParameter FromString(string source) {

        var values      = new List<string>();
        var match       = Regex.Match(source, NameValuePattern);
        var name        = match.Groups[1].ToString().Trim();
        var valueString = match.Groups[2].ToString();
        var matches     = Regex.Matches(valueString, ValueListPattern);

        foreach (Match paramMatch in matches) {
            values.Add(paramMatch.Groups[1].ToString().Trim());
        }

        return new ContentLineParameter {
            Name   = name,
            Values = [.. values]
        };
    }

    public required string                 Name   { get; init; }
    public required ImmutableArray<string> Values { get; init; }

}