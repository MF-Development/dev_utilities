using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApplication.Utility
{
    public static class StringUtility
    {
        /// <summary>
        /// Joins an array on the specified delimeter, but only
        /// until the specified maxIndex
        /// </summary>
        /// <param name="values"></param>
        /// <param name="delim"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        public static string Join(string[] values, char delim, int stopAtIndex)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < stopAtIndex; i++)
            {
                if (i == stopAtIndex - 1)
                {
                    sb.Append(values[i]);
                }
                else
                {
                    sb.Append(values[i] + delim);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns a trimmed string or string.Empty if the supplied string s is null.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string TrimSafe(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                s = string.Empty;
            }
            else
            {
                s = s.Trim();
            }

            return s;
        }

        // utility function to limit string s to only include values in our include list
        public static string SpanIncluding(string s, string includeList)
        {
            StringBuilder returnString = new StringBuilder();

            char[] chars = s.ToCharArray();
            for (int i = 0; i < s.Length - 1; i++ )
            {
                if (includeList.Contains(chars[i]))
                {
                    returnString.Append(chars[i].ToString());
                }
            }
            
            return returnString.ToString();
        }
    }
}
