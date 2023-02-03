namespace TacticalOpsQuickJoin {
    partial class FormAbout {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.linkLabelWebsite = new System.Windows.Forms.LinkLabel();
            this.linlLabelSteam = new System.Windows.Forms.LinkLabel();
            this.lblAboutInfo = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkLabelWebsite
            // 
            this.linkLabelWebsite.LinkColor = System.Drawing.Color.Black;
            this.linkLabelWebsite.Location = new System.Drawing.Point(92, 149);
            this.linkLabelWebsite.Name = "linkLabelWebsite";
            this.linkLabelWebsite.Size = new System.Drawing.Size(100, 13);
            this.linkLabelWebsite.TabIndex = 1;
            this.linkLabelWebsite.TabStop = true;
            this.linkLabelWebsite.Text = "Visit jildert.com";
            this.linkLabelWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWebsite_LinkClicked);
            // 
            // linlLabelSteam
            // 
            this.linlLabelSteam.LinkColor = System.Drawing.Color.Black;
            this.linlLabelSteam.Location = new System.Drawing.Point(92, 124);
            this.linlLabelSteam.Margin = new System.Windows.Forms.Padding(0);
            this.linlLabelSteam.Name = "linlLabelSteam";
            this.linlLabelSteam.Size = new System.Drawing.Size(100, 13);
            this.linlLabelSteam.TabIndex = 2;
            this.linlLabelSteam.TabStop = true;
            this.linlLabelSteam.Text = "Visit steamprofile";
            this.linlLabelSteam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linlLabelSteam.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linlLabelSteam_LinkClicked);
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAboutInfo.Location = new System.Drawing.Point(0, 9);
            this.lblAboutInfo.Name = "lblAboutInfo";
            this.lblAboutInfo.Size = new System.Drawing.Size(284, 95);
            this.lblAboutInfo.TabIndex = 3;
            this.lblAboutInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(244, 169);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(37, 13);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "v1.1.2";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblAboutInfo);
            this.Controls.Add(this.linlLabelSteam);
            this.Controls.Add(this.linkLabelWebsite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabelWebsite;
        private System.Windows.Forms.LinkLabel linlLabelSteam;
        private System.Windows.Forms.Label lblAboutInfo;
        private System.Windows.Forms.Label lblVersion;
    }
}