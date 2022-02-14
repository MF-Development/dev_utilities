using System;
using System.Collections.Generic;
using System.Configuration;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace MRM7MigrationUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            clsUtility utility = new clsUtility();
            DataSet ds = utility.GetClub(txtClubSearchText.Text);

            //cbClubSelectBox.Items.Clear();
            int clubIDZero = -1;

            DataTable dt = ds.Tables[0];
            DataTable newDt = dt.Clone();
            newDt.Rows.Clear();
            newDt.Rows.Add(newDt.NewRow());

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    string clubID = dr["club_id"].ToString();
                    string club_name = dr["club_name"].ToString();
                    string club_dir = dr["club_directory"] != System.DBNull.Value ? dr["club_directory"].ToString() : "FOOBAR";

                    string path = ConfigurationManager.AppSettings["WWWRoot"].ToString() + club_dir;
                    if (System.IO.Directory.Exists(path))
                    {
                        DataRow nDr = newDt.NewRow();
                        clubIDZero += 1;
                        nDr["club_id"] = dr["club_id"].ToString();
                        nDr["club_name"] = dr["club_name"].ToString();
                        nDr["Club_ItemText"] = dr["Club_ItemText"].ToString();
                        newDt.Rows.Add(nDr);
                    }
                }
                catch (Exception ex)
                {
                }
            }

            cbClubSelectBox.DataSource = newDt;
            cbClubSelectBox.DisplayMember = "Club_ItemText";
            cbClubSelectBox.ValueMember = "club_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clubId = 0;
            int.TryParse(cbClubSelectBox.SelectedValue.ToString(), out clubId);

            if (clubId == 0)
            {
                MessageBox.Show("Please select a club first.");
                return;
            }

            if (MessageBox.Show("Are you sure you wish to migrate : " + clubId.ToString() + " " + cbClubSelectBox.Text + "?", "Migration", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            txtResults.Text = "Migrating Site - BEGIN";
            txtResults.Text += Environment.NewLine;

            Hashtable clubInfo = new clsUtility().GetClubInfo(clubId);
            StringBuilder sb = new clsUtility().MigrateSite(clubId, clubInfo["CLUB_DIRECTORY"].ToString());
            
            txtResults.AppendText(sb.ToString());
            txtResults.Text += "Migrating Site - DONE";
            txtResults.Text += Environment.NewLine;

            txtResults.Text += "Migrating Database Changes - BEGIN";
            txtResults.Text += Environment.NewLine;

            clsUtility utility = new clsUtility();
            sb = utility.MigrateSiteData(clubId);
            txtResults.AppendText(sb.ToString());
            txtResults.Text += Environment.NewLine;

            txtResults.Text += "Validating Database Changes - BEGIN";
            txtResults.Text += Environment.NewLine;

            DataSet ds = utility.ValidateClubMigrationData(clubId);
            DataTable dt = null;
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];
            else
                txtResults.Text += "Failed to validate data" + Environment.NewLine;
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtResults.Text += dr[0].ToString() + " : " + String.Format("{0}", dr[1] != System.DBNull.Value ? dr[1].ToString() : "");
                    txtResults.Text += Environment.NewLine;
                }
            }
            txtResults.Text += "Validating Database Changes - DONE";
            txtResults.Text += Environment.NewLine;

            txtResults.Text += "Migrating Database Changes - DONE";
            txtResults.Text += Environment.NewLine;

            txtResults.Text += "Launching browser to rebuild config file.";

            string adminUrl = ConfigurationManager.AppSettings["TccnUrl"].ToString(); 
        
            System.Diagnostics.Process.Start(adminUrl + clubId.ToString()); 

            StreamWriter sr = new StreamWriter(Application.StartupPath + "\\" + clubId.ToString() + ".log",true);
            sr.Write(txtResults.Text);
            sr.Close();
        }

        private void cbClubSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int clubId = 0;
            int.TryParse(cbClubSelectBox.SelectedValue.ToString(), out clubId);

            if (clubId == 0)
            {
                return;
            }
            txtResults.Text = "";

            Hashtable clubInfo = new clsUtility().GetClubInfo(clubId);
            foreach (string key in clubInfo.Keys)
            {
                txtResults.Text += String.Format("{0} = {1}", key, clubInfo[key].ToString());
                txtResults.Text += Environment.NewLine;
            }
        }

    }
}
