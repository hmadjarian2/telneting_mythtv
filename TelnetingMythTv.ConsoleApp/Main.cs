using System;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace TelnetingMythTv.ConsoleApp
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var client = new TcpClient("192.168.1.10", 6543);
			
			var response = SendCommand(client, "MYTH_PROTO_VERSION 40");
			Console.WriteLine(response + "\n");
			
			response = SendCommand(client, "ANN Monitor Cena 0");
			Console.WriteLine(response + "\n");
			
			response = SendCommand(client, "QUERY_RECORDINGS Play");
			Console.WriteLine(response + "\n");
			
			response = SendCommand(client, "DONE");
			Console.WriteLine(response + "\n");
		}
		
		private static string SendCommand(TcpClient client, string command)
		{
			var commandSize = command.Length;
			command = string.Format("{0,-8:G}{1}", commandSize.ToString(), command);
			
			var bytes = Encoding.ASCII.GetBytes(command);
			
			var stream = client.GetStream();
			
        	stream.Write(bytes, 0, bytes.Length);

        	var bufferSize = client.ReceiveBufferSize;
        	var bufferBytes = new Byte[bufferSize];

        	stream.Read(bufferBytes, 0, bufferSize);
        	
			return Encoding.ASCII.GetString(bufferBytes, 0, bufferSize);
		}
	}
}