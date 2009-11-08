using System;
using NUnit.Framework;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace TelnetingMythTv.Tests
{
	[TestFixture]	
	public class MyClass
	{
		
		//[Test]
		public void CanConnectToBackend()
		{
			var client = new TcpClient("192.168.1.10", 6543);
			var stream = client.GetStream();
			
			var streamWriter = new StreamWriter(stream);
			
			streamWriter.WriteLine("21      MYTH_PROTO_VERSION 40");
			
			if (stream.CanRead)
			{
				var buffer = new Byte[1024];
				var bytesRead = 0;
				
				do
				{
	            	bytesRead = stream.Read(buffer, 0, buffer.Length);
					Console.Write("{0}", Encoding.ASCII.GetString(buffer, 0, bytesRead));
	            }
	            while(stream.DataAvailable);
		            
				Console.Write("\n");
			}
			
			stream.Close();
			client.Close();
		}
	}
}
