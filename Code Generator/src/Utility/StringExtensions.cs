using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApplication.Utility.StringExtensions
{
    /// <summary>
    /// Provides convenience overlay methods into the String class to
    /// make working with string-only properties more usable and familiar 
    /// from a programmer's point-of-view.
    /// </summary>
    public static class StringExtensionsClass
    {
        #region Conversion Helpers

        public static bool ToBool(this string s)
        {
            bool rv = false;

            s = Utility.StringUtility.TrimSafe(s);

            if (string.IsNullOrEmpty(s))
            {
                s = bool.FalseString;
            }
            else if (s.Equals("1"))
            {
                s = bool.TrueString;
            }
            else if (s.Equals("0"))
            {
                s = bool.FalseString;
            }

            bool.TryParse(s, out rv);

            return rv;
        }

        public static int ToInt(this string s)
        {
            int rv = 0;

            int.TryParse(s, out rv);

            return rv;
        }
        public static double ToDouble(this string s)
        {
            double rv = 0;

            double.TryParse(s, out rv);

            return rv;
        }

        public static string ToShortDateString(this string s)
        {
            DateTime dateValue;
            DateTime.TryParse(s, out dateValue);

            return dateValue.ToShortDateString();
        }

        #endregion
    }
}
