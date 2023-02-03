using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TacticalOpsQuickJoin {
    public class MasterServer {
        public class MasterServerInfo {
            public string Address { get; set; }
            public int Port { get; set; }
        }

        public struct MasterServerResponse {
            public string[] serverList;
            public int errorCode;
            public string errorMessage;
        }

        public static MasterServerResponse DownloadServerList(MasterServerInfo serverInfo) {
            TcpClient tcp = null;
            MasterServerResponse masterServerResponse = new MasterServerResponse();
            try {
                tcp = new TcpClient(serverInfo.Address, serverInfo.Port);
            } catch (SocketException se) {
                masterServerResponse.errorCode = 1;
                masterServerResponse.errorMessage = se.Message;
                return masterServerResponse;
            }

            if (tcp != null) {
                NetworkStream ns = tcp.GetStream();
                Console.WriteLine("waiting for stream");
                int timeOutCount = 0;

                while (tcp.Available == 0) {
                    timeOutCount++;
                    if (timeOutCount > 200) {
                        masterServerResponse.errorCode = 1;
                        masterServerResponse.errorMessage = "Masterserver timeout";
                        return masterServerResponse;
                    }
                    Thread.Sleep(10);
                }
                Console.WriteLine("done waiting for stream");

                StringBuilder sb = new StringBuilder();
                while (tcp.Available > 0) {
                    sb.Append(Convert.ToChar(ns.ReadByte()));
                }
                Console.WriteLine(sb.ToString());
                string secureResponse = MakeValidate(Encoding.ASCII.GetBytes(GetSecureCode(sb.ToString())), Encoding.ASCII.GetBytes("Z5Nfb0"));
                string returnString = "\\gamename\\ut\\location\\0\\validate\\" + secureResponse + "\\final\\";

                byte[] response = Encoding.ASCII.GetBytes(returnString);
                ns.Write(response, 0, response.Length);
                Thread.Sleep(10);

                Console.WriteLine("requesting serverlist now");
                byte[] requestServerlist = Encoding.ASCII.GetBytes("\\list\\\\gamename\\ut\\final\\");
                ns.Write(requestServerlist, 0, requestServerlist.Length);

                DateTime startTime = DateTime.UtcNow;
                bool timeOut = false;
                while (tcp.Available == 0 && !timeOut) {
                    DateTime currentTime = DateTime.UtcNow;
                    TimeSpan timeoutTime = currentTime.Subtract(startTime);
                    if (timeoutTime.TotalSeconds > 1) {
                        timeOut = true;
                    }
                    Thread.Sleep(10);
                }

                if (timeOut) {
                    ns.Close();
                    tcp.Close();
                    ns.Dispose();
                    tcp.Dispose();
                    masterServerResponse.errorCode = 2;
                    masterServerResponse.errorMessage = "Masterserver securitycode failed.";
                    return masterServerResponse;
                }


                Console.WriteLine("received serverlist now");

                StringBuilder serverListRaw = new StringBuilder();
                List<byte> received = new List<byte>();
                bool containsFinal = false;
                while (tcp.Available > 0 || !containsFinal) {
                    if (tcp.Available > 0)
                        serverListRaw.Append(Convert.ToChar(ns.ReadByte()));

                    if (tcp.Available == 0) {
                        containsFinal = serverListRaw.ToString().Contains(@"\final\");
                        Thread.Sleep(100);
                    }
                }

                ns.Close();
                tcp.Close();
                ns.Dispose();
                tcp.Dispose();

                string[] serverList = serverListRaw.ToString().Split(new string[] { "\\ip\\", "\\final\\" }, StringSplitOptions.RemoveEmptyEntries);
                masterServerResponse.errorCode = 0;
                masterServerResponse.serverList = serverList;
                return masterServerResponse;
            }

            masterServerResponse.errorCode = 1;
            masterServerResponse.errorMessage = "Something when horrible wrong... Please restart the application.";
            return masterServerResponse;
        }


        private static string GetSecureCode(string s) {
            string[] parts = s.Split('\\');
            return parts[4];
        }

        private static string MakeValidate(byte[] securekey, byte[] handoff) {
            byte[] table = new byte[256];                                   // Buffer
            int[] temp = new int[4];                                        // Some Temporary variables

            #region " Buffer with incremental data "
            for (short i = 0; i < 256; i++) {
                table[i] = (byte)i;// Convert.ToByte(i);
            }
            #endregion

            #region " Scramble with key "
            for (short i = 0; i < 256; i++) {
                //Scramble the Table with our Handoff
                temp[0] = temp[0] + table[i] + handoff[i % handoff.Length] & 255;
                temp[2] = table[temp[0]];

                //Update the buffer
                table[temp[0]] = table[i];
                table[i] = (byte)temp[2]; //Convert.ToByte(temp[2]);
            }
            #endregion

            #region " Scramble securekey with buffer "
            temp[0] = 0;
            byte[] key = new byte[6];
            for (byte i = 0; i < securekey.Length; i++) {
                //Add the next char to the array
                key[i] = securekey[i];

                temp[0] = (temp[0] + key[i] + 1) & 255;
                temp[2] = table[temp[0]];

                temp[1] = (temp[1] + temp[2]) & 255;
                temp[3] = table[temp[1]];

                table[temp[1]] = Convert.ToByte(temp[2]);
                table[temp[0]] = Convert.ToByte(temp[3]);

                //XOR the Buffer
                key[i] = Convert.ToByte(key[i] ^ table[(temp[2] + temp[3]) & 255]);
            }
            #endregion

            // for (byte i = 0; i < securekey.Length; i++)
            //   key[i] = EncType1_Data[key[i]];

            ///for (byte i = 0; i < securekey.Length; i++)
            //   key[i] ^= handoff[i % handoff.Length];


            #region " Create 8 byte long validate key "
            int length = Convert.ToInt32(securekey.Length / 3);
            StringBuilder sb = new StringBuilder();
            byte j = 0;
            while (length >= 1) {
                length--;

                temp[2] = key[j];
                temp[3] = key[j + 1];

                sb.Append(AddChar(temp[2] >> 2));
                sb.Append(AddChar(((temp[2] & 3) << 4) | (temp[3] >> 4)));

                temp[2] = key[j + 2];

                sb.Append(AddChar(((temp[3] & 15) << 2) | (temp[2] >> 6)));
                sb.Append(AddChar(temp[2] & 63));

                j = Convert.ToByte(j + 3);
            }
            #endregion

            return sb.ToString();
        }

        private static char AddChar(int value) {
            if (value < 26) return Convert.ToChar(value + 65);
            if (value < 52) return Convert.ToChar(value + 71);
            if (value < 62) return Convert.ToChar(value - 4);
            if (value == 62) return '+';
            if (value == 63) return '/';
            return Convert.ToChar(0);
        }
    }
}
