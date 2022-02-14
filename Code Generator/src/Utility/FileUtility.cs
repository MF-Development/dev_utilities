using System;
using System.IO;
using System.Collections;

using MyApplication.Error;

namespace MyApplication.Utility
{
    public class FileUtility
    {
        #region Methods
        public static bool CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }                
            }
            catch (Exception ex)
            {
                ErrorHandler.AddError("Error creating directory.");
            }

            return Directory.Exists(path);
        }

        /// <summary>
        /// Writes a string into a specified text file
        /// </summary>
        /// <param name="filePath">String with the complete file path</param>
        /// <param name="fileContents">String with the file contents</param>
        /// <param name="overWrite">Boolean that determines if file will be overwritten</param>
        public static void Write(string filePath, string fileContents, bool overWrite)
        {
            if (File.Exists(filePath))
            {
                if (overWrite)
                {
                    TextWriter tw = new StreamWriter(filePath);
                    tw.Write(fileContents);
                    tw.Close();
                }
                else
                {
                    TextReader tr = new StreamReader(filePath);
                    string actualData = tr.ReadToEnd();
                    tr.Close();

                    TextWriter tw = new StreamWriter(filePath);
                    tw.Write(actualData);
                    tw.WriteLine(fileContents);
                    tw.Close();
                }
            }
            else
            {
                TextWriter tw = new StreamWriter(filePath);
                tw.Write(fileContents);
                tw.Close();
            }
        }
        /// <summary>
        /// Reads from a specified text file into a String 
        /// </summary>
        /// <param name="filePath">String with the complete file path</param>
        /// <returns>String containing the data form the file</returns>
        public static string Read(string filePath)
        {
            string returnValue = String.Empty;

            if (File.Exists(filePath))
            {
                TextReader tr = new StreamReader(filePath);

                returnValue = tr.ReadToEnd();
                tr.Close();
            }
            return returnValue;
        }

        /// <summary>
        /// Compare file exention with list of valid file extentions
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="validExtentions"></param>
        /// <returns></returns>
        public static bool IsValidFileType(string fileName, string validExtentions)
        {
            bool success = false;
            string fileExt = fileName.Substring(fileName.LastIndexOf(".") + 1, 3);
            ArrayList list = new ArrayList(validExtentions.Split(','));
            
            //iterate through the extention list to validate
            foreach (string ext in list)
            {
                if (fileExt.ToLower().Equals(ext.ToLower().Trim()))
                {
                    success = true;
                    break;
                }
            }

            return success;
        }

        /// <summary>
        /// Removes file from drive
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            //Delete file from the server
            if (fileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

        #endregion
    }
}
