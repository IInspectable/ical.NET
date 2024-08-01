# ical.NET

**ical.NET** is a free iCal/ICS parser written in C#.  

## Usage

Pass a .ics file as a string to  **Calendar.FromString** Method.

```CS
string fileName = "Path to .ics-File";

var content = File.ReadAllText(fileName);
var cal     = Calendar.FromString(content);

foreach (var evt in cal.Events) {

    var dtStartLine = evt.ContentLines["DTSTART"];
    var summaryLine = evt.ContentLines["SUMMARY"];

    var s       = DateTime.ParseExact(dtStartLine.Value, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
    var summary = summaryLine.Value;

    Console.WriteLine($"{s:d}: {summary}");
}

Console.WriteLine($"{cal.Events.Length} Einträge gefunden!");
```
