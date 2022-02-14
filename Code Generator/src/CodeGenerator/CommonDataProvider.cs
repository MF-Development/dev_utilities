using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Transactions;

namespace CodeGenerator.DataAccess
{
    public static class CommonDataProvider
    {
        #region Variables
            private static string _connectionString = String.Empty;
        #endregion

        #region Properties
        public static string ConnectionString
        {
            get {
                return _connectionString;
            }
            set {
                _connectionString = value;
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
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = CreateCommandObject(queryString, parameters, isStoredProc, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    //ErrorHandler.AddError(ex.Message + " [" + queryString + "]");
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
                //even the table is empty, we may still need the column names - Don 5/6/2008
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                dt = ds.Tables[0];
                //}
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
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        SqlCommand cmd = CreateCommandObject(queryString, parameters, isStoredProc, conn);
                        conn.Open();

                        returnValue = cmd.ExecuteNonQuery();
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        //ErrorHandler.AddError(ex.Message + " [" + queryString + "]");
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
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        SqlCommand cmd = CreateCommandObject(queryString, parameters, isStoredProc, conn);
                        conn.Open();

                        returnValue = cmd.ExecuteScalar().ToString();
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        //ErrorHandler.AddError(ex.Message + " [" + queryString + "]");
                    }
                }
            }

            return returnValue;
        }
        #endregion

        #region Helper Functions
        public static SqlCommand CreateCommandObject(string queryString, Hashtable parameters, bool isStoredProc, SqlConnection conn)
        {
            //for debugging
            //System.Text.StringBuilder rawQuery = new System.Text.StringBuilder();
            //rawQuery.Append(queryString + " ");

            SqlCommand cmd = new SqlCommand(queryString, conn);

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
                    cmd.Parameters.AddWithValue("@" + key, parameters[key].ToString());
                    //for debugging
                    //rawQuery.Append("@" + key + "=" + parameters[key].ToString() + ", ");
                }
            }

            return cmd;
        }

        #endregion
    }
}
