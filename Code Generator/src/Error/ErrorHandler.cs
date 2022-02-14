using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Text;

using MyApplication.Utility;

namespace MyApplication.Error
{
    /// <summary>
    /// The ErrorHandler class is used to store errors for the UI.
    /// Error messages are stored in the session and should be cleared out 
    /// in the OnPreInit() method of the CommonWebPageBase class.
    /// </summary>
    public class ErrorHandler
    {
        private static readonly string ERRORS_KEY = "__Errors";

        /// <summary>
        /// Clear any previously stored errors
        /// </summary>
        public static void Clear() 
        {
            ArrayList errorList = new ArrayList();
            StateManagementUtility.Set(ERRORS_KEY, errorList);
        }

        /// <summary>
        /// Retrieves Array List of errors
        /// </summary>
        public static ArrayList GetErrorList
        {
            get
            {
                ArrayList errorList = StateManagementUtility.Get(ERRORS_KEY) as ArrayList;
                if (errorList == null)
                {
                    errorList = new ArrayList();
                }
                return errorList;
            }
        }
        /// <summary>
        /// Converts array list of errors to string. The delimiter
        /// is a <br> tag
        /// </summary>
        public static string GetErrorListString
        {
            get
            {
                ArrayList errorList = GetErrorList;
                StringBuilder errors = new StringBuilder();
                if (errorList.Count > 0)
                {

                    foreach (string error in errorList) 
                    {
                        errors.Append(error + "\n");
                    }
                }

                return errors.ToString();
            }
        }

        /// <summary>
        /// Method used to add errors to the array list
        /// </summary>
        /// <param name="error">Error string</param>
        public static void AddError(string error)
        {
            ArrayList errorList = GetErrorList;
            errorList.Add(error);
            StateManagementUtility.Set(ERRORS_KEY, errorList);
        }

        /// <summary>
        /// Method used to insert errors at a particular location in the array list
        /// </summary>
        /// <param name="index"></param>
        /// <param name="error"></param>
        public static void InsertError(int index, string error)
        {
            InsertError(index, error, false);
        }

        /// <summary>
        /// Method used to insert errors at a particular location in the array list
        /// </summary>
        /// <param name="index"></param>
        /// <param name="error"></param>
        /// <param name="isHeader"></param>
        public static void InsertError(int index, string error, bool isHeader)
        {
            ArrayList errorList = GetErrorList;
            
            //add css class if error header
            //if (isHeader)
            //{
            //    error = "<span class=\"errorHeader\">" + error + "</span>";
            //}

            try
            {
                //try to insert
                errorList.Insert(index, error);
                StateManagementUtility.Set(ERRORS_KEY, errorList);
            }
            catch (Exception)
            {
                //add error if index out of range
                AddError(error);
            }
        }

        /// <summary>
        /// Determines whether there are errors in the list
        /// </summary>
        public static bool HasError
        {
            get
            {
                return GetErrorList.Count > 0;
            }
        }

    }
}
