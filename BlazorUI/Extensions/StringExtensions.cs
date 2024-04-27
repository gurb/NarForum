using System.Globalization;
using System.Text;

namespace BlazorUI.Extensions
{
    public static class StringExtensions
    {
        public static string ToFriendlyUrl(this string title)
        {
            if (title == null)
                return "";

            var normalizedString = title.ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC)
                .Trim()
                .Replace(" ", "-")
                .Replace("&", "and")
                .Replace("'", "")
                .Replace("\"", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("/", "")
                .Replace("\\", "");
        }
    }
}
