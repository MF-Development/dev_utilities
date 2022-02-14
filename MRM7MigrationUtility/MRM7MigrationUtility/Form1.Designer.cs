namespace MRM7MigrationUtility
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbClubSelectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClubSearchText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbClubSelectBox
            // 
            this.cbClubSelectBox.FormattingEnabled = true;
            this.cbClubSelectBox.Location = new System.Drawing.Point(393, 16);
            this.cbClubSelectBox.Name = "cbClubSelectBox";
            this.cbClubSelectBox.Size = new System.Drawing.Size(251, 21);
            this.cbClubSelectBox.TabIndex = 0;
            this.cbClubSelectBox.SelectedIndexChanged += new System.EventHandler(this.cbClubSelectBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search and then select club";
            // 
            // txtClubSearchText
            // 
            this.txtClubSearchText.Location = new System.Drawing.Point(210, 16);
            this.txtClubSearchText.Name = "txtClubSearchText";
            this.txtClubSearchText.Size = new System.Drawing.Size(116, 20);
            this.txtClubSearchText.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(210, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 89);
            this.button1.TabIndex = 3;
            this.button1.Text = "MIGRATE!";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(334, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(3, 59);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(685, 270);
            this.txtResults.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 436);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtClubSearchText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbClubSelectBox);
            this.Name = "Form1";
            this.Text = "MRM7 Migration Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClubSelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClubSearchText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtResults;
    }
}

