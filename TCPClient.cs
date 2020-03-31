using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketCom
{
	class TCPClient
	{
		public TcpClient client { get; set; }
		public NetworkStream stream { get; set; }
		public TCPClient()
		{
			client = new TcpClient();
		}

		public void Connect(string ip, int port)
		{
			IPAddress address = IPAddress.Parse(ip);
			client.Connect(address, port);
			stream = client.GetStream();
		}

		public void SendMessage(string message)
		{
			byte[] data = Encoding.UTF8.GetBytes(message);
			stream.Write(data);
		}

		public string ReadMessage()
		{
			byte[] buffer = new byte[1024];
			stream.Read(buffer);
			string resultado  = Encoding.ASCII.GetString(buffer);
			return resultado;
		}
	}
}
