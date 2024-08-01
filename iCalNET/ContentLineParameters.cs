using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace iCalNET;

public static class ContentLineParameters {

    const string ParameterPattern = "([^;]+)(?=;|$)";

    public static ImmutableDictionary<string, ContentLineParameter> FromString(string source) {

        var matches = Regex.Matches(source, ParameterPattern);

        return matches.Select(match => ContentLineParameter.FromString(match.Groups[1].ToString()))
                      .ToDictionary(keySelector: contentLineParameter => contentLineParameter.Name,
                                    elementSelector: contentLineParameter => contentLineParameter)
                      .ToImmutableDictionary();

    }

}