using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace TelnetingMythTv
{
	public class ServerConnection
	{
        private string _name;
        private int _port;
        private TcpClient _client;

        public ServerConnection(string name) : this(name, 6543) { }
        
        public ServerConnection(string name, int port)
        {
            _name = name;
            _port = port;
        }

        public void Open()
        {
            _client = new TcpClient(_name, _port);
        }

        public NetworkStream GetStream()
        {
            return _client.GetStream();
        }

        public TcpClient Client
        {
            get
            {
                return _client;
            }
        }

        public bool Connected 
        {
            get
            {
                return _client.Connected; ;
            }
        }
    }
}
