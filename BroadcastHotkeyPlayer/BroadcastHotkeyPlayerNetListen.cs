using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastHotkeyPlayer
{
    class BroadcastHotkeyPlayerNetListen
    {
        private const int listenPort = 11000;
        private const string cmdPlay = "ply";
        private char[] sepeartor = new char[] { ':' };

        private UdpClient listener;
        private BroadcastHotkeyPlayerWindow window;
        
        public BroadcastHotkeyPlayerNetListen(BroadcastHotkeyPlayerWindow window)
        {
            this.window = window;
        }

        public void StartListener()
        {
            listener = new UdpClient(listenPort);
            try
            {
                Console.WriteLine("Waiting for broadcast");
                listener.BeginReceive(new AsyncCallback(recv), null);
            }
            catch (Exception e)
            {
                //TODO: error handling
                throw;
            }
        }

        public void StopListener()
        {
            listener.Close();
        }

        void recv(IAsyncResult res)
        {
            IPEndPoint RemoteIPEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
            byte[] received = listener.EndReceive(res, ref RemoteIPEndPoint);
            listener.BeginReceive(new AsyncCallback(recv), null);
            decodeMsg(Encoding.ASCII.GetString(received));
        }

        private void decodeMsg(string msg)
        {
            string[] splits = msg.Split(sepeartor, 2);
            string cmd = splits[0];
            string param = splits[1];

            switch (cmd)
            {
                case cmdPlay: window.play(param); break;
            }
        }
    }
}
