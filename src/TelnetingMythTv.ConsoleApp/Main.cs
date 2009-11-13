using System;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TelnetingMythTv.ConsoleApp
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var connection = new ServerConnection("192.168.1.10", 6543);
			connection.Open();
			
			var command = new ServerCommand(connection);
			command.CommandText = "MYTH_PROTO_VERSION 40";
			var result = command.Execute();	
			Console.WriteLine(result);
			
//			command = new ServerCommand(connection);
			command.CommandText = "ANN Monitor Cena 0";
			result = command.Execute();
			Console.WriteLine(result);
			
//			command = new ServerCommand(connection);
			command.CommandText = "QUERY_RECORDINGS Delete";
			result = command.Execute();
			Console.WriteLine(result);

            CreateRecordings(result);

//			command = new ServerCommand(connection);
			command.CommandText = "DONE";
			result = command.Execute();
			Console.WriteLine(result);
/*	
		    
			var client = new TcpClient("192.168.1.10", 6543);
			
			var response = SendCommand(client, "MYTH_PROTO_VERSION 40");
			Console.WriteLine(response + "\n");
			
			response = SendCommand(client, "ANN Monitor Cena 0");
			Console.WriteLine(response + "\n");
			
			response = SendCommand(client, "QUERY_RECORDINGS Delete");
			Console.WriteLine(response + "\n");

            CreateRecordings(response);

			response = SendCommand(client, "DONE");
			Console.WriteLine(response + "\n");
*/
            Console.ReadLine();

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

        private static void CreateRecordings(string result)
        {
            //return;
            //result = result.Substring(8);

            var recordingsCount = int.Parse(result.Substring(0, result.IndexOf("[]:[]")));

            result = result.Substring(result.IndexOf("[") + 5);

            //var arr = result.Split("[]:[]".ToCharArray());
			//var arr = Regex.Split(result, "[]:[]");
			string Delimiter = "[]:[]";  
			var arr = result.Split(new[] { Delimiter }, StringSplitOptions.None);

            var recordings = new string[recordingsCount, 46];

            var someOtherIndex = 0;

            for (var index = 0; index < recordingsCount; index++)
            {
                for (var field = 0; field < 46; field++)
                {
                    if (someOtherIndex >= arr.Length) break;
                    recordings[index, field] = arr[someOtherIndex];
                    someOtherIndex++;
                }
                if (someOtherIndex >= arr.Length) break;
            }
        }
    }
}