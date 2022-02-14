using System;
using System.Text.RegularExpressions;

namespace MyApplication.Utility
{
    public class FormatUtility
    {
        #region Methods
        public static string StripHTML(string htmlText)
        {
          //htmlText = htmlText.ToLower().Replace("<br>", chr(10));
          return Regex.Replace(htmlText, @"<(.|\n)*?>", String.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static TimeSpan DiffDates(DateTime presentDateTime, DateTime pastDateTime)
        {
            return presentDateTime - pastDateTime;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <param name="hasLetters"></param>
        /// <param name="hasNumbers"></param>
        /// <param name="hasSpecialCharacters"></param>
        /// <returns></returns>
        public static string RandomString(int length, bool hasLetters, bool hasNumbers, bool hasSpecialCharacters)
        {
            Random rand = new Random();
            string returnValue = String.Empty;
            string source = String.Empty;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string special = "~!@#$%^&* ()_+ ,.;";
            string numbers = "1234567890";

            if (hasLetters)
            {
                source += alphabet;
            }
            if (hasSpecialCharacters)
            {
                source += special;
            }
            if (hasNumbers)
            {
                source += numbers;
            }

            for (int i = 0; i < length; i++)
            {
                returnValue += source[rand.Next(0, source.Length)];
            }

            return returnValue;
        }

        /// <summary>
        /// Special method to increment string values
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string IncrementString(string value)
        {
            string returnValue = String.Empty;

            if (!String.IsNullOrEmpty(value))
            {
                int tmpInt;
                if (int.TryParse(value, out tmpInt))
                {
                    //integer increment value directly
                    int intValue = Convert.ToInt32(value) + 1;
                    returnValue = Convert.ToString(intValue);
                }
                else
                {
                    //increment character string
                    char[] charArray = value.ToCharArray();
                    int charLength = charArray.Length - 1;
                    for (int i = charLength; i >= 0; i--)
                    {
                        if (charArray[i].ToString().ToLower().Equals("z"))
                        {
                            charArray[i] = Convert.ToChar("a");
                            if (i == 0)
                            {
                                //if all z's, add "a" to start of string
                                string tmp = "a" + new string(charArray);
                                charArray = tmp.ToCharArray();
                            }
                        }
                        else if (charArray[i].ToString().ToLower().Equals("9"))
                        {
                            charArray[i] = Convert.ToChar("0");

                            if (i == 0)
                            {
                                ////if all 9's, add "1" to start of string
                                string tmp = "1" + new string(charArray);
                                charArray = tmp.ToCharArray();
                            }
                        }
                        else
                        {
                            charArray[i] = (char)(charArray[i] + 1);
                            break;
                        }
                    }

                    returnValue = new string(charArray);
                }
            }

            return returnValue;
        }

        #endregion

    }
}
