using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TacticalOpsQuickJoin.Properties;

namespace TacticalOpsQuickJoin
{
    public partial class FormMasterServers : Form
    {
        public FormMasterServers()
        {
            InitializeComponent();
            textBox1.Text = Settings.Default.masterservers;
        }

        private void FormMasterServers_FormClosing(object sender, FormClosingEventArgs e)
        {
            string masterservers = textBox1.Text.Trim();
            Settings.Default.masterservers = masterservers;
            Settings.Default.Save();
        }
    }
}
