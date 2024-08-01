using System.Globalization;

namespace iCalNET.Demo;

internal class Program {

    static void Main(string[] args) {

        string fileName = args[0];

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
    }

}