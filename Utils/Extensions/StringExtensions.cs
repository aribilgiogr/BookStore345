using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils.Extensions
{
    public static class StringExtensions
    {
        public static string ToSlug(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;

            var normalizedString = value.Normalize(NormalizationForm.FormD);

            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            var cleanString = stringBuilder.ToString()
                                           .Normalize(NormalizationForm.FormC)
                                           .ToLowerInvariant();

            cleanString = Regex.Replace(cleanString, @"[^a-z0-9\s-]", "");
            cleanString = Regex.Replace(cleanString, @"[\s-]+", "-").Trim('-');

            return cleanString;
        }
    }
}
