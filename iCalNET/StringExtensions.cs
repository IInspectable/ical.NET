using System.Text.RegularExpressions;

namespace iCalNET;

static class StringExtensions {

    public static string UnfoldAndUnescape(this string s) {
        var unfold    = Regex.Replace(s, "(\\r\\n )", "");
        var unescaped = Regex.Unescape(unfold);
        return unescaped;
    }

}