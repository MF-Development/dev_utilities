Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click

        If MsgBox("Are you sure you are ready to copy to " + txtNewClubID.Text + " from " + txtSiteMaster.Text + "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        End If
        btnGo.Enabled = False

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("MRM").ConnectionString)

        Dim cmd As SqlCommand = conn.CreateCommand
        conn.Open()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@work_sitesetup_clubid", txtSiteMaster.Text))
        cmd.Parameters.Add(New SqlParameter("@work_newsite_clubid", txtNewClubID.Text))

        cmd.CommandText = "MF_Copy_Site_Setup_Master"
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
        End Try

        conn.Close()
        btnGo.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtSiteMaster.Text = ConfigurationManager.AppSettings("SiteSetupMasterDefault")
    End Sub
End Class
