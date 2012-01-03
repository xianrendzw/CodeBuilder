using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeBuilder.Util
{
    public static class StringExtension
    {
        public static string StandardizeName(this string str)
        {
            if (String.IsNullOrEmpty(str)) return str;
            string[] words = Regex.Split(str, "[_\\-\\. ]");
            return string.Join("", words.Select(FirstCharToUpper));
        }

        private static string FirstCharToUpper(string str)
        {
            if (String.IsNullOrEmpty(str) || str.Length == 0)
                return str;
            return str[0].ToString().ToUpper() + str.Substring(1);
        }
    }
}
