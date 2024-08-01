using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace iCalNET;

public class ContentLine {

    const string       ContentLineContentPattern      = "(.+?)((;.+?)*):(.+)";
    const RegexOptions ContentLineContentRegexOptions = RegexOptions.Singleline;

    public required string Name  { get; init; }
    public required string Value { get; init; }

    public required ImmutableDictionary<string, ContentLineParameter> Parameters { get; init; }

    public static ContentLine FromString(string source) {

        source = source.UnfoldAndUnescape();
        var match = Regex.Match(source, ContentLineContentPattern, ContentLineContentRegexOptions);

        // TODO Error Handling
        return new() {
            Name       = match.Groups[1].ToString().Trim(),
            Parameters = ContentLineParameters.FromString(match.Groups[2].ToString()),
            Value      = match.Groups[4].ToString().Trim(),
        };
    }

}