<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSiteMaster = New System.Windows.Forms.TextBox()
        Me.txtNewClubID = New System.Windows.Forms.TextBox()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Site Setup Master"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "New Club ID"
        '
        'txtSiteMaster
        '
        Me.txtSiteMaster.Location = New System.Drawing.Point(196, 31)
        Me.txtSiteMaster.Name = "txtSiteMaster"
        Me.txtSiteMaster.Size = New System.Drawing.Size(113, 20)
        Me.txtSiteMaster.TabIndex = 2
        '
        'txtNewClubID
        '
        Me.txtNewClubID.Location = New System.Drawing.Point(196, 85)
        Me.txtNewClubID.Name = "txtNewClubID"
        Me.txtNewClubID.Size = New System.Drawing.Size(113, 20)
        Me.txtNewClubID.TabIndex = 3
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(228, 185)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(81, 37)
        Me.btnGo.TabIndex = 4
        Me.btnGo.Text = "Copy"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 263)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.txtNewClubID)
        Me.Controls.Add(Me.txtSiteMaster)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Site Setup Master Copy Utility"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSiteMaster As System.Windows.Forms.TextBox
    Friend WithEvents txtNewClubID As System.Windows.Forms.TextBox
    Friend WithEvents btnGo As System.Windows.Forms.Button

End Class
