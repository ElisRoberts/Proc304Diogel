using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digoel.Common
{
    public static class Extensions
    {
        //This class deals with gramatical options when generating passwords
        internal static string Remove(this string s, string pattern)
        {
            return s.Replace(pattern, "");
        }

        internal static string[] Split(this string s, string separator)
        {
            return s.Split(new[] { separator }, StringSplitOptions.None);
        }

        internal static string UppercaseFirst(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}