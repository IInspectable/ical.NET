using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace iCalNET;

public class CalendarParameters {

    const string       ParameterPattern     = "(.+?):(.+?)(?=\\r\\n[A-Z]|$)";
    const RegexOptions ParameteRegexOptions = RegexOptions.Singleline;

    public static ImmutableDictionary<string, CalendarParameter> FromString(string source) {

        var dict              = new Dictionary<string, CalendarParameter>();
        var parametereMatches = Regex.Matches(source, ParameterPattern, ParameteRegexOptions);

        foreach (Match parametereMatch in parametereMatches) {

            var parameterString   = parametereMatch.Groups[0].ToString();
            var calendarParameter = CalendarParameter.FromString(parameterString);

            dict[calendarParameter.Name] = calendarParameter;
        }

        return dict.ToImmutableDictionary();
    }

}