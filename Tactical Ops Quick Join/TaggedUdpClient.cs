using System;
using System.Net;
using System.Net.Sockets;

namespace TacticalOpsQuickJoin {
    public class TaggedUdpClient : UdpClient {
        public int Id { get; private set; }
        public ServerData serverData;
        public IPEndPoint ipEndPoint;
        public DateTime startTime;
        public double timeoutValue = 1.0;
        public int tries = 0;

        public TaggedUdpClient(int id) : base() {
            Id = id;
        }

        public bool Timedout() {
            var currentTime = DateTime.Now;
            var timePassed = currentTime.Subtract(startTime).TotalSeconds;
            return (timePassed > timeoutValue);
        }
    }
}
