using System.Text.RegularExpressions;

namespace UITesting
{
    public static class StringExtensions
    {
        public static string SanitizeId(this string value)
        {
            return Regex.Replace(value, @"[^-_:A-Za-z0-9]", "_");
        }
    }
}