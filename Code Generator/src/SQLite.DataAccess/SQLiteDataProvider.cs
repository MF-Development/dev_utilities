using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;

using MyApplication.Error;
using System.Data.OleDb;
using System.Data.SQLite;

namespace MyApplication.SQLite.DataAccess
{
    public static class CommonDataProvider
    {
        #region Variables
            private static string _connectionString = String.Empty;

        public enum FieldTypes
        {
            Bool,
            Byte,
            DateTime,
            Decimal,
            Double,
            Float,
            Guid,
            Int,
            Long,
            Short,
            String,
            Unknown
        }

        #endregion

        #region Properties
        /// <summary>
        /// Retrieves default connection name from config file
        /// </summary>
        private static string DefaultConnectionName
        {
            get
            {
                string defaultConnectionStringName = ConfigurationManager.AppSettings["DefaultConnectionStringName"];

                if (string.IsNullOrEmpty(defaultConnectionStringName))
                {
                    throw new InvalidOperationException("Unable to obtain the default connection string name from the AppSettings configuration section. Ensure that you have an AppSettings value named DefaultConnectionStringName that refers to a valid ConnectionStrings entry.");
                }

                return defaultConnectionStringName;
            }
        }        
                
        public static string ConnectionString
        {
            get 
            { 
                return _connectionString; 
            }
            set 
            { 
                _connectionString = value; 
            }
        }

        #endregion

        #region Connection String / Source methods
        public static string GetConnectionString(string connectionName)
        {
            if (!String.IsNullOrEmpty(ConnectionString))
            {
                return ConnectionString;
            }

            ConnectionStringSettings connectionStringSettings;
            const string ERROR_MESSAGE = "Unable about to obtain a connection string named {0}. Ensure that this is included in the ConnectionStrings configuration section.";

            if (string.IsNullOrEmpty(connectionName))
            {
                connectionName = DefaultConnectionName;
            }

            // Now obtain the actual connection string from configuration settings
            connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionName];

            if (connectionStringSettings == null)
            {
                throw new InvalidOperationException(string.Format(ERROR_MESSAGE, connectionName));
            }
            else
            {
                ConnectionString = connectionStringSettings.ConnectionString;

                return ConnectionString;
            }


        }
        #endregion

        #region Generic GetDataSet methods
        public static DataSet GetDataSet(string queryString)
        {
            return GetDataSet(queryString, null, false, null);
        }
        public static DataSet GetDataSet(string queryString, Hashtable parameters)
        {
            return GetDataSet(queryString, parameters, false, null);
        }
        public static DataSet GetDataSet(string queryString, Hashtable parameters, bool isStoredProc)
        {
            return GetDataSet(queryString, parameters, isStoredProc, null);
        }
        public static DataSet GetDataSet(string queryString, Hashtable parameters, bool isStoredProc, string connectionName)
        {
            DataSet ds = new DataSet();

            string connectionString = GetConnectionString(connectionName);
            
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = CreateCommandObject(queryString, parameters, isStoredProc, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

                try
                {
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    ErrorHandler.AddError(ex.Message + " [" + queryString + "]");
                }
            }

            return ds;
        }
        #endregion

        #region Generic GetDataTable methods
        public static DataTable GetDataTable(string queryString)
        {
            return GetDataTable(queryString, null, false, null);
        }
        public static DataTable GetDataTable(string queryString, Hashtable parameters)
        {
            return GetDataTable(queryString, parameters, false, null);
        }
        public static DataTable GetDataTable(string queryString, Hashtable parameters, bool isStoredProc)
        {
            return GetDataTable(queryString, parameters, isStoredProc, null);
        }

        /// <summary>
        /// Returns the result set for a SQL query or stored procedure
        /// </summary>
        /// <param name="queryString">query string or stored procedure's name</param>
        /// <param name="parameters">Hashtable of parameters to narrow search</param>
        /// <param name="isStoredProc">Determines if its a query or a stored procedure</param>
        /// <param name="connectionName">Connection string of the database</param>
        /// <returns>DataTable containg the result set</returns>
        public static DataTable GetDataTable(string queryString, Hashtable parameters, bool isStoredProc, string connectionName)
        {
            DataSet ds = CommonDataProvider.GetDataSet(queryString, parameters, isStoredProc, connectionName);
            DataTable dt = new DataTable();

            if (ds.Tables.Count > 0)
            {
                 dt = ds.Tables[0];
            }

            return dt;
        }
        #endregion

        #region Generic ExecuteQuery methods
        public static int ExecuteQuery(string queryString)
        {
            return ExecuteQuery(queryString, null, false, null);
        }
        public static int ExecuteQuery(string queryString, Hashtable parameters)
        {
            return ExecuteQuery(queryString, parameters, false, null);
        }
        public static int ExecuteQuery(string queryString, Hashtable parameters, bool isStoredProc)
        {
            return ExecuteQuery(queryString, parameters, isStoredProc, null);
        }
        public static int ExecuteQuery(string queryString, Hashtable parameters, bool isStoredProc, string connectionName)
        {
            int returnValue = 0;

            string connectionString = GetConnectionString(connectionName);

            using (TransactionScope scope = new TransactionScope())
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        SQLiteCommand cmd = CreateCommandObject(queryString, parameters, isStoredProc, conn);
                        conn.Open();

                        returnValue = cmd.ExecuteNonQuery();
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.AddError(ex.Message + " [" + queryString + "]");
                    }
                }
            }

            return returnValue;
        }
        #endregion

        #region Generic ExecuteScalar methods
        public static string ExecuteScalar(string queryString)
        {
            return ExecuteScalar(queryString, null, false, null);
        }
        public static string ExecuteScalar(string queryString, Hashtable parameters)
        {
            return ExecuteScalar(queryString, parameters, false, null);
        }
        public static string ExecuteScalar(string queryString, Hashtable parameters, bool isStoredProc)
        {
            return ExecuteScalar(queryString, parameters, isStoredProc, null);
        }
        public static string ExecuteScalar(string queryString, Hashtable parameters, bool isStoredProc, string connectionName)
        {
            string returnValue = String.Empty;

            string connectionString = GetConnectionString(connectionName);

            using (TransactionScope scope = new TransactionScope())
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        SQLiteCommand cmd = CreateCommandObject(queryString, parameters, isStoredProc, conn);
                        conn.Open();

                        returnValue = cmd.ExecuteScalar().ToString();
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.AddError(ex.Message + " [" + queryString + "]");
                    }
                }
            }

            return returnValue;
        }
        #endregion

        #region Helper Functions

        public static SQLiteCommand CreateCommandObject(string queryString, Hashtable parameters, bool isStoredProc, SQLiteConnection conn)
        {
            SQLiteCommand cmd = new SQLiteCommand(queryString, conn);

            if (isStoredProc)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }

            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    //rjt 2009.06.18 added
                    string parameterName = key;
                    if (parameterName.Contains("."))
                    {
                        parameterName = key.Substring(key.IndexOf('.') + 1);
                    }

                    string objType = parameters[key].GetType().Name;
                    switch (objType.ToUpper())
                    { 
                        //case "BYTE[]":
                        //    cmd.Parameters.Add("@" + parameterName, SqlDbType.Image).Value = (byte[])parameters[key];
                        //    break;
                        //case "GUID":
                        //    cmd.Parameters.Add("@" + parameterName, SqlDbType.UniqueIdentifier).Value = (Guid)parameters[key];
                        //    break;
                        //case "DECIMAL":
                        //    cmd.Parameters.Add("@" + parameterName, SqlDbType.Decimal).Value = (decimal)parameters[key];
                        //    break;
                        //case "FLOAT":
                        //    cmd.Parameters.Add("@" + parameterName, SqlDbType.Float).Value = (double)parameters[key];
                        //    break;
                        //case "MONEY":
                        //    cmd.Parameters.Add("@" + parameterName, SqlDbType.Money).Value = (decimal)parameters[key];
                        //    break;
                        //case "DATETIME":
                        //    cmd.Parameters.Add("@" + parameterName, SqlDbType.DateTime).Value = (DateTime)parameters[key];
                        //    break;
                        default:
                            cmd.Parameters.AddWithValue("@" + parameterName, parameters[key].ToString());
                            break;
                    }

                    //System.Diagnostics.Debug.Write(parameterName + " = " + objType.ToUpper() + "\n");
                }
            }

            return cmd;
        }

        #region Factory methods for encapsulated query objects

        public static SQLInsertQuery CreateInsertQuery()
        {
            SQLInsertQuery insertQuery = new SQLInsertQuery();

            return insertQuery;
        }

        public static SQLSelectQuery CreateSelectQuery()
        {
            SQLSelectQuery query = new SQLSelectQuery();

            return query;
        }
        
        public static SQLUpdateQuery CreateUpdateQuery()
        {
            SQLUpdateQuery updateQuery = new SQLUpdateQuery();

            return updateQuery;
        }

        public static SQLDeleteQuery CreateDeleteQuery()
        {
            SQLDeleteQuery deleteQuery = new SQLDeleteQuery();

            return deleteQuery;
        }

        #endregion

        public static SQLSelectQuery CreateSelectQuery(string objectName, Hashtable whereClauseParameters,
            IEnumerable<string> fields, string whereClauseFragment)
        {
            SQLSelectQuery query = new SQLSelectQuery();

            query.ObjectName = objectName;
            query.WhereClauseParameters = whereClauseParameters;
            query.Fields = new List<string>(fields);
            query.WhereClauseFragment = whereClauseFragment;

            return query;
        }

        public static bool IsValidValueRange(string propertyName, string propertyValue, FieldTypes valueType, bool isRequired)
        {
            bool isValid = true;

            switch (valueType)
            {
                case FieldTypes.Int:
                case FieldTypes.Short:
                    int intTmp;
                    if (!Int32.TryParse(propertyValue, out intTmp))
                    {
                        if (isRequired && String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError(propertyName + " is required.");
                            isValid = false;
                        }
                        else if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Float:
                    float fTmp;
                    if (!Single.TryParse(propertyValue, out fTmp))
                    {
                        if (isRequired && String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError(propertyName + " is required.");
                            isValid = false;
                        }
                        else if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Double:
                    double dTmp;
                    if (!Double.TryParse(propertyValue, out dTmp))
                    {
                        if (isRequired && String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError(propertyName + " is required.");
                            isValid = false;
                        }
                        else if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Decimal:
                    decimal mTmp;
                    if (!Decimal.TryParse(propertyValue, out mTmp))
                    {
                        if (isRequired && String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError(propertyName + " is required.");
                            isValid = false;
                        }
                        else if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.String:
                    if (String.IsNullOrEmpty(propertyValue))
                    {
                        if (isRequired && String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError(propertyName + " is required.");
                            isValid = false;
                        }
                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.DateTime:
                    DateTime dtTmp;
                    if (!DateTime.TryParse(propertyValue, out dtTmp))
                    {
                        if (isRequired && String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError(propertyName + " is required.");
                            isValid = false;
                        }
                        else if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Bool:
                    bool boolTmp;
                    if (!Boolean.TryParse(propertyValue, out boolTmp))
                    {
                        if (isRequired && String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError(propertyName + " is required.");
                            isValid = false;
                        }
                        else if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Byte:
                    byte byteTmp;
                    if (!Byte.TryParse(propertyValue, out byteTmp))
                    {
                        if (isRequired && String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError(propertyName + " is required.");
                            isValid = false;
                        }
                        else if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Guid:
                    if (String.IsNullOrEmpty(propertyValue))
                    {
                        if (isRequired && String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError(propertyName + " is required.");
                            isValid = false;
                        }
                        else if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                default:
                    throw new ArgumentException(propertyName, propertyName + " - Property Type '" + valueType + "' not defined.");
                    break;
            }

            return isValid;
        }

        public static bool IsValidValueRange(string propertyName, string propertyValue, FieldTypes valueType, bool isRequired, bool hasDatabaseDefault)
        {
            bool isValid = true;

            if (isRequired && String.IsNullOrEmpty(propertyValue) && hasDatabaseDefault)
            { // Required field, but no value specified, but default in the database
                return isValid;
            }
            else if (isRequired && String.IsNullOrEmpty(propertyValue) && hasDatabaseDefault == false)
            { // Required field, but no value specified, and no default in the database!
                ErrorHandler.AddError(propertyName + " is required.");
                isValid = false;

                return isValid;
            }

            // 2009.06.11 RJT, JSG:
            // Now, check validity of values by:
            // 1) Try to parse valid type, and if valid
            // 1.1) Return validation SUCCESS
            // 2) If parse fails, then:
            // 2.1) Provide error message when empty value caused parse failure, or
            // 2.2) Provider error message when INVALID value caused parse failure
            // 2.3) Return validation FAILURE           

            switch (valueType)
            {
                case FieldTypes.Int:
                case FieldTypes.Short:
                    int intTmp;
                    if (!Int32.TryParse(propertyValue, out intTmp))
                    {
                        if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }
                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Float:
                    float fTmp;
                    if (!Single.TryParse(propertyValue, out fTmp))
                    {
                        if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Double:
                    double dTmp;
                    if (!Double.TryParse(propertyValue, out dTmp))
                    {
                        if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Decimal:
                    decimal mTmp;
                    if (!Decimal.TryParse(propertyValue, out mTmp))
                    {
                        if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.String:
                    // It's already a string, so no need to specially parse here
                    break;
                case FieldTypes.DateTime:
                    DateTime dtTmp;
                    if (!DateTime.TryParse(propertyValue, out dtTmp))
                    {
                        if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Bool:
                    bool boolTmp;
                    if (!Boolean.TryParse(propertyValue, out boolTmp))
                    {
                        if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Byte:
                    byte byteTmp;
                    if (!Byte.TryParse(propertyValue, out byteTmp))
                    {
                        if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                case FieldTypes.Guid:
                    if (String.IsNullOrEmpty(propertyValue))
                    {
                        if (!String.IsNullOrEmpty(propertyValue))
                        {
                            ErrorHandler.AddError("Invalid value for " + propertyName);
                            isValid = false;
                        }

                        //throw new ArgumentOutOfRangeException(propertyName, propertyName + " can't be NULL");
                    }
                    break;
                default:
                    throw new ArgumentException(propertyName, propertyName + " - Property Type '" + valueType + "' not defined.");
                    break;
            }

            return isValid;
        }

        public static DataTable ImportExcelFile(string fileName, string sql)
        {
            string connString = ConfigurationManager.ConnectionStrings["ExcelFile"].ConnectionString;
            OleDbConnection conn = new OleDbConnection(connString.Replace("[FILENAME]", fileName));
            DataTable dt = new DataTable();

            try
            {
                conn.Open();

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                DataSet ds = new DataSet();

                // Fill the DataSet with the information from the worksheet.
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.AddError(ex.Message);
            }
            finally
            {
                // Clean up objects.
                conn.Close();

            }

            return dt;
        }
        public static ArrayList GetExcelWorkSheetNames(string fileName)
        {
            string connString = ConfigurationManager.ConnectionStrings["ExcelFile"].ConnectionString;
            OleDbConnection conn = new OleDbConnection(connString.Replace("[FILENAME]", fileName));
            DataTable dt = new DataTable();
            ArrayList worksheets = new ArrayList();
            try
            {
                conn.Open();
                dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow dr in dt.Rows)
                {
                    worksheets.Add(dr["TABLE_NAME"].ToString());
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.AddError(ex.Message);
            }
            finally
            {
                // Clean up objects.
                conn.Close();

            }

            return worksheets;
        }

        #endregion
    }
}
