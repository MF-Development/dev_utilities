using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

using Microsoft.Web.Administration;

namespace MRM7MigrationUtility
{
    public class clsUtility
    {
        public DataSet GetClub(string searchText)
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MRM"].ConnectionString);

            String query = String.Format("SELECT club_id, club_name, club_directory, club_name + ' : ' + IsNull(club_webUrl,'') as 'Club_ItemText' from tbl_club_master where club_name not like '%DO NOT%' and (club_name like '%{0}%')", searchText);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            try
            {
                SqlDataAdapter dad = new SqlDataAdapter(query, conn);
                dad.Fill(ds);
            }
            catch(Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        public Hashtable GetClubInfo(int clubID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MRM"].ConnectionString);

            String query = String.Format("SELECT * from tbl_club_master where club_id = {0}", clubID);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            try
            {
                SqlDataAdapter dad = new SqlDataAdapter(query, conn);
                dad.Fill(dt);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

            Hashtable props = new Hashtable();
            DataRow dr = dt.Rows[0];
            foreach (DataColumn dc in dt.Columns)
            {
                if (dr[dc.ColumnName] != System.DBNull.Value)
                {
                    props.Add(dc.ColumnName.ToUpper(), dr[dc.ColumnName].ToString());
                }
            }

            return props;
        }

        public StringBuilder MigrateSite(int clubID, string webDirectory)
        {
            StringBuilder sb = new StringBuilder();
            ServerManager sm = new ServerManager();

            string mrm6 = ConfigurationManager.AppSettings["MRM6Path"].ToString();
            string mrm7 = ConfigurationManager.AppSettings["MRM7Path"].ToString();
            string includeApps = ConfigurationManager.AppSettings["IncludeCommonApps"].ToString();
            string includeNet = ConfigurationManager.AppSettings["IncludeCommonNet"].ToString();
            Site clubSite = sm.Sites[webDirectory];
            if (clubSite != null)
            {
                sb.AppendLine("Found Club Directory");

                foreach (Application app in clubSite.Applications)
                {
                    if (app.Path == @"/")
                    {
                        foreach (VirtualDirectory vd in app.VirtualDirectories)
                        {
                            if (vd.Path.ToUpper() == @"/ADMIN")
                            {
                                sb.AppendLine("Updating Admin Path");
                                vd.PhysicalPath = mrm7 + "Admin";
                            }
                            if (vd.Path.ToUpper() == @"/CLUB")
                            {
                                sb.AppendLine("Updating Club Path");
                                vd.PhysicalPath = mrm7 + "Club";
                            }
                            if (vd.Path.ToUpper() == @"/COMMON")
                            {
                                sb.AppendLine("Updating Common Path");
                                vd.PhysicalPath = mrm7 + "Common";
                            }
                        }
                    }

                    if (!String.IsNullOrEmpty(includeApps) || !String.IsNullOrEmpty(includeNet))
                    {
                        if (app.Path.ToUpper() == @"/COMMONNET")
                        {
                            foreach (VirtualDirectory vd in app.VirtualDirectories)
                            {
                                if (vd.Path.ToUpper() == @"/")
                                {
                                    sb.AppendLine("Updating CommonNet Path");
                                    vd.PhysicalPath = mrm7 + "CommonNet";
                                }
                            }
                        }
                    }
                }

                sm.CommitChanges();
            }
            else
            {
                sb.AppendLine("ERROR: Could not Find Club Directory");
            }

            return sb;
        }

        public StringBuilder MigrateSiteData(int clubID)
        {
            StringBuilder sb = new StringBuilder();

            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MRM"].ConnectionString);
            string migrationStoredProc = "exec dbo.mf_Migrate_Site_To_MRM7 " + clubID.ToString() + ",1";
           
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = migrationStoredProc;

            try
            {
                sb.AppendLine("Executing migration stored procedure");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sb.AppendLine("ERROR Executing migration stored procedure");
                sb.AppendLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return sb;
        }

        public DataSet ValidateClubMigrationData(int clubID)
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MRM"].ConnectionString);

            String query = "exec dbo.mf_Migrate_Site_To_MRM7_Validate " + clubID.ToString(); 
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            try
            {
                SqlDataAdapter dad = new SqlDataAdapter(query, conn);
                dad.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
    }
}
