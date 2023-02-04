namespace TacticalOpsQuickJoin {
    partial class FormMain {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.serverListView = new System.Windows.Forms.DataGridView();
            this.serverListNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverListMapColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverListPlayersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverListVersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerListView = new System.Windows.Forms.DataGridView();
            this.playerListNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerListScoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerListKillsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerListDeathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerListPingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerListTeamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchTacticalOps34ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchTacticalOps35ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterserversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTacticalOps34PathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTacticalOps35PathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeOnJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTO340Dialog = new System.Windows.Forms.OpenFileDialog();
            this.openTO350Dialog = new System.Windows.Forms.OpenFileDialog();
            this.splitServerSettingsList = new System.Windows.Forms.SplitContainer();
            this.splitPlayerServerList = new System.Windows.Forms.SplitContainer();
            this.lblWaitingForResponse = new System.Windows.Forms.Label();
            this.lblNoResponse = new System.Windows.Forms.Label();
            this.lblNoPlayers = new System.Windows.Forms.Label();
            this.serverSettingsView = new System.Windows.Forms.DataGridView();
            this.serverSettingsSettingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverSettingsValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.split = new System.Windows.Forms.Label();
            this.btnJoinServer = new System.Windows.Forms.Button();
            this.splitMainStatusBar = new System.Windows.Forms.SplitContainer();
            this.lblDownloadState = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTO220Dialog = new System.Windows.Forms.OpenFileDialog();
            this.setTacticalOps22PathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchTacticalOps22ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.serverListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerListView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitServerSettingsList)).BeginInit();
            this.splitServerSettingsList.Panel1.SuspendLayout();
            this.splitServerSettingsList.Panel2.SuspendLayout();
            this.splitServerSettingsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPlayerServerList)).BeginInit();
            this.splitPlayerServerList.Panel1.SuspendLayout();
            this.splitPlayerServerList.Panel2.SuspendLayout();
            this.splitPlayerServerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverSettingsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMainStatusBar)).BeginInit();
            this.splitMainStatusBar.Panel1.SuspendLayout();
            this.splitMainStatusBar.Panel2.SuspendLayout();
            this.splitMainStatusBar.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverListView
            // 
            this.serverListView.AllowUserToAddRows = false;
            this.serverListView.AllowUserToDeleteRows = false;
            this.serverListView.AllowUserToResizeColumns = false;
            this.serverListView.AllowUserToResizeRows = false;
            this.serverListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.serverListView.BackgroundColor = System.Drawing.Color.White;
            this.serverListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverListView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.serverListView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.serverListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serverListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serverListNameColumn,
            this.serverListMapColumn,
            this.serverListPlayersColumn,
            this.serverListVersionColumn});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.serverListView.DefaultCellStyle = dataGridViewCellStyle7;
            this.serverListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverListView.Location = new System.Drawing.Point(0, 0);
            this.serverListView.Margin = new System.Windows.Forms.Padding(0);
            this.serverListView.MultiSelect = false;
            this.serverListView.Name = "serverListView";
            this.serverListView.ReadOnly = true;
            this.serverListView.RowHeadersVisible = false;
            this.serverListView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.serverListView.Size = new System.Drawing.Size(750, 298);
            this.serverListView.TabIndex = 5;
            this.serverListView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.serverListView_CellMouseDown);
            this.serverListView.SelectionChanged += new System.EventHandler(this.serverListView_SelectionChanged);
            this.serverListView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.serverListView_SortCompare);
            // 
            // serverListNameColumn
            // 
            this.serverListNameColumn.HeaderText = "Server";
            this.serverListNameColumn.Name = "serverListNameColumn";
            this.serverListNameColumn.ReadOnly = true;
            // 
            // serverListMapColumn
            // 
            this.serverListMapColumn.FillWeight = 60F;
            this.serverListMapColumn.HeaderText = "Map";
            this.serverListMapColumn.Name = "serverListMapColumn";
            this.serverListMapColumn.ReadOnly = true;
            // 
            // serverListPlayersColumn
            // 
            this.serverListPlayersColumn.FillWeight = 60F;
            this.serverListPlayersColumn.HeaderText = "Players";
            this.serverListPlayersColumn.Name = "serverListPlayersColumn";
            this.serverListPlayersColumn.ReadOnly = true;
            // 
            // serverListVersionColumn
            // 
            this.serverListVersionColumn.FillWeight = 20F;
            this.serverListVersionColumn.HeaderText = "Version";
            this.serverListVersionColumn.Name = "serverListVersionColumn";
            this.serverListVersionColumn.ReadOnly = true;
            // 
            // playerListView
            // 
            this.playerListView.AllowUserToAddRows = false;
            this.playerListView.AllowUserToDeleteRows = false;
            this.playerListView.AllowUserToResizeColumns = false;
            this.playerListView.AllowUserToResizeRows = false;
            this.playerListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.playerListView.BackgroundColor = System.Drawing.Color.White;
            this.playerListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playerListView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.playerListView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.playerListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerListNameColumn,
            this.playerListScoreColumn,
            this.playerListKillsColumn,
            this.playerListDeathColumn,
            this.playerListPingColumn,
            this.playerListTeamColumn});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.playerListView.DefaultCellStyle = dataGridViewCellStyle8;
            this.playerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerListView.Location = new System.Drawing.Point(0, 0);
            this.playerListView.Margin = new System.Windows.Forms.Padding(0);
            this.playerListView.MultiSelect = false;
            this.playerListView.Name = "playerListView";
            this.playerListView.ReadOnly = true;
            this.playerListView.RowHeadersVisible = false;
            this.playerListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.playerListView.Size = new System.Drawing.Size(445, 224);
            this.playerListView.TabIndex = 6;
            // 
            // playerListNameColumn
            // 
            this.playerListNameColumn.HeaderText = "Player Name";
            this.playerListNameColumn.Name = "playerListNameColumn";
            this.playerListNameColumn.ReadOnly = true;
            // 
            // playerListScoreColumn
            // 
            this.playerListScoreColumn.FillWeight = 60F;
            this.playerListScoreColumn.HeaderText = "Score";
            this.playerListScoreColumn.Name = "playerListScoreColumn";
            this.playerListScoreColumn.ReadOnly = true;
            // 
            // playerListKillsColumn
            // 
            this.playerListKillsColumn.FillWeight = 60F;
            this.playerListKillsColumn.HeaderText = "Kills";
            this.playerListKillsColumn.Name = "playerListKillsColumn";
            this.playerListKillsColumn.ReadOnly = true;
            // 
            // playerListDeathColumn
            // 
            this.playerListDeathColumn.FillWeight = 60F;
            this.playerListDeathColumn.HeaderText = "Deaths";
            this.playerListDeathColumn.Name = "playerListDeathColumn";
            this.playerListDeathColumn.ReadOnly = true;
            // 
            // playerListPingColumn
            // 
            this.playerListPingColumn.FillWeight = 60F;
            this.playerListPingColumn.HeaderText = "Ping";
            this.playerListPingColumn.Name = "playerListPingColumn";
            this.playerListPingColumn.ReadOnly = true;
            // 
            // playerListTeamColumn
            // 
            this.playerListTeamColumn.FillWeight = 40F;
            this.playerListTeamColumn.HeaderText = "Team";
            this.playerListTeamColumn.Name = "playerListTeamColumn";
            this.playerListTeamColumn.ReadOnly = true;
            this.playerListTeamColumn.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Snow;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.configToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchTacticalOps22ToolStripMenuItem,
            this.launchTacticalOps34ToolStripMenuItem,
            this.launchTacticalOps35ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // launchTacticalOps34ToolStripMenuItem
            // 
            this.launchTacticalOps34ToolStripMenuItem.Name = "launchTacticalOps34ToolStripMenuItem";
            this.launchTacticalOps34ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.launchTacticalOps34ToolStripMenuItem.Text = "Launch Tactical Ops 3.4";
            this.launchTacticalOps34ToolStripMenuItem.Click += new System.EventHandler(this.launchTacticalOps34ToolStripMenuItem_Click);
            // 
            // launchTacticalOps35ToolStripMenuItem
            // 
            this.launchTacticalOps35ToolStripMenuItem.Name = "launchTacticalOps35ToolStripMenuItem";
            this.launchTacticalOps35ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.launchTacticalOps35ToolStripMenuItem.Text = "Launch Tactical Ops 3.5";
            this.launchTacticalOps35ToolStripMenuItem.Click += new System.EventHandler(this.launchTacticalOps35ToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterserversToolStripMenuItem,
            this.setTacticalOps22PathToolStripMenuItem,
            this.setTacticalOps34PathToolStripMenuItem,
            this.setTacticalOps35PathToolStripMenuItem,
            this.closeOnJoinToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // masterserversToolStripMenuItem
            // 
            this.masterserversToolStripMenuItem.Name = "masterserversToolStripMenuItem";
            this.masterserversToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.masterserversToolStripMenuItem.Text = "Masterservers";
            this.masterserversToolStripMenuItem.Click += new System.EventHandler(this.masterserversToolStripMenuItem_Click);
            // 
            // setTacticalOps34PathToolStripMenuItem
            // 
            this.setTacticalOps34PathToolStripMenuItem.Name = "setTacticalOps34PathToolStripMenuItem";
            this.setTacticalOps34PathToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.setTacticalOps34PathToolStripMenuItem.Text = "Set Tactical Ops 3.4 Path";
            this.setTacticalOps34PathToolStripMenuItem.Click += new System.EventHandler(this.setTacticalOps34PathToolStripMenuItem_Click);
            // 
            // setTacticalOps35PathToolStripMenuItem
            // 
            this.setTacticalOps35PathToolStripMenuItem.Name = "setTacticalOps35PathToolStripMenuItem";
            this.setTacticalOps35PathToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.setTacticalOps35PathToolStripMenuItem.Text = "Set Tactical Ops 3.5 Path";
            this.setTacticalOps35PathToolStripMenuItem.Click += new System.EventHandler(this.setTacticalOps35PathToolStripMenuItem_Click);
            // 
            // closeOnJoinToolStripMenuItem
            // 
            this.closeOnJoinToolStripMenuItem.CheckOnClick = true;
            this.closeOnJoinToolStripMenuItem.Name = "closeOnJoinToolStripMenuItem";
            this.closeOnJoinToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.closeOnJoinToolStripMenuItem.Text = "Close app when joining server";
            this.closeOnJoinToolStripMenuItem.Click += new System.EventHandler(this.closeOnJoinToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openTO340Dialog
            // 
            this.openTO340Dialog.FileName = "TacticalOps.exe";
            this.openTO340Dialog.Filter = "Tactical Ops 3.4 | *.exe";
            this.openTO340Dialog.Title = "Please select Tactical Ops 3.4 file";
            // 
            // openTO350Dialog
            // 
            this.openTO350Dialog.FileName = "TacticalOps.exe";
            this.openTO350Dialog.Filter = "Tactical Ops 3.5 | *.exe";
            this.openTO350Dialog.Title = "Please select Tactical Ops 3.5 file";
            // 
            // splitServerSettingsList
            // 
            this.splitServerSettingsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitServerSettingsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitServerSettingsList.IsSplitterFixed = true;
            this.splitServerSettingsList.Location = new System.Drawing.Point(0, 0);
            this.splitServerSettingsList.Name = "splitServerSettingsList";
            this.splitServerSettingsList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitServerSettingsList.Panel1
            // 
            this.splitServerSettingsList.Panel1.Controls.Add(this.serverListView);
            // 
            // splitServerSettingsList.Panel2
            // 
            this.splitServerSettingsList.Panel2.Controls.Add(this.splitPlayerServerList);
            this.splitServerSettingsList.Size = new System.Drawing.Size(752, 528);
            this.splitServerSettingsList.SplitterDistance = 300;
            this.splitServerSettingsList.SplitterWidth = 2;
            this.splitServerSettingsList.TabIndex = 9;
            // 
            // splitPlayerServerList
            // 
            this.splitPlayerServerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitPlayerServerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPlayerServerList.IsSplitterFixed = true;
            this.splitPlayerServerList.Location = new System.Drawing.Point(0, 0);
            this.splitPlayerServerList.Name = "splitPlayerServerList";
            // 
            // splitPlayerServerList.Panel1
            // 
            this.splitPlayerServerList.Panel1.Controls.Add(this.lblWaitingForResponse);
            this.splitPlayerServerList.Panel1.Controls.Add(this.lblNoResponse);
            this.splitPlayerServerList.Panel1.Controls.Add(this.lblNoPlayers);
            this.splitPlayerServerList.Panel1.Controls.Add(this.playerListView);
            // 
            // splitPlayerServerList.Panel2
            // 
            this.splitPlayerServerList.Panel2.Controls.Add(this.serverSettingsView);
            this.splitPlayerServerList.Panel2.Controls.Add(this.split);
            this.splitPlayerServerList.Panel2.Controls.Add(this.btnJoinServer);
            this.splitPlayerServerList.Size = new System.Drawing.Size(752, 226);
            this.splitPlayerServerList.SplitterDistance = 447;
            this.splitPlayerServerList.SplitterWidth = 2;
            this.splitPlayerServerList.TabIndex = 0;
            // 
            // lblWaitingForResponse
            // 
            this.lblWaitingForResponse.AutoSize = true;
            this.lblWaitingForResponse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWaitingForResponse.Location = new System.Drawing.Point(11, 26);
            this.lblWaitingForResponse.Name = "lblWaitingForResponse";
            this.lblWaitingForResponse.Size = new System.Drawing.Size(139, 13);
            this.lblWaitingForResponse.TabIndex = 9;
            this.lblWaitingForResponse.Text = "Waiting for server response.";
            // 
            // lblNoResponse
            // 
            this.lblNoResponse.AutoSize = true;
            this.lblNoResponse.ForeColor = System.Drawing.Color.Red;
            this.lblNoResponse.Location = new System.Drawing.Point(11, 26);
            this.lblNoResponse.Name = "lblNoResponse";
            this.lblNoResponse.Size = new System.Drawing.Size(153, 13);
            this.lblNoResponse.TabIndex = 8;
            this.lblNoResponse.Text = "Server did not repond to query.";
            // 
            // lblNoPlayers
            // 
            this.lblNoPlayers.AutoSize = true;
            this.lblNoPlayers.Location = new System.Drawing.Point(11, 26);
            this.lblNoPlayers.Name = "lblNoPlayers";
            this.lblNoPlayers.Size = new System.Drawing.Size(180, 13);
            this.lblNoPlayers.TabIndex = 7;
            this.lblNoPlayers.Text = "No players are playing on this server.";
            // 
            // serverSettingsView
            // 
            this.serverSettingsView.AllowUserToAddRows = false;
            this.serverSettingsView.AllowUserToDeleteRows = false;
            this.serverSettingsView.AllowUserToResizeColumns = false;
            this.serverSettingsView.AllowUserToResizeRows = false;
            this.serverSettingsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.serverSettingsView.BackgroundColor = System.Drawing.Color.White;
            this.serverSettingsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverSettingsView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.serverSettingsView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.serverSettingsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serverSettingsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serverSettingsSettingColumn,
            this.serverSettingsValueColumn});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.serverSettingsView.DefaultCellStyle = dataGridViewCellStyle9;
            this.serverSettingsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverSettingsView.Location = new System.Drawing.Point(0, 0);
            this.serverSettingsView.Margin = new System.Windows.Forms.Padding(0);
            this.serverSettingsView.MultiSelect = false;
            this.serverSettingsView.Name = "serverSettingsView";
            this.serverSettingsView.ReadOnly = true;
            this.serverSettingsView.RowHeadersVisible = false;
            this.serverSettingsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.serverSettingsView.Size = new System.Drawing.Size(301, 200);
            this.serverSettingsView.TabIndex = 7;
            // 
            // serverSettingsSettingColumn
            // 
            this.serverSettingsSettingColumn.FillWeight = 50F;
            this.serverSettingsSettingColumn.HeaderText = "Setting";
            this.serverSettingsSettingColumn.Name = "serverSettingsSettingColumn";
            this.serverSettingsSettingColumn.ReadOnly = true;
            // 
            // serverSettingsValueColumn
            // 
            this.serverSettingsValueColumn.HeaderText = "Value";
            this.serverSettingsValueColumn.Name = "serverSettingsValueColumn";
            this.serverSettingsValueColumn.ReadOnly = true;
            // 
            // split
            // 
            this.split.BackColor = System.Drawing.Color.DimGray;
            this.split.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.split.Location = new System.Drawing.Point(0, 200);
            this.split.Name = "split";
            this.split.Size = new System.Drawing.Size(301, 1);
            this.split.TabIndex = 9;
            // 
            // btnJoinServer
            // 
            this.btnJoinServer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnJoinServer.FlatAppearance.BorderSize = 0;
            this.btnJoinServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoinServer.Location = new System.Drawing.Point(0, 201);
            this.btnJoinServer.Name = "btnJoinServer";
            this.btnJoinServer.Size = new System.Drawing.Size(301, 23);
            this.btnJoinServer.TabIndex = 8;
            this.btnJoinServer.Text = "Join Server";
            this.btnJoinServer.UseVisualStyleBackColor = true;
            this.btnJoinServer.Click += new System.EventHandler(this.btnJoinServer_Click);
            // 
            // splitMainStatusBar
            // 
            this.splitMainStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMainStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMainStatusBar.IsSplitterFixed = true;
            this.splitMainStatusBar.Location = new System.Drawing.Point(0, 24);
            this.splitMainStatusBar.Margin = new System.Windows.Forms.Padding(10);
            this.splitMainStatusBar.Name = "splitMainStatusBar";
            this.splitMainStatusBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMainStatusBar.Panel1
            // 
            this.splitMainStatusBar.Panel1.Controls.Add(this.splitServerSettingsList);
            // 
            // splitMainStatusBar.Panel2
            // 
            this.splitMainStatusBar.Panel2.Controls.Add(this.lblDownloadState);
            this.splitMainStatusBar.Size = new System.Drawing.Size(752, 560);
            this.splitMainStatusBar.SplitterDistance = 528;
            this.splitMainStatusBar.SplitterWidth = 2;
            this.splitMainStatusBar.TabIndex = 7;
            // 
            // lblDownloadState
            // 
            this.lblDownloadState.Location = new System.Drawing.Point(3, 7);
            this.lblDownloadState.Name = "lblDownloadState";
            this.lblDownloadState.Size = new System.Drawing.Size(744, 13);
            this.lblDownloadState.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyIPToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(187, 26);
            // 
            // copyIPToolStripMenuItem
            // 
            this.copyIPToolStripMenuItem.Name = "copyIPToolStripMenuItem";
            this.copyIPToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.copyIPToolStripMenuItem.Text = "Copy Server Location";
            this.copyIPToolStripMenuItem.Click += new System.EventHandler(this.copyIPToolStripMenuItem_Click);
            // 
            // openTO220Dialog
            // 
            this.openTO220Dialog.FileName = "TacticalOps.exe";
            this.openTO220Dialog.Filter = "Tactical Ops 2.2 | *.exe";
            this.openTO220Dialog.Title = "Please select Tactical Ops 2.2 file";
            // 
            // setTacticalOps22PathToolStripMenuItem
            // 
            this.setTacticalOps22PathToolStripMenuItem.Name = "setTacticalOps22PathToolStripMenuItem";
            this.setTacticalOps22PathToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.setTacticalOps22PathToolStripMenuItem.Text = "Set Tactical Ops 2.2 Path";
            this.setTacticalOps22PathToolStripMenuItem.Click += new System.EventHandler(this.setTacticalOps22PathToolStripMenuItem_Click);
            // 
            // launchTacticalOps22ToolStripMenuItem
            // 
            this.launchTacticalOps22ToolStripMenuItem.Name = "launchTacticalOps22ToolStripMenuItem";
            this.launchTacticalOps22ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.launchTacticalOps22ToolStripMenuItem.Text = "Launch Tactical Ops 2.2";
            this.launchTacticalOps22ToolStripMenuItem.Click += new System.EventHandler(this.launchTacticalOps22ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 584);
            this.Controls.Add(this.splitMainStatusBar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "Tactical Ops Quick Join";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.serverListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerListView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitServerSettingsList.Panel1.ResumeLayout(false);
            this.splitServerSettingsList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitServerSettingsList)).EndInit();
            this.splitServerSettingsList.ResumeLayout(false);
            this.splitPlayerServerList.Panel1.ResumeLayout(false);
            this.splitPlayerServerList.Panel1.PerformLayout();
            this.splitPlayerServerList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPlayerServerList)).EndInit();
            this.splitPlayerServerList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serverSettingsView)).EndInit();
            this.splitMainStatusBar.Panel1.ResumeLayout(false);
            this.splitMainStatusBar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMainStatusBar)).EndInit();
            this.splitMainStatusBar.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView serverListView;
        private System.Windows.Forms.DataGridView playerListView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchTacticalOps34ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchTacticalOps35ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTacticalOps34PathToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openTO340Dialog;
        private System.Windows.Forms.OpenFileDialog openTO350Dialog;
        private System.Windows.Forms.SplitContainer splitServerSettingsList;
        private System.Windows.Forms.SplitContainer splitPlayerServerList;
        private System.Windows.Forms.DataGridView serverSettingsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverSettingsSettingColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverSettingsValueColumn;
        private System.Windows.Forms.Button btnJoinServer;
        private System.Windows.Forms.SplitContainer splitMainStatusBar;
        private System.Windows.Forms.Label split;
        private System.Windows.Forms.Label lblDownloadState;
        private System.Windows.Forms.ToolStripMenuItem setTacticalOps35PathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeOnJoinToolStripMenuItem;
        private System.Windows.Forms.Label lblNoPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerListNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerListScoreColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerListKillsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerListDeathColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerListPingColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerListTeamColumn;
        private System.Windows.Forms.Label lblNoResponse;
        private System.Windows.Forms.Label lblWaitingForResponse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyIPToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverListNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverListMapColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverListPlayersColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverListVersionColumn;
        private System.Windows.Forms.ToolStripMenuItem masterserversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTacticalOps22PathToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openTO220Dialog;
        private System.Windows.Forms.ToolStripMenuItem launchTacticalOps22ToolStripMenuItem;
    }
}

