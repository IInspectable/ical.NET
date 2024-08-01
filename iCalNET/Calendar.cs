using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace iCalNET;

public class Calendar {

    const string       CalendarParameterPattern      = "BEGIN:VCALENDAR\\r\\n(.+?)\\r\\nBEGIN:VEVENT";
    const RegexOptions CalendarParameterRegexOptions = RegexOptions.Singleline;
    const string       EventPattern                  = "(BEGIN:VEVENT.+?END:VEVENT)";
    const RegexOptions EventRegexOptions             = RegexOptions.Singleline;

    public static Calendar FromString(string source) {

        var parameterMatch  = Regex.Match(source, CalendarParameterPattern, CalendarParameterRegexOptions);
        var parameterString = parameterMatch.Groups[1].ToString();
        var parameters      = CalendarParameters.FromString(parameterString);
        var events          = new List<Event>();

        foreach (Match vEventMatch in Regex.Matches(source, EventPattern, EventRegexOptions)) {
            var vEventString = vEventMatch.Groups[1].ToString();
            events.Add(Event.FromString(vEventString));
        }

        return new Calendar {
            Source     = source,
            Parameters = parameters,
            Events     = [.. events]
        };
    }

    public required string                                         Source     { get; init; }
    public required ImmutableDictionary<string, CalendarParameter> Parameters { get; init; }
    public required ImmutableArray<Event>                          Events     { get; init; }

}