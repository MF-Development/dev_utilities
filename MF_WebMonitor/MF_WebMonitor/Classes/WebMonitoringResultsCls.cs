using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MF_WebMonitor.Classes
{
    public class WebMonitoringResultsCls
    {
        public WebMonitoringResultsCls()
        {
            this.FailuresInLast24Hours = 0;
        }
        
        public WebMonitoringResultsCls(DataRow dr, WebApplicationCls app)
        {
            this.ClubName = app.ClubName;
            this.ClubID = app.ClubID;
            this.Url = app.Url;
            
            this.Success = Convert.ToBoolean(dr["Issue"].ToString()) == false;
            this.FailureReason = dr["FailureMsg"] != System.DBNull.Value ? dr["FailureMsg"].ToString() : "";
            this.ExpectedToFail = Convert.ToBoolean(dr["Issue"].ToString()) == false && Convert.ToBoolean(dr["Success"].ToString()) == false;
            this.ServerName = app.ServerName;
            this.FailuresInLast24Hours = 0;
            this.IgnoreErrors = app.IgnoreErrors;
        }

        public int ClubID { get; set; }
        public string ClubName { get; set; }
        public string Url { get; set; }
        public string FailureReason { get; set; }
        public bool Success { get; set; }
        public bool ExpectedToFail { get; set; }
        public int FailuresInLast24Hours { get; set; }
        public string ServerName { get; set; }
        public bool IgnoreErrors { get; set; }

        public static List<WebMonitoringResultsCls> GetResults(string testBatch)
        {
            List<WebMonitoringResultsCls> results = new List<WebMonitoringResultsCls>();
            List<WebApplicationCls> apps = WebApplicationCls.GetAllWebApplications();
            DataTable it = GetDistinctServerInfos();
            foreach (DataRow dr in it.Rows)
            {
                int clubID = Convert.ToInt32(dr["ClubID"].ToString());
                WebApplicationCls app = apps.Where(c => c.ClubID == clubID).Take(1).SingleOrDefault();
                if( app != null )
                    app.ServerName = dr["ServerName"] != System.DBNull.Value ? dr["ServerName"].ToString() : "";
            }

            List<WebMonitoringResultsCls> failuresInLast24 = new List<WebMonitoringResultsCls>();
            DataTable ft = GetFailuresInLast24Hours();
            foreach (DataRow dr in ft.Rows)
            {
                int clubID = Convert.ToInt32(dr["ClubID"].ToString());
                WebApplicationCls app = apps.Where(c => c.ClubID == clubID).Take(1).SingleOrDefault();
                if (app != null)
                {
                    WebMonitoringResultsCls result = new WebMonitoringResultsCls(dr, app);
                    failuresInLast24.Add(result);
                }
            }

            DataTable dt = GetResultsDataTable(testBatch);
            foreach (DataRow dr in dt.Rows)
            {
                int clubID = Convert.ToInt32(dr["ClubID"].ToString());
                WebApplicationCls app = apps.Where(c => c.ClubID == clubID).Take(1).SingleOrDefault();
                if (app != null)
                {
                    WebMonitoringResultsCls result = new WebMonitoringResultsCls(dr, app);

                    List<WebMonitoringResultsCls> failuresInLast24ForThisClub = failuresInLast24.Where(f => f.ClubID == clubID).ToList();
                    if (failuresInLast24ForThisClub == null) failuresInLast24ForThisClub = new List<WebMonitoringResultsCls>();
                    if (failuresInLast24ForThisClub.Count > 1)
                        result.FailuresInLast24Hours = failuresInLast24ForThisClub.Count - 1;

                    results.Add(result);
                }
            }

            return results;
        }

        public static DataTable GetResultsDataTable(string testBatch)
        {
            DataTable dt = new DataTable();

            String query = String.Format("select * from WebMonitor where TestBatch = '{0}'", testBatch);

            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["Monitoring"].ConnectionString;

            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            conn.Close();
            da.Dispose();

            return dt;
        }

        public static DataTable GetDistinctServerInfos()
        {
            DataTable dt = new DataTable();

            String query = String.Format("select distinct clubID, serverName from WebMonitor where TestBatch >= '{0}' and serverName is not null", DateTime.Now.AddDays(-1).ToString());

            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["Monitoring"].ConnectionString;

            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            conn.Close();
            da.Dispose();

            return dt;
        }

        public static DataTable GetFailuresInLast24Hours()
        {
            DataTable dt = new DataTable();

            String query = String.Format("select * from WebMonitor where TestBatch >= '{0}' AND success = 0 and issue = 1", DateTime.Now.AddDays(-1).ToString());

            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["Monitoring"].ConnectionString;

            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            conn.Close();
            da.Dispose();

            return dt;
        }
    }
}
