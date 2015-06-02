using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastHotkeyPlayer
{
    class BroadcastHotkeyPlayerNetSend
    {
        private const int sendPort = 11000;
        private UdpClient sender;

        public void Send(string msg)
        {
            sender = new UdpClient();
            IPEndPoint RemoteIPEndPoint = new IPEndPoint(IPAddress.Broadcast, sendPort);
            byte[] bytes = Encoding.ASCII.GetBytes(msg);
            sender.SendAsync(bytes, bytes.Length, RemoteIPEndPoint);
            sender.Close();
        }
    }
}
