using System;
using System.Collections.Generic;

namespace TacticalOpsQuickJoin {
    public class ServerData {
        public int Id { get; private set; }
        public string ServerIP { get; private set; }
        public int ServerPort { get; private set; }
        public string ServerName { get; private set; }
        public bool IsTO220 { get; private set; }
        public bool IsTO340 { get; private set; }
        public bool IsTO350 { get; private set; }

        private Dictionary<string, string> serverInfo;

        public ServerData(int id, string serverAddress) {
            Id = id;
            string[] parts = serverAddress.Split(':');
            ServerIP = parts[0];
            ServerPort = Convert.ToInt32(parts[1]);
            serverInfo = new Dictionary<string, string>();
        }

        public string GetProperty(string name) {
            string value = string.Empty;
            serverInfo.TryGetValue(name, out value);
            if (string.IsNullOrEmpty(value))
                value = GetDefaultValueForKey(name);
            return value;
        }

        public string GetDefaultValueForKey(string key) {
            if (key.StartsWith("frags_"))
                key = "frags";
            else if (key.StartsWith("deaths_"))
                key = "deaths";
            else if (key.StartsWith("score_"))
                key = "score";
            else if (key.StartsWith("ping_"))
                key = "ping";
            else if (key.StartsWith("team_"))
                key = "team";

            switch (key) {
                case "tostversion":
                case "protection":
                case "esemode": return "None";
                case "frags":
                case "deaths":
                case "team":
                case "score": return "0";
                case "ping": return "999";

            }
            return string.Empty;
        }

        public void SetInfo(string data) {
            string[] dataElements = data.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < dataElements.Length; i = i + 2) {
                string tag = dataElements[i - 1];
                if (tag != "final" && tag != "queryid") {
                    string content = dataElements[i];
                    serverInfo[tag] = content;
                }
            }

            string gameType = string.Empty;

            serverInfo.TryGetValue("gametype", out gameType);
            IsTO220 = (gameType == "TO220");
            IsTO340 = (gameType == "TO340");
            IsTO350 = (gameType == "TO350");
        }

        public void ClearPlayerList() {
            List<string> keys = new List<string>();
            foreach (string key in serverInfo.Keys) {
                key.StartsWith("player_");
                keys.Add(key);
            }

            foreach (string key in keys) {
                serverInfo.Remove(key);
            }
        }

        public bool UpdateInfo(string data) {
            string[] dataElements = data.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            bool containsFinal = false;
            for (int i = 1; i < dataElements.Length; i = i + 2) {
                string tag = dataElements[i - 1].ToLower();
                if (tag != "final" && tag != "queryid") {
                    string content = dataElements[i];
                    serverInfo[tag] = content;
                }
            }

            if (dataElements[dataElements.Length - 1] == "final") {
                containsFinal = true;
            }
            return containsFinal;
        }
    }
}
