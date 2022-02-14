using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using System.Net;
using System.Net.NetworkInformation;

namespace MF_WebMonitor.Classes
{
    public class WebApplicationCls
    {
        public bool MRM { get; set; }
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        public string Url { get; set; }
        public string ServerName { get; set; }
        public string TestUrl 
        { 
            get
            {
                if (this.MRM == false) return this.Url;

                if (this.UseInternalAddress && this.Retest)
                {
                    return string.Format("{0}/common/sitetest/sitetest.asp", this.InternalAddress); 
                }
                else
                    return string.Format("{0}/common/sitetest/sitetest.asp", this.Url); 
            } 
        }
        public bool Successful { get; set; }
        public bool PassedWebTest { get; set; }
        public bool PassedPingTest { get; set; }
        public string ResultsText { get; set; }
        public DateTime TestBatch { get; set; }
        public bool ExpectedToFail { get; set; }
        public string ExpectedToFailReason { get; set; }
        public bool Retest { get; set; }
        public bool UseInternalAddress { get; set; }
        public String InternalAddress { get; set; }
        public bool IgnoreErrors { get; set; }

        public WebApplicationCls()
        {
            MRM = true;
        }
        public WebApplicationCls(DataRow dr)
        {
            String clubID = dr["Club_ID"].ToString();
            String url = dr["Club_WebURL"] != System.DBNull.Value ? dr["Club_WebURL"].ToString() : "";
            this.ClubName = dr["Club_Name"].ToString();
            this.InternalAddress = dr["Club_WebURL_Local"].ToString();
            this.MRM = true;
            this.ClubID = Convert.ToInt32(clubID);
            this.Url = url;
            this.Retest = false;
        }
        public static List<WebApplicationCls> GetAllWebApplications()
        {
            List<WebApplicationCls> apps = GetWebApplications();
            List<WebApplicationCls> otherApps = GetAdditionalApplications();
            foreach (WebApplicationCls app in otherApps)
                apps.Add(app);


            return apps;
        }
        public static List<WebApplicationCls> GetWebApplications()
        {
            List<WebApplicationCls> apps = new List<WebApplicationCls>();
            List<ClubExclusionsCls> exclusions = ClubExclusionsCls.GetExclusions();

            DataTable results = GetData();
            foreach (DataRow dr in results.Rows)
            {
                WebApplicationCls app = new WebApplicationCls(dr);
                ClubExclusionsCls exclusion = exclusions.Where(c => c.ClubID == app.ClubID).Take(1).SingleOrDefault();
                if (exclusion != null)
                {
                    app.ExpectedToFail = exclusion.ExpectedToFail;
                    app.ExpectedToFailReason = exclusion.ExpectedToFailReason;
                    app.UseInternalAddress = exclusion.UseInternalAddress;
                    app.IgnoreErrors = exclusion.IgnoreUntil > DateTime.Now;
                }
                apps.Add(app);
            }

            return apps;
        }

        public static List<WebApplicationCls> GetAdditionalApplications()
        {
            List<WebApplicationCls> apps = new List<WebApplicationCls>();
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["MFDining"]))
            {
                WebApplicationCls app = new WebApplicationCls();
                app.Url = ConfigurationManager.AppSettings["MFDining"].ToString();
                app.ExpectedToFail = false;
                app.ClubID = -1;
                app.ClubName = "MFDining";
                app.MRM = false;
                apps.Add(app);
            }

            return apps;
        }
        public static DataTable GetData()
        {
            DataTable dt = new DataTable();

            String query = "select * from tbl_club_master where (left(club_name,10) <> 'Do Not Use' and left(Club_Name,8) <> 'New Club') and Club_ID > 0 and Club_Demo = 0 and Club_Status = 7";

            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["MRM"].ConnectionString;

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
        


        public bool PingUrl(string overrideURL = "")
        {
            string url = this.Url;
            if (!String.IsNullOrEmpty(overrideURL)) url = overrideURL;

            string hostName = url.Replace("http://", "");
            hostName = hostName.Replace("https://", "");
            if (hostName.EndsWith("/") == true) hostName = hostName.Substring(0, hostName.Length - 1);

            bool result = false;
            Ping p = new Ping();

            for (int pCounter = 0; pCounter < 3; pCounter++)
            {
                try
                {
                    PingReply reply = p.Send(hostName, 5000);
                    this.ServerName = reply.Address.ToString();
                    if (reply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    if (!String.IsNullOrEmpty(this.ResultsText))
                        this.ResultsText = ex.Message;
                }
            }
            return result;
        }

        public bool ExecuteWebTest(bool bLogResults)
        {
            bool success = false;

            try
            {
                WebClient client = new WebClient();
                string downloadString = client.DownloadString(this.TestUrl);
                if (this.MRM == true)
                {
                    int i = downloadString.IndexOf("The Test has been Completed Successfully", StringComparison.CurrentCultureIgnoreCase);

                    success = i >= 0;

                    if (success == false)
                    {
                        this.ResultsText = "Test did not succeed: possibly due to redirection of web application to a new provider.";
                    }
                }
                else
                {
                    if (downloadString.ToLower().Contains("error") == true)
                    {
                        success = false;
                        this.ResultsText = "Found an error on non MRM Page";
                    }
                    else
                        success = true;
                }
            }
            catch (Exception ex)
            {
                this.ResultsText = ex.Message;
            }

            bool secondarySuccess = success;
            if (bLogResults == true)
            {
                string overrideAddress = this.Retest && this.UseInternalAddress ? this.InternalAddress : "";
                if( success == true && this.MRM == true)
                    secondarySuccess = this.PingUrl(overrideAddress);
                
                this.Successful = secondarySuccess == true && success == true;

                this.PassedWebTest = success;
                this.PassedPingTest = secondarySuccess;

                if (Successful == false && String.IsNullOrEmpty(this.ResultsText) && this.Retest == false)
                    this.Retest = true;
                else
                {
                    this.Retest = false;
                    this.LogResult();
                }
            }
            
            return success;
        }

        public bool LogResult()
        {
            string resultsText = "NULL";
            if (!String.IsNullOrEmpty(this.ResultsText))
            {
                resultsText = String.Format("'{0}'", this.ResultsText.Replace("'","''"));
            }
            bool isAFailure = false;
            if (this.Successful == false && this.ExpectedToFail == false && this.IgnoreErrors == false)
            {
                isAFailure = true;
            }

            // if ping times out or something like that we call it a pass
            if (this.Successful == false && this.PassedWebTest == true && this.PassedPingTest == false) this.Successful = true;

            String query = String.Format("WebMonitor_LogResult {0},'{1}','{2}',{3},'{4}',{5},{6}", this.ClubID, this.ServerName, this.Url, this.Successful ? "1" : "0", this.TestBatch, isAFailure ? "1" : "0", resultsText);

            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["Monitoring"].ConnectionString;

            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            cmd.ExecuteNonQuery();

            return true;
        }

        public static void ArchiveData()
        {
            String query = "WebMonitor_Archiving";

            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["Monitoring"].ConnectionString;

            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            cmd.ExecuteNonQuery();
        }
    }
}
