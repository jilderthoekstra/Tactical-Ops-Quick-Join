using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TacticalOpsQuickJoin.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace TacticalOpsQuickJoin {
    public partial class FormMain : Form {
        public List<MasterServer.MasterServerInfo> masterServers = new List<MasterServer.MasterServerInfo>();

        public delegate void UpdateServerStatusAction(ServerData serverData);
        public delegate void UpdateMasterThreadStateAction(string state);

        private bool appIsClosing = false;
        private List<ServerData> servers = new List<ServerData>();
        private BackgroundWorker masterServerWorker = new BackgroundWorker();
        private BackgroundWorker serverStatusWorker;
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);

        public FormMain() {
            InitializeComponent();

            playerListScoreColumn.ValueType = typeof(Int32);
            playerListKillsColumn.ValueType = typeof(Int32);
            playerListDeathColumn.ValueType = typeof(Int32);
            playerListPingColumn.ValueType = typeof(Int32);
            playerListTeamColumn.ValueType = typeof(Int32);

            closeOnJoinToolStripMenuItem.Checked = Settings.Default.closeOnJoin;
            serverListView.Sort(serverListPlayersColumn, ListSortDirection.Descending);
            playerListView.Sort(playerListTeamColumn, ListSortDirection.Descending);

            string serverInputList = Settings.Default.masterservers;
            using (StringReader sr = new StringReader(serverInputList)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        MasterServer.MasterServerInfo masterServerInfo = new MasterServer.MasterServerInfo
                        {
                            Address = parts[0],
                            Port = Convert.ToInt16(parts[1])
                        };
                        masterServers.Add(masterServerInfo);
                    }
                }
            }

            lblNoResponse.Hide();
            lblNoPlayers.Hide();
            lblWaitingForResponse.Hide();
        }

        private void Form1_Load(object sender, EventArgs e) {
            GetMasterList();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (serverStatusWorker != null && serverStatusWorker.IsBusy)
                serverStatusWorker.CancelAsync();

            if (masterServerWorker.IsBusy) {
                appIsClosing = true;
                masterServerWorker.CancelAsync();
                e.Cancel = true;
                Enabled = false;
                Hide();
                return;
            }
        }

        private void GetServerStatus(ServerData serverData) {
            if (serverStatusWorker != null && serverStatusWorker.IsBusy) {
                serverStatusWorker.CancelAsync();
            }
            serverStatusWorker = new BackgroundWorker();
            serverStatusWorker.WorkerSupportsCancellation = true;
            serverStatusWorker.DoWork += new DoWorkEventHandler(ServerStatusWorker_DoWork);
            serverStatusWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ServerStatusWorker_Completed);
            serverStatusWorker.RunWorkerAsync(serverData);
        }

        private void ServerStatusWorker_DoWork(object sender, DoWorkEventArgs e) {
            var worker = sender as BackgroundWorker;
            var serverData = e.Argument as ServerData;
            IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Parse(serverData.ServerIP), serverData.ServerPort);
            byte[] dataStatus = System.Text.Encoding.UTF8.GetBytes(@"\status\");
            byte[] dataPlayer = System.Text.Encoding.UTF8.GetBytes(@"\players\");
            
            TaggedUdpClient udpClient = new TaggedUdpClient(serverData.Id);
            udpClient.ipEndPoint = ipEndpoint;
            udpClient.serverData = serverData;
            udpClient.startTime = DateTime.Now;
            udpClient.Connect(ipEndpoint);
            udpClient.timeoutValue = 0.5;
            udpClient.tries++;
            udpClient.Send(dataStatus, dataStatus.Length);

            var serverResponse = new ServerStatusResponse();
            serverResponse.serverData = serverData;

            bool completed = false;
            bool receivedData = false;
            while (!completed && !worker.CancellationPending) {
                if (udpClient.Available > 0) {
                    receivedData = true;
                    try { 
                        Byte[] receiveBytes = udpClient.Receive(ref udpClient.ipEndPoint);
                        string dataReceived = Encoding.UTF8.GetString(receiveBytes);
                        completed = serverData.UpdateInfo(dataReceived);
                        serverResponse.ReceivedFinal = completed;
                    } catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                } else if (udpClient.Timedout()) {
                    if (receivedData && udpClient.tries < 2) {
                        udpClient.startTime = DateTime.Now;
                        udpClient.Send(dataPlayer, dataPlayer.Length);
                        udpClient.tries++;
                    } else {
                        completed = true;
                    }
                }
                Thread.Sleep(100);
            }

            serverResponse.ReceivedData = receivedData;

            udpClient.Close();
            udpClient.Dispose();

            e.Result = serverResponse;
            e.Cancel = worker.CancellationPending;
        }

        private void ServerStatusWorker_Completed(object sender, RunWorkerCompletedEventArgs e) {
            var worker = sender as BackgroundWorker;
            worker.Dispose();
            if (!e.Cancelled) {
                lblWaitingForResponse.Hide();
                var serverResponse = e.Result as ServerStatusResponse;
                if (!serverResponse.ReceivedData) {
                    lblNoResponse.Show();
                } else {
                    UpdateStatusInfo(serverResponse.serverData);
                }
            }
        }

        private void GetMasterList() {
            masterServerWorker.WorkerSupportsCancellation = true;
            masterServerWorker.WorkerReportsProgress = true;
            masterServerWorker.DoWork += new DoWorkEventHandler(MasterServerWorker_DoWork);
            masterServerWorker.ProgressChanged += new ProgressChangedEventHandler(MasterServerWorker_ProgressChanged);
            masterServerWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MasterServerWork_Completed);
            masterServerWorker.RunWorkerAsync();
        }

        private void MasterServerWorker_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = sender as BackgroundWorker;
            Console.WriteLine("start download serverlist");
            Thread.Sleep(200);

            var responseData = new MasterServer.MasterServerResponse();
            List<string> completeMasterServerList = new List<string>();
            for (int i = 0; i < masterServers.Count; i++) {
                Console.WriteLine("testing!!!!!!!!!!!!");
                BeginInvoke(new UpdateMasterThreadStateAction(UpdateDownloadState), string.Format("Contacting masterservers... {0}/{1}", i + 1, masterServers.Count));
                bool contactingMasterServer = true;
                int tries = 0;
                var currentMasterServer = masterServers[i];
                while (contactingMasterServer && tries < 3 && !worker.CancellationPending) {
                    responseData = MasterServer.DownloadServerList(currentMasterServer);
                    if (responseData.errorCode == 2) {
                        BeginInvoke(new UpdateMasterThreadStateAction(UpdateDownloadState), String.Format("{0} Will try again in just a moment.", responseData.errorMessage));
                        tries++;
                        Thread.Sleep(500);
                    } else {
                        contactingMasterServer = false;
                    }
                }

                if (responseData.errorCode == 1) {
                    BeginInvoke(new UpdateMasterThreadStateAction(UpdateDownloadState), responseData.errorMessage);
                    continue;
                } else if (responseData.errorCode == 0) {
                    if (responseData.serverList != null)
                        completeMasterServerList.AddRange(responseData.serverList);
                }
            }

            if (worker.CancellationPending)
                return;

            string[] masterServerList = completeMasterServerList.Distinct().ToArray();
            if (masterServerList.Length == 0) {
                Console.WriteLine("serverlist empty");
                this.BeginInvoke(new UpdateMasterThreadStateAction(UpdateDownloadState), "Received empty serverlist");
            } else {
                Console.WriteLine("received serverlist");
                this.BeginInvoke(new UpdateMasterThreadStateAction(UpdateDownloadState), String.Format("Received {0} servers", masterServerList.Length));
            }

            servers.Clear();
            int totalServers = masterServerList.Length;
            for (int i = 0; i < totalServers; i++) {
                string ip = masterServerList[i];
                ServerData serverData = new ServerData(i, ip);
                servers.Add(serverData);
            }

            byte[] data = System.Text.Encoding.UTF8.GetBytes(@"\info\");
            Queue<TaggedUdpClient> clients = new Queue<TaggedUdpClient>();
            List<TaggedUdpClient> receiveList = new List<TaggedUdpClient>();
            List<TaggedUdpClient> failedConnections = new List<TaggedUdpClient>();

            this.BeginInvoke(new UpdateMasterThreadStateAction(UpdateDownloadState), String.Format("Sending info request to servers {0:000}/{1:000}", 0, totalServers));

            for (int i = 0; i < totalServers; i++) {
                ServerData currentServer = servers[i];
                IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Parse(currentServer.ServerIP), currentServer.ServerPort);
                TaggedUdpClient udpClient = new TaggedUdpClient(currentServer.Id);
                udpClient.ipEndPoint = ipEndpoint;
                udpClient.serverData = currentServer;
                clients.Enqueue(udpClient);
            }

            int to340Count = 0;
            int to350Count = 0;
            int numberOfServerReceived = 0;

            bool communicatingWithServers = true;
            while (communicatingWithServers && !worker.CancellationPending) {
                // send data to servers
                if (clients.Count > 0) {
                    var udpClient = clients.Dequeue();
                    udpClient.tries++;
                    udpClient.startTime = DateTime.Now;
                    udpClient.Connect(udpClient.ipEndPoint);
                    udpClient.Send(data, data.Length);
                    receiveList.Add(udpClient);
                }

                // check connection if we have received any data
                for (int i = receiveList.Count - 1; i >= 0; i--) {
                    var udpClient = receiveList[i];
                    if (udpClient.Available > 0) {
                        try {
                            Byte[] receiveBytes = udpClient.Receive(ref udpClient.ipEndPoint);
                            string dataReceived = Encoding.UTF8.GetString(receiveBytes);
                            udpClient.serverData.SetInfo(dataReceived);
                            if (udpClient.serverData.IsTO340 || udpClient.serverData.IsTO350) {
                                if (udpClient.serverData.IsTO340)
                                    to340Count++;
                                else if (udpClient.serverData.IsTO350)
                                    to350Count++;
                                int progress = numberOfServerReceived / (totalServers / 100);
                                worker.ReportProgress(progress, udpClient.serverData);
                            }
                        } catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                        receiveList.RemoveAt(i);
                        udpClient.Close();
                        udpClient.Dispose();
                        numberOfServerReceived++;
                        BeginInvoke(new UpdateMasterThreadStateAction(UpdateDownloadState), String.Format("Received info from servers {0:000}/{1:000}, found {2:00} Tactical Ops 3.4 and {3:00} Tactical Ops 3.5 servers", numberOfServerReceived, totalServers, to340Count, to350Count));
                    } else if (udpClient.Timedout()) {
                        if (udpClient.tries < 3)
                            clients.Enqueue(udpClient);
                        else
                            failedConnections.Add(udpClient);
                        receiveList.RemoveAt(i);
                    }
                }

                // if all connection are completed exit
                if (clients.Count == 0 && receiveList.Count == 0)
                    communicatingWithServers = false;

                Thread.Sleep(5);
            }


            BeginInvoke(new UpdateMasterThreadStateAction(UpdateDownloadState), String.Format("Found ({0}) Tactical Ops 3.4 and ({1}) Tactical Ops 3.5 servers", to340Count, to350Count));
            Console.WriteLine("Failed connections: "+ failedConnections.Count);
            for (int i = failedConnections.Count - 1; i >= 0; i--) {
                failedConnections[i].Close();
                failedConnections[i].Dispose();
                failedConnections.RemoveAt(i);
            }
        }

        private void MasterServerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            ServerData serverData = e.UserState as ServerData;
            string name = serverData.GetProperty("hostname");
            string map = serverData.GetProperty("maptitle");
            string totalPlayers = String.Format("{0:00}/{1:00}", serverData.GetProperty("numplayers"), serverData.GetProperty("maxplayers"));
            string version = serverData.GetProperty("gametype");
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(serverListView, name, map, totalPlayers, version);
            newRow.Tag = serverData.Id;
            int index = serverListView.Rows.Add(newRow);
            serverListView.Sort(serverListPlayersColumn, ListSortDirection.Descending);
        }

        private void MasterServerWork_Completed(object sender, RunWorkerCompletedEventArgs e) {
            if (appIsClosing)
                Close();
        }

        private void serverListView_SelectionChanged(object sender, EventArgs e) {
            serverSettingsView.Rows.Clear();
            playerListView.Rows.Clear();
            lblNoPlayers.Hide();
            lblNoResponse.Hide();
            lblWaitingForResponse.Show();

            int index = (int)serverListView.SelectedRows[0].Tag;
            ServerData selectedServer = servers[index];
            selectedServer.ClearPlayerList();
            GetServerStatus(selectedServer);
        }

        private void UpdateDownloadState(string state) {
            lblDownloadState.Text = state;
        }

        private void UpdateStatusInfo(ServerData serverData) {
            // if we have gotten an old packet just ignore it
            if (serverData.Id != (int)serverListView.CurrentRow.Tag) {
                return;
            }

            string totalPlayers = String.Format("{0:00}/{1:00}", serverData.GetProperty("numplayers"), serverData.GetProperty("maxplayers"));
            serverListView.CurrentRow.Cells[2].Value = totalPlayers;

            Dictionary<string, string> serverSettings = new Dictionary<string, string>();
            serverSettings["Admin Name"] = serverData.GetProperty("adminname");
            serverSettings["Admin Email"] = serverData.GetProperty("adminemail");
            serverSettings["TOST Version"] = serverData.GetProperty("tostversion");
            serverSettings["ESE Version"] = serverData.GetProperty("protection");
            serverSettings["ESE Mode"] = serverData.GetProperty("esemode");
            serverSettings["Password"] = serverData.GetProperty("password");
            serverSettings["Time Limit"] = serverData.GetProperty("timelimit");
            serverSettings["Min Players"] = serverData.GetProperty("minplayers");
            serverSettings["Friendly Fire"] = serverData.GetProperty("friendlyfire");
            serverSettings["Explosion FF"] = serverData.GetProperty("explositionff");

            serverSettingsView.Rows.Clear();
            foreach (KeyValuePair<string, string> setting in serverSettings) {
                DataGridViewRow newSetting = new DataGridViewRow();
                newSetting.CreateCells(serverSettingsView, setting.Key, setting.Value);
                serverSettingsView.Rows.Add(newSetting);
            }

            Console.WriteLine("players: " + serverData.GetProperty("numplayers"));
            int numPlayers = Convert.ToInt16(serverData.GetProperty("numplayers"));
            playerListView.Rows.Clear();

            if (numPlayers == 0)
                lblNoPlayers.Show();
            else
                lblNoPlayers.Hide();

            for (int i = 0; i < numPlayers; i++) {
                string playerName = serverData.GetProperty("player_" + i.ToString());
                int score = Convert.ToInt32(serverData.GetProperty("score_" + i.ToString()));
                int kills = Convert.ToInt32(serverData.GetProperty("frags_" + i.ToString()));
                int deaths = Convert.ToInt32(serverData.GetProperty("deaths_" + i.ToString()));
                int ping = Convert.ToInt32(serverData.GetProperty("ping_" + i.ToString()));
                int team = Convert.ToInt32(serverData.GetProperty("team_" + i.ToString()));

                if (!string.IsNullOrEmpty(playerName)) {
                    DataGridViewRow newPlayerRow = new DataGridViewRow();
                    newPlayerRow.CreateCells(playerListView, playerName, score, kills, deaths, ping, team);

                    foreach (DataGridViewCell cell in newPlayerRow.Cells) {
                        newPlayerRow.DefaultCellStyle.BackColor = (team == 0) ? Color.FromArgb(255, 99, 99) : Color.FromArgb(99, 99, 255);
                        newPlayerRow.DefaultCellStyle.SelectionBackColor = (team == 0) ? Color.FromArgb(255, 99, 99) : Color.FromArgb(99, 99, 255);
                    }
                    playerListView.Rows.Add(newPlayerRow);
                }
            }
            playerListView.Sort(playerListView.SortedColumn, (playerListView.SortOrder == SortOrder.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending);
        }

        private void btnJoinServer_Click(object sender, EventArgs e) {
            if (serverListView.CurrentRow == null) {
                return;
            }

            int index = (int)serverListView.CurrentRow.Tag;
            ServerData server = servers[index];
            string serverAddress = String.Format("{0}:{1}", server.ServerIP, server.GetProperty("hostport"));
            IntPtr cpus = new IntPtr(0x0001);

            if (server.IsTO340) {
                string fullPath = Path.GetFullPath(Settings.Default.to340path);
                if (TacticalOpsFound(fullPath)) {
                    var process = Process.Start(fullPath, serverAddress);
                    process.ProcessorAffinity = cpus;
                } else {
                    FormError errorDialog = new FormError("Tactical Ops 3.4 path not set.\nPlease set it through Config->Set Tactical Ops Path");
                    errorDialog.StartPosition = FormStartPosition.CenterParent;
                    errorDialog.ShowDialog(this);
                    errorDialog.Dispose();
                }
            } else if (server.IsTO350) {
                string fullPath = Path.GetFullPath(Settings.Default.to350path);
                if (TacticalOpsFound(fullPath)) {
                    var process = Process.Start(fullPath, serverAddress);
                    process.ProcessorAffinity = cpus;
                } else {
                    FormError errorDialog = new FormError("Tactical Ops 3.5 path not set.\nPlease set it through Config->Set Tactical Ops Path");
                    errorDialog.StartPosition = FormStartPosition.CenterParent;
                    errorDialog.ShowDialog(this);
                    errorDialog.Dispose();
                }
            }

            if (Settings.Default.closeOnJoin) {
                Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            FormAbout aboutDialog = new FormAbout();
            aboutDialog.StartPosition = FormStartPosition.CenterParent;
            aboutDialog.ShowDialog(this);
            aboutDialog.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void setTacticalOps34PathToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openTO340Dialog.ShowDialog() == DialogResult.OK) {
                Settings.Default.to340path = openTO340Dialog.FileName;
            }
        }

        private void setTacticalOps35PathToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openTO350Dialog.ShowDialog() == DialogResult.OK) {
                Settings.Default.to350path = openTO350Dialog.FileName;
            }

            Settings.Default.Save();
        }

        private void closeOnJoinToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings.Default.closeOnJoin = closeOnJoinToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void launchTacticalOps34ToolStripMenuItem_Click(object sender, EventArgs e) {
            string fullPath = Path.GetFullPath(Settings.Default.to340path);
            if (TacticalOpsFound(fullPath)) {
                IntPtr cpus = new IntPtr(0x0001);
                var process = Process.Start(fullPath);
                process.ProcessorAffinity = cpus;
            } else {
                FormError errorDialog = new FormError("Tactical Ops 3.4 path not set.\nPlease set it through Config->Set Tactical Ops Path");
                errorDialog.StartPosition = FormStartPosition.CenterParent;
                errorDialog.ShowDialog(this);
                errorDialog.Dispose();
            }
        }

        private void launchTacticalOps35ToolStripMenuItem_Click(object sender, EventArgs e) {
            string fullPath = Path.GetFullPath(Settings.Default.to350path);
            if (TacticalOpsFound(fullPath)) {
                IntPtr cpus = new IntPtr(0x0001);
                var process = Process.Start(fullPath);
                process.ProcessorAffinity = cpus;
            } else {
                FormError errorDialog = new FormError("Tactical Ops 3.5 path not set.\nPlease set it through Config->Set Tactical Ops Path");
                errorDialog.StartPosition = FormStartPosition.CenterParent;
                errorDialog.ShowDialog(this);
                errorDialog.Dispose();
            }
        }

        private bool TacticalOpsFound(string path) {
            if (string.IsNullOrEmpty(path))
                return false;

            return File.Exists(path);
        }


        private void serverListView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var grid = sender as DataGridView;
                grid.CurrentCell = grid[e.ColumnIndex, e.RowIndex];
                grid.Rows[e.RowIndex].Selected = true;
                contextMenuStrip.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void copyIPToolStripMenuItem_Click(object sender, EventArgs e) {
            ServerData serverData = servers[(int)serverListView.CurrentRow.Tag];
            string ip = string.Format("unreal://{0}:{1}", serverData.ServerIP, serverData.GetProperty("hostport"));
            Clipboard.SetText(ip);
            Console.WriteLine((int)serverListView.CurrentRow.Tag);
            Console.WriteLine(ip);

        }

        private void serverListView_SortCompare(object sender, DataGridViewSortCompareEventArgs e) {
            if (serverListPlayersColumn.Name == e.Column.Name) {
                var cellValue1 = e.CellValue1.ToString().Split('/');
                var cellValue2 = e.CellValue2.ToString().Split('/');

                if (Convert.ToInt16(cellValue1[0]) > Convert.ToInt16(cellValue2[0]))
                    e.SortResult = 1;
                else if (Convert.ToInt16(cellValue1[0]) < Convert.ToInt16(cellValue2[0]))
                    e.SortResult = -1;
                else if (Convert.ToInt16(cellValue1[1]) > Convert.ToInt16(cellValue2[1]))
                    e.SortResult = 1;
                else if (Convert.ToInt16(cellValue1[1]) < Convert.ToInt16(cellValue2[1]))
                    e.SortResult = -1;
                else
                    e.SortResult = 0;
                e.Handled = true;
            }
        }

        private void masterserversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMasterServers masterserverForm = new FormMasterServers();
            masterserverForm.StartPosition = FormStartPosition.CenterParent;
            masterserverForm.ShowDialog(this);
            masterserverForm.Dispose();
        }
    }
}
