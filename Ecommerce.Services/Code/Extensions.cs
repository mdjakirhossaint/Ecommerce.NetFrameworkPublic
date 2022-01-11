using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecommerce.Services.Code
{
    public static class Extensions
    {
        private static string IllegalCharacterReplacePattern = @"^\w";
        public static string SanitizeString(this string str)
        {
            string sanitizeString = string.Empty;

            if (!string.IsNullOrEmpty(str))
            {
                sanitizeString = Regex.Replace(str.Trim(), IllegalCharacterReplacePattern, "-");
                sanitizeString = sanitizeString.Replace("---", "-").Replace("--", "-");
                sanitizeString = sanitizeString.TrimStart('-').TrimEnd('-');
            }
            return sanitizeString;
        }
    }
}
