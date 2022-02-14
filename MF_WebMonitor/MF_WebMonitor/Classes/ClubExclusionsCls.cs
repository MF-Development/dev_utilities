using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MF_WebMonitor.Classes
{
    public class ClubExclusionsCls
    {
        public ClubExclusionsCls()
        {

        }
        public ClubExclusionsCls(DataRow dr)
        {
            String clubID = dr["ClubID"].ToString();
            String expectedToFail = dr["ExpectedToFail"].ToString();
            String expectedToFailReason = dr["ExpectedToFailReason"] != System.DBNull.Value ? dr["ExpectedToFailReason"].ToString() : "";
            String useInternal = dr["UseInternalAddress"].ToString();
            if (dr["IgnoreUntil"] != System.DBNull.Value)
            {
                this.IgnoreUntil = Convert.ToDateTime(dr["IgnoreUntil"].ToString());
            }

            this.ClubID = Convert.ToInt32(clubID);
            this.ExpectedToFail = !String.IsNullOrEmpty(expectedToFail) ? Convert.ToBoolean(expectedToFail) : false;
            this.UseInternalAddress = !String.IsNullOrEmpty(useInternal) ? Convert.ToBoolean(useInternal) : false;
            this.ExpectedToFailReason = expectedToFailReason;
            
        }
        public int ClubID { get; set; }
        public bool ExpectedToFail { get; set; }
        public String ExpectedToFailReason { get; set; }
        public bool UseInternalAddress { get; set; }
        public DateTime IgnoreUntil { get; set; }

        public static List<ClubExclusionsCls> GetExclusions()
        {
            List<ClubExclusionsCls> exclusions = new List<ClubExclusionsCls>();

            DataTable results = GetData();
            foreach (DataRow dr in results.Rows)
            {
                ClubExclusionsCls club = new ClubExclusionsCls(dr);
                exclusions.Add(club);
            }

            return exclusions;
        }

        public static DataTable GetData()
        {
            DataTable dt = new DataTable();

            String query = "select * from WebMonitorClubExclusions";

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
