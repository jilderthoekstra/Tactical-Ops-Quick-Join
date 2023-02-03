using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TacticalOpsQuickJoin {
    public partial class FormAbout : Form {
        public FormAbout() {
            InitializeComponent();

            lblAboutInfo.Text = @"Tactical Ops Quick Joiner made by - (\/)(\/)-." + Environment.NewLine
                                + "Join your friends on the servers quicker." + Environment.NewLine + Environment.NewLine
                                + "Just add me on steam if you have any questions.";
        }

        private void linkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://www.jildert.com");
        }

        private void linlLabelSteam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://steamcommunity.com/id/jildert");
        }

        private void lblVersion_Click(object sender, EventArgs e) {

        }
    }
}
